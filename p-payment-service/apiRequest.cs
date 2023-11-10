using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Management;

namespace p_payment_service
{
   
     class apiRequest
    {
       

        private readonly string _publicKey;
        private readonly string _privateKey;
        private readonly string _apiUrl;
        private readonly string _apiOrderSyncUrl;
        public apiRequest()
        {
            _publicKey = Properties.Settings.Default.PublicKey;
            _privateKey = Properties.Settings.Default.PrivateKey;
            _apiUrl = "https://terminal.plife.se/";
            //_apiUrl = "http://terminal.plife.loc/";
            _apiOrderSyncUrl = "http://terminal.plife.loc/";
        }

        public string getAll()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiUrl);

            client.DefaultRequestHeaders.Add("Public-Key", _publicKey);
            client.DefaultRequestHeaders.Add("Private-Key", _privateKey);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.
            try
            {
                HttpResponseMessage response = client.GetAsync("api/product/v2").Result;  // Blocking call!
                //HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    //Console.WriteLine("Request Message Information:- \n\n" + response.RequestMessage + "\n");
                    //Console.WriteLine("Response Message Header \n\n" + response.Content.Headers + "\n");
                    var products = response.Content.ReadAsStringAsync().Result;
                    ///Console.WriteLine(products);
                    return products;
                }
                else
                {
                    //Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return "error";

                }

            } catch(Exception e)
            {
                return "error";
            }
           
        }

        //Sync Order 

        public async Task<bool> SubmitOrderToApiAsync()
        {
            LogWriter _log = new LogWriter();
            try
            {
                // Create JSON data for the API request
                var jsonData = new
                {
                    orderTotal = MainCykel.cartItem.CalculateTotal(), // Calculate total order amount
                    orderNote =( new {
                        orderNo = MainCykel.cartItem.orderNo,
                        transactionId = MainCykel.cartItem.transactionId
                    }),
                    date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), // Current date in the format expected by the API
                    orderContent = MainCykel.cartItem.Item.Select(item => new
                    {
                        productName = item.Name,
                        unitPrice = item.Price,
                        quantity = item.Quantity,
                        selectedAdditional = item.AdditionalItem.Select(additionalItem => new
                        {
                            Name = additionalItem.Name,
                            additionalCartOptions = additionalItem.additionalCartOptions
                        }).ToList()
                    }).ToList()
                };

                // Serialize the JSON data
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonData);

                // Create HttpClient instance with headers
                using (var httpClient = new HttpClient())
                {
                    // Set headers
                    httpClient.BaseAddress = new Uri(_apiOrderSyncUrl);
                    httpClient.DefaultRequestHeaders.Add("Public-Key", _publicKey);
                    httpClient.DefaultRequestHeaders.Add("Private-Key", _privateKey);

                    // Set the content type to JSON
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Make the POST request to the API
                    HttpResponseMessage response = await httpClient.PostAsync("api/order", content);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("order Sync Success");
                        Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                        // Order submitted successfully
                        return true;
                    }
                }

                _log.LogWrite("order submission failed", "order Submission");
                // Order submission failed
                return false;
                
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., network issues, API errors)
                Console.WriteLine("Error: " + ex.Message);
                _log.LogWrite(ex.Message, "order Submission erro");
                return false;
            }
        }

        public void sendOrder()
        {
            //CartItem _cartItem = MainCykel.cartItem;
            foreach (Item cartItem in MainCykel.cartItem.Item)
            {
               LogWriter _log = new LogWriter();
                _log.LogWrite(cartItem.ToString(), "cart item");

            }
        }
     
    }
  
}
