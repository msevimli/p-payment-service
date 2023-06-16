using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_payment_service
{
    public class CartItem
    {
        public List<Item> item { get; set; }
        public CartItem()
        {
            item = new List<Item>(); // Initialize the item list in the constructor
        }
        public void ClearItems()
        {
            item.Clear();
        }
    }


    public class  Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { set; get; }
    }
}
