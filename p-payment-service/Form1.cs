using System;

//using Newtonsoft.Json;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace p_payment_service
{
    public partial class Form1 : Form
    {
        public static  ApiObjects objects;
        public static FlowLayoutPanel categoryPanel;
        public static FlowLayoutPanel productPanel;
        public static PictureBox storeLogoPicture;
        public static Label storeBaseName;
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            try
            {
                categoryPanel = categoryFlowPanel;
                productPanel = itemFlowPanel;
                storeLogoPicture = formStoreLogo;
                storeBaseName = storeName;
                apiRequest req = new apiRequest();
                //req.apiUrl = "http://terminal.plife.loc/";
                req.apiUrl = "https://terminal.plife.se/";
                //req.apiUrl = "http://apitest.plife.loc/";
                req.publicKey = "wwe";
                req.privateKey = "zz";
                var apiString = req.getAll();
                objects = JsonSerializer.Deserialize<ApiObjects>(apiString);
                Console.WriteLine($"Person's settings storename: {objects.settings.storeName}");
                StoreBuilder storeBuilder = new StoreBuilder();
                CategoryBuilder categoryBuilder = new CategoryBuilder();
               
            } catch
            {
                Console.WriteLine("error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button temp = new Button();
            itemFlowPanel.Controls.Add(temp);
            temp.Width = 250;
            temp.Height = 250;
            temp.Text = "test button";
   
            temp.BackColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Panel  pane = new Panel();
            pane.Width = 118;
            pane.Height=88;
            pane.BackColor = Color.Black;
            categoryFlowPanel.Controls.Add(pane);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            apiRequest req = new apiRequest();
            req.apiUrl = "http://terminal.plife.loc/";
            //req.apiUrl = "http://apitest.plife.loc/";
            req.publicKey = "wwe";
            req.privateKey = "zz";
            var  apiString = req.getAll();
            
            var apiObject = JsonSerializer.Deserialize<ApiObjects>(apiString);

            //string json = apiString;
            //ApiObjects apiObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiObjects>(json);

            Console.WriteLine($"Person's settings storename: {apiObject.settings.storeName}");
            foreach (var item in apiObject.products)
            {
                Console.WriteLine($"Product name: {item.productName}");
               // Console.WriteLine($"Category IDs: {string.Join(", ", item.categoryId)}");
                Console.WriteLine($"Category IDs: { item.categoryId.First()}");
            
                 
                    if (item.additional != null)
                    {
                         //Console.WriteLine($"Additionall: {item.additional.First().option}");

                        foreach (AdditionalOption additionalOption in item.additional)
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
                     

                }


        }

        private void bottomPanelCover_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
