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
            this.btnViewLog = new System.Windows.Forms.Button();
            this.btnCalibration = new System.Windows.Forms.Button();
            this.panelTemp.SuspendLayout();
            this.panelPH.SuspendLayout();
            this.panelOxygen.SuspendLayout();
            this.panelLight.SuspendLayout();
            this.panelFeeder.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelTemp
            // 
            this.panelTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTemp.Controls.Add(this.ledTemp);
            this.panelTemp.Controls.Add(this.lblTemp);
            this.panelTemp.Location = new System.Drawing.Point(20, 40);
            this.panelTemp.Name = "panelTemp";
            this.panelTemp.Size = new System.Drawing.Size(380, 70);
            this.panelTemp.TabIndex = 0;
            // 
            // ledTemp
            // 
            this.ledTemp.BackColor = System.Drawing.Color.Gray;
            this.ledTemp.Location = new System.Drawing.Point(15, 25);
            this.ledTemp.Name = "ledTemp";
            this.ledTemp.Size = new System.Drawing.Size(18, 18);
            this.ledTemp.TabIndex = 0;
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(50, 25);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(125, 16);
            this.lblTemp.TabIndex = 1;
            this.lblTemp.Text = "🌡️ Temperature: -- °C";
            // 
            // panelPH
            // 
            this.panelPH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPH.Controls.Add(this.ledPH);
            this.panelPH.Controls.Add(this.lblPH);
            this.panelPH.Location = new System.Drawing.Point(20, 140);
            this.panelPH.Name = "panelPH";
            this.panelPH.Size = new System.Drawing.Size(380, 70);
            this.panelPH.TabIndex = 1;
            // 
            // ledPH
            // 
            this.ledPH.BackColor = System.Drawing.Color.Gray;
            this.ledPH.Location = new System.Drawing.Point(15, 25);
            this.ledPH.Name = "ledPH";
            this.ledPH.Size = new System.Drawing.Size(18, 18);
            this.ledPH.TabIndex = 0;
            // 
            // lblPH
            // 
            this.lblPH.AutoSize = true;
            this.lblPH.Location = new System.Drawing.Point(50, 25);
            this.lblPH.Name = "lblPH";
            this.lblPH.Size = new System.Drawing.Size(90, 16);
            this.lblPH.TabIndex = 1;
            this.lblPH.Text = "⚗️ pH Level: --";
            // 
            // panelOxygen
            // 
            this.panelOxygen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOxygen.Controls.Add(this.ledOxygen);
            this.panelOxygen.Controls.Add(this.lblOxygen);
            this.panelOxygen.Location = new System.Drawing.Point(20, 240);
            this.panelOxygen.Name = "panelOxygen";
            this.panelOxygen.Size = new System.Drawing.Size(380, 70);
            this.panelOxygen.TabIndex = 2;
            // 
            // ledOxygen
            // 
            this.ledOxygen.BackColor = System.Drawing.Color.Gray;
            this.ledOxygen.Location = new System.Drawing.Point(15, 25);
            this.ledOxygen.Name = "ledOxygen";
            this.ledOxygen.Size = new System.Drawing.Size(18, 18);
            this.ledOxygen.TabIndex = 0;
            // 
            // lblOxygen
            // 
            this.lblOxygen.AutoSize = true;
            this.lblOxygen.Location = new System.Drawing.Point(50, 25);
            this.lblOxygen.Name = "lblOxygen";
            this.lblOxygen.Size = new System.Drawing.Size(109, 16);
            this.lblOxygen.TabIndex = 1;
            this.lblOxygen.Text = "🫧 Oxygen: -- mg/L";
            // 
            // panelLight
            // 
            this.panelLight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLight.Controls.Add(this.ledLight);
            this.panelLight.Controls.Add(this.lblLight);
            this.panelLight.Location = new System.Drawing.Point(20, 340);
            this.panelLight.Name = "panelLight";
            this.panelLight.Size = new System.Drawing.Size(380, 70);
            this.panelLight.TabIndex = 3;
            // 
            // ledLight
            // 
            this.ledLight.BackColor = System.Drawing.Color.Gray;
            this.ledLight.Location = new System.Drawing.Point(15, 25);
            this.ledLight.Name = "ledLight";
            this.ledLight.Size = new System.Drawing.Size(18, 18);
            this.ledLight.TabIndex = 0;
            // 
            // lblLight
            // 
            this.lblLight.AutoSize = true;
            this.lblLight.Location = new System.Drawing.Point(50, 25);
            this.lblLight.Name = "lblLight";
            this.lblLight.Size = new System.Drawing.Size(61, 16);
            this.lblLight.TabIndex = 1;
            this.lblLight.Text = "💡 Light: --";
            // 
            // panelFeeder
            // 
            this.panelFeeder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFeeder.Controls.Add(this.ledFeeder);
            this.panelFeeder.Controls.Add(this.lblFeeder);
            this.panelFeeder.Location = new System.Drawing.Point(20, 440);
            this.panelFeeder.Name = "panelFeeder";
            this.panelFeeder.Size = new System.Drawing.Size(380, 70);
            this.panelFeeder.TabIndex = 4;
            // 
            // ledFeeder
            // 
            this.ledFeeder.BackColor = System.Drawing.Color.Gray;
            this.ledFeeder.Location = new System.Drawing.Point(15, 25);
            this.ledFeeder.Name = "ledFeeder";
            this.ledFeeder.Size = new System.Drawing.Size(18, 18);
            this.ledFeeder.TabIndex = 0;
            // 
            // lblFeeder
            // 
            this.lblFeeder.AutoSize = true;
            this.lblFeeder.Location = new System.Drawing.Point(50, 25);
            this.lblFeeder.Name = "lblFeeder";
            this.lblFeeder.Size = new System.Drawing.Size(80, 16);
            this.lblFeeder.TabIndex = 1;
            this.lblFeeder.Text = "🐟 Feeder: --";
            // 
            // btnDarkMode
            // 
            this.btnDarkMode.Location = new System.Drawing.Point(700, 30);
            this.btnDarkMode.Name = "btnDarkMode";
            this.btnDarkMode.Size = new System.Drawing.Size(120, 30);
            this.btnDarkMode.TabIndex = 5;
            this.btnDarkMode.Text = "🌙 Dark Mode";
            this.btnDarkMode.Click += new System.EventHandler(this.btnDarkMode_Click);
            // 
            // btnViewLog
            // 
            this.btnViewLog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnViewLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewLog.Location = new System.Drawing.Point(170, 570);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(150, 35);
            this.btnViewLog.TabIndex = 6;
            this.btnViewLog.Text = "📄 View Log";
            this.btnViewLog.UseVisualStyleBackColor = false;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // btnCalibration
            // 
            this.btnCalibration.BackColor = System.Drawing.Color.White;
            this.btnCalibration.Location = new System.Drawing.Point(700, 70);
            this.btnCalibration.Name = "btnCalibration";
            this.btnCalibration.Size = new System.Drawing.Size(120, 30);
            this.btnCalibration.TabIndex = 7;
            this.btnCalibration.Text = "⚙️ Calibration";
            this.btnCalibration.UseVisualStyleBackColor = false;
            this.btnCalibration.Click += new System.EventHandler(this.btnCalibration_Click);
            // 
            // MainDashboard
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(850, 650);
            this.Controls.Add(this.panelTemp);
            this.Controls.Add(this.panelPH);
            this.Controls.Add(this.panelOxygen);
            this.Controls.Add(this.panelLight);
            this.Controls.Add(this.panelFeeder);
            this.Controls.Add(this.btnDarkMode);
            this.Controls.Add(this.btnViewLog);
            this.Controls.Add(this.btnCalibration);
            this.Name = "MainDashboard";
            this.Text = "Smart Aquarium Controller – Main Dashboard";
            this.panelTemp.ResumeLayout(false);
            this.panelTemp.PerformLayout();
            this.panelPH.ResumeLayout(false);
            this.panelPH.PerformLayout();
            this.panelOxygen.ResumeLayout(false);
            this.panelOxygen.PerformLayout();
            this.panelLight.ResumeLayout(false);
            this.panelLight.PerformLayout();
            this.panelFeeder.ResumeLayout(false);
            this.panelFeeder.PerformLayout();
            this.ResumeLayout(false);

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

        private System.Windows.Forms.Panel panelTemp;
        private System.Windows.Forms.Panel panelPH;
        private System.Windows.Forms.Panel panelOxygen;
        private System.Windows.Forms.Panel panelLight;
        private System.Windows.Forms.Panel panelFeeder;

        private System.Windows.Forms.Panel ledTemp;
        private System.Windows.Forms.Panel ledPH;
        private System.Windows.Forms.Panel ledOxygen;
        private System.Windows.Forms.Panel ledLight;
        private System.Windows.Forms.Panel ledFeeder;

        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblPH;
        private System.Windows.Forms.Label lblOxygen;
        private System.Windows.Forms.Label lblLight;
        private System.Windows.Forms.Label lblFeeder;

        private System.Windows.Forms.Button btnDarkMode;
        private System.Windows.Forms.Button btnViewLog;
        private System.Windows.Forms.Button btnCalibration;
    }
}