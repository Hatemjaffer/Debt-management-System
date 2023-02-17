namespace DMM.Pages
{
    partial class Page_Home
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txt_datetime = new System.Windows.Forms.Label();
            this.txt_companytitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_datetime
            // 
            this.txt_datetime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_datetime.AutoSize = true;
            this.txt_datetime.Font = new System.Drawing.Font("Cairo", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_datetime.ForeColor = System.Drawing.Color.Gray;
            this.txt_datetime.Location = new System.Drawing.Point(3, 424);
            this.txt_datetime.Name = "txt_datetime";
            this.txt_datetime.Size = new System.Drawing.Size(473, 88);
            this.txt_datetime.TabIndex = 0;
            this.txt_datetime.Text = "تاريخ ووقت اليوم هو ";
            // 
            // txt_companytitle
            // 
            this.txt_companytitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_companytitle.AutoSize = true;
            this.txt_companytitle.Font = new System.Drawing.Font("LBC", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_companytitle.ForeColor = System.Drawing.Color.Gray;
            this.txt_companytitle.Location = new System.Drawing.Point(259, 254);
            this.txt_companytitle.Name = "txt_companytitle";
            this.txt_companytitle.Size = new System.Drawing.Size(220, 51);
            this.txt_companytitle.TabIndex = 0;
            this.txt_companytitle.Text = "اسم الشركة";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::DMM.Properties.Resources.c_sharp_logo_2_480px;
            this.pictureBox1.Location = new System.Drawing.Point(261, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(218, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Page_Home
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_companytitle);
            this.Controls.Add(this.txt_datetime);
            this.Name = "Page_Home";
            this.Size = new System.Drawing.Size(768, 515);
            this.Load += new System.EventHandler(this.Page_Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_datetime;
        private System.Windows.Forms.Label txt_companytitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}
