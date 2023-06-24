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
            this.additionalPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.priceLabel = new System.Windows.Forms.Label();
            this.quantityPanelCover = new System.Windows.Forms.Panel();
            this.quantityIncrease = new System.Windows.Forms.Button();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.quantityDecrease = new System.Windows.Forms.Button();
            this.productPicture = new System.Windows.Forms.PictureBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addToCartButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.additionalCover.SuspendLayout();
            this.picturePanel.SuspendLayout();
            this.quantityPanelCover.SuspendLayout();
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
            // additionalPanel
            // 
            this.additionalPanel.AutoScroll = true;
            this.additionalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.additionalPanel.Location = new System.Drawing.Point(0, 0);
            this.additionalPanel.Name = "additionalPanel";
            this.additionalPanel.Padding = new System.Windows.Forms.Padding(20, 10, 0, 20);
            this.additionalPanel.Size = new System.Drawing.Size(415, 386);
            this.additionalPanel.TabIndex = 0;
            this.additionalPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.additionalPanel_Paint);
            // 
            // picturePanel
            // 
            this.picturePanel.BackColor = System.Drawing.Color.White;
            this.picturePanel.Controls.Add(this.priceLabel);
            this.picturePanel.Controls.Add(this.quantityPanelCover);
            this.picturePanel.Controls.Add(this.productPicture);
            this.picturePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.picturePanel.Location = new System.Drawing.Point(0, 57);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(376, 386);
            this.picturePanel.TabIndex = 2;
            // 
            // priceLabel
            // 
            this.priceLabel.BackColor = System.Drawing.Color.Red;
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.ForeColor = System.Drawing.Color.White;
            this.priceLabel.Location = new System.Drawing.Point(11, 17);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(68, 30);
            this.priceLabel.TabIndex = 1;
            this.priceLabel.Text = "label1";
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // quantityPanelCover
            // 
            this.quantityPanelCover.BackColor = System.Drawing.Color.White;
            this.quantityPanelCover.Controls.Add(this.quantityIncrease);
            this.quantityPanelCover.Controls.Add(this.quantityLabel);
            this.quantityPanelCover.Controls.Add(this.quantityDecrease);
            this.quantityPanelCover.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.quantityPanelCover.ForeColor = System.Drawing.Color.Black;
            this.quantityPanelCover.Location = new System.Drawing.Point(0, 295);
            this.quantityPanelCover.Name = "quantityPanelCover";
            this.quantityPanelCover.Padding = new System.Windows.Forms.Padding(90, 5, 0, 30);
            this.quantityPanelCover.Size = new System.Drawing.Size(376, 91);
            this.quantityPanelCover.TabIndex = 0;
            // 
            // quantityIncrease
            // 
            this.quantityIncrease.Dock = System.Windows.Forms.DockStyle.Left;
            this.quantityIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityIncrease.Location = new System.Drawing.Point(220, 5);
            this.quantityIncrease.Name = "quantityIncrease";
            this.quantityIncrease.Size = new System.Drawing.Size(65, 56);
            this.quantityIncrease.TabIndex = 3;
            this.quantityIncrease.Text = "+";
            this.quantityIncrease.UseVisualStyleBackColor = true;
            this.quantityIncrease.Click += new System.EventHandler(this.quantityIncrease_Click);
            // 
            // quantityLabel
            // 
            this.quantityLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.quantityLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.quantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityLabel.Location = new System.Drawing.Point(155, 5);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(65, 56);
            this.quantityLabel.TabIndex = 2;
            this.quantityLabel.Text = "1";
            this.quantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.quantityLabel.UseMnemonic = false;
            // 
            // quantityDecrease
            // 
            this.quantityDecrease.Dock = System.Windows.Forms.DockStyle.Left;
            this.quantityDecrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityDecrease.Location = new System.Drawing.Point(90, 5);
            this.quantityDecrease.Name = "quantityDecrease";
            this.quantityDecrease.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.quantityDecrease.Size = new System.Drawing.Size(65, 56);
            this.quantityDecrease.TabIndex = 1;
            this.quantityDecrease.Text = "-";
            this.quantityDecrease.UseVisualStyleBackColor = true;
            this.quantityDecrease.Click += new System.EventHandler(this.quantityDecrease_Click);
            // 
            // productPicture
            // 
            this.productPicture.Location = new System.Drawing.Point(6, 13);
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
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelButton.Location = new System.Drawing.Point(511, 5);
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
            this.addToCartButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.addToCartButton.FlatAppearance.BorderSize = 0;
            this.addToCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addToCartButton.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToCartButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addToCartButton.Location = new System.Drawing.Point(5, 5);
            this.addToCartButton.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.addToCartButton.Name = "addToCartButton";
            this.addToCartButton.Size = new System.Drawing.Size(496, 47);
            this.addToCartButton.TabIndex = 0;
            this.addToCartButton.Text = "Add to cart";
            this.addToCartButton.UseVisualStyleBackColor = false;
            this.addToCartButton.Click += new System.EventHandler(this.addToCartButton_Click);
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
            this.picturePanel.ResumeLayout(false);
            this.quantityPanelCover.ResumeLayout(false);
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
        private System.Windows.Forms.Panel quantityPanelCover;
        private System.Windows.Forms.Button quantityIncrease;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Button quantityDecrease;
        private System.Windows.Forms.FlowLayoutPanel additionalPanel;
        private System.Windows.Forms.Label priceLabel;
    }
}