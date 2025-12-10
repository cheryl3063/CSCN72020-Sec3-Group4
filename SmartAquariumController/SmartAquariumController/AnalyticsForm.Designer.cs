namespace SmartAquariumController
{
    partial class AnalyticsForm
    {
        private System.ComponentModel.IContainer components = null;

        private ScottPlot.WinForms.FormsPlot formsPlotTemp;
        private ScottPlot.WinForms.FormsPlot formsPlotPH;
        private ScottPlot.WinForms.FormsPlot formsPlotOxy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.formsPlotTemp = new ScottPlot.WinForms.FormsPlot();
            this.formsPlotPH = new ScottPlot.WinForms.FormsPlot();
            this.formsPlotOxy = new ScottPlot.WinForms.FormsPlot();
            this.SuspendLayout();
            // 
            // formsPlotTemp
            // 
            this.formsPlotTemp.Location = new System.Drawing.Point(25, 20);
            this.formsPlotTemp.Name = "formsPlotTemp";
            this.formsPlotTemp.Size = new System.Drawing.Size(740, 120);
            this.formsPlotTemp.TabIndex = 0;
            // 
            // formsPlotPH
            // 
            this.formsPlotPH.Location = new System.Drawing.Point(25, 160);
            this.formsPlotPH.Name = "formsPlotPH";
            this.formsPlotPH.Size = new System.Drawing.Size(740, 120);
            this.formsPlotPH.TabIndex = 1;
            // 
            // formsPlotOxy
            // 
            this.formsPlotOxy.Location = new System.Drawing.Point(25, 300);
            this.formsPlotOxy.Name = "formsPlotOxy";
            this.formsPlotOxy.Size = new System.Drawing.Size(740, 120);
            this.formsPlotOxy.TabIndex = 2;
            // 
            // AnalyticsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.formsPlotOxy);
            this.Controls.Add(this.formsPlotPH);
            this.Controls.Add(this.formsPlotTemp);
            this.Name = "AnalyticsForm";
            this.Text = "Sensor History Analytics";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
