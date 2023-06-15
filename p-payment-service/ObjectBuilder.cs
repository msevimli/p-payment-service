using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace p_payment_service
{
    internal class ObjectBuilder
    {

    }
    public class StoreBuilder
    {
        public StoreBuilder()
        {
            Form1.storeBaseName.Text = Form1.objects.settings.storeName;
            using (WebClient webClient = new WebClient())
            {
                if(Form1.objects.settings.storeLogo != null)
                try
                {
                    byte[] imageData = webClient.DownloadData(Form1.objects.settings.storeLogo);
                    using (var stream = new System.IO.MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(stream);
                        Form1.storeLogoPicture.Image = image;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during downloading or displaying the image
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }
    }
    public class CategoryBuilder
    {
        public CategoryBuilder()
        {
            ApiObjects objects = Form1.objects;
            foreach (var category in objects.categories)
            {
                //Console.WriteLine(category.name);
                Panel pane = new Panel();
                pane.Width = 135;
                pane.Height = 140;
                pane.BackColor = Color.White;
                pane.BorderStyle = BorderStyle.FixedSingle;
                pane.ForeColor = Color.Black; // Set the desired border color
                // Create a new instance of PictureBox
                PictureBox pictureBox = new PictureBox();

                // Set properties of the PictureBox
                pictureBox.Location = new System.Drawing.Point(10, 10);
                pictureBox.Size = new System.Drawing.Size(118, 88);
                //pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Click += (sender, e) => Category_Click(sender, e, category.id); ;
                // Download the image from the URL
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        byte[] imageData = webClient.DownloadData(category.image);
                        using (var stream = new System.IO.MemoryStream(imageData))
                        {
                            Image image = Image.FromStream(stream);
                            pictureBox.Image = image;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that occur during downloading or displaying the image
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

                // Create a new instance of Label
                Label label = new Label();

                // Set properties of the Label
                label.Text = category.name;
                label.Dock = DockStyle.Bottom;
                label.TextAlign = ContentAlignment.MiddleCenter;

                // Set the background color and text color
                label.BackColor = Color.Black;
                label.ForeColor = Color.White;

                // Set the font to bold
                label.Font = new Font(label.Font, FontStyle.Bold);
                //label.Font = new Font(label.Font, FontStyle.Bold);

                // Add the Label to the form's Controls collection
                pane.Controls.Add(label);

                // Add the PictureBox to the form's Controls collection
                pane.Controls.Add(pictureBox);

                Form1.categoryPanel.Controls.Add(pane);
            }
            //build first category products
            BuildProducts products = new BuildProducts(objects.categories.First().id);
        }
        private void Category_Click(object sender, EventArgs e, int id)
        {
            // Handle the click event here
            PictureBox clickedPanel = (PictureBox)sender;
            //Console.WriteLine($"clicked id : {id}");
            BuildProducts products = new BuildProducts(id);
        }

    }

    public class BuildProducts
    {
        public BuildProducts(int categoryId)
        {

            //clear panel

            Form1.productPanel.Controls.Clear();
            // Search products by categoryId
            List<Products> searchedProducts = Form1.objects.products
                .Where(p => p.categoryId.Contains(categoryId))
                .ToList();

            // Display the searched products

            if (searchedProducts.Count > 0)
            {
                foreach (Products product in searchedProducts)
                {
                    Console.WriteLine("Product Name: " + product.productName);

                    //Console.WriteLine(category.name);
                    Panel pane = new Panel();
                    pane.Width = 250;
                    pane.Height = 250;
                    pane.BackColor = Color.White;
                    pane.Margin = new Padding(10, 10, 10, 10);
                    pane.BorderStyle = BorderStyle.FixedSingle;
                    pane.ForeColor = Color.Black; // Set the desired border color
                    // Create a new instance of PictureBox
                    PictureBox pictureBox = new PictureBox();

                    // Set properties of the PictureBox
                    pictureBox.Location = new System.Drawing.Point(10, 10);
                    pictureBox.Size = new System.Drawing.Size(230, 200);
                    //pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Click += (sender, e) => Product_Click(sender, e, product.id); ;
                    // Download the image from the URL
                    using (WebClient webClient = new WebClient())
                    {
                        try
                        {
                            byte[] imageData = webClient.DownloadData(product.image);
                            using (var stream = new System.IO.MemoryStream(imageData))
                            {
                                Image image = Image.FromStream(stream);
                                pictureBox.Image = image;
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle any errors that occur during downloading or displaying the image
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }

                    // Create a new instance of Label
                    Label label = new Label();

                    // Set properties of the Label
                    label.Text = product.productName;
                    label.Dock = DockStyle.Bottom;
                    label.TextAlign = ContentAlignment.MiddleCenter;

                    // Set the background color and text color
                    label.BackColor = Color.Black;
                    label.ForeColor = Color.White;

                    // Set the font to bold
                    label.Font = new Font(label.Font, FontStyle.Bold);
                    //label.Font = new Font(label.Font, FontStyle.Bold);

                    // Add the Label to the form's Controls collection
                    pane.Controls.Add(label);

                    // Add the PictureBox to the form's Controls collection
                    pane.Controls.Add(pictureBox);

                    Form1.productPanel.Controls.Add(pane);
                   

                }
            }
        }
        private void Product_Click(object sender, EventArgs e, int id)
        {
            // Handle the click event here
            PictureBox clickedPanel = (PictureBox)sender;
            Console.WriteLine($"product id : {id}");
            //BuildProducts products = new BuildProducts(id);
            ProductDetails productDetails = new ProductDetails();
            if(!ProductDetails.is_active )
            {
                productDetails.Owner = Form1.ActiveForm;
                productDetails.productId = id;

                // Show the other form
                productDetails.Show();
                ProductDetails.is_active = true;
            }
            
        }
    }
}
