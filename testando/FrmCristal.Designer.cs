namespace testando
{
    partial class FrmCristal
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
            this.enterpriseReport1 = new CrystalDecisions.Shared.EnterpriseReport();
            this.SuspendLayout();
            // 
            // enterpriseReport1
            // 
            this.enterpriseReport1.ApsServer = "";
            this.enterpriseReport1.AuthenticationType = "";
            this.enterpriseReport1.ObjectCUID = "";
            this.enterpriseReport1.ObjectID = "";
            this.enterpriseReport1.Password = "";
            this.enterpriseReport1.ReportSource = null;
            this.enterpriseReport1.Username = "";
            this.enterpriseReport1.WebConnector = "";
            this.enterpriseReport1.WebServiceUrl = "";
            // 
            // FrmCristal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "FrmCristal";
            this.Text = "FrmCristal";
            this.Load += new System.EventHandler(this.FrmCristal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Shared.EnterpriseReport enterpriseReport1;
    }
}