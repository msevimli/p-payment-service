
using System.Collections.Generic;


namespace p_payment_service
{
   public class ApiObjects
    {
        public List<Products> products { get; set; }
        public List<Categories> categories { get; set; }
        public Settings settings { get; set; }
    }
    public class Products
    {
        public int id { get; set; }
        public List<int> categoryId { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public decimal unitPrice { get; set; }
        public string image { get; set; }
        public List<AdditionalOption> additional { get; set; }
    }
    public class AdditionalOption
    {
        public List<Option> options { get; set; }
        public string additional_name { get; set; }
        public string multiple { get; set; }
    }
    public class Option
    {
        public string option_name { get; set; }
        public int price { get; set; }
        public string direction { get; set; }
    }
    public class Categories
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }
    public class Settings
    {
        public string lastUpdate { get; set; }
        public string storeName { get; set; }
        public string storeLogo { get; set; }

    }
}
