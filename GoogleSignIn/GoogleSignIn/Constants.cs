namespace GoogleSignIn
{
    public static class Constants
    {
        public static string AppName = "OAuthNativeFlow";

        // Google OAuth
        // For Google login, configure at https://console.developers.google.com/
        public static string GoogleiOSClientId = "999007805390-o9s340sr8ts4u8h0mk5f7ed3il5lev2n.apps.googleusercontent.com";
        public static string GoogleAndroidClientId = "999007805390-edcc0jlhvbqeh1euhq9n4ic5h39qj73s.apps.googleusercontent.com";

        // These values do not need changing
        public static string GoogleScope = "https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile";
        public static string GoogleAuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
        public static string GoogleAccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
        public static string GoogleUserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";

        // Set these to reversed iOS/Android client ids, with :/oauth2redirect appended
        public static string GoogleiOSRedirectUrl = "com.googleusercontent.apps.999007805390-o9s340sr8ts4u8h0mk5f7ed3il5lev2n:/oauth2redirect";
        public static string GoogleAndroidRedirectUrl = "com.googleusercontent.apps.999007805390-edcc0jlhvbqeh1euhq9n4ic5h39qj73s:/oauth2redirect";

        //-------------------------------------------------------------------------------------------------------

        // Facebook OAuth
        // For Facebook login, configure at https://developers.facebook.com
        public static string FacebookiOSClientId = "<insert IOS client ID here>";
        public static string FacebookAndroidClientId = "730487788164293";

        // These values do not need changing
        public static string FacebookScope = "email";
        public static string FacebookAuthorizeUrl = "https://www.facebook.com/dialog/oauth/";
        public static string FacebookAccessTokenUrl = "https://www.facebook.com/connect/login_success.html";
        public static string FacebookUserInfoUrl = "https://graph.facebook.com/me?fields=email&access_token={accessToken}";

        // Set these to reversed iOS/Android client ids, with :/oauth2redirect appended
        public static string FacebookiOSRedirectUrl = "<insert IOS redirect URL here>:/oauth2redirect";
        public static string FacebookAndroidRedirectUrl = "https://www.facebook.com/connect/login_success.html";

        //-------------------------------------------------------------------------------------------------------

        // Spotify OAuth
        // For Spotify login, configure at https://developer.spotify.com/
        public static string SpotifyiOSClientId = "4a48a39ff02a461d9505b00679ab2c2d";
        public static string SpotifyAndroidClientId = "4a48a39ff02a461d9505b00679ab2c2d";

        public static string SpotifyiOSSecretId = "48b69938450649dd881fdd8476cb1cc1";
        public static string SpotifyAndroidSecretId = "48b69938450649dd881fdd8476cb1cc1";

        // These values do not need changing
        public static string SpotifyScope = "user-read-recently-played";
        public static string SpotifyAuthorizeUrl = "https://accounts.spotify.com/authorize";
        public static string SpotifyAccessTokenUrl = "https://accounts.spotify.com/api/token";
        public static string SpotifyUserInfoUrl = "https://api.spotify.com/v1/me";

        // Set these to reversed iOS/Android client ids, with :/oauth2redirect appended
        public static string SpotifyiOSRedirectUrl = "com.companyname.googlesignin:/oauth2redirect";
        public static string SpotifyAndroidRedirectUrl = "com.companyname.googlesignin:/oauth2redirect";

    }
}
