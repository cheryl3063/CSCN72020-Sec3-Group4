using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace SmartAquariumController
{
    public partial class MainDashboard : Form
    {
        private TemperatureSensor tempSensor;
        private PHSensor phSensor;
        private OxygenSensor oxygenSensor;
        private LightControl lightControl;
        private FeederControl feederControl;

        private bool blinkState = false;
        private Timer blinkTimer;
        private bool darkMode = false;

        // Alert flags (current tick)
        private bool isTempHotBlinking = false;
        private bool isTempColdBlinking = false;
        private bool isPHAlertBlinking = false;
        private bool isOxygenAlertBlinking = false;

        // Logging previous states
        private bool lastTempHotBlinking = false;
        private bool lastTempColdBlinking = false;
        private bool lastPHAlertBlinking = false;
        private bool lastOxygenAlertBlinking = false;
        private bool lastLightOn = false;
        private string lastFeederStatus = "";

        // Log file
        private string logFile = "aquarium_log.txt";

        public MainDashboard()
        {
            InitializeComponent();

            // Create sensor/control objects
            tempSensor = new TemperatureSensor();
            phSensor = new PHSensor();
            oxygenSensor = new OxygenSensor();
            lightControl = new LightControl();
            feederControl = new FeederControl();

            // Blink timer setup
            blinkTimer = new Timer();
            blinkTimer.Interval = 400;
            blinkTimer.Tick += BlinkTimer_Tick;
            blinkTimer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateDashboardUI();
        }

        private void UpdateDashboardUI()
        {
            // Reset alert flags for this tick
            isTempHotBlinking = false;
            isTempColdBlinking = false;
            isPHAlertBlinking = false;
            isOxygenAlertBlinking = false;

            // ---------------- TEMPERATURE ----------------
            double temp = tempSensor.ReadValue();
            lblTemp.Text = $"🌡️ Temperature: {temp:F1} °C";

            if (temp > 28) // HOT ALERT
            {
                lblTemp.ForeColor = Color.Red;
                isTempHotBlinking = true;
            }
            else if (temp < 20) // COLD ALERT
            {
                lblTemp.ForeColor = Color.DodgerBlue;
                isTempColdBlinking = true;
            }
            else // NORMAL
            {
                lblTemp.ForeColor = Color.Black;
                ledTemp.BackColor = Color.LimeGreen;
            }

            // ---------------- pH ----------------
            double ph = phSensor.ReadValue();
            lblPH.Text = $"⚗️ pH Level: {ph:F2}";

            if (ph < 6.5 || ph > 8.0)
            {
                lblPH.ForeColor = Color.Orange;
                isPHAlertBlinking = true;
            }
            else
            {
                lblPH.ForeColor = Color.Black;
                ledPH.BackColor = Color.LimeGreen;
            }

            // ---------------- OXYGEN ----------------
            double oxygen = oxygenSensor.ReadValue();
            lblOxygen.Text = $"🫧 Oxygen: {oxygen:F1} mg/L";

            if (oxygen < 5.0)
            {
                lblOxygen.ForeColor = Color.Red;
                isOxygenAlertBlinking = true;
            }
            else
            {
                lblOxygen.ForeColor = Color.Black;
                ledOxygen.BackColor = Color.LimeGreen;
            }

            // ---------------- LIGHT ----------------
            bool isOn = lightControl.IsLightOn();
            lblLight.Text = isOn ? "💡 Light: ON" : "💡 Light: OFF";
            ledLight.BackColor = isOn ? Color.LimeGreen : Color.DimGray;

            // ---------------- FEEDER ----------------
            string status = feederControl.GetStatus();
            lblFeeder.Text = $"🐟 Feeder: {status}";
            ledFeeder.BackColor = status == "Feeding" ? Color.LimeGreen : Color.DimGray;

            // ---------------- LOGGING ----------------

            // Hot temp started
            if (isTempHotBlinking && !lastTempHotBlinking)
                LogEvent($"Temperature High ({temp:F1} °C)");

            // Hot temp ended
            if (!isTempHotBlinking && lastTempHotBlinking)
                LogEvent($"Temperature Back to Normal ({temp:F1} °C)");

            // Cold temp started
            if (isTempColdBlinking && !lastTempColdBlinking)
                LogEvent($"Temperature Low ({temp:F1} °C)");

            // Cold temp ended
            if (!isTempColdBlinking && lastTempColdBlinking)
                LogEvent($"Temperature Back to Normal ({temp:F1} °C)");

            // pH alert started
            if (isPHAlertBlinking && !lastPHAlertBlinking)
                LogEvent($"pH Out of Range ({ph:F2})");

            // pH alert ended
            if (!isPHAlertBlinking && lastPHAlertBlinking)
                LogEvent($"pH Back to Normal ({ph:F2})");

            // Oxygen alert started
            if (isOxygenAlertBlinking && !lastOxygenAlertBlinking)
                LogEvent($"Oxygen Low ({oxygen:F1} mg/L)");

            // Oxygen alert ended
            if (!isOxygenAlertBlinking && lastOxygenAlertBlinking)
                LogEvent($"Oxygen Back to Normal ({oxygen:F1} mg/L)");

            // Light changed
            if (isOn != lastLightOn)
                LogEvent(isOn ? "Light Turned ON" : "Light Turned OFF");

            // Feeder changed
            if (status != lastFeederStatus)
                LogEvent($"Feeder Status: {status}");

            // Update "last" trackers
            lastTempHotBlinking = isTempHotBlinking;
            lastTempColdBlinking = isTempColdBlinking;
            lastPHAlertBlinking = isPHAlertBlinking;
            lastOxygenAlertBlinking = isOxygenAlertBlinking;
            lastLightOn = isOn;
            lastFeederStatus = status;
        }

        private void LogEvent(string message)
        {
            try
            {
                string entry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
                File.AppendAllText(logFile, entry + Environment.NewLine);
            }
            catch
            {
                // no crash if logging fails
            }
        }

        // ----------- LED BLINK TIMER ----------------
        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            blinkState = !blinkState;

            if (isTempHotBlinking)
                ledTemp.BackColor = blinkState ? Color.Red : Color.White;

            if (isTempColdBlinking)
                ledTemp.BackColor = blinkState ? Color.DodgerBlue : Color.White;

            if (isPHAlertBlinking)
                ledPH.BackColor = blinkState ? Color.Orange : Color.White;

            if (isOxygenAlertBlinking)
                ledOxygen.BackColor = blinkState ? Color.Red : Color.White;
        }

        // ---------------- UI LOAD ----------------
        private void MainDashboard_Load(object sender, EventArgs e)
        {
            MakeRoundLED(ledTemp);
            MakeRoundLED(ledPH);
            MakeRoundLED(ledOxygen);
            MakeRoundLED(ledLight);
            MakeRoundLED(ledFeeder);

            StyleCardPanel(panelTemp);
            StyleCardPanel(panelPH);
            StyleCardPanel(panelOxygen);
            StyleCardPanel(panelLight);
            StyleCardPanel(panelFeeder);

            this.BackColor = Color.WhiteSmoke;
        }

        private void MakeRoundLED(Panel p)
        {
            p.Width = p.Height;
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, p.Width - 1, p.Height - 1);
                p.Region = new Region(path);
            }
        }

        private void StyleCardPanel(Panel p)
        {
            p.BackColor = Color.White;
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Padding = new Padding(10);
        }

        // Gradient header
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle header = new Rectangle(0, 0, this.Width, 90);
            using (var brush = new LinearGradientBrush(
                header,
                Color.FromArgb(202, 240, 255),
                Color.FromArgb(160, 210, 255),
                90F))
            {
                e.Graphics.FillRectangle(brush, header);
            }
        }

        // Dark mode toggle
        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            darkMode = !darkMode;

            Color bg = darkMode ? Color.FromArgb(30, 30, 30) : Color.WhiteSmoke;
            Color card = darkMode ? Color.FromArgb(45, 45, 45) : Color.White;

            this.BackColor = bg;

            panelTemp.BackColor = card;
            panelPH.BackColor = card;
            panelOxygen.BackColor = card;
            panelLight.BackColor = card;
            panelFeeder.BackColor = card;

            if (!darkMode)
            {
                // restore normal label colors
                ResetLabelColor(lblTemp);
                ResetLabelColor(lblPH);
                ResetLabelColor(lblOxygen);
                ResetLabelColor(lblLight);
                ResetLabelColor(lblFeeder);
            }
            else
            {
                // convert normal labels to white
                MakeLabelsLight(lblTemp);
                MakeLabelsLight(lblPH);
                MakeLabelsLight(lblOxygen);
                MakeLabelsLight(lblLight);
                MakeLabelsLight(lblFeeder);
            }

            btnDarkMode.Text = darkMode ? "☀️ Light Mode" : "🌙 Dark Mode";
        }

        private void MakeLabelsLight(Label lbl)
        {
            if (lbl.ForeColor == Color.Black || lbl.ForeColor == Color.Gray)
                lbl.ForeColor = Color.White;
        }

        private void ResetLabelColor(Label lbl)
        {
            if (lbl.ForeColor == Color.White)
                lbl.ForeColor = Color.Black;
        }

        // VIEW LOG button
        private void btnViewLog_Click(object sender, EventArgs e)
        {
            if (File.Exists(logFile))
            {
                string content = File.ReadAllText(logFile);
                MessageBox.Show(string.IsNullOrWhiteSpace(content) ? "Log is empty." : content, "Event Log");
            }
            else
            {
                MessageBox.Show("No events logged yet.", "Event Log");
            }
        }
    }
}
