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

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            if (product != null)
            {
                this.Text = product.productName;
                this.Refresh();
                productNameLabel.Text = product.productName;
                //productPriceLabel.Text = product.unitPrice.ToString() + " "+currency;
                ImageBuilder image = new ImageBuilder();
                Image productImage = image.getFromCache(product.image);
                productPicture.Image = productImage;
               
                if (product.additional != null)
                {
                    //Console.WriteLine($"Additionall: {item.additional.First().option}");

                    foreach (AdditionalOption additionalOption in product.additional)
                    {

                        // Create a GroupBox control

                        GroupBox groupBox = new GroupBox();
                        groupBox.Text = additionalOption.additional_name;
                        //groupBox.Location = new Point(10, 10);
                        groupBox.Size = new Size(350, 350);
                       // groupBox.Width = 350;
                        groupBox.MinimumSize = new Size(300, 100); //
                        groupBox.Font = new Font(groupBox.Font.FontFamily, 13, FontStyle.Bold);
                        groupBox.Padding = new Padding(10);
                        //groupBox.Paint += groupBox_Paint;


                        //Console.WriteLine($"Additionall: {additionalOption.option.First().option_name}");
                        Console.WriteLine($"Additionall: {additionalOption.additional_name}");
                        
                        FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                        flowLayoutPanel.Dock = DockStyle.Fill; // Fill the entire available space within the GroupBox
                        flowLayoutPanel.FlowDirection = FlowDirection.TopDown; // Arrange controls vertically
                        flowLayoutPanel.Padding = new Padding(10);
                        flowLayoutPanel.AutoScroll = true;
                        flowLayoutPanel.BackColor = Color.White;
                        

                        foreach (var optionGroup in additionalOption.options)
                        {
                            CheckBox checkBox = new CheckBox();
                            checkBox.Text = optionGroup.option_name ;
                            checkBox.Location = new Point(20, 30); // Set the desired location
                            //checkBox.Size = new Size(150, 20); // Set the desired size

                            // Add the checkbox to the form or any container control
                            flowLayoutPanel.Controls.Add(checkBox);
                        }

                        groupBox.Controls.Add(flowLayoutPanel);
                        additionalPanel.Controls.Add(groupBox);


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

        private void picturePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
