using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartAquariumController
{
    public partial class ManualControlForm : Form
    {
        private LightControl lightControl;
        private FeederControl feederControl;

        public ManualControlForm(LightControl light, FeederControl feeder)
        {
            InitializeComponent();
            lightControl = light;
            feederControl = feeder;

            UpdateUI();
        }

        private void UpdateUI()
        {
            lblLightStatus.Text = lightControl.GetStatus();
            ledLight.BackColor = lightControl.IsLightOn ? Color.LimeGreen : Color.Gray;

            lblFeederStatus.Text = "Feeder: " + feederControl.GetStatus();
        }

        // ---------------- LIGHT BUTTONS ----------------

        private void btnLightOn_Click(object sender, EventArgs e)
        {
            lightControl.TurnOn();
            UpdateUI();
        }

        private void btnLightOff_Click(object sender, EventArgs e)
        {
            lightControl.TurnOff();
            UpdateUI();
        }

        private void btnToggleLight_Click(object sender, EventArgs e)
        {
            lightControl.Toggle();
            UpdateUI();
        }

        private void btnAutoMode_Click(object sender, EventArgs e)
        {
            lightControl.ResetToAuto();
            UpdateUI();
        }

        // ---------------- FEEDER BUTTON ----------------

        private void btnFeed_Click(object sender, EventArgs e)
        {
            lblFeederStatus.Text = "Feeder: " + feederControl.GetStatus();
        }
    }
}