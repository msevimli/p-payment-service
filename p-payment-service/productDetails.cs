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
        public List<CheckBoxTagData> AdditionalSelected = new List<CheckBoxTagData>();
        // Declare the event based on the custom event arguments
       // public event EventHandler<CheckBoxCheckedEventArgs> CheckBoxChecked;
        public ProductDetails()
        {
            InitializeComponent();
            InitializeLanguage();
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
                priceLabel.Text = product.unitPrice + " " + MainCykel.Currency;
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
                                string additionalName = additionalOption.additional_name; // Replace with the actual additional data you want to send
                                CheckBoxTagData tagData = new CheckBoxTagData(optionGroup, additionalName);
                                checkBox.Tag = tagData;
                                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                            }
                            else
                            {
                                RadioButton radioButton = new RadioButton();
                                radioButton.Text = optionGroup.price + " " + MainCykel.Currency + " > " + optionGroup.option_name;
                                //radioButton.Location = new Point(20, 30);
                                radioButton.Size = new Size(300, 30);
                                flowLayoutPanel.Controls.Add(radioButton);
                                string additionalName = additionalOption.additional_name; // Replace with the actual additional data you want to send
                                CheckBoxTagData tagData = new CheckBoxTagData(optionGroup, additionalName);
                                radioButton.Tag = tagData;
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
            CheckBoxTagData tagData = (CheckBoxTagData)checkBox.Tag;
            if (checkBox.Checked)
            {
                // Checkbox is checked, raise the event with custom event arguments
                //Option optionGroup = (Option)checkBox.Tag;
               
                Option optionGroup = tagData.OptionGroup;
                string additionalName = tagData.AdditionalName;
                Console.WriteLine(additionalName);
                Console.WriteLine(optionGroup.option_name);
                AdditionalSelected.Add(tagData);
                Console.WriteLine(AdditionalSelected.Count);
            }
            else
            {
                // Checkbox is unchecked, handle the event
                AdditionalSelected.Remove(tagData);
                Console.WriteLine(AdditionalSelected.Count);
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            CheckBoxTagData tagData = (CheckBoxTagData)radioButton.Tag;
            if (radioButton.Checked)
            {
                // Radio button is checked, handle the event
                // You can access the specific radio button using the 'radioButton' variable
                Option optionGroup = tagData.OptionGroup;
                string additionalName = tagData.AdditionalName;
                Console.WriteLine(additionalName);
                Console.WriteLine(optionGroup.option_name);
                AdditionalSelected.Add(tagData);
                Console.WriteLine(AdditionalSelected.Count);

            }
            else
            {
                // Radio button is unchecked, handle the event
                AdditionalSelected.Remove(tagData);
                Console.WriteLine(AdditionalSelected.Count);
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
                Picture = productPicture.Image
            };

            if (AdditionalSelected.Count > 0)
            {
                AdditionalCartItem additionalItem = new AdditionalCartItem();
                foreach ( var additionalSelected in AdditionalSelected )
                {

                    additionalItem.Name = additionalSelected.AdditionalName;
                    
                    AdditionalCartOption additionalCartOption = new AdditionalCartOption();
                    additionalCartOption.Name = additionalSelected.OptionGroup.option_name;
                    additionalCartOption.Price = additionalSelected.OptionGroup.price;

                    additionalItem.additionalCartOptions.Add(additionalCartOption);
                }
                item.AdditionalItem.Add(additionalItem);
            }

          
            MainCykel.cartItem.AddItem(item);
            this.Close();
        }

        private void additionalPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InitializeLanguage()
        {
            cancelButton.Text = LangHelper.GetString("Cancel");
            addToCartButton.Text = LangHelper.GetString("Add to cart");
        }
    }
    // Custom class to hold multiple variables
    public class CheckBoxTagData
    {
        public Option OptionGroup { get; set; }
        public string AdditionalName { get; set; }

        public CheckBoxTagData(Option optionGroup, string additionalData)
        {
            OptionGroup = optionGroup;
            AdditionalName = additionalData;
        }
    }
}
