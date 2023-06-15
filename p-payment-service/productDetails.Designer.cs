namespace p_payment_service
{
    partial class ProductDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.additionalCover = new System.Windows.Forms.Panel();
            this.pricePanelCover = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.productPicture = new System.Windows.Forms.PictureBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addToCartButton = new System.Windows.Forms.Button();
            this.additionalPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mainPanel.SuspendLayout();
            this.additionalCover.SuspendLayout();
            this.pricePanelCover.SuspendLayout();
            this.picturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productPicture)).BeginInit();
            this.topPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.additionalCover);
            this.mainPanel.Controls.Add(this.picturePanel);
            this.mainPanel.Controls.Add(this.topPanel);
            this.mainPanel.Controls.Add(this.bottomPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(791, 502);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // additionalCover
            // 
            this.additionalCover.Controls.Add(this.additionalPanel);
            this.additionalCover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.additionalCover.Location = new System.Drawing.Point(376, 57);
            this.additionalCover.Name = "additionalCover";
            this.additionalCover.Size = new System.Drawing.Size(415, 386);
            this.additionalCover.TabIndex = 3;
            // 
            // pricePanelCover
            // 
            this.pricePanelCover.BackColor = System.Drawing.Color.White;
            this.pricePanelCover.Controls.Add(this.button4);
            this.pricePanelCover.Controls.Add(this.quantityLabel);
            this.pricePanelCover.Controls.Add(this.button3);
            this.pricePanelCover.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pricePanelCover.ForeColor = System.Drawing.Color.Black;
            this.pricePanelCover.Location = new System.Drawing.Point(0, 282);
            this.pricePanelCover.Name = "pricePanelCover";
            this.pricePanelCover.Padding = new System.Windows.Forms.Padding(90, 5, 0, 30);
            this.pricePanelCover.Size = new System.Drawing.Size(376, 104);
            this.pricePanelCover.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Left;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(220, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 69);
            this.button4.TabIndex = 3;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // quantityLabel
            // 
            this.quantityLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.quantityLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.quantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityLabel.Location = new System.Drawing.Point(155, 5);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(65, 69);
            this.quantityLabel.TabIndex = 2;
            this.quantityLabel.Text = "1";
            this.quantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.quantityLabel.UseMnemonic = false;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(90, 5);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.button3.Size = new System.Drawing.Size(65, 69);
            this.button3.TabIndex = 1;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // picturePanel
            // 
            this.picturePanel.BackColor = System.Drawing.Color.White;
            this.picturePanel.Controls.Add(this.pricePanelCover);
            this.picturePanel.Controls.Add(this.productPicture);
            this.picturePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.picturePanel.Location = new System.Drawing.Point(0, 57);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(376, 386);
            this.picturePanel.TabIndex = 2;
            this.picturePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.picturePanel_Paint);
            // 
            // productPicture
            // 
            this.productPicture.Location = new System.Drawing.Point(6, 6);
            this.productPicture.Name = "productPicture";
            this.productPicture.Size = new System.Drawing.Size(364, 270);
            this.productPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productPicture.TabIndex = 0;
            this.productPicture.TabStop = false;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.topPanel.Controls.Add(this.productNameLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(791, 57);
            this.topPanel.TabIndex = 1;
            // 
            // productNameLabel
            // 
            this.productNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.productNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productNameLabel.ForeColor = System.Drawing.Color.White;
            this.productNameLabel.Location = new System.Drawing.Point(0, 0);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(791, 57);
            this.productNameLabel.TabIndex = 0;
            this.productNameLabel.Text = "label1";
            this.productNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Controls.Add(this.addToCartButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 443);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(5);
            this.bottomPanel.Size = new System.Drawing.Size(791, 59);
            this.bottomPanel.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.OrangeRed;
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelButton.Location = new System.Drawing.Point(5, 5);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(273, 47);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addToCartButton
            // 
            this.addToCartButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.addToCartButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.addToCartButton.FlatAppearance.BorderSize = 0;
            this.addToCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addToCartButton.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToCartButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addToCartButton.Location = new System.Drawing.Point(288, 5);
            this.addToCartButton.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.addToCartButton.Name = "addToCartButton";
            this.addToCartButton.Size = new System.Drawing.Size(496, 47);
            this.addToCartButton.TabIndex = 0;
            this.addToCartButton.Text = "Add to cart";
            this.addToCartButton.UseVisualStyleBackColor = false;
            // 
            // additionalPanel
            // 
            this.additionalPanel.AutoScroll = true;
            this.additionalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.additionalPanel.Location = new System.Drawing.Point(0, 0);
            this.additionalPanel.Name = "additionalPanel";
            this.additionalPanel.Padding = new System.Windows.Forms.Padding(20, 10, 0, 20);
            this.additionalPanel.Size = new System.Drawing.Size(415, 386);
            this.additionalPanel.TabIndex = 0;
            // 
            // ProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 502);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "productDetails";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProductDetails_FormClosed);
            this.Load += new System.EventHandler(this.ProductDetails_Load);
            this.mainPanel.ResumeLayout(false);
            this.additionalCover.ResumeLayout(false);
            this.pricePanelCover.ResumeLayout(false);
            this.picturePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productPicture)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addToCartButton;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.PictureBox productPicture;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel additionalCover;
        private System.Windows.Forms.Panel pricePanelCover;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FlowLayoutPanel additionalPanel;
    }
}