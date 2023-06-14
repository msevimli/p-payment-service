using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p_payment_service
{
    public partial class ProductDetails : Form
    {
        public  int productId { get; set; }
        public static bool is_active;
        public ProductDetails()
        {
            InitializeComponent();
        }

        private void ProductDetails_Load(object sender, EventArgs e)
        {
            // Find the product with the matching productId
            Products product = Form1.objects.products.FirstOrDefault(p => p.id == productId);

            if (product != null)
            {
                Console.WriteLine($"ID: {product.id}");
                Console.WriteLine($"Category ID: {string.Join(", ", product.categoryId)}");
                Console.WriteLine($"Product Name: {product.productName}");
                Console.WriteLine($"Description: {product.description}");
                Console.WriteLine($"Unit Price: {product.unitPrice}");
            }
        }

        private void ProductDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            is_active = false;
        }
    }
}
