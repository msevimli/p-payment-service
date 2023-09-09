using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Resources;
using System.Windows.Forms;
using System.Xml.Linq;


namespace p_payment_service
{
    internal class ObjectBuilder
    {

    }
    public class StoreBuilder
    {
        public StoreBuilder()
        {
            MainCykel.storeBaseName.Text = MainCykel.objects.settings.storeName;
            // Build image 
            if (MainCykel.objects.settings.storeLogo != null)
            {
                ImageBuilder image = new ImageBuilder();
                Image productImage = image.getFromCache(MainCykel.objects.settings.storeLogo);
                MainCykel.storeLogoPicture.Image = productImage;
            }

        }
    }
    public class CategoryBuilder
    {
        public CategoryBuilder()
        {
            ApiObjects objects = MainCykel.objects;
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
                pictureBox.Click += (sender, e) => Category_Click(sender, e, category.id,category.name); ;
                
                // Build image 

                ImageBuilder image = new ImageBuilder();
                Image categoryImage = image.getFromCache(category.image);
                pictureBox.Image = categoryImage;
                

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
               
                MainCykel.categoryPanel.Controls.Add(pane);
            }

            //build first category products
            MainCykel.activeCategory.Text = "> "+objects.categories.First().name;
            BuildProducts products = new BuildProducts(objects.categories.First().id);
        }
        private void Category_Click(object sender, EventArgs e, int id, string name)
        {
            // Handle the click event here
            PictureBox clickedPanel = (PictureBox)sender;
            //Console.WriteLine($"clicked id : {id}");
            BuildProducts products = new BuildProducts(id);
            MainCykel.activeCategory.Text = "> "+name;
        }

    }

    public class BuildProducts
    {
        public BuildProducts(int categoryId)
        {

            //clear panel

            MainCykel.productPanel.Controls.Clear();
            // Search products by categoryId
            List<Products> searchedProducts = MainCykel.objects.products
                .Where(p => p.categoryId.Contains(categoryId))
                .ToList();

            // Display the searched products

            if (searchedProducts.Count > 0)
            {
                int paneWidth = 250;
                int paneHeight = 250;
                int pictureWidth = 230;
                int pictureHeight = 200;
                int productNameLabelHeight = 30;
                int productNameFontSize = 10;
                
                if (searchedProducts.Count < 7)
                {
                     paneWidth = 410;
                     paneHeight = 400;
                     pictureWidth = 370;
                     pictureHeight = 360;
                     productNameLabelHeight = 40;
                     productNameFontSize = 15;
                } 
                    foreach (Products product in searchedProducts)
                {
                    //Console.WriteLine("Product Name: " + product.productName);

                    //Console.WriteLine(category.name);
                    Panel pane = new Panel();
                    pane.Width = paneWidth;
                    pane.Height = paneHeight;
                    pane.BackColor = Color.White;
                    pane.Margin = new Padding(10, 10, 10, 10);
                    pane.BorderStyle = BorderStyle.FixedSingle;
                    pane.ForeColor = Color.OrangeRed; // Set the desired border color
                    
                    // Create a new instance of PictureBox
                    PictureBox pictureBox = new PictureBox();

                    // Set properties of the PictureBox
                    pictureBox.Location = new System.Drawing.Point(10, 10);
                    pictureBox.Size = new System.Drawing.Size(pictureWidth, pictureHeight);
                    //pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Click += (sender, e) => Product_Click(sender, e, product.id); ;

                    // Build image 

                    ImageBuilder image = new ImageBuilder();
                    Image productImage = image.getFromCache(product.image);
                    pictureBox.Image=productImage;

                    // Create a new instance of Label
                    Label productNameLabel = new Label();

                    // Set properties of the Label
                    productNameLabel.Text = product.productName;
                    productNameLabel.Dock = DockStyle.Bottom;
                    productNameLabel.TextAlign = ContentAlignment.MiddleCenter;

                    // Set the background color and text color
                    productNameLabel.BackColor = Color.Black;
                    productNameLabel.ForeColor = Color.White;
                    productNameLabel.Height = productNameLabelHeight;
                   // productNameLabel.AutoSize = false;
                    //productNameLabel.Padding = new Padding(0,10,0,10);
                    // Set the font to bold
                    productNameLabel.Font = new Font(productNameLabel.Font.FontFamily, productNameFontSize, FontStyle.Regular);

                    //label.Font = new Font(label.Font, FontStyle.Bold);

                    // Product Price label
                    /*
                    Label productPriceLabel = new Label();
                    productPriceLabel.Text = product.unitPrice.ToString() + " " + MainCykel.Currency;
                    productPriceLabel.BackColor = Color.Red;
                    productPriceLabel.ForeColor = Color.White;
                    productPriceLabel.Font = new Font(productNameLabel.Font.FontFamily, 10, FontStyle.Bold);
                    productPriceLabel.TextAlign = ContentAlignment.MiddleCenter;
                    productPriceLabel.Width = 55;
                    */
                    Label productPriceLabel = new Label();
                    productPriceLabel.Text = product.unitPrice.ToString() + " " + MainCykel.Currency;
                    productPriceLabel.Font = new Font(productNameLabel.Font.FontFamily, 12, FontStyle.Bold);
                    productPriceLabel.TextAlign = ContentAlignment.MiddleCenter;
                    productPriceLabel.Padding = new Padding(12, 22, 12, 22);
                    productPriceLabel.AutoSize = true;

                    productPriceLabel.Height = 50;
                    productPriceLabel.BackgroundImageLayout = ImageLayout.Stretch;
                    productPriceLabel.ForeColor = Color.White;

                    ResourceManager rm = new ResourceManager(typeof(Properties.Resources));
                    Image priceImage = (Image)rm.GetObject("price-budget");
                    productPriceLabel.BackgroundImage = priceImage;

                    // Add the Label to the form's Controls collection
                    pane.Controls.Add(productPriceLabel);
                    pane.Controls.Add(productNameLabel);

                    // Add the PictureBox to the form's Controls collection
                    pane.Controls.Add(pictureBox);

                    MainCykel.productPanel.Controls.Add(pane);
                 
                   
                }
                new TouchScroll(MainCykel.productPanel, 300, 20);
            }
        }
        private void Product_Click(object sender, EventArgs e, int id)
        {
            // Handle the click event here
            PictureBox clickedPanel = (PictureBox)sender;
            //Console.WriteLine($"product id : {id}");
            //BuildProducts products = new BuildProducts(id);
            ProductDetails productDetails = new ProductDetails();
            if(!ProductDetails.is_active )
            {
                productDetails.Owner = MainCykel.ActiveForm;
                productDetails.productId = id;

                // Show the other form
                productDetails.Show();
                ProductDetails.is_active = true;
            }
            
        }
    }
    class ImageBuilder
    {

        public Image getFromCache(string url)
        {
            
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    string imageName = ExtractFileNameFromUrl(url);
                    string cachePath = "cache/" + imageName; // Path to the cache file

                    if (File.Exists(cachePath))
                    {
                        // Load image from cache
                        Image image = Image.FromFile(cachePath);
                        return image;
                    }
                    else
                    {
                        // Download image and save it to cache
                        byte[] imageData = webClient.DownloadData(url);
                        using (var stream = new MemoryStream(imageData))
                        {
                            Image image = Image.FromStream(stream);
                            
                            image.Save(cachePath); // Save image to cache
                            return image;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during downloading or displaying the image
                    MessageBox.Show("Error: " + ex.Message);
                    return null;   
                }
            }

        }
        public string ExtractFileNameFromUrl(string url)
        {
            try
            {
                Uri uri = new Uri(url);
                string fileName = Path.GetFileName(uri.LocalPath);
                return fileName;
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during URL parsing
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }

}
