using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace p_payment_service
{
   
     class apiRequest
    {
        public string publicKey { get; set; }
        public string privateKey { get; set; }
        public string apiUrl  { get; set; }
        public string getProduct()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);

            client.DefaultRequestHeaders.Add("Public-Key", publicKey);
            client.DefaultRequestHeaders.Add("Private-Key", privateKey);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.
            try
            {
               // HttpResponseMessage response = client.GetAsync("api/product").Result;  // Blocking call!
                HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!
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

    }
  
}
