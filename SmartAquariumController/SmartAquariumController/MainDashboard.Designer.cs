namespace SmartAquariumController
{
    partial class MainDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.MainDashboard_Load);
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);

            // --- PANELS ---
            this.panelTemp = new System.Windows.Forms.Panel();
            this.panelPH = new System.Windows.Forms.Panel();
            this.panelOxygen = new System.Windows.Forms.Panel();
            this.panelLight = new System.Windows.Forms.Panel();
            this.panelFeeder = new System.Windows.Forms.Panel();

            // --- LED PANELS ---
            this.ledTemp = new System.Windows.Forms.Panel();
            this.ledPH = new System.Windows.Forms.Panel();
            this.ledOxygen = new System.Windows.Forms.Panel();
            this.ledLight = new System.Windows.Forms.Panel();
            this.ledFeeder = new System.Windows.Forms.Panel();

            // --- LABELS ---
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblPH = new System.Windows.Forms.Label();
            this.lblOxygen = new System.Windows.Forms.Label();
            this.lblLight = new System.Windows.Forms.Label();
            this.lblFeeder = new System.Windows.Forms.Label();

            // --- BUTTONS ---
            this.btnDarkMode = new System.Windows.Forms.Button();
            this.btnViewLog = new System.Windows.Forms.Button();

            // --- FORM SETUP ---
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(850, 650);
            this.Text = "Smart Aquarium Controller – Main Dashboard";

            // -------- TEMP PANEL --------
            this.panelTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTemp.Size = new System.Drawing.Size(380, 70);
            this.panelTemp.Location = new System.Drawing.Point(20, 120);

            this.ledTemp.BackColor = System.Drawing.Color.Gray;
            this.ledTemp.Size = new System.Drawing.Size(18, 18);
            this.ledTemp.Location = new System.Drawing.Point(15, 25);

            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(50, 25);
            this.lblTemp.Text = "🌡️ Temperature: -- °C";

            this.panelTemp.Controls.Add(this.ledTemp);
            this.panelTemp.Controls.Add(this.lblTemp);

            // -------- PH PANEL --------
            this.panelPH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPH.Size = new System.Drawing.Size(380, 70);
            this.panelPH.Location = new System.Drawing.Point(20, 210);

            this.ledPH.BackColor = System.Drawing.Color.Gray;
            this.ledPH.Size = new System.Drawing.Size(18, 18);
            this.ledPH.Location = new System.Drawing.Point(15, 25);

            this.lblPH.AutoSize = true;
            this.lblPH.Location = new System.Drawing.Point(50, 25);
            this.lblPH.Text = "⚗️ pH Level: --";

            this.panelPH.Controls.Add(this.ledPH);
            this.panelPH.Controls.Add(this.lblPH);

            // -------- OXYGEN PANEL --------
            this.panelOxygen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOxygen.Size = new System.Drawing.Size(380, 70);
            this.panelOxygen.Location = new System.Drawing.Point(20, 300);

            this.ledOxygen.BackColor = System.Drawing.Color.Gray;
            this.ledOxygen.Size = new System.Drawing.Size(18, 18);
            this.ledOxygen.Location = new System.Drawing.Point(15, 25);

            this.lblOxygen.AutoSize = true;
            this.lblOxygen.Location = new System.Drawing.Point(50, 25);
            this.lblOxygen.Text = "🫧 Oxygen: -- mg/L";

            this.panelOxygen.Controls.Add(this.ledOxygen);
            this.panelOxygen.Controls.Add(this.lblOxygen);

            // -------- LIGHT PANEL --------
            this.panelLight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLight.Size = new System.Drawing.Size(380, 70);
            this.panelLight.Location = new System.Drawing.Point(20, 390);

            this.ledLight.BackColor = System.Drawing.Color.Gray;
            this.ledLight.Size = new System.Drawing.Size(18, 18);
            this.ledLight.Location = new System.Drawing.Point(15, 25);

            this.lblLight.AutoSize = true;
            this.lblLight.Location = new System.Drawing.Point(50, 25);
            this.lblLight.Text = "💡 Light: --";

            this.panelLight.Controls.Add(this.ledLight);
            this.panelLight.Controls.Add(this.lblLight);

            // -------- FEEDER PANEL --------
            this.panelFeeder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFeeder.Size = new System.Drawing.Size(380, 70);
            this.panelFeeder.Location = new System.Drawing.Point(20, 480);

            this.ledFeeder.BackColor = System.Drawing.Color.Gray;
            this.ledFeeder.Size = new System.Drawing.Size(18, 18);
            this.ledFeeder.Location = new System.Drawing.Point(15, 25);

            this.lblFeeder.AutoSize = true;
            this.lblFeeder.Location = new System.Drawing.Point(50, 25);
            this.lblFeeder.Text = "🐟 Feeder: --";

            this.panelFeeder.Controls.Add(this.ledFeeder);
            this.panelFeeder.Controls.Add(this.lblFeeder);

            // -------- DARK MODE BUTTON (top-right) --------
            this.btnDarkMode.Location = new System.Drawing.Point(700, 30);
            this.btnDarkMode.Size = new System.Drawing.Size(120, 30);
            this.btnDarkMode.Text = "🌙 Dark Mode";
            this.btnDarkMode.UseVisualStyleBackColor = true;
            this.btnDarkMode.Click += new System.EventHandler(this.btnDarkMode_Click);

            // -------- VIEW LOG BUTTON (centered under cards) --------
            this.btnViewLog.Location = new System.Drawing.Point(170, 570); // under cards
            this.btnViewLog.Size = new System.Drawing.Size(130, 30);
            this.btnViewLog.Text = "📄 View Log";
            this.btnViewLog.UseVisualStyleBackColor = true;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);

            // -------- TIMER --------
            this.timer1.Interval = 2000;
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            // -------- ADD CONTROLS TO FORM --------
            this.Controls.Add(this.panelTemp);
            this.Controls.Add(this.panelPH);
            this.Controls.Add(this.panelOxygen);
            this.Controls.Add(this.panelLight);
            this.Controls.Add(this.panelFeeder);
            this.Controls.Add(this.btnDarkMode);
            this.Controls.Add(this.btnViewLog);

            this.ResumeLayout(false);
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
    }
}
