namespace testando
{
    partial class FrmRelatorios
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).BeginInit();
            this.SuspendLayout();
            // 
            // grafico
            // 
            chartArea2.Name = "ChartArea1";
            this.grafico.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.grafico.Legends.Add(legend2);
            this.grafico.Location = new System.Drawing.Point(153, 67);
            this.grafico.Name = "grafico";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.XValueMember = "desc_prod";
            series2.YValueMembers = "qtde";
            this.grafico.Series.Add(series2);
            this.grafico.Size = new System.Drawing.Size(300, 300);
            this.grafico.TabIndex = 0;
            this.grafico.Text = "chart1";
            // 
            // FrmRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grafico);
            this.Name = "FrmRelatorios";
            this.Text = "FrmRelatorios";
            this.Load += new System.EventHandler(this.FrmRelatorios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart grafico;
    }
}