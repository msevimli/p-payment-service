namespace p_payment_service
{
    partial class Cart
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
            this.cartDetailsCover = new System.Windows.Forms.Panel();
            this.cartDetailsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.backShop = new System.Windows.Forms.Button();
            this.toPayment = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.totalLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.cartDetailsCover.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.cartDetailsCover);
            this.mainPanel.Controls.Add(this.bottomPanel);
            this.mainPanel.Controls.Add(this.topPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 0;
            // 
            // cartDetailsCover
            // 
            this.cartDetailsCover.Controls.Add(this.cartDetailsPanel);
            this.cartDetailsCover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartDetailsCover.Location = new System.Drawing.Point(0, 55);
            this.cartDetailsCover.Name = "cartDetailsCover";
            this.cartDetailsCover.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.cartDetailsCover.Size = new System.Drawing.Size(800, 336);
            this.cartDetailsCover.TabIndex = 3;
            // 
            // cartDetailsPanel
            // 
            this.cartDetailsPanel.AutoScroll = true;
            this.cartDetailsPanel.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.cartDetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartDetailsPanel.Location = new System.Drawing.Point(0, 0);
            this.cartDetailsPanel.Name = "cartDetailsPanel";
            this.cartDetailsPanel.Padding = new System.Windows.Forms.Padding(15, 15, 0, 150);
            this.cartDetailsPanel.Size = new System.Drawing.Size(800, 326);
            this.cartDetailsPanel.TabIndex = 2;
            this.cartDetailsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.cartDetailsPanel_Paint);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bottomPanel.Controls.Add(this.backShop);
            this.bottomPanel.Controls.Add(this.toPayment);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 391);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(5);
            this.bottomPanel.Size = new System.Drawing.Size(800, 59);
            this.bottomPanel.TabIndex = 1;
            // 
            // backShop
            // 
            this.backShop.BackColor = System.Drawing.Color.DodgerBlue;
            this.backShop.Dock = System.Windows.Forms.DockStyle.Left;
            this.backShop.FlatAppearance.BorderSize = 0;
            this.backShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backShop.ForeColor = System.Drawing.Color.White;
            this.backShop.Location = new System.Drawing.Point(5, 5);
            this.backShop.Name = "backShop";
            this.backShop.Size = new System.Drawing.Size(295, 49);
            this.backShop.TabIndex = 1;
            this.backShop.Text = "Back to Shop";
            this.backShop.UseVisualStyleBackColor = false;
            this.backShop.Click += new System.EventHandler(this.backShop_Click);
            // 
            // toPayment
            // 
            this.toPayment.BackColor = System.Drawing.Color.LimeGreen;
            this.toPayment.Dock = System.Windows.Forms.DockStyle.Right;
            this.toPayment.FlatAppearance.BorderSize = 0;
            this.toPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toPayment.ForeColor = System.Drawing.Color.Transparent;
            this.toPayment.Location = new System.Drawing.Point(306, 5);
            this.toPayment.Name = "toPayment";
            this.toPayment.Size = new System.Drawing.Size(489, 49);
            this.toPayment.TabIndex = 0;
            this.toPayment.Text = "To Payment";
            this.toPayment.UseVisualStyleBackColor = false;
            this.toPayment.Click += new System.EventHandler(this.toPayment_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Indigo;
            this.topPanel.Controls.Add(this.totalLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(800, 55);
            this.topPanel.TabIndex = 0;
            // 
            // totalLabel
            // 
            this.totalLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.totalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.Color.White;
            this.totalLabel.Location = new System.Drawing.Point(0, 0);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(800, 55);
            this.totalLabel.TabIndex = 0;
            this.totalLabel.Text = "Total : ";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.totalLabel.Click += new System.EventHandler(this.totalLabel_Click);
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cart";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cart";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Cart_FormClosed);
            this.Load += new System.EventHandler(this.Cart_Load);
            this.mainPanel.ResumeLayout(false);
            this.cartDetailsCover.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.FlowLayoutPanel cartDetailsPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button backShop;
        private System.Windows.Forms.Button toPayment;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Panel cartDetailsCover;
    }
}