namespace DMM.Rrport
{
    partial class ReportPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportPage));
            this.panl1 = new System.Windows.Forms.Panel();
            this.btn_customerreport = new DevExpress.XtraEditors.SimpleButton();
            this.btn_supplierreport = new DevExpress.XtraEditors.SimpleButton();
            this.panl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panl1
            // 
            this.panl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panl1.Controls.Add(this.btn_customerreport);
            this.panl1.Controls.Add(this.btn_supplierreport);
            this.panl1.Location = new System.Drawing.Point(110, 161);
            this.panl1.Name = "panl1";
            this.panl1.Size = new System.Drawing.Size(513, 176);
            this.panl1.TabIndex = 7;
            // 
            // btn_customerreport
            // 
            this.btn_customerreport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_customerreport.Appearance.BackColor = System.Drawing.Color.White;
            this.btn_customerreport.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_customerreport.Appearance.Options.UseBackColor = true;
            this.btn_customerreport.Appearance.Options.UseFont = true;
            this.btn_customerreport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_customerreport.ImageOptions.Image")));
            this.btn_customerreport.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_customerreport.Location = new System.Drawing.Point(38, 55);
            this.btn_customerreport.Name = "btn_customerreport";
            this.btn_customerreport.Size = new System.Drawing.Size(158, 68);
            this.btn_customerreport.TabIndex = 6;
            this.btn_customerreport.Text = "تقرير ديون العملاء";
            this.btn_customerreport.Click += new System.EventHandler(this.btn_customerreport_Click);
            // 
            // btn_supplierreport
            // 
            this.btn_supplierreport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_supplierreport.Appearance.BackColor = System.Drawing.Color.White;
            this.btn_supplierreport.Appearance.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_supplierreport.Appearance.Options.UseBackColor = true;
            this.btn_supplierreport.Appearance.Options.UseFont = true;
            this.btn_supplierreport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_supplierreport.ImageOptions.Image")));
            this.btn_supplierreport.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_supplierreport.Location = new System.Drawing.Point(342, 55);
            this.btn_supplierreport.Name = "btn_supplierreport";
            this.btn_supplierreport.Size = new System.Drawing.Size(158, 68);
            this.btn_supplierreport.TabIndex = 6;
            this.btn_supplierreport.Text = "تقرير ديون الموردين";
            this.btn_supplierreport.Click += new System.EventHandler(this.btn_supplierreport_Click);
            // 
            // ReportPage
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panl1);
            this.Name = "ReportPage";
            this.Size = new System.Drawing.Size(732, 499);
            this.panl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_supplierreport;
        private System.Windows.Forms.Panel panl1;
        private DevExpress.XtraEditors.SimpleButton btn_customerreport;
    }
}
