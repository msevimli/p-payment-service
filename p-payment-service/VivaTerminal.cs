using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace p_payment_service
{
    public class VivaTerminal
    {
        private readonly string _tokenUrl;
        private readonly string _apiUrl;
        private readonly string _clientId;
        private readonly string _clientSecret;

        public VivaTerminal(string tokenUrl, string apiUrl, string clientId, string clientSecret)
        {
            _tokenUrl = tokenUrl;
            _apiUrl = apiUrl;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        public async Task<string> GetBearerToken()
        {
            using (HttpClient client = new HttpClient())
            {
                // Encode the client ID and client secret for Basic Authentication
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_clientId}:{_clientSecret}"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);

                var tokenRequestData = new Dictionary<string, string>
                    {
                        { "grant_type", "client_credentials" }
                    };

                // Encode the tokenRequestData as URL encoded content
                HttpContent content = new FormUrlEncodedContent(tokenRequestData);

                try
                {
                    HttpResponseMessage tokenResponse = await client.PostAsync(_tokenUrl, content);

                    if (tokenResponse.IsSuccessStatusCode)
                    {
                        string tokenResponseJson = await tokenResponse.Content.ReadAsStringAsync();
                        Token token = JsonConvert.DeserializeObject<Token>(tokenResponseJson);
                        return token.access_token;
                    }
                    else
                    {
                        string errorContent = await tokenResponse.Content.ReadAsStringAsync();
                        throw new HttpRequestException($"Error getting token: {tokenResponse.StatusCode}, {errorContent}");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Token Request Error: " + e.Message);
                    throw;
                }
            }
        }

        public async Task<string> MakeApiRequest(string accessToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(_apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        throw new HttpRequestException($"Error making API request: {response.StatusCode}, {errorContent}");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("API Request Error: " + e.Message);
                    throw;
                }
            }
        }

        private class Token
        {
            public string access_token { get; set; }
            public int expires_in { get; set; }
            public string token_type { get; set; }
            public string scope { get; set; }
        }
    }
}
