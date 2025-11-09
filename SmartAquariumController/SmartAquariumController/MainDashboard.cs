using SmartAquariumController.Sensors;
using System;
using System.Windows.Forms;

namespace SmartAquariumController
{
    public partial class MainDashboard : Form
    {
        TemperatureSensor tempSensor = new TemperatureSensor();
        Timer timer = new Timer();

        public MainDashboard()
        {
            InitializeComponent();
            this.Text = "Smart Aquarium Controller – Main Dashboard";

            //var ph = new SmartAquariumController.Sensors.PHSensor();
            //ph.Update();
            //MessageBox.Show(ph.ToString(), "pH Test");
        }


        private void MainDashboard_Load(object sender, EventArgs e)
        {
            timer.Interval = 2000; // every 2 seconds
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tempSensor.Update();
            lblTemp.Text = $"Temperature: {tempSensor.Value} °C";
        }
    }
}
