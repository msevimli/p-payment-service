using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static p_payment_service.VivaTerminal;

namespace p_payment_service
{
    public class VivaTerminal
    {
        private readonly string _tokenUrl;
        private readonly string _apiUrl;
        private readonly string _clientId;
        private readonly string _clientSecret;

        public VivaTerminal()
        {
            //ISV
            string tokenUrl = "https://demo-accounts.vivapayments.com/connect/token";
            string apiUrl = "https://demo-api.vivapayments.com/ecr/isv/v1/transactions:sale";
            string clientId = "isjgf19w6pflo4v1ut8oqw718jzwy6fskor8gf7o6rra1.apps.vivapayments.com";
            string clientSecret = "gagjOf16G55KO83Ds45Z2rtLL7M71W";
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

        public async Task<string> MakeApiRequest()
        {
            //Generate Bearer Token
            string accessToken = await this.GetBearerToken();
            Console.WriteLine("Access Token: " + accessToken);

            // Generate a new unique sessionId
            string sessionId = Guid.NewGuid().ToString();
            Console.WriteLine("Session id: " + sessionId);

            // JSON payload to be sent in the request body
            string jsonBody = @"{
                ""sessionId"": """ + sessionId + @""",
                ""terminalId"": "+Properties.Settings.Default.terminalId+@",
                ""cashRegisterId"": ""XDE384678UY"",
                ""amount"": 1170,
                ""currencyCode"": 978,
                ""merchantReference"": null,
                ""customerTrns"": null,
                ""preauth"": false,
                ""maxInstalments"": 0,
                ""tipAmount"": 0,
                ""isvDetails"": {
                    ""amount"": 122,
                    ""merchantSourceCode"": 5678,
                    ""terminalMerchantId"": """+Properties.Settings.Default.merchantId+@"""
                }
            }";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                // Create StringContent with raw JSON payload
                StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync(_apiUrl, content);

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

        public async Task<Terminal> SearchPos(string accessToken)
        {
            // JSON payload for the POST request
            string jsonBody = @"{
                ""merchantId"": """+Properties.Settings.Default.merchantId+@""",
                ""statusId"": 1
            }";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                // Create StringContent with raw JSON payload
                StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync(_apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Terminal terminal = JsonConvert.DeserializeObject<Terminal>(jsonResponse);
                        return terminal;
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

        async Task RunTransactionStatusCheck()
        {
            string expectedValue = "expected response"; // Replace this with your expected response

            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://example.com/api/endpoint"; // Replace this with your API endpoint URL
                string requestBody = "your request body"; // Replace this with your request body content

                while (true) // Keep looping until the expected response is received
                {
                    // Make a POST request
                    HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(requestBody));

                    // Check if the response is successful and contains the expected value
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();

                        // Check if the response contains the expected value
                        if (responseContent.Contains(expectedValue))
                        {
                            Console.WriteLine("Expected response received: " + responseContent);
                            break; // Exit the loop since the expected response is received
                        }
                        else
                        {
                            Console.WriteLine("Received response, but not the expected value: " + responseContent);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error response received: " + response.StatusCode);
                    }

                    // Wait for a specific duration before making the next request (e.g., 1 second)
                    await Task.Delay(1000);
                }
            }

            Console.WriteLine("Transaction status check completed.");
        }

        private class Token
        {
            public string access_token { get; set; }
            public int expires_in { get; set; }
            public string token_type { get; set; }
            public string scope { get; set; }
        }
        public class Terminal
        {
            public string MerchantId { get; set; }
            public int StatusId { get; set; }
            public string SourceCode { get; set; }
            public string TerminalId { get; set; }
            public string VirtualTerminalId { get; set; }
        }

    }
}
