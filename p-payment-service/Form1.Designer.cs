namespace p_payment_service
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.topPanelCover = new System.Windows.Forms.Panel();
            this.bottomPanelCover = new System.Windows.Forms.Panel();
            this.categoryCoverPanel = new System.Windows.Forms.Panel();
            this.itemPanelCover = new System.Windows.Forms.Panel();
            this.categoryFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.itemFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.categoryCoverPanel.SuspendLayout();
            this.itemPanelCover.SuspendLayout();
            this.categoryFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.itemFlowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanelCover
            // 
            this.topPanelCover.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanelCover.Location = new System.Drawing.Point(0, 0);
            this.topPanelCover.Name = "topPanelCover";
            this.topPanelCover.Size = new System.Drawing.Size(800, 61);
            this.topPanelCover.TabIndex = 0;
            // 
            // bottomPanelCover
            // 
            this.bottomPanelCover.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanelCover.Location = new System.Drawing.Point(0, 390);
            this.bottomPanelCover.Name = "bottomPanelCover";
            this.bottomPanelCover.Size = new System.Drawing.Size(800, 60);
            this.bottomPanelCover.TabIndex = 1;
            // 
            // categoryCoverPanel
            // 
            this.categoryCoverPanel.Controls.Add(this.categoryFlowPanel);
            this.categoryCoverPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.categoryCoverPanel.Location = new System.Drawing.Point(0, 61);
            this.categoryCoverPanel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.categoryCoverPanel.Name = "categoryCoverPanel";
            this.categoryCoverPanel.Size = new System.Drawing.Size(127, 329);
            this.categoryCoverPanel.TabIndex = 2;
            // 
            // itemPanelCover
            // 
            this.itemPanelCover.BackColor = System.Drawing.SystemColors.Window;
            this.itemPanelCover.Controls.Add(this.itemFlowPanel);
            this.itemPanelCover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanelCover.Location = new System.Drawing.Point(127, 61);
            this.itemPanelCover.Name = "itemPanelCover";
            this.itemPanelCover.Size = new System.Drawing.Size(673, 329);
            this.itemPanelCover.TabIndex = 3;
            // 
            // categoryFlowPanel
            // 
            this.categoryFlowPanel.AccessibleName = "";
            this.categoryFlowPanel.Controls.Add(this.pictureBox1);
            this.categoryFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.categoryFlowPanel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.categoryFlowPanel.Name = "categoryFlowPanel";
            this.categoryFlowPanel.Size = new System.Drawing.Size(127, 329);
            this.categoryFlowPanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.categoryFlowPanel.SetFlowBreak(this.pictureBox1, true);
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
   
            // 
            // itemFlowPanel
            // 
            this.itemFlowPanel.AutoScroll = true;
            this.itemFlowPanel.Controls.Add(this.button1);
            this.itemFlowPanel.Controls.Add(this.button2);
            this.itemFlowPanel.Controls.Add(this.button3);
            this.itemFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.itemFlowPanel.Name = "itemFlowPanel";
            this.itemFlowPanel.Size = new System.Drawing.Size(673, 329);
            this.itemFlowPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 250);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(259, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 250);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 259);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(250, 250);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.itemPanelCover);
            this.Controls.Add(this.categoryCoverPanel);
            this.Controls.Add(this.bottomPanelCover);
            this.Controls.Add(this.topPanelCover);
            this.Name = "Form1";
            this.Text = "Form1";
            this.categoryCoverPanel.ResumeLayout(false);
            this.itemPanelCover.ResumeLayout(false);
            this.categoryFlowPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.itemFlowPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanelCover;
        private System.Windows.Forms.Panel bottomPanelCover;
        private System.Windows.Forms.Panel categoryCoverPanel;
        private System.Windows.Forms.Panel itemPanelCover;
        private System.Windows.Forms.FlowLayoutPanel categoryFlowPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel itemFlowPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

