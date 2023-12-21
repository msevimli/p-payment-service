using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p_payment_service
{
    public class QuickView
    {

        public  QuickView()
        {
           
            MainCykel.cartItem.ItemAdded -= CartItem_ItemAdded;
            MainCykel.cartItem.ItemChanged -= CartItem_ItemChanged;
            MainCykel.cartItem.ItemAdded += CartItem_ItemAdded;
            MainCykel.cartItem.ItemChanged += CartItem_ItemChanged;
           
        }
       
        public void initCartDetails()
        {
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MainCykel.QuickViewFlow.Controls.Clear();
            calculateCartTotal();
            foreach (Item cartItem in MainCykel.cartItem.Item)
            {
                Panel pane = new Panel();
                pane.Width = 250;
                pane.Height = 100;
                //pane.Dock= DockStyle.Fill;
                pane.BackColor = Color.White;
                pane.Padding = new Padding(10);
                //pane.BorderStyle = BorderStyle.FixedSingle;

                // quantity Panel
                if (cartItem.AdditionalItem.Count < 1)
                {
                    pane.Controls.Add(quantityPanel(cartItem));
                }
                else
                {
                    pane.Controls.Add(additionalPanel(cartItem));
                }


                //Name panel
                Panel namePane = new Panel();
                namePane.Width = 100;
                namePane.Height = 25;
                namePane.Dock = DockStyle.Top;

                Label nameLabel = new Label();
                nameLabel.Text = cartItem.Name;
                nameLabel.Dock = DockStyle.Top;
                //nameLabel.TextAlign = ContentAlignment.MiddleCenter;
                nameLabel.Font = new Font(nameLabel.Font.FontFamily, 12, FontStyle.Regular);


                // Set the background color and text color
                nameLabel.ForeColor = Color.Black;
                namePane.Controls.Add(nameLabel);
                pane.Controls.Add(namePane);

                // Set properties of the PictureBox
                Panel imagePane = new Panel();
                imagePane.Width = 50;
                imagePane.Height = 50;
                imagePane.Dock = DockStyle.Left;


                //pictureBox.Location = new System.Drawing.Point(10, 10);
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new System.Drawing.Size(25, 25);
                pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                pictureBox.Image = cartItem.Picture;
                pictureBox.Dock = DockStyle.Fill;
                imagePane.Controls.Add(pictureBox);

                // Product Price label
                Label productPriceLabel = new Label();
                productPriceLabel.Width = 150;
                productPriceLabel.Height = 100;
                productPriceLabel.Text = cartItem.Price.ToString() + " " + MainCykel.Currency;
                productPriceLabel.BackColor = Color.Red;
                productPriceLabel.ForeColor = Color.White;
                productPriceLabel.Font = new Font(productPriceLabel.Font.FontFamily, 8, FontStyle.Regular);
                productPriceLabel.TextAlign = ContentAlignment.MiddleCenter;
                //productPriceLabel.Width = 55;
                productPriceLabel.Dock = DockStyle.Bottom;
                //imagePane.Controls.Add(productPriceLabel);

                pane.Controls.Add(imagePane);

                //pane.Controls.Add(removeButton);
                pane.Controls.Add(removePanel(cartItem, pane));
                MainCykel.QuickViewFlow.Controls.Add(pane);

            }
          
            if (MainCykel.cartItem.Item.Count == 0)
            {
                Panel pane = new Panel();
                pane.Width = 250;
                pane.Height = 100;
                //pane.Dock= DockStyle.Fill;
                pane.BackColor = Color.White;
                pane.Padding = new Padding(10);

                Label nameLabel = new Label();
                nameLabel.Text = LangHelper.GetString("No item in the cart");
                nameLabel.Dock = DockStyle.Fill;
                nameLabel.TextAlign = ContentAlignment.MiddleCenter;
                nameLabel.Font = new Font(nameLabel.Font.FontFamily, 12, FontStyle.Regular);

             

                pane.Controls.Add(nameLabel);
                MainCykel.QuickViewFlow.Controls.Add(pane);
            }
        }

        private Panel removePanel(Item cartItem, Panel pane)
        {
            Panel rmvPanel = new Panel();
            rmvPanel.Dock = DockStyle.Right;
            rmvPanel.Size = new System.Drawing.Size(50, 50);
            rmvPanel.Padding = new Padding(10, 20, 10, 20); // Set top and bottom padding
            
            // Remove button 
            Button removeButton = new Button();
            //removeButton.Text = LangHelper.GetString("Remove");
            removeButton.Text = "x";
            removeButton.Width = 20;
            removeButton.Height = 20;
            removeButton.Dock = DockStyle.Fill;

            removeButton.Click += (sender, e) =>
            {
                // Remove the cartItem from the list

                // Usage:
                DialogResult result;
                using (CustomDialogForm dialog = new CustomDialogForm())
                {
                    result = dialog.ShowDialog();
                }

                // Handle the result accordingly
                if (result == DialogResult.Yes)
                {
                    // User clicked Yes
                    MainCykel.cartItem.Item.Remove(cartItem);
                    MainCykel.QuickViewFlow.Controls.Remove(pane);
                    calculateCartTotal();
                    initCartDetails();
                }
                else if (result == DialogResult.No)
                {
                    // User clicked No
                }

            };
            rmvPanel.Controls.Add(removeButton);
            return rmvPanel;
        }

        private Panel additionalPanel(Item cartItem)
        {
            Panel addPanel = new Panel();
            addPanel.Width = 210;
            addPanel.Height = 100;
            addPanel.Dock = DockStyle.Fill;

            FlowLayoutPanel addDetailsPanel = new FlowLayoutPanel();
            addDetailsPanel.Width = 100;
            addDetailsPanel.Height = 15;
            addDetailsPanel.Dock = DockStyle.Top;
            // total price  Label
            decimal total = cartItem.Price;
            foreach (var option in cartItem.AdditionalItem)
            {
                foreach (var additionalOption in option.additionalCartOptions)
                {
                    Label optionDetail = new Label();
                    optionDetail.Text = additionalOption.Name + " - " + additionalOption.Price + " " + MainCykel.Currency;
                    optionDetail.AutoSize = false;
                    addDetailsPanel.Controls.Add(optionDetail);
                    total += additionalOption.Price;
                }
            }
            addPanel.Controls.Add(addDetailsPanel);
            Label priceLabel = new Label();
            priceLabel.Width = 100;
            priceLabel.Height = 33;
            priceLabel.Text = total.ToString() + " " + MainCykel.Currency;
            priceLabel.Dock = DockStyle.Bottom;
            priceLabel.TextAlign = ContentAlignment.MiddleLeft; // Set text alignment to the middle
            priceLabel.Font = new Font(priceLabel.Font.FontFamily, 13, FontStyle.Regular);
            addPanel.Controls.Add(priceLabel);

            return addPanel;
        }

        private Panel quantityPanel(Item cartItem)
        {
            Panel qtyPanel = new Panel();
            qtyPanel.Width = 210;
            qtyPanel.Height = 50;
            qtyPanel.Dock = DockStyle.Fill;
            qtyPanel.Location = new Point(0, 0);
            //qtyPanel.Padding = new Padding(0, 20, 0, 20); // Set top and bottom padding

            // total price  Label
            decimal total = cartItem.Price * cartItem.Quantity;
            Label priceLabel = new Label();
            priceLabel.Width = 80;
            priceLabel.Height = 20;
            priceLabel.Text = total.ToString() + " " + MainCykel.Currency;
            priceLabel.Dock = DockStyle.Bottom;
            priceLabel.TextAlign = ContentAlignment.MiddleLeft; // Set text alignment to the middle
            priceLabel.Font = new Font(priceLabel.Font.FontFamily, 13, FontStyle.Regular);
            qtyPanel.Controls.Add(priceLabel);

            Panel qtyPanelButtonGroup = new Panel();
            qtyPanelButtonGroup.Width = 100;
            qtyPanelButtonGroup.Height = 30;
            //qtyPanelButtonGroup.Dock = DockStyle.Fill;


            // Increase button
            Button incBtt = new Button();
            incBtt.Text = "+";
            incBtt.Font = new Font(incBtt.Font.FontFamily, 10, FontStyle.Bold);
            incBtt.Width = 30;
            incBtt.Height = 30;
            incBtt.Dock = DockStyle.Left;
            incBtt.FlatStyle = FlatStyle.Flat;
            qtyPanelButtonGroup.Controls.Add(incBtt);

            // Quantity Label
            Label qtyLabel = new Label();
            qtyLabel.Width = 30;
            qtyLabel.Height = 30;
            qtyLabel.Text = cartItem.Quantity.ToString();
            qtyLabel.Dock = DockStyle.Left;
            qtyLabel.TextAlign = ContentAlignment.MiddleCenter; // Set text alignment to the middle
            qtyPanelButtonGroup.Controls.Add(qtyLabel);

            // Decrease button
            Button decBtt = new Button();
            decBtt.Text = "-";
            decBtt.Width = 30;
            decBtt.Height = 30;
            decBtt.Dock = DockStyle.Left;
            decBtt.Font = new Font(decBtt.Font.FontFamily, 10, FontStyle.Bold);
            decBtt.FlatStyle = FlatStyle.Flat;

            qtyPanelButtonGroup.Controls.Add(decBtt);
            qtyPanel.Controls.Add(qtyPanelButtonGroup);

            // Event handler for incBtt click event
            incBtt.Click += (sender, e) =>
            {
                cartItem.Quantity++; // Increase the quantity
                qtyLabel.Text = cartItem.Quantity.ToString(); // Update the label with the new quantity
                priceLabel.Text = (cartItem.Quantity * cartItem.Price).ToString() + " " + MainCykel.Currency;
                calculateCartTotal();
            };

            // Event handler for decBtt click event
            decBtt.Click += (sender, e) =>
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--; // Increase the quantity
                    qtyLabel.Text = cartItem.Quantity.ToString(); // Update the label with the new quantity
                    priceLabel.Text = (cartItem.Quantity * cartItem.Price).ToString() + " " + MainCykel.Currency;
                    calculateCartTotal();
                }
            };

            return qtyPanel;
        }

        private void CartItem_ItemAdded(object sender, ItemAddedEventArgs e)
        {
            Item addedItem = e.AddedItem;

            // Handle the added item
            //Console.WriteLine("Item added-cart: " + addedItem.Name);
            initCartDetails();
            calculateCartTotal();
        }

        private void CartItem_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            //Item addedItem = e.AddedItem;

            // Handle the added item
            //Console.WriteLine("Item added-cart: " + addedItem.Name);
            initCartDetails();
            calculateCartTotal();
        }

        private void calculateCartTotal()
        {
           
            MainCykel.calculateCartTotal();
        }

    }
}
