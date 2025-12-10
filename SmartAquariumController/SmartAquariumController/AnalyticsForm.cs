using System;
using System.Windows.Forms;

namespace SmartAquariumController
{
    public partial class AnalyticsForm : Form
    {
        public AnalyticsForm()
        {
            InitializeComponent();
            LoadDummyData();
        }

        private void LoadDummyData()
        {
            // Temperature dummy data
            double[] tempHistory = { 23, 24, 25, 26, 24, 23 };
            formsPlotTemp.Plot.Add.Signal(tempHistory);
            formsPlotTemp.Plot.Title("Temperature History (°C)");
            formsPlotTemp.Plot.YLabel("°C");
            formsPlotTemp.Refresh();

            // pH dummy data
            double[] phHistory = { 7.1, 7.2, 7.0, 6.9, 7.3, 7.2 };
            formsPlotPH.Plot.Add.Signal(phHistory);
            formsPlotPH.Plot.Title("pH History");
            formsPlotPH.Plot.YLabel("pH");
            formsPlotPH.Refresh();

            // Oxygen dummy data
            double[] oxyHistory = { 6.1, 6.3, 6.0, 5.8, 6.2, 6.4 };
            formsPlotOxy.Plot.Add.Signal(oxyHistory);
            formsPlotOxy.Plot.Title("Oxygen History (mg/L)");
            formsPlotOxy.Plot.YLabel("mg/L");
            formsPlotOxy.Refresh();
        }
    }
}
