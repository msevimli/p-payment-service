namespace p_payment_service
{
    partial class Checkout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Checkout));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.paymentFlowPanel = new System.Windows.Forms.Panel();
            this.orderNotifyLabel = new System.Windows.Forms.Label();
            this.statusImage = new System.Windows.Forms.PictureBox();
            this.paymentOptionPanel = new System.Windows.Forms.Panel();
            this.orderService = new System.Windows.Forms.GroupBox();
            this.eatHere = new System.Windows.Forms.RadioButton();
            this.takeAway = new System.Windows.Forms.RadioButton();
            this.paymentOptions = new System.Windows.Forms.GroupBox();
            this.cashPay = new System.Windows.Forms.RadioButton();
            this.bankCard = new System.Windows.Forms.RadioButton();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.payButton = new System.Windows.Forms.Button();
            this.backToCart = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.paymentFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusImage)).BeginInit();
            this.paymentOptionPanel.SuspendLayout();
            this.orderService.SuspendLayout();
            this.paymentOptions.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.paymentFlowPanel);
            this.mainPanel.Controls.Add(this.paymentOptionPanel);
            this.mainPanel.Controls.Add(this.bottomPanel);
            this.mainPanel.Controls.Add(this.topPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 0;
            // 
            // paymentFlowPanel
            // 
            this.paymentFlowPanel.BackColor = System.Drawing.Color.White;
            this.paymentFlowPanel.Controls.Add(this.orderNotifyLabel);
            this.paymentFlowPanel.Controls.Add(this.statusImage);
            this.paymentFlowPanel.Location = new System.Drawing.Point(341, 59);
            this.paymentFlowPanel.Name = "paymentFlowPanel";
            this.paymentFlowPanel.Size = new System.Drawing.Size(459, 332);
            this.paymentFlowPanel.TabIndex = 3;
            // 
            // orderNotifyLabel
            // 
            this.orderNotifyLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.orderNotifyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderNotifyLabel.Location = new System.Drawing.Point(0, 264);
            this.orderNotifyLabel.Name = "orderNotifyLabel";
            this.orderNotifyLabel.Size = new System.Drawing.Size(459, 68);
            this.orderNotifyLabel.TabIndex = 1;
            this.orderNotifyLabel.Text = "label1";
            this.orderNotifyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusImage
            // 
            this.statusImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusImage.Image = global::p_payment_service.Properties.Resources.white_background;
            this.statusImage.Location = new System.Drawing.Point(0, 0);
            this.statusImage.Name = "statusImage";
            this.statusImage.Size = new System.Drawing.Size(459, 332);
            this.statusImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.statusImage.TabIndex = 0;
            this.statusImage.TabStop = false;
            // 
            // paymentOptionPanel
            // 
            this.paymentOptionPanel.BackColor = System.Drawing.Color.White;
            this.paymentOptionPanel.Controls.Add(this.orderService);
            this.paymentOptionPanel.Controls.Add(this.paymentOptions);
            this.paymentOptionPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.paymentOptionPanel.Location = new System.Drawing.Point(0, 59);
            this.paymentOptionPanel.Name = "paymentOptionPanel";
            this.paymentOptionPanel.Padding = new System.Windows.Forms.Padding(20);
            this.paymentOptionPanel.Size = new System.Drawing.Size(335, 332);
            this.paymentOptionPanel.TabIndex = 2;
            // 
            // orderService
            // 
            this.orderService.Controls.Add(this.eatHere);
            this.orderService.Controls.Add(this.takeAway);
            this.orderService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderService.Location = new System.Drawing.Point(19, 174);
            this.orderService.Name = "orderService";
            this.orderService.Size = new System.Drawing.Size(300, 135);
            this.orderService.TabIndex = 3;
            this.orderService.TabStop = false;
            this.orderService.Text = "Service";
            // 
            // eatHere
            // 
            this.eatHere.AutoSize = true;
            this.eatHere.Checked = true;
            this.eatHere.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eatHere.Image = global::p_payment_service.Properties.Resources.eat_here;
            this.eatHere.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.eatHere.Location = new System.Drawing.Point(26, 32);
            this.eatHere.Name = "eatHere";
            this.eatHere.Size = new System.Drawing.Size(87, 71);
            this.eatHere.TabIndex = 1;
            this.eatHere.TabStop = true;
            this.eatHere.Text = "Eat Here";
            this.eatHere.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.eatHere.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.eatHere.UseVisualStyleBackColor = true;
            this.eatHere.CheckedChanged += new System.EventHandler(this.eatHereChecked_Changed);
            // 
            // takeAway
            // 
            this.takeAway.AutoSize = true;
            this.takeAway.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takeAway.Image = global::p_payment_service.Properties.Resources.take_away;
            this.takeAway.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.takeAway.Location = new System.Drawing.Point(165, 32);
            this.takeAway.Name = "takeAway";
            this.takeAway.Size = new System.Drawing.Size(95, 71);
            this.takeAway.TabIndex = 2;
            this.takeAway.Text = "Take Away";
            this.takeAway.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.takeAway.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.takeAway.UseVisualStyleBackColor = true;
            this.takeAway.CheckedChanged += new System.EventHandler(this.takeAway_CheckedChanged);
            // 
            // paymentOptions
            // 
            this.paymentOptions.Controls.Add(this.cashPay);
            this.paymentOptions.Controls.Add(this.bankCard);
            this.paymentOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentOptions.Location = new System.Drawing.Point(19, 14);
            this.paymentOptions.Name = "paymentOptions";
            this.paymentOptions.Size = new System.Drawing.Size(300, 142);
            this.paymentOptions.TabIndex = 0;
            this.paymentOptions.TabStop = false;
            this.paymentOptions.Text = "Payment Options";
            // 
            // cashPay
            // 
            this.cashPay.AutoSize = true;
            this.cashPay.Image = ((System.Drawing.Image)(resources.GetObject("cashPay.Image")));
            this.cashPay.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cashPay.Location = new System.Drawing.Point(7, 117);
            this.cashPay.Name = "cashPay";
            this.cashPay.Size = new System.Drawing.Size(122, 52);
            this.cashPay.TabIndex = 1;
            this.cashPay.TabStop = true;
            this.cashPay.Text = "Cash";
            this.cashPay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cashPay.UseVisualStyleBackColor = true;
            // 
            // bankCard
            // 
            this.bankCard.AutoSize = true;
            this.bankCard.Checked = true;
            this.bankCard.Image = global::p_payment_service.Properties.Resources.visa_master_align;
            this.bankCard.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bankCard.Location = new System.Drawing.Point(26, 40);
            this.bankCard.Name = "bankCard";
            this.bankCard.Size = new System.Drawing.Size(186, 71);
            this.bankCard.TabIndex = 0;
            this.bankCard.TabStop = true;
            this.bankCard.Text = "Bank/Credit Card";
            this.bankCard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bankCard.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.bankCard.UseVisualStyleBackColor = true;
            this.bankCard.CheckedChanged += new System.EventHandler(this.bankCard_CheckedChanged);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bottomPanel.Controls.Add(this.payButton);
            this.bottomPanel.Controls.Add(this.backToCart);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 391);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(5);
            this.bottomPanel.Size = new System.Drawing.Size(800, 59);
            this.bottomPanel.TabIndex = 1;
            // 
            // payButton
            // 
            this.payButton.BackColor = System.Drawing.Color.LimeGreen;
            this.payButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.payButton.FlatAppearance.BorderSize = 0;
            this.payButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.payButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payButton.ForeColor = System.Drawing.Color.White;
            this.payButton.Image = global::p_payment_service.Properties.Resources.card_icon;
            this.payButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.payButton.Location = new System.Drawing.Point(340, 5);
            this.payButton.Name = "payButton";
            this.payButton.Size = new System.Drawing.Size(455, 49);
            this.payButton.TabIndex = 1;
            this.payButton.Text = "Pay";
            this.payButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.payButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.payButton.UseVisualStyleBackColor = false;
            this.payButton.Click += new System.EventHandler(this.payButton_Click);
            // 
            // backToCart
            // 
            this.backToCart.BackColor = System.Drawing.Color.DodgerBlue;
            this.backToCart.Dock = System.Windows.Forms.DockStyle.Left;
            this.backToCart.FlatAppearance.BorderSize = 0;
            this.backToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backToCart.ForeColor = System.Drawing.Color.White;
            this.backToCart.Image = global::p_payment_service.Properties.Resources.arrow_left_square;
            this.backToCart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.backToCart.Location = new System.Drawing.Point(5, 5);
            this.backToCart.Name = "backToCart";
            this.backToCart.Size = new System.Drawing.Size(329, 49);
            this.backToCart.TabIndex = 0;
            this.backToCart.Text = "Back to Cart";
            this.backToCart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.backToCart.UseVisualStyleBackColor = false;
            this.backToCart.Click += new System.EventHandler(this.backToCart_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.topPanel.Controls.Add(this.button2);
            this.topPanel.Controls.Add(this.button1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(800, 59);
            this.topPanel.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(687, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(521, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Checkout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Checkout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkout";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Checkout_FormClosed);
            this.Load += new System.EventHandler(this.Checkout_Load);
            this.mainPanel.ResumeLayout(false);
            this.paymentFlowPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusImage)).EndInit();
            this.paymentOptionPanel.ResumeLayout(false);
            this.orderService.ResumeLayout(false);
            this.orderService.PerformLayout();
            this.paymentOptions.ResumeLayout(false);
            this.paymentOptions.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel paymentFlowPanel;
        private System.Windows.Forms.Panel paymentOptionPanel;
        private System.Windows.Forms.RadioButton takeAway;
        private System.Windows.Forms.RadioButton eatHere;
        private System.Windows.Forms.GroupBox paymentOptions;
        private System.Windows.Forms.RadioButton bankCard;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button payButton;
        private System.Windows.Forms.Button backToCart;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox statusImage;
        private System.Windows.Forms.GroupBox orderService;
        private System.Windows.Forms.RadioButton cashPay;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label orderNotifyLabel;
    }
}