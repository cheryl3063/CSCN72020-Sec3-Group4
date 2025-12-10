namespace SmartAquariumController
{
    partial class ManualControlForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitleLight;
        private System.Windows.Forms.Button btnLightOn;
        private System.Windows.Forms.Button btnLightOff;
        private System.Windows.Forms.Button btnToggleLight;
        private System.Windows.Forms.Button btnAutoMode;
        private System.Windows.Forms.Panel ledLight;
        private System.Windows.Forms.Label lblLightStatus;

        private System.Windows.Forms.Label lblTitleFeeder;
        private System.Windows.Forms.Button btnFeed;
        private System.Windows.Forms.Label lblFeederStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitleLight = new System.Windows.Forms.Label();
            this.btnLightOn = new System.Windows.Forms.Button();
            this.btnLightOff = new System.Windows.Forms.Button();
            this.btnToggleLight = new System.Windows.Forms.Button();
            this.btnAutoMode = new System.Windows.Forms.Button();
            this.ledLight = new System.Windows.Forms.Panel();
            this.lblLightStatus = new System.Windows.Forms.Label();

            this.lblTitleFeeder = new System.Windows.Forms.Label();
            this.btnFeed = new System.Windows.Forms.Button();
            this.lblFeederStatus = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // ---------------- LIGHT ----------------

            this.lblTitleLight.AutoSize = true;
            this.lblTitleLight.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitleLight.Location = new System.Drawing.Point(30, 20);
            this.lblTitleLight.Text = "Light Controls";

            this.btnLightOn.Location = new System.Drawing.Point(30, 60);
            this.btnLightOn.Size = new System.Drawing.Size(120, 35);
            this.btnLightOn.Text = "Light ON";
            this.btnLightOn.Click += new System.EventHandler(this.btnLightOn_Click);

            this.btnLightOff.Location = new System.Drawing.Point(160, 60);
            this.btnLightOff.Size = new System.Drawing.Size(120, 35);
            this.btnLightOff.Text = "Light OFF";
            this.btnLightOff.Click += new System.EventHandler(this.btnLightOff_Click);

            this.btnToggleLight.Location = new System.Drawing.Point(30, 105);
            this.btnToggleLight.Size = new System.Drawing.Size(120, 35);
            this.btnToggleLight.Text = "Toggle";
            this.btnToggleLight.Click += new System.EventHandler(this.btnToggleLight_Click);

            this.btnAutoMode.Location = new System.Drawing.Point(160, 105);
            this.btnAutoMode.Size = new System.Drawing.Size(120, 35);
            this.btnAutoMode.Text = "Auto Mode";
            this.btnAutoMode.Click += new System.EventHandler(this.btnAutoMode_Click);

            this.ledLight.Location = new System.Drawing.Point(30, 155);
            this.ledLight.Size = new System.Drawing.Size(20, 20);
            this.ledLight.BackColor = System.Drawing.Color.Gray;

            this.lblLightStatus.AutoSize = true;
            this.lblLightStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLightStatus.Location = new System.Drawing.Point(60, 155);
            this.lblLightStatus.Text = "Light: OFF";

            // ---------------- FEEDER ----------------

            this.lblTitleFeeder.AutoSize = true;
            this.lblTitleFeeder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitleFeeder.Location = new System.Drawing.Point(30, 210);
            this.lblTitleFeeder.Text = "Feeder Controls";

            this.btnFeed.Location = new System.Drawing.Point(30, 250);
            this.btnFeed.Size = new System.Drawing.Size(120, 35);
            this.btnFeed.Text = "Feed Now";
            this.btnFeed.Click += new System.EventHandler(this.btnFeed_Click);

            this.lblFeederStatus.AutoSize = true;
            this.lblFeederStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFeederStatus.Location = new System.Drawing.Point(30, 300);
            this.lblFeederStatus.Text = "Feeder: Idle";

            // ---------------- FORM ----------------

            this.ClientSize = new System.Drawing.Size(350, 380);
            this.Controls.Add(this.lblTitleLight);
            this.Controls.Add(this.btnLightOn);
            this.Controls.Add(this.btnLightOff);
            this.Controls.Add(this.btnToggleLight);
            this.Controls.Add(this.btnAutoMode);
            this.Controls.Add(this.ledLight);
            this.Controls.Add(this.lblLightStatus);

            this.Controls.Add(this.lblTitleFeeder);
            this.Controls.Add(this.btnFeed);
            this.Controls.Add(this.lblFeederStatus);

            this.Name = "ManualControlForm";
            this.Text = "Manual Controls";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}