using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p_payment_service
{
    internal class QuickView
    {

        public void initCartDetails()
        {
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MainCykel.cartItem.ItemAdded -= CartItem_ItemAdded;
            MainCykel.cartItem.ItemChanged -= CartItem_ItemChanged;
            MainCykel.cartItem.ItemAdded += CartItem_ItemAdded;
            MainCykel.cartItem.ItemChanged += CartItem_ItemChanged;
            MainCykel.QuickViewFlow.Controls.Clear();
            calculateCartTotal();
            foreach (Item cartItem in MainCykel.cartItem.Item)
            {
                Panel pane = new Panel();
                pane.Width = 500;
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
                namePane.Width = 25;
                namePane.Height = 25;
                namePane.Dock = DockStyle.Left;

                Label nameLabel = new Label();
                nameLabel.Text = cartItem.Name;
                nameLabel.Dock = DockStyle.Fill;
                nameLabel.TextAlign = ContentAlignment.MiddleCenter;
                nameLabel.Font = new Font(nameLabel.Font.FontFamily, 12, FontStyle.Regular);


                // Set the background color and text color
                nameLabel.ForeColor = Color.Black;
                namePane.Controls.Add(nameLabel);
                pane.Controls.Add(namePane);

                // Set properties of the PictureBox
                Panel imagePane = new Panel();
                imagePane.Width = 25;
                imagePane.Height = 25;
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
                pane.Width = 750;
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
            rmvPanel.Size = new System.Drawing.Size(100, 100);
            rmvPanel.Padding = new Padding(0, 20, 0, 20); // Set top and bottom padding
            // Remove button 
            Button removeButton = new Button();
            removeButton.Text = LangHelper.GetString("Remove");
            removeButton.Width = 75;
            removeButton.Height = 30;
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
            addPanel.Width = 250;
            addPanel.Height = 100;
            addPanel.Dock = DockStyle.Left;

            FlowLayoutPanel addDetailsPanel = new FlowLayoutPanel();
            addDetailsPanel.Width = 145;
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
            priceLabel.Dock = DockStyle.Right;
            priceLabel.TextAlign = ContentAlignment.MiddleCenter; // Set text alignment to the middle
            priceLabel.Font = new Font(priceLabel.Font.FontFamily, 13, FontStyle.Regular);
            addPanel.Controls.Add(priceLabel);

            return addPanel;
        }

        private Panel quantityPanel(Item cartItem)
        {
            Panel qtyPanel = new Panel();
            qtyPanel.Width = 250;
            qtyPanel.Height = 100;
            qtyPanel.Dock = DockStyle.Left;
            qtyPanel.Location = new Point(0, 0);
            qtyPanel.Padding = new Padding(0, 20, 0, 20); // Set top and bottom padding

            // total price  Label
            decimal total = cartItem.Price * cartItem.Quantity;
            Label priceLabel = new Label();
            priceLabel.Width = 100;
            priceLabel.Height = 100;
            priceLabel.Text = total.ToString() + " " + MainCykel.Currency;
            priceLabel.Dock = DockStyle.Right;
            priceLabel.TextAlign = ContentAlignment.MiddleCenter; // Set text alignment to the middle
            priceLabel.Font = new Font(priceLabel.Font.FontFamily, 13, FontStyle.Regular);
            qtyPanel.Controls.Add(priceLabel);

            // Increase button
            Button incBtt = new Button();
            incBtt.Text = "+";
            incBtt.Font = new Font(incBtt.Font.FontFamily, 10, FontStyle.Bold);
            incBtt.Width = 40;
            incBtt.Height = 33;
            incBtt.Dock = DockStyle.Left;
            incBtt.FlatStyle = FlatStyle.Flat;
            qtyPanel.Controls.Add(incBtt);

            // Quantity Label
            Label qtyLabel = new Label();
            qtyLabel.Width = 40;
            qtyLabel.Height = 33;
            qtyLabel.Text = cartItem.Quantity.ToString();
            qtyLabel.Dock = DockStyle.Left;
            qtyLabel.TextAlign = ContentAlignment.MiddleCenter; // Set text alignment to the middle
            qtyPanel.Controls.Add(qtyLabel);

            // Decrease button
            Button decBtt = new Button();
            decBtt.Text = "-";
            decBtt.Width = 40;
            decBtt.Height = 33;
            decBtt.Dock = DockStyle.Left;
            decBtt.Font = new Font(decBtt.Font.FontFamily, 10, FontStyle.Bold);
            decBtt.FlatStyle = FlatStyle.Flat;

            qtyPanel.Controls.Add(decBtt);

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
