using GoogleSignIn.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;

namespace GoogleSignIn
{
    public partial class MainPage : ContentPage
    {
        bool teslaVisible = false;
        public MainPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            string clientId = null;
            string redirectUri = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    clientId = Constants.GoogleiOSClientId;
                    redirectUri = Constants.GoogleiOSRedirectUrl;
                    break;

                case Device.Android:
                    clientId = Constants.GoogleAndroidClientId;
                    redirectUri = Constants.GoogleAndroidRedirectUrl;
                    break;
            }

            var authenticator = new OAuth2Authenticator(
                clientId,
                null,
                Constants.GoogleScope,
                new Uri(Constants.GoogleAuthorizeUrl),
                new Uri(redirectUri),
                new Uri(Constants.GoogleAccessTokenUrl),
                null,
                true);

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        private void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }


            if (e.IsAuthenticated)
            {
                if (authenticator.AuthorizeUrl.Host == "www.facebook.com")
                {
                    var f = 10;
                }
                else if (authenticator.AuthorizeUrl.Host == "accounts.google.com")
                {
                    var s = 10;
                }
            }
        }
        string CodeVerifier;
        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Debug.WriteLine("Authentication error: " + e.Message);
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            string clientId = null;
            string secretId = null;
            string redirectUri = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    clientId = Constants.SpotifyiOSClientId;
                    secretId = Constants.SpotifyiOSSecretId;
                    redirectUri = Constants.SpotifyiOSRedirectUrl;
                    break;

                case Device.Android:
                    secretId = Constants.SpotifyAndroidSecretId;
                    clientId = Constants.SpotifyAndroidClientId;
                    redirectUri = Constants.SpotifyAndroidRedirectUrl;
                    break;
            }

            var authenticator = new OAuth2Authenticator(
                clientId,
                secretId,
                Constants.SpotifyScope,
                new Uri(Constants.SpotifyAuthorizeUrl),
                new Uri(redirectUri),
                new Uri(Constants.SpotifyAccessTokenUrl),
                null,
                true);

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            string clientId = null;
            string redirectUri = null;
            string secretId = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    clientId = Constants.FacebookiOSClientId;
                    secretId = Constants.FacebookiOSSecrettId;
                    redirectUri = Constants.FacebookiOSRedirectUrl;
                    break;

                case Device.Android:
                    secretId = Constants.FacebookAndroidSecretId;
                    clientId = Constants.FacebookAndroidClientId;
                    redirectUri = Constants.FacebookAndroidRedirectUrl;
                    break;
            }

            var authenticator = new OAuth2Authenticator(
                clientId,
                null,
                new Uri(Constants.FacebookAuthorizeUrl),
                new Uri(Constants.FacebookAndroidRedirectUrl),
                null,
                true);

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            CodeVerifier = GeneratorService.GenerateNonce();
            var CodeChallenge = GeneratorService.GenerateCodeChallenge(CodeVerifier);

            var code_challenge_method = "S256";

            TeslaView.IsVisible = true;
            TeslaView.Source = $"{Constants.TeslaAuthorizeUrl}?response_type=code&client_id={Constants.TeslaiOSClientId}&state=1234&scope={Constants.TeslaScope}&redirect_uri={Constants.TeslaiOSRedirectUrl}&code_challenge={CodeChallenge}&code_challenge_method={code_challenge_method}";
            TeslaView.Navigating += TeslaView_Navigating;
        }

        private async void TeslaView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Url.Contains("https://auth.tesla.com/void/callback?code="))
            {
                var code = e.Url.Substring((e.Url.IndexOf("code=") + 5), (e.Url.IndexOf('&') - (e.Url.IndexOf("code=") + 5)));
                TeslaView.IsVisible = false;
                var accessToken = await GeneratorService.OnGet(code, CodeVerifier);


                var breakPointHere = "place_break_point_here_and_check_above_accesstoken_variable_if_it_has_accesstoken";
            }
        }  
    }
}
