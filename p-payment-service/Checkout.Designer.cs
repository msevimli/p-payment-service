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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.paymentFlowPanel = new System.Windows.Forms.Panel();
            this.paymentOptionPanel = new System.Windows.Forms.Panel();
            this.takeAway = new System.Windows.Forms.RadioButton();
            this.eatHere = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.bankCard = new System.Windows.Forms.RadioButton();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.payButton = new System.Windows.Forms.Button();
            this.backToCart = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.paymentOptionPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.bottomPanel.SuspendLayout();
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
            this.paymentFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentFlowPanel.Location = new System.Drawing.Point(335, 59);
            this.paymentFlowPanel.Name = "paymentFlowPanel";
            this.paymentFlowPanel.Size = new System.Drawing.Size(465, 332);
            this.paymentFlowPanel.TabIndex = 3;
            // 
            // paymentOptionPanel
            // 
            this.paymentOptionPanel.BackColor = System.Drawing.Color.White;
            this.paymentOptionPanel.Controls.Add(this.takeAway);
            this.paymentOptionPanel.Controls.Add(this.eatHere);
            this.paymentOptionPanel.Controls.Add(this.groupBox1);
            this.paymentOptionPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.paymentOptionPanel.Location = new System.Drawing.Point(0, 59);
            this.paymentOptionPanel.Name = "paymentOptionPanel";
            this.paymentOptionPanel.Padding = new System.Windows.Forms.Padding(20);
            this.paymentOptionPanel.Size = new System.Drawing.Size(335, 332);
            this.paymentOptionPanel.TabIndex = 2;
            // 
            // takeAway
            // 
            this.takeAway.AutoSize = true;
            this.takeAway.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takeAway.Image = global::p_payment_service.Properties.Resources.take_away;
            this.takeAway.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.takeAway.Location = new System.Drawing.Point(217, 212);
            this.takeAway.Name = "takeAway";
            this.takeAway.Size = new System.Drawing.Size(95, 71);
            this.takeAway.TabIndex = 2;
            this.takeAway.Text = "Take Away";
            this.takeAway.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.takeAway.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.takeAway.UseVisualStyleBackColor = true;
            this.takeAway.CheckedChanged += new System.EventHandler(this.takeAway_CheckedChanged);
            // 
            // eatHere
            // 
            this.eatHere.AutoSize = true;
            this.eatHere.Checked = true;
            this.eatHere.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eatHere.Image = global::p_payment_service.Properties.Resources.eat_here;
            this.eatHere.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.eatHere.Location = new System.Drawing.Point(12, 212);
            this.eatHere.Name = "eatHere";
            this.eatHere.Size = new System.Drawing.Size(87, 71);
            this.eatHere.TabIndex = 1;
            this.eatHere.TabStop = true;
            this.eatHere.Text = "Eat Here";
            this.eatHere.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.eatHere.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.eatHere.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.bankCard);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Options";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(9, 115);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(75, 24);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Others";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // bankCard
            // 
            this.bankCard.AutoSize = true;
            this.bankCard.Checked = true;
            this.bankCard.Image = global::p_payment_service.Properties.Resources.visa_master_align;
            this.bankCard.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bankCard.Location = new System.Drawing.Point(9, 25);
            this.bankCard.Name = "bankCard";
            this.bankCard.Size = new System.Drawing.Size(186, 71);
            this.bankCard.TabIndex = 0;
            this.bankCard.TabStop = true;
            this.bankCard.Text = "Bank/Credit Card";
            this.bankCard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bankCard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            this.payButton.Location = new System.Drawing.Point(340, 5);
            this.payButton.Name = "payButton";
            this.payButton.Size = new System.Drawing.Size(455, 49);
            this.payButton.TabIndex = 1;
            this.payButton.Text = "Pay";
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
            this.backToCart.Location = new System.Drawing.Point(5, 5);
            this.backToCart.Name = "backToCart";
            this.backToCart.Size = new System.Drawing.Size(329, 49);
            this.backToCart.TabIndex = 0;
            this.backToCart.Text = "Back to Cart";
            this.backToCart.UseVisualStyleBackColor = false;
            this.backToCart.Click += new System.EventHandler(this.backToCart_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(800, 59);
            this.topPanel.TabIndex = 0;
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
            this.paymentOptionPanel.ResumeLayout(false);
            this.paymentOptionPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel paymentFlowPanel;
        private System.Windows.Forms.Panel paymentOptionPanel;
        private System.Windows.Forms.RadioButton takeAway;
        private System.Windows.Forms.RadioButton eatHere;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton bankCard;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button payButton;
        private System.Windows.Forms.Button backToCart;
        private System.Windows.Forms.Panel topPanel;
    }
}