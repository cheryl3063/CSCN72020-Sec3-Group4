namespace SmartAquariumController
{
    partial class CalibrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTempMin = new System.Windows.Forms.Label();
            this.lblTempMax = new System.Windows.Forms.Label();
            this.lblPHMin = new System.Windows.Forms.Label();
            this.lblPHMax = new System.Windows.Forms.Label();
            this.lblOxyMin = new System.Windows.Forms.Label();
            this.lblOxyMax = new System.Windows.Forms.Label();

            this.numTempMin = new System.Windows.Forms.NumericUpDown();
            this.numTempMax = new System.Windows.Forms.NumericUpDown();
            this.numPHMin = new System.Windows.Forms.NumericUpDown();
            this.numPHMax = new System.Windows.Forms.NumericUpDown();
            this.numOxyMin = new System.Windows.Forms.NumericUpDown();
            this.numOxyMax = new System.Windows.Forms.NumericUpDown();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numTempMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTempMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPHMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPHMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOxyMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOxyMax)).BeginInit();

            this.SuspendLayout();

            // ─────────────────────────────────────────────
            // FORM
            // ─────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 420);
            this.Text = "Calibration Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // ─────────────────────────────────────────────
            // LABELS WITH EMOJIS
            // ─────────────────────────────────────────────
            this.lblTempMin.AutoSize = true;
            this.lblTempMin.Location = new System.Drawing.Point(30, 40);
            this.lblTempMin.Text = "🌡️ Temperature Min:";

            this.lblTempMax.AutoSize = true;
            this.lblTempMax.Location = new System.Drawing.Point(30, 90);
            this.lblTempMax.Text = "🌡️ Temperature Max:";

            this.lblPHMin.AutoSize = true;
            this.lblPHMin.Location = new System.Drawing.Point(30, 140);
            this.lblPHMin.Text = "⚗️ pH Min:";

            this.lblPHMax.AutoSize = true;
            this.lblPHMax.Location = new System.Drawing.Point(30, 190);
            this.lblPHMax.Text = "⚗️ pH Max:";

            this.lblOxyMin.AutoSize = true;
            this.lblOxyMin.Location = new System.Drawing.Point(30, 240);
            this.lblOxyMin.Text = "🫧 Oxygen Min:";

            this.lblOxyMax.AutoSize = true;
            this.lblOxyMax.Location = new System.Drawing.Point(30, 290);
            this.lblOxyMax.Text = "🫧 Oxygen Max:";

            // ─────────────────────────────────────────────
            // NUMERIC UPDOWN CONTROLS
            // ─────────────────────────────────────────────
            this.numTempMin.Location = new System.Drawing.Point(200, 38);
            this.numTempMin.Minimum = 0;
            this.numTempMin.Maximum = 40;
            this.numTempMin.DecimalPlaces = 1;

            this.numTempMax.Location = new System.Drawing.Point(200, 88);
            this.numTempMax.Minimum = 0;
            this.numTempMax.Maximum = 40;
            this.numTempMax.DecimalPlaces = 1;

            this.numPHMin.Location = new System.Drawing.Point(200, 138);
            this.numPHMin.Minimum = 0;
            this.numPHMin.Maximum = 14;
            this.numPHMin.DecimalPlaces = 2;

            this.numPHMax.Location = new System.Drawing.Point(200, 188);
            this.numPHMax.Minimum = 0;
            this.numPHMax.Maximum = 14;
            this.numPHMax.DecimalPlaces = 2;

            this.numOxyMin.Location = new System.Drawing.Point(200, 238);
            this.numOxyMin.Minimum = 0;
            this.numOxyMin.Maximum = 15;
            this.numOxyMin.DecimalPlaces = 1;

            this.numOxyMax.Location = new System.Drawing.Point(200, 288);
            this.numOxyMax.Minimum = 0;
            this.numOxyMax.Maximum = 15;
            this.numOxyMax.DecimalPlaces = 1;

            // ─────────────────────────────────────────────
            // SAVE BUTTON
            // ─────────────────────────────────────────────
            this.btnSave.Location = new System.Drawing.Point(70, 340);
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.Text = "💾 Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // ─────────────────────────────────────────────
            // LOAD BUTTON
            // ─────────────────────────────────────────────
            this.btnLoad.Location = new System.Drawing.Point(240, 340);
            this.btnLoad.Size = new System.Drawing.Size(120, 35);
            this.btnLoad.Text = "📂 Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            // ─────────────────────────────────────────────
            // ADD CONTROLS
            // ─────────────────────────────────────────────
            this.Controls.Add(this.lblTempMin);
            this.Controls.Add(this.lblTempMax);
            this.Controls.Add(this.lblPHMin);
            this.Controls.Add(this.lblPHMax);
            this.Controls.Add(this.lblOxyMin);
            this.Controls.Add(this.lblOxyMax);

            this.Controls.Add(this.numTempMin);
            this.Controls.Add(this.numTempMax);
            this.Controls.Add(this.numPHMin);
            this.Controls.Add(this.numPHMax);
            this.Controls.Add(this.numOxyMin);
            this.Controls.Add(this.numOxyMax);

            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTempMin;
        private System.Windows.Forms.Label lblTempMax;
        private System.Windows.Forms.Label lblPHMin;
        private System.Windows.Forms.Label lblPHMax;
        private System.Windows.Forms.Label lblOxyMin;
        private System.Windows.Forms.Label lblOxyMax;

        private System.Windows.Forms.NumericUpDown numTempMin;
        private System.Windows.Forms.NumericUpDown numTempMax;
        private System.Windows.Forms.NumericUpDown numPHMin;
        private System.Windows.Forms.NumericUpDown numPHMax;
        private System.Windows.Forms.NumericUpDown numOxyMin;
        private System.Windows.Forms.NumericUpDown numOxyMax;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
    }
}