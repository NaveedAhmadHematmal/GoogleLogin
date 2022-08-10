using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GoogleSignIn.Services
{
    public static class GeneratorService
    {
        public static string GenerateNonce()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz123456789";
            var random = new Random();
            var nonce = new char[128];
            for (int i = 0; i < nonce.Length; i++)
            {
                nonce[i] = chars[random.Next(chars.Length)];
            }

            return new string(nonce);
        }

        public static string GenerateCodeChallenge(string codeVerifier)
        {
            string code;
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(codeVerifier));
                var b64Hash = Convert.ToBase64String(hash);
                code = Regex.Replace(b64Hash, "\\+", "-");
                code = Regex.Replace(code, "\\/", "_");
                code = Regex.Replace(code, "=+$", "");
            }
            return code;
        }

        public static async Task<string> OnGet(string code, string codeVerifier)
        {
            var httpClient = new HttpClient();

            var parameters = new Dictionary<string, string>
                {
                    {"client_id", Constants.TeslaiOSClientId},
                    {"grant_type", "authorization_code"},
                    {"code", code},
                    {"redirect_uri", Constants.TeslaiOSRedirectUrl},
                    {"code_verifier", codeVerifier}
                };

            var urlEncodedParameters = new FormUrlEncodedContent(parameters);
            var req = new HttpRequestMessage(HttpMethod.Post, "https://auth.tesla.com/oauth2/v3/token") { Content = urlEncodedParameters };
            var response = await httpClient.SendAsync(req);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
