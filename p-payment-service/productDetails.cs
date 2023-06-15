using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p_payment_service
{
    public partial class ProductDetails : Form
    {
        public  int productId { get; set; }
        public static bool is_active;
        public string currency = "DKK";
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
                this.Text = product.productName;
                this.Refresh();
                productNameLabel.Text = product.productName;
                productPriceLabel.Text = product.unitPrice.ToString() + " "+currency;
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        byte[] imageData = webClient.DownloadData(product.image);
                        using (var stream = new System.IO.MemoryStream(imageData))
                        {
                            Image image = Image.FromStream(stream);
                            productPicture.Image = image;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that occur during downloading or displaying the image
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

                if (product.additional != null)
                {
                    //Console.WriteLine($"Additionall: {item.additional.First().option}");

                    foreach (AdditionalOption additionalOption in product.additional)
                    {
                        //Console.WriteLine($"Additionall: {additionalOption.option.First().option_name}");
                        Console.WriteLine($"Additionall: {additionalOption.additional_name}");
                        /*
                            foreach (var optionGroup in additionalOption.option)
                            {
                                Console.WriteLine("Option Group: " + optionGroup.Key);

                                foreach (Option option in optionGroup.Value)
                                {
                                    Console.WriteLine("  Option Name: " + option.option_name);
                                    Console.WriteLine("  Price: " + option.price);
                                    Console.WriteLine("  Direction: " + option.direction);
                                }

                            }
                        */

                    }

                }

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

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void additionalPanel_Paint(object sender, PaintEventArgs e)
        {

        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
