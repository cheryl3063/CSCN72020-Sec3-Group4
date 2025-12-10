using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartAquariumController
{
    partial class MainDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelAnalytics;
        private System.Windows.Forms.Label lblAnalyticsHeader;
        private System.Windows.Forms.Label lblTempStats;
        private System.Windows.Forms.Label lblPHStats;
        private System.Windows.Forms.Label lblOxyStats;
        private System.Windows.Forms.Label lblAlertSummary;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.timer1 = new System.Windows.Forms.Timer(this.components);

            this.panelTemp = new System.Windows.Forms.Panel();
            this.ledTemp = new System.Windows.Forms.Panel();
            this.lblTemp = new System.Windows.Forms.Label();

            this.panelPH = new System.Windows.Forms.Panel();
            this.ledPH = new System.Windows.Forms.Panel();
            this.lblPH = new System.Windows.Forms.Label();

            this.panelOxygen = new System.Windows.Forms.Panel();
            this.ledOxygen = new System.Windows.Forms.Panel();
            this.lblOxygen = new System.Windows.Forms.Label();

            this.panelLight = new System.Windows.Forms.Panel();
            this.ledLight = new System.Windows.Forms.Panel();
            this.lblLight = new System.Windows.Forms.Label();

            this.panelFeeder = new System.Windows.Forms.Panel();
            this.ledFeeder = new System.Windows.Forms.Panel();
            this.lblFeeder = new System.Windows.Forms.Label();

            this.btnDarkMode = new System.Windows.Forms.Button();
            this.btnCalibration = new System.Windows.Forms.Button();
            this.btnViewLog = new System.Windows.Forms.Button();

            this.lblSectionSensors = new System.Windows.Forms.Label();
            this.lblSectionSystems = new System.Windows.Forms.Label();

            this.lineSensors = new System.Windows.Forms.Panel();
            this.lineSystems = new System.Windows.Forms.Panel();

            this.SuspendLayout();

            // ----------------------------------------
            // TIMER
            // ----------------------------------------
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            // ----------------------------------------
            // LABELS & DIVIDERS
            // ----------------------------------------
            this.lblSectionSensors.AutoSize = true;
            this.lblSectionSensors.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblSectionSensors.ForeColor = Color.FromArgb(180, 180, 190);
            this.lblSectionSensors.Location = new Point(50, 130);
            this.lblSectionSensors.Text = "SENSORS";

            this.lineSensors.Location = new Point(50, 160);
            this.lineSensors.Size = new Size(1000, 1);
            this.lineSensors.BackColor = Color.FromArgb(80, 80, 90);

            this.lblSectionSystems.AutoSize = true;
            this.lblSectionSystems.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblSectionSystems.ForeColor = Color.FromArgb(180, 180, 190);
            this.lblSectionSystems.Location = new Point(50, 300);
            this.lblSectionSystems.Text = "SYSTEM DEVICES";

            this.lineSystems.Location = new Point(50, 330);
            this.lineSystems.Size = new Size(1000, 1);
            this.lineSystems.BackColor = Color.FromArgb(80, 80, 90);

            // ----------------------------------------
            // TEMP PANEL (placeholder pos)
            // ----------------------------------------
            this.panelTemp.Size = new Size(300, 120);
            this.panelTemp.Location = new Point(50, 170);

            this.ledTemp.Size = new Size(18, 18);
            this.ledTemp.Location = new Point(20, 20);
            this.ledTemp.BackColor = Color.Silver;

            this.lblTemp.AutoSize = true;
            this.lblTemp.Font = new Font("Segoe UI", 12F);
            this.lblTemp.Location = new Point(50, 16);
            this.lblTemp.Text = "🌡️ Temperature: --";

            this.panelTemp.Controls.Add(this.ledTemp);
            this.panelTemp.Controls.Add(this.lblTemp);

            // ----------------------------------------
            // PH PANEL
            // ----------------------------------------
            this.panelPH.Size = new Size(300, 120);
            this.panelPH.Location = new Point(400, 170);

            this.ledPH.Size = new Size(18, 18);
            this.ledPH.Location = new Point(20, 20);
            this.ledPH.BackColor = Color.Silver;

            this.lblPH.AutoSize = true;
            this.lblPH.Font = new Font("Segoe UI", 12F);
            this.lblPH.Location = new Point(50, 16);
            this.lblPH.Text = "⚗️ pH Level: --";

            this.panelPH.Controls.Add(this.ledPH);
            this.panelPH.Controls.Add(this.lblPH);

            // ----------------------------------------
            // OXYGEN PANEL
            // ----------------------------------------
            this.panelOxygen.Size = new Size(300, 120);
            this.panelOxygen.Location = new Point(750, 170);

            this.ledOxygen.Size = new Size(18, 18);
            this.ledOxygen.Location = new Point(20, 20);
            this.ledOxygen.BackColor = Color.Silver;

            this.lblOxygen.AutoSize = true;
            this.lblOxygen.Font = new Font("Segoe UI", 12F);
            this.lblOxygen.Location = new Point(50, 16);
            this.lblOxygen.Text = "🫧 Oxygen: --";

            this.panelOxygen.Controls.Add(this.ledOxygen);
            this.panelOxygen.Controls.Add(this.lblOxygen);

            // ----------------------------------------
            // LIGHT PANEL
            // ----------------------------------------
            this.panelLight.Size = new Size(300, 120);
            this.panelLight.Location = new Point(300, 350);

            this.ledLight.Size = new Size(18, 18);
            this.ledLight.Location = new Point(20, 20);
            this.ledLight.BackColor = Color.Silver;

            this.lblLight.AutoSize = true;
            this.lblLight.Font = new Font("Segoe UI", 12F);
            this.lblLight.Location = new Point(50, 16);
            this.lblLight.Text = "💡 Light: --";

            this.panelLight.Controls.Add(this.ledLight);
            this.panelLight.Controls.Add(this.lblLight);

            // ----------------------------------------
            // FEEDER PANEL
            // ----------------------------------------
            this.panelFeeder.Size = new Size(300, 120);
            this.panelFeeder.Location = new Point(650, 350);

            this.ledFeeder.Size = new Size(18, 18);
            this.ledFeeder.Location = new Point(20, 20);
            this.ledFeeder.BackColor = Color.Silver;

            this.lblFeeder.AutoSize = true;
            this.lblFeeder.Font = new Font("Segoe UI", 12F);
            this.lblFeeder.Location = new Point(50, 16);
            this.lblFeeder.Text = "🐟 Feeder: --";

            this.panelFeeder.Controls.Add(this.ledFeeder);
            this.panelFeeder.Controls.Add(this.lblFeeder);

            // ----------------------------------------
            // TOP BUTTONS
            // ----------------------------------------
            this.btnDarkMode.Text = "☀ Light";
            this.btnDarkMode.Size = new Size(120, 34);
            this.btnDarkMode.Location = new Point(940, 20);
            this.btnDarkMode.FlatStyle = FlatStyle.Flat;
            this.btnDarkMode.FlatAppearance.BorderSize = 0;
            this.btnDarkMode.Click += new EventHandler(this.btnDarkMode_Click);

            this.btnCalibration.Text = "⚙ Calibration";
            this.btnCalibration.Size = new Size(120, 34);
            this.btnCalibration.Location = new Point(940, 62);
            this.btnCalibration.FlatStyle = FlatStyle.Flat;
            this.btnCalibration.FlatAppearance.BorderSize = 0;
            this.btnCalibration.Click += new EventHandler(this.btnCalibration_Click);

            this.btnViewLog.Text = "📜 View Event Log";
            this.btnViewLog.Size = new Size(200, 34);
            this.btnViewLog.Location = new Point(460, 650);
            this.btnViewLog.FlatStyle = FlatStyle.Flat;
            this.btnViewLog.FlatAppearance.BorderSize = 0;
            this.btnViewLog.Click += new EventHandler(this.btnViewLog_Click);

            // ----------------------------------------
            // FORM SETTINGS
            // ----------------------------------------
            this.ClientSize = new Size(1122, 806);
            this.BackColor = Color.FromArgb(240, 244, 252);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Smart Aquarium Controller – Dashboard";
            this.DoubleBuffered = true;
            this.Load += new EventHandler(this.MainDashboard_Load);

            // ----------------------------------------
            // ADD CONTROLS
            // ----------------------------------------
            this.Controls.Add(this.lblSectionSensors);
            this.Controls.Add(this.lineSensors);
            this.Controls.Add(this.lblSectionSystems);
            this.Controls.Add(this.lineSystems);

            this.Controls.Add(this.panelTemp);
            this.Controls.Add(this.panelPH);
            this.Controls.Add(this.panelOxygen);
            this.Controls.Add(this.panelLight);
            this.Controls.Add(this.panelFeeder);

            this.Controls.Add(this.btnDarkMode);
            this.Controls.Add(this.btnCalibration);
            this.Controls.Add(this.btnViewLog);

            // ================== ANALYTICS PANEL (RIGHT SIDE) ==================

            this.panelAnalytics = new System.Windows.Forms.Panel();
            this.lblAnalyticsHeader = new System.Windows.Forms.Label();
            this.lblTempStats = new System.Windows.Forms.Label();
            this.lblPHStats = new System.Windows.Forms.Label();
            this.lblOxyStats = new System.Windows.Forms.Label();
            this.lblAlertSummary = new System.Windows.Forms.Label();

            // 
            // panelAnalytics
            // 
            this.panelAnalytics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAnalytics.Location = new System.Drawing.Point(650, 120);  // RIGHT SIDE — Safe
            this.panelAnalytics.Name = "panelAnalytics";
            this.panelAnalytics.Size = new System.Drawing.Size(260, 240);
            this.panelAnalytics.BackColor = System.Drawing.Color.WhiteSmoke;

            // 
            // lblAnalyticsHeader
            // 
            this.lblAnalyticsHeader.AutoSize = true;
            this.lblAnalyticsHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblAnalyticsHeader.Location = new System.Drawing.Point(20, 15);
            this.lblAnalyticsHeader.Name = "lblAnalyticsHeader";
            this.lblAnalyticsHeader.Size = new System.Drawing.Size(150, 20);
            this.lblAnalyticsHeader.Text = "Analytics Summary";

            // 
            // lblTempStats
            // 
            this.lblTempStats.AutoSize = true;
            this.lblTempStats.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTempStats.Location = new System.Drawing.Point(20, 55);
            this.lblTempStats.Name = "lblTempStats";
            this.lblTempStats.Size = new System.Drawing.Size(65, 17);
            this.lblTempStats.Text = "Temp: --";

            // 
            // lblPHStats
            // 
            this.lblPHStats.AutoSize = true;
            this.lblPHStats.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPHStats.Location = new System.Drawing.Point(20, 85);
            this.lblPHStats.Name = "lblPHStats";
            this.lblPHStats.Size = new System.Drawing.Size(48, 17);
            this.lblPHStats.Text = "pH: --";

            // 
            // lblOxyStats
            // 
            this.lblOxyStats.AutoSize = true;
            this.lblOxyStats.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblOxyStats.Location = new System.Drawing.Point(20, 115);
            this.lblOxyStats.Name = "lblOxyStats";
            this.lblOxyStats.Size = new System.Drawing.Size(75, 17);
            this.lblOxyStats.Text = "Oxygen: --";

            // 
            // lblAlertSummary
            // 
            this.lblAlertSummary.AutoSize = true;
            this.lblAlertSummary.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAlertSummary.Location = new System.Drawing.Point(20, 150);
            this.lblAlertSummary.Name = "lblAlertSummary";
            this.lblAlertSummary.Size = new System.Drawing.Size(60, 17);
            this.lblAlertSummary.Text = "Alerts: --";

            // Add controls into panel
            this.panelAnalytics.Controls.Add(this.lblAnalyticsHeader);
            this.panelAnalytics.Controls.Add(this.lblTempStats);
            this.panelAnalytics.Controls.Add(this.lblPHStats);
            this.panelAnalytics.Controls.Add(this.lblOxyStats);
            this.panelAnalytics.Controls.Add(this.lblAlertSummary);

            // Add analytics panel to form
            this.Controls.Add(this.panelAnalytics);
        }
        #endregion

        private System.Windows.Forms.Timer timer1;

        private Panel panelTemp;
        private Panel ledTemp;
        private Label lblTemp;

        private Panel panelPH;
        private Panel ledPH;
        private Label lblPH;

        private Panel panelOxygen;
        private Panel ledOxygen;
        private Label lblOxygen;

        private Panel panelLight;
        private Panel ledLight;
        private Label lblLight;

        private Panel panelFeeder;
        private Panel ledFeeder;
        private Label lblFeeder;

        private Button btnDarkMode;
        private Button btnCalibration;
        private Button btnViewLog;

        private Label lblSectionSensors;
        private Label lblSectionSystems;
        private Panel lineSensors;
        private Panel lineSystems;
    }
}
