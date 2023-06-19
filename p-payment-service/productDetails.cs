using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace p_payment_service
{
    public partial class ProductDetails : Form
    {
        public int productId { get; set; }
        public int quantity { set; get; }
        public static bool is_active;
        public string currency = "kr";
        public Products product;
        public Item item = new Item();
        public ProductDetails()
        {
            
            InitializeComponent();

        }

        private void ProductDetails_Load(object sender, EventArgs e)
        {
            this.quantity = 1;
            // Find the product with the matching productId
            product = MainCykel.objects.products.FirstOrDefault(p => p.id == productId);
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
                    quantityPanelCover.Visible = false;
                    foreach (AdditionalOption additionalOption in product.additional)
                    {

                        // Create a GroupBox control

                        GroupBox groupBox = new GroupBox();
                        groupBox.Text = additionalOption.additional_name;
                        //groupBox.Location = new Point(10, 10);
                        groupBox.Size = new Size(350, 350);
             
                        //groupBox.Width = 350;
                        //groupBox.MinimumSize = new Size(350, 100); //
                        groupBox.Font = new Font(groupBox.Font.FontFamily, 12, FontStyle.Bold);
                        groupBox.Padding = new Padding(10);
                        //groupBox.Paint += groupBox_Paint;


                        //Console.WriteLine($"Additionall: {additionalOption.option.First().option_name}");
                        Console.WriteLine($"Additionall: {additionalOption.additional_name}");
                        
                        FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                        flowLayoutPanel.Dock = DockStyle.Fill; // Fill the entire available space within the GroupBox
                        //flowLayoutPanel.FlowDirection = FlowDirection.TopDown; // Arrange controls vertically
                        flowLayoutPanel.Padding = new Padding(10);
                        flowLayoutPanel.AutoScroll = true;
                        flowLayoutPanel.BackColor = Color.White;


                        foreach (var optionGroup in additionalOption.options)
                        {
                            if(additionalOption.multiple == "true")
                            {
                                CheckBox checkBox = new CheckBox();
                                checkBox.Text = optionGroup.price + " " +  MainCykel.Currency + " > " + optionGroup.option_name;
                                //checkBox.Location = new Point(20, 30); // Set the desired location
                                checkBox.Size = new Size(300, 30);
                                flowLayoutPanel.Controls.Add(checkBox);
                                checkBox.Tag = optionGroup;
                                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                            }
                            else
                            {
                                RadioButton radioButton = new RadioButton();
                                radioButton.Text = optionGroup.price + " " + MainCykel.Currency + " > " + optionGroup.option_name;
                                //radioButton.Location = new Point(20, 30);
                                radioButton.Size = new Size(300, 30);
                                flowLayoutPanel.Controls.Add(radioButton);
                                radioButton.Tag = optionGroup;
                                radioButton.CheckedChanged += RadioButton_CheckedChanged;

                            }

                        }
                        

                        groupBox.Controls.Add(flowLayoutPanel);
                    
                        additionalPanel.Controls.Add(groupBox);

                    }

                }

            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                // Checkbox is checked, handle the event
                // You can access the specific checkbox using the 'checkBox' variable

                

            }
            else
            {
                // Checkbox is unchecked, handle the event
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                // Radio button is checked, handle the event
                // You can access the specific radio button using the 'radioButton' variable

            }
            else
            {
                // Radio button is unchecked, handle the event
            }
        }

        private void ProductDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            is_active = false;
        }



        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void quantityIncrease_Click(object sender, EventArgs e)
        {
            int qty = quantity + 1;
            quantity = qty;
            quantityLabel.Text = qty.ToString();
        }

        private void quantityDecrease_Click(object sender, EventArgs e)
        {
            if(quantity > 1)
            {
                int qty = quantity - 1;
                quantity = qty;
                quantityLabel.Text = qty.ToString();
            }
        }

        private void addToCartButton_Click(object sender, EventArgs e)
        {
            Item item = new Item
            {
                Id = productId,
                Name = product.productName,
                Price = product.unitPrice,
                Quantity = quantity,
                Picture = productPicture.Image,
                /*
                AdditionalItem = new AdditionalCartItem
                {
                    Name = new List<string> { "Option 1", "Option 2" },
                    additionalCartOptions = new List<AdditionalCartOption>
                    {
                        new AdditionalCartOption { Name = "Option 1", Price = 0 },
                        new AdditionalCartOption { Name = "Option 2", Price = 0 }
                    }
                }
                */
            };


            AdditionalCartItem additionalItem = new AdditionalCartItem
            {
                additionalCartOptions = new List<AdditionalCartOption>
                    {
                        new AdditionalCartOption { Name = "Option 1", Price = 1 },
                        new AdditionalCartOption { Name = "Option 2", Price = 1 }
                    }
            };
            additionalItem.Name = "Additional Item 1";

           
            item.AdditionalItem.Add(additionalItem);


            MainCykel.cartItem.AddItem(item);
            this.Close();
        }

        private void additionalPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
