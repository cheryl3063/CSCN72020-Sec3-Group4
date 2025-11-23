using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace SmartAquariumController
{
    public partial class CalibrationForm : Form
    {
        private string configFile = "thresholds.json";

        public CalibrationForm()
        {
            InitializeComponent();
        }

        private class ThresholdData
        {
            public double TempMin { get; set; }
            public double TempMax { get; set; }
            public double PHMin { get; set; }
            public double PHMax { get; set; }
            public double OxyMin { get; set; }
            public double OxyMax { get; set; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var data = new ThresholdData()
            {
                TempMin = (double)numTempMin.Value,
                TempMax = (double)numTempMax.Value,
                PHMin = (double)numPHMin.Value,
                PHMax = (double)numPHMax.Value,
                OxyMin = (double)numOxyMin.Value,
                OxyMax = (double)numOxyMax.Value
            };

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configFile, json);

            MessageBox.Show("Thresholds saved successfully!");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!File.Exists(configFile))
            {
                MessageBox.Show("No saved thresholds found.");
                return;
            }

            string json = File.ReadAllText(configFile);
            var data = JsonSerializer.Deserialize<ThresholdData>(json);

            numTempMin.Value = (decimal)data.TempMin;
            numTempMax.Value = (decimal)data.TempMax;
            numPHMin.Value = (decimal)data.PHMin;
            numPHMax.Value = (decimal)data.PHMax;
            numOxyMin.Value = (decimal)data.OxyMin;
            numOxyMax.Value = (decimal)data.OxyMax;

            MessageBox.Show("Thresholds loaded!");
        }

        private void CalibrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}