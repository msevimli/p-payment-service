using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static p_payment_service.VivaTerminal;

namespace p_payment_service
{
    public class VivaTerminal
    {
        private readonly string _tokenUrl;
        private readonly string _apiUrl;
        private readonly string _sessionUrl;
        private readonly string _sessionId;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private  string _accessToken;
        private Transaction _transaction;
        public VivaTerminal()
        {
            //ISV
            string tokenUrl = "https://demo-accounts.vivapayments.com/connect/token";
            string apiUrl = "https://demo-api.vivapayments.com/ecr/isv/v1/transactions:sale";
            string sessionUrl = "https://demo-api.vivapayments.com/ecr/isv/v1/sessions/";
            string clientId = "isjgf19w6pflo4v1ut8oqw718jzwy6fskor8gf7o6rra1.apps.vivapayments.com";
            string clientSecret = "gagjOf16G55KO83Ds45Z2rtLL7M71W";
            _tokenUrl = tokenUrl;
            _apiUrl = apiUrl;
            _sessionUrl = sessionUrl;
            _clientId = clientId;
            _clientSecret = clientSecret;

            // Generate a new unique sessionId
            string sessionId = Guid.NewGuid().ToString();
            _sessionId = sessionId;
            //_transaction.SessionId = sessionId;
            Console.WriteLine("Session id: " + sessionId);

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

        public async Task<Transaction> MakeSalesRequest(double amount)
        {
            //Generate Bearer Token
            string accessToken = await this.GetBearerToken();
            Console.WriteLine("Access Token: " + accessToken);
            _accessToken = accessToken;

            

            // JSON payload to be sent in the request body
            string jsonBody = @"{
                ""sessionId"": """ + _sessionId + @""",
                ""terminalId"": "+Properties.Settings.Default.terminalId+@",
                ""cashRegisterId"": ""XDE384678UY"",
                ""amount"": "+amount+@",
                ""currencyCode"": 978,
                ""merchantReference"": ""self-order-system"",
                ""customerTrns"": null,
                ""preauth"": false,
                ""maxInstalments"": 0,
                ""tipAmount"": 0,
                ""isvDetails"": {
                    ""amount"": 125,
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
                         //return await response.Content.ReadAsStringAsync();
                         return await RunTransactionStatusCheck();
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

        public async Task<Transaction> RunTransactionStatusCheck()
        {
            //string sessionId = "356ba76c-8ada-4dfc-b9c4-76731712e039";
            string apiUrl = $"{_sessionUrl}{_sessionId}";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            while (stopwatch.Elapsed < TimeSpan.FromSeconds(20)) // Run for up to 20 seconds
            {
                using (HttpClient client = new HttpClient())
                {
                    // Set the Bearer token in the request header
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

                    // Make a POST request
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string responseContent = await response.Content.ReadAsStringAsync();

                        // Deserialize the response content into Transaction class
                        //Transaction transactionResponse = JsonConvert.DeserializeObject<Transaction>(responseContent);
                        _transaction = JsonConvert.DeserializeObject<Transaction>(responseContent);

                        // Check if the response is in the expected format
                        if (_transaction.Message != null)
                        {
                            
                            Console.WriteLine(_transaction);
                            Console.WriteLine("Received valid response: " + responseContent);
                            return _transaction; // Exit the method since a valid response is received
                            
                        }
                        else
                        {
                            Console.WriteLine("Received response, but not in the expected format: " + responseContent);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error response received: " + response.StatusCode);
                    }

                    // Wait for a specific duration before making the next request (e.g., 1 second)
                    await Task.Delay(2000);
                }
            }

            Console.WriteLine("Transaction status check completed. 20 seconds elapsed.");
            //return "20 seconds elapsed";
            _transaction.SessionId = _sessionId;
            _transaction.Message = "20 seconds elapsed";
            return _transaction;
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

        public class IsvDetails
        {
            public int Amount { get; set; }
            public object MerchantId { get; set; }
            public object SourceCode { get; set; }
            public string MerchantSourceCode { get; set; }
        }

        public class Transaction
        {
            public string SessionId { get; set; }
            public string TerminalId { get; set; }
            public string CashRegisterId { get; set; }
            public int Amount { get; set; }
            public string CurrencyCode { get; set; }
            public object MerchantReference { get; set; }
            public object CustomerTrns { get; set; }
            public int TipAmount { get; set; }
            public bool Success { get; set; }
            public int EventId { get; set; }
            public object AuthorizationId { get; set; }
            public object TransactionId { get; set; }
            public object TransactionTypeId { get; set; }
            public object RetrievalReferenceNumber { get; set; }
            public object PanEntryMode { get; set; }
            public object ApplicationLabel { get; set; }
            public object PrimaryAccountNumberMasked { get; set; }
            public object TransactionDateTime { get; set; }
            public bool AbortOperation { get; set; }
            public object AbortAckTime { get; set; }
            public object AbortSuccess { get; set; }
            public object LoyaltyInfo { get; set; }
            public object VerificationMethod { get; set; }
            public object Tid { get; set; }
            public object ShortOrderCode { get; set; }
            public object Installments { get; set; }
            public string Message { get; set; }
            public bool Preauth { get; set; }
            public object ReferenceNumber { get; set; }
            public object OrderCode { get; set; }
            public IsvDetails IsvDetails { get; set; }
            public Transaction(string _sessionId)
            {
                
            }
        }

    }
}
