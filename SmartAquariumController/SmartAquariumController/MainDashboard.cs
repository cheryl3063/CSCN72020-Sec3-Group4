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
        private AnalyticsEngine analytics;

        private bool blinkState = false;
        private Timer blinkTimer;
        private bool darkMode = true;   // start in dark (Apple style)

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

        // JSON log storage (sprint 3)
        private LogRepository logRepository;

        public MainDashboard()
        {
            InitializeComponent();

            // Create sensor/control objects
            tempSensor = new TemperatureSensor();
            phSensor = new PHSensor();
            oxygenSensor = new OxygenSensor();
            lightControl = new LightControl();
            feederControl = new FeederControl();
            analytics = new AnalyticsEngine();

            // Blink timer setup
            blinkTimer = new Timer();
            blinkTimer.Interval = 400;
            blinkTimer.Tick += BlinkTimer_Tick;
            blinkTimer.Start();

            // Initialize JSON log repository
            logRepository = new LogRepository();
        }

        // ---------------------------------------------
        // TIMER TICK – UPDATE DASHBOARD
        // ---------------------------------------------
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

            // Choose normal text colour based on mode
            Color normalText = darkMode ? Color.White : Color.Black;
            Color secondaryText = darkMode ? Color.Gainsboro : Color.DimGray;

            // ---------------- TEMPERATURE ----------------
            double temp = tempSensor.ReadValue();
            lblTemp.Text = $"🌡️ Temperature: {temp:F1} °C";

            if (temp > 28) // HOT ALERT
            {
                lblTemp.ForeColor = Color.FromArgb(255, 80, 80);
                isTempHotBlinking = true;
            }
            else if (temp < 20) // COLD ALERT
            {
                lblTemp.ForeColor = Color.FromArgb(80, 150, 255);
                isTempColdBlinking = true;
            }
            else // NORMAL
            {
                lblTemp.ForeColor = normalText;
                ledTemp.BackColor = Color.FromArgb(50, 215, 75); // soft Apple green
            }

            // ---------------- pH ----------------
            double ph = phSensor.ReadValue();
            lblPH.Text = $"⚗️ pH Level: {ph:F2}";

            if (ph < 6.5 || ph > 8.0)
            {
                lblPH.ForeColor = Color.FromArgb(255, 159, 10); // soft orange
                isPHAlertBlinking = true;
            }
            else
            {
                lblPH.ForeColor = normalText;
                ledPH.BackColor = Color.FromArgb(50, 215, 75);
            }

            // ---------------- OXYGEN ----------------
            double oxygen = oxygenSensor.ReadValue();
            lblOxygen.Text = $"🫧 Oxygen: {oxygen:F1} mg/L";

            if (oxygen < 5.0)
            {
                lblOxygen.ForeColor = Color.FromArgb(255, 80, 80);
                isOxygenAlertBlinking = true;
            }
            else
            {
                lblOxygen.ForeColor = normalText;
                ledOxygen.BackColor = Color.FromArgb(50, 215, 75);
            }

            // ---------------- LIGHT (SPRINT 2) ----------------

            // Step 1 — auto-cycle every tick
            lightControl.UpdateAutoCycle();

            // Step 2 — current light state
            bool isOn = lightControl.IsLightOn;

            // Step 3 — update label with emoji + status
            lblLight.Text = "💡 " + lightControl.GetStatus();
            lblLight.ForeColor = secondaryText;

            // Step 4 — update LED color
            ledLight.BackColor = isOn
                ? Color.FromArgb(50, 215, 75)
                : Color.FromArgb(120, 120, 130);

            // Step 5 — log only when state actually changes
            if (lightControl.CheckForStateChange())
            {
                LogEvent(isOn ? "Light Turned ON" : "Light Turned OFF");
            }

            lblLight.Text = lightControl.GetStatus();
            ledLight.BackColor = lightControl.IsLightOn ? Color().LimeGreen : Color.Gray;

            // ---------------- FEEDER ----------------
            string status = feederControl.GetStatus();
            lblFeeder.Text = $"🐟 Feeder: {status}";
            lblFeeder.ForeColor = secondaryText;
            ledFeeder.BackColor = status == "Feeding"
                ? Color.FromArgb(50, 215, 75)
                : Color.FromArgb(120, 120, 130);

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

            analytics.LogNewEventIfNeeded();

            UpdateAnalyticsUI();
        }

        private void LogEvent(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string category = "";

            if (message.Contains("Temperature")) category = "[TEMP]";
            else if (message.Contains("pH")) category = "[PH]";
            else if (message.Contains("Oxygen")) category = "[OXY]";
            else if (message.Contains("Light")) category = "[LIGHT]";
            else if (message.Contains("Calibration")) category = "[CALIB]";
            else category = "[SYS]";

            string formatted = $"{timestamp} {category} {message}";
            File.AppendAllText("aquarium_log.txt", formatted + Environment.NewLine);

            // Also save in JSON file for analytics (Sprint 3)
            logRepository.AddLog(message);
        }

        // ----------- LED BLINK TIMER ----------------
        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            blinkState = !blinkState;

            if (isTempHotBlinking)
                ledTemp.BackColor = blinkState ? Color.FromArgb(255, 80, 80) : Color.White;

            if (isTempColdBlinking)
                ledTemp.BackColor = blinkState ? Color.FromArgb(80, 150, 255) : Color.White;

            if (isPHAlertBlinking)
                ledPH.BackColor = blinkState ? Color.FromArgb(255, 159, 10) : Color.White;

            if (isOxygenAlertBlinking)
                ledOxygen.BackColor = blinkState ? Color.FromArgb(255, 80, 80) : Color.White;
        }

        // ---------------- UI LOAD ----------------
        private void MainDashboard_Load(object sender, EventArgs e)
        {
            // Round LEDs
            MakeRoundLED(ledTemp);
            MakeRoundLED(ledPH);
            MakeRoundLED(ledOxygen);
            MakeRoundLED(ledLight);
            MakeRoundLED(ledFeeder);

            // Attach glow to LEDs
            AttachLEDGlow(ledTemp);
            AttachLEDGlow(ledPH);
            AttachLEDGlow(ledOxygen);
            AttachLEDGlow(ledLight);
            AttachLEDGlow(ledFeeder);

            // Style cards + hover
            StyleCardPanel(panelTemp);
            StyleCardPanel(panelPH);
            StyleCardPanel(panelOxygen);
            StyleCardPanel(panelLight);
            StyleCardPanel(panelFeeder);

            this.BackColor = Color.WhiteSmoke;

            analytics.LoadLogs();
            // Enable clicking for device tiles (UI only)
            panelLight.Cursor = Cursors.Hand;
            panelFeeder.Cursor = Cursors.Hand;

            panelLight.Click += PanelLight_Click;
            panelFeeder.Click += PanelFeeder_Click;

            // Attach paint handler for rounded glass cards
            panelTemp.Paint += CardPanel_Paint;
            panelPH.Paint += CardPanel_Paint;
            panelOxygen.Paint += CardPanel_Paint;
            panelLight.Paint += CardPanel_Paint;
            panelFeeder.Paint += CardPanel_Paint;

            // Round the top buttons + log button
            MakeRoundedButton(btnDarkMode);
            MakeRoundedButton(btnCalibration);
            MakeRoundedButton(btnViewLog);

            btnViewLog.Width = 160;
            btnViewLog.Height = 36;
            btnViewLog.Padding = new Padding(8, 0, 8, 0);

            // Typography
            ApplyTypography();

            // Apply current light/dark theme
            ApplyThemeFromMode();

            // ------------------------------------------------------
            // COMPACT APPLE-LIKE CENTERED LAYOUT (OPTION A)
            // ------------------------------------------------------
            int tileWidth = 300;
            int tileHeight = 95;  // compact tile height
            int spacing = 25;     // compact spacing between tiles

            // Apply new size to all tiles
            panelTemp.Size = new Size(tileWidth, tileHeight);
            panelPH.Size = new Size(tileWidth, tileHeight);
            panelOxygen.Size = new Size(tileWidth, tileHeight);
            panelLight.Size = new Size(tileWidth, tileHeight);
            panelFeeder.Size = new Size(tileWidth, tileHeight);

            // Compute centered positions
            int totalWidthTop = tileWidth * 3 + spacing * 2;
            int startXTop = (this.ClientSize.Width - totalWidthTop) / 2;

            int topY = 180; // vertical position for top row

            panelTemp.Location = new Point(startXTop, topY);
            panelPH.Location = new Point(startXTop + tileWidth + spacing, topY);
            panelOxygen.Location = new Point(startXTop + (tileWidth + spacing) * 2, topY);

            // Bottom row (2 tiles)
            int totalWidthBottom = tileWidth * 2 + spacing;
            int startXBottom = (this.ClientSize.Width - totalWidthBottom) / 2;

            int bottomY = topY + tileHeight + 120; // space between rows

            panelLight.Location = new Point(startXBottom, bottomY);
            panelFeeder.Location = new Point(startXBottom + tileWidth + spacing, bottomY);

            // Recenter log button
            btnViewLog.Location = new Point(
                (this.ClientSize.Width - btnViewLog.Width) / 2,
                bottomY + tileHeight + 80
            );
        }

        // ---------------- HELPER: LED STYLE ----------------
        private void MakeRoundLED(Panel p)
        {
            p.Width = p.Height;
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, p.Width - 1, p.Height - 1);
                p.Region = new Region(path);
            }
        }

        private void AttachLEDGlow(Panel led)
        {
            led.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, led.Width - 1, led.Height - 1);

                using (var path = new GraphicsPath())
                {
                    path.AddEllipse(rect);
                    using (var glowBrush = new SolidBrush(Color.FromArgb(120, led.BackColor)))
                    {
                        e.Graphics.FillEllipse(glowBrush, rect);
                    }
                }
            };
        }

        // ---------------- HELPER: CARD STYLE + HOVER ----------------
        private void StyleCardPanel(Panel p)
        {
            p.BackColor = Color.Transparent;
            p.BorderStyle = BorderStyle.None;
            p.Padding = new Padding(20, 22, 20, 18);

            p.MouseEnter += Card_MouseEnter;
            p.MouseLeave += Card_MouseLeave;
        }

        private void Card_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Panel panel)
            {
                panel.Tag = true; // hovering
                panel.Invalidate();
            }
        }

        private void Card_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Panel panel)
            {
                panel.Tag = false;
                panel.Invalidate();
            }
        }

        private void CardPanel_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            if (p == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            bool hovering = p.Tag is bool isHovering && isHovering;

            int radius = 18;
            Rectangle cardRect = new Rectangle(0, 0, p.Width - 1, p.Height - 1);

            // -------------------------------------------------
            //  FIXED: Correct Apple-style glass gradient
            // -------------------------------------------------
            Color glassTop, glassBottom;

            if (darkMode)
            {
                glassTop = Color.FromArgb(46, 48, 62);    // slightly brighter for depth
                glassBottom = Color.FromArgb(32, 33, 45);
            }
            else
            {
                glassTop = Color.FromArgb(255, 255, 255);
                glassBottom = Color.FromArgb(238, 240, 245);
            }

            using (var path = CreateRoundedRectangle(cardRect, radius))
            using (var brush = new LinearGradientBrush(cardRect, glassTop, glassBottom, 90f))
            {
                e.Graphics.FillPath(brush, path);
            }

            // -------------------------------------------------
            //  Border
            // -------------------------------------------------
            Color borderColor = darkMode
                ? Color.FromArgb(90, 110, 150)    // subtle blue-grey
                : Color.FromArgb(210, 215, 225);  // soft neutral grey

            using (var path = CreateRoundedRectangle(cardRect, radius))
            using (var pen = new Pen(borderColor, hovering ? 2.0f : 1.4f))
            {
                e.Graphics.DrawPath(pen, path);
            }

            // -------------------------------------------------
            // Shadow (hover lift)
            // -------------------------------------------------
            int shadowOffsetY = hovering ? 5 : 3;
            int shadowAlpha = hovering ? 35 : 20;

            Rectangle shadowRect = new Rectangle(
                cardRect.X,
                cardRect.Y + shadowOffsetY,
                cardRect.Width,
                cardRect.Height);

            using (GraphicsPath shadowPath = CreateRoundedRectangle(shadowRect, radius))
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(shadowAlpha, 0, 0, 0)))
            {
                e.Graphics.FillPath(shadowBrush, shadowPath);
            }

            // -------------------------------------------------
            // Shine overlay (hover)
            // -------------------------------------------------
            if (hovering && !darkMode)  // ONLY in light mode (Apple look)
            {
                Rectangle shineRect = new Rectangle(
                    cardRect.X,
                    cardRect.Y,
                    cardRect.Width,
                    cardRect.Height / 2);

                using (GraphicsPath shinePath = CreateRoundedRectangle(shineRect, radius))
                using (LinearGradientBrush shineBrush = new LinearGradientBrush(
                    shineRect,
                    Color.FromArgb(80, Color.White),
                    Color.FromArgb(0, Color.White),
                    90f))
                {
                    e.Graphics.FillPath(shineBrush, shinePath);
                }
            }
        }

        private GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        // ---------------- HELPER: BUTTONS ----------------
        private void MakeRoundedButton(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;

            b.Height = 34;
            b.Width = 120;

            b.TextAlign = ContentAlignment.MiddleCenter;
            b.ImageAlign = ContentAlignment.MiddleLeft;
            b.Padding = new Padding(10, 0, 10, 0);

            // LIGHT MODE COLORS
            if (darkMode)
            {
                lineSensors.BackColor = Color.FromArgb(55, 58, 68);
                lineSystems.BackColor = Color.FromArgb(55, 58, 68);
            }
            else
            {
                lineSensors.BackColor = Color.FromArgb(200, 205, 210);
                lineSystems.BackColor = Color.FromArgb(200, 205, 210);
            }

            // Apply round region AFTER size is set
            int radius = b.Height;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(b.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(b.Width - radius, b.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, b.Height - radius, radius, radius, 90, 90);
                b.Region = new Region(path);
            }
        }

        // ---------------- TYPOGRAPHY ----------------
        private void ApplyTypography()
        {
            // Try Apple-style variable font; fallback to Segoe UI if missing.
            Font baseFont;
            Font headerFont;
            Font labelFont;

            try
            {
                baseFont = new Font("Segoe UI Variable Display", 11F, FontStyle.Regular);
                headerFont = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
                labelFont = new Font("Segoe UI Variable Display", 13F, FontStyle.Regular);
            }
            catch
            {
                // Fallback fonts (SAFE for all Windows Forms versions)
                baseFont = new Font("Segoe UI", 11F, FontStyle.Regular);
                headerFont = new Font("Segoe UI", 12F, FontStyle.Bold);
                labelFont = new Font("Segoe UI", 13F, FontStyle.Regular);
            }

            this.Font = baseFont;

            lblTemp.Font = labelFont;
            lblPH.Font = labelFont;
            lblOxygen.Font = labelFont;
            lblLight.Font = labelFont;
            lblFeeder.Font = labelFont;

            lblSectionSensors.Font = headerFont;
            lblSectionSystems.Font = headerFont;

            lblSectionSensors.Margin = new Padding(0, 0, 0, 2);
            lblSectionSystems.Margin = new Padding(0, 0, 0, 2);
        }

        // ---------------- BACKGROUND GRADIENT ----------------
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            Color c1 = darkMode
                ? Color.FromArgb(15, 16, 22)
                : Color.FromArgb(240, 244, 252);

            Color c2 = darkMode
                ? Color.FromArgb(5, 5, 12)
                : Color.FromArgb(230, 236, 246);

            using (var brush = new LinearGradientBrush(rect, c1, c2, 90F))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        // ---------------- THEME SWITCH ----------------
        private void ApplyThemeFromMode()
        {
            // Background is handled by OnPaintBackground – just invalidate
            Invalidate();

            btnDarkMode.Text = darkMode ? "☀ Light" : "🌙 Dark";

            MakeRoundedButton(btnDarkMode);
            MakeRoundedButton(btnCalibration);
            MakeRoundedButton(btnViewLog);

            panelTemp.Invalidate();
            panelPH.Invalidate();
            panelOxygen.Invalidate();
            panelLight.Invalidate();
            panelFeeder.Invalidate();

            if (darkMode)
            {
                lblSectionSensors.ForeColor = Color.FromArgb(145, 148, 155);
                lblSectionSystems.ForeColor = Color.FromArgb(145, 148, 155);

                lblSectionSensors.BackColor = Color.Transparent;
                lblSectionSystems.BackColor = Color.Transparent;
            }
            else
            {
                lblSectionSensors.ForeColor = Color.FromArgb(120, 125, 135);
                lblSectionSystems.ForeColor = Color.FromArgb(120, 125, 135);

                lblSectionSensors.BackColor = Color.Transparent;
                lblSectionSystems.BackColor = Color.Transparent;
            }
        }

        // ---------------- DEVICE TILE CLICK EVENTS ----------------
        private void PanelLight_Click(object sender, EventArgs e)
        {
            // TODO (Nifemi): Implement LightControl.Toggle()
            // Example:
            // lightControl.Toggle();
        }

        private void PanelFeeder_Click(object sender, EventArgs e)
        {
            // TODO (Chidera): Implement feederControl.FeedNow();
        }

        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            darkMode = !darkMode;
            ApplyThemeFromMode();
        }

        // VIEW LOG button
        private void btnViewLog_Click(object sender, EventArgs e)
        {
            if (!File.Exists(logFile))
            {
                MessageBox.Show("No events have been logged yet.", "Event Log");
                return;
            }

            string[] lines = File.ReadAllLines(logFile);
            LogViewerForm viewer = new LogViewerForm(lines);
            viewer.ShowDialog(this);
        }

        private void btnCalibration_Click(object sender, EventArgs e)
        {
            CalibrationForm cf = new CalibrationForm();
            cf.ShowDialog();
        }

        private void UpdateAnalyticsUI()
        {
            var tempStats = analytics.GetTemperatureAnalytics();
            lblTempStats.Text =
                $"Temp: Avg {tempStats.Average:F1}°C | Min {tempStats.Min:F1}°C | Max {tempStats.Max:F1}°C";

            var phStats = analytics.GetPHAnalytics();
            lblPHStats.Text =
                $"pH: Avg {phStats.Average:F2} | Min {phStats.Min:F2} | Max {phStats.Max:F2}";

            var oxyStats = analytics.GetOxygenAnalytics();
            lblOxyStats.Text =
                $"Oxy: Avg {oxyStats.Average:F1} | Min {oxyStats.Min:F1} | Max {oxyStats.Max:F1}";

            var alerts = analytics.GetAlertSummary();
            lblAlertSummary.Text =
                $"Alerts → Temp: {alerts.TemperatureAlerts}, pH: {alerts.PHAlerts}, Oxy: {alerts.OxygenAlerts}";
        private void btnManualControls_Click(object sender, EventArgs e)
        {
            var form = new ManualControlForm(lightControl, feederControl);
            form.Show();
        private async void PanelLight_Click(object sender, EventArgs e)
        {
            lightControl.Toggle();
            await feederControl.FeedNow();
            UpdateDashboardUI();
        }
    }
}
