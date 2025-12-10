using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAquariumController
{
    public partial class LogViewerForm : Form
    {
        private class LogEvent
        {
            public DateTime? Time { get; set; }
            public string RawTimeText { get; set; } = "";
            public string Message { get; set; } = "";
            public string Source { get; set; } = "";   // TEMP / PH / OXY / SYS / FEED / LIGHT
            public string Severity { get; set; } = ""; // Alert / Normal / Info
        }

        private readonly List<LogEvent> _allEvents = new List<LogEvent>();
        private readonly List<LogEvent> _filteredEvents = new List<LogEvent>();

        // --------------------------------------------------------------------
        // Constructors
        // --------------------------------------------------------------------
        public LogViewerForm()
        {
            InitializeComponent();
            InitializeOwnerDrawListView();
            InitializeFilterControls();
        }

        // This is what MainDashboard should call:
        // new LogViewerForm(File.ReadAllLines(logFile)).ShowDialog(this);
        public LogViewerForm(string[] lines) : this()
        {
            if (lines != null)
            {
                LoadFromLines(lines);
            }
        }

        // --------------------------------------------------------------------
        // Initialization helpers
        // --------------------------------------------------------------------
        private void InitializeOwnerDrawListView()
        {
            // Slightly taller rows using a dummy image list
            var img = new ImageList();
            img.ImageSize = new Size(16, 24); // height controls row height
            lvEvents.SmallImageList = img;

            lvEvents.OwnerDraw = true;
            lvEvents.FullRowSelect = true;
            lvEvents.HideSelection = false;

            lvEvents.DrawColumnHeader += LvEvents_DrawColumnHeader;
            lvEvents.DrawItem += LvEvents_DrawItem;
            lvEvents.DrawSubItem += LvEvents_DrawSubItem;
        }

        private void InitializeFilterControls()
        {
            cboFilterSource.Items.Clear();
            cboFilterSource.Items.Add("All sources");
            cboFilterSource.Items.Add("Temperature");
            cboFilterSource.Items.Add("pH");
            cboFilterSource.Items.Add("Oxygen");
            cboFilterSource.Items.Add("System / Light / Feeder");
            cboFilterSource.SelectedIndex = 0;

            cboFilterSeverity.Items.Clear();
            cboFilterSeverity.Items.Add("All severities");
            cboFilterSeverity.Items.Add("Alerts only");
            cboFilterSeverity.Items.Add("Normal only");
            cboFilterSeverity.Items.Add("Info only");
            cboFilterSeverity.SelectedIndex = 0;

            txtSearch.TextChanged += (_, __) => ApplyFilters();
            cboFilterSource.SelectedIndexChanged += (_, __) => ApplyFilters();
            cboFilterSeverity.SelectedIndexChanged += (_, __) => ApplyFilters();
        }

        // --------------------------------------------------------------------
        // Loading + parsing
        // --------------------------------------------------------------------
        public void LoadFromLines(IEnumerable<string> lines)
        {
            _allEvents.Clear();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var ev = ParseLogLine(line);
                _allEvents.Add(ev);
            }

            ApplyFilters();
        }

        private LogEvent ParseLogLine(string line)
        {
            var ev = new LogEvent();
            ev.Message = line.Trim();
            ev.Source = "SYS";
            ev.Severity = "Info";
            ev.RawTimeText = "";

            // ---------- FORMAT A ----------
            // [2025-12-05 18:31:22] [TEMP] Temperature High (31.4 °C)
            if (line.StartsWith("[") && line.IndexOf("]") > 1)
            {
                try
                {
                    int end1 = line.IndexOf("]");
                    string ts = line.Substring(1, end1 - 1).Trim();
                    ev.RawTimeText = ts;

                    if (DateTime.TryParse(ts, out DateTime dt))
                        ev.Time = dt;

                    string rest = line.Substring(end1 + 1).Trim();

                    if (rest.StartsWith("[") && rest.IndexOf("]") > 1)
                    {
                        int end2 = rest.IndexOf("]");
                        ev.Source = rest.Substring(1, end2 - 1).Trim();
                        ev.Message = rest.Substring(end2 + 1).Trim();
                    }
                    else
                    {
                        ev.Message = rest;
                    }

                    ApplySeverity(ev);
                    return ev;
                }
                catch { }
            }

            // ---------- FORMAT B ----------
            // 2025-12-02 14:02:56 Temperature High (...)
            if (char.IsDigit(line[0]))
            {
                string tsPart = line.Substring(0, 19); // yyyy-MM-dd HH:mm:ss

                if (DateTime.TryParse(tsPart, out DateTime dt))
                {
                    ev.Time = dt;
                    ev.RawTimeText = tsPart;
                    ev.Message = line.Substring(19).Trim();
                    ApplySeverity(ev);
                    return ev;
                }
            }

            // ---------- FALLBACK ----------
            ev.Time = DateTime.Now;
            ApplySeverity(ev);
            return ev;
        }

        // Helper
        private void ApplySeverity(LogEvent ev)
        {
            string msg = ev.Message.ToLower();

            if (msg.Contains("high") || msg.Contains("low") || msg.Contains("out of range"))
                ev.Severity = "Alert";
            else if (msg.Contains("back to normal"))
                ev.Severity = "Normal";
            else
                ev.Severity = "Info";
        }

        // --------------------------------------------------------------------
        // Filtering + search
        // --------------------------------------------------------------------
        private void ApplyFilters()
        {
            _filteredEvents.Clear();

            string search = txtSearch.Text.Trim().ToLowerInvariant();
            string srcFilter = cboFilterSource.SelectedItem?.ToString() ?? "All sources";
            string sevFilter = cboFilterSeverity.SelectedItem?.ToString() ?? "All severities";

            foreach (var ev in _allEvents)
            {
                if (!MatchesSourceFilter(ev, srcFilter)) continue;
                if (!MatchesSeverityFilter(ev, sevFilter)) continue;

                if (!string.IsNullOrEmpty(search))
                {
                    if (!(ev.Message.ToLowerInvariant().Contains(search) ||
                          ev.RawTimeText.ToLowerInvariant().Contains(search)))
                        continue;
                }

                _filteredEvents.Add(ev);
            }

            RebuildListView();
            lblStatus.Text = $"Showing {_filteredEvents.Count} of {_allEvents.Count} events.";
        }

        private bool MatchesSourceFilter(LogEvent ev, string srcFilter)
        {
            switch (srcFilter)
            {
                case "Temperature": return ev.Source == "TEMP";
                case "pH": return ev.Source == "PH";
                case "Oxygen": return ev.Source == "OXY";
                case "System / Light / Feeder":
                    return ev.Source == "SYS" || ev.Source == "LIGHT" || ev.Source == "FEED";
                default: // All sources
                    return true;
            }
        }

        private bool MatchesSeverityFilter(LogEvent ev, string sevFilter)
        {
            switch (sevFilter)
            {
                case "Alerts only": return ev.Severity == "Alert";
                case "Normal only": return ev.Severity == "Normal";
                case "Info only": return ev.Severity == "Info";
                default:
                    return true;
            }
        }

        private void RebuildListView()
        {
            lvEvents.BeginUpdate();
            lvEvents.Items.Clear();

            foreach (var ev in _filteredEvents)
            {
                var item = new ListViewItem(""); // icon column
                item.Tag = ev;

                string cleanTime = (ev.Time?.ToString("yyyy-MM-dd HH:mm:ss") ?? ev.RawTimeText).Trim();
                string cleanMsg = (ev.Message ?? "").Trim(); // <<< CRITICAL FIX

                item.SubItems.Add(cleanTime);
                item.SubItems.Add(cleanMsg);

                lvEvents.Items.Add(item);
            }

            lvEvents.EndUpdate();
        }

        // --------------------------------------------------------------------
        // Owner draw: row spacing, indent, colour
        // --------------------------------------------------------------------
        private void LvEvents_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var backBrush = new SolidBrush(Color.FromArgb(245, 245, 248)))
            using (var borderPen = new Pen(Color.FromArgb(210, 210, 215)))
            using (var textBrush = new SolidBrush(Color.FromArgb(80, 80, 90)))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                e.Graphics.DrawRectangle(borderPen, e.Bounds);

                var textRect = e.Bounds;
                textRect.X += 8;
                textRect.Y += 4;

                using (var font = new Font(Font, FontStyle.Bold))
                {
                    e.Graphics.DrawString(e.Header.Text, font, textBrush, textRect);
                }
            }
        }

        private void LvEvents_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // We draw everything in DrawSubItem, but this needs to be here
            // to prevent default drawing.
        }

        private void LvEvents_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            var ev = e.Item.Tag as LogEvent;
            if (ev == null)
            {
                e.DrawDefault = true;
                return;
            }

            bool selected = (e.ItemState & ListViewItemStates.Selected) != 0;

            // Background ------------------------------------------------------
            Color backColor = selected
                ? Color.FromArgb(45, 100, 220)
                : (e.ItemIndex % 2 == 0
                    ? Color.FromArgb(255, 255, 255)
                    : Color.FromArgb(248, 248, 251));

            Rectangle bg = e.Bounds;
            bg.Inflate(0, -2);

            using (var backBrush = new SolidBrush(backColor))
                e.Graphics.FillRectangle(backBrush, bg);

            using (var pen = new Pen(Color.FromArgb(230, 230, 235)))
                e.Graphics.DrawRectangle(pen, bg);

            // Text / icons ----------------------------------------------------
            // ALWAYS recompute textRect fresh per subitem
            Rectangle textRect = e.Bounds;
            textRect.Inflate(-8, -4); // uniform padding

            using (var regularBrush = new SolidBrush(selected ? Color.White : Color.FromArgb(40, 40, 45)))
            using (var greenBrush = new SolidBrush(selected ? Color.White : Color.FromArgb(0, 140, 70)))
            using (var redBrush = new SolidBrush(selected ? Color.White : Color.FromArgb(210, 60, 50)))
            using (var orangeBrush = new SolidBrush(selected ? Color.White : Color.FromArgb(214, 126, 10)))
            using (var grayBrush = new SolidBrush(selected ? Color.White : Color.FromArgb(120, 120, 130)))
            {
                if (e.ColumnIndex == 0)
                {
                    // Icon column (force alignment at left)
                    textRect.X = e.Bounds.Left + 8;

                    string icon = "✓";
                    Brush brush = greenBrush;

                    if (ev.Severity == "Alert")
                    {
                        icon = "⚠";
                        brush = redBrush;
                    }
                    else if (ev.Severity == "Info")
                    {
                        icon = "i";
                        brush = grayBrush;
                    }

                    e.Graphics.DrawString(icon, Font, brush, textRect);
                }
                else if (e.ColumnIndex == 1)
                {
                    // Time column (force alignment under "Time" header)
                    textRect.X = e.Bounds.Left + 8;
                    e.Graphics.DrawString(e.SubItem.Text, Font, grayBrush, textRect);
                }
                else
                {
                    // Event column (force alignment under "Event" header)
                    textRect.X = e.Bounds.Left + 8;

                    Brush brush = regularBrush;
                    string lower = ev.Message.ToLowerInvariant();

                    if (ev.Severity == "Alert")
                        brush = lower.Contains("high") ? redBrush : orangeBrush;
                    else if (ev.Severity == "Normal")
                        brush = greenBrush;
                    else if (ev.Severity == "Info")
                        brush = grayBrush;

                    e.Graphics.DrawString(e.SubItem.Text, Font, brush, textRect);
                }
            }
        }

        // --------------------------------------------------------------------
        // CSV Export
        // --------------------------------------------------------------------
        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (_filteredEvents.Count == 0)
            {
                MessageBox.Show("There are no events to export.", "Export Log",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FileName = "aquarium-log.csv";

                if (sfd.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("Time,Source,Severity,Message");

                    foreach (var ev in _filteredEvents)
                    {
                        string time = ev.Time?.ToString("yyyy-MM-dd HH:mm:ss")
                                      ?? ev.RawTimeText.Replace(",", " ");
                        string source = ev.Source.Replace(",", " ");
                        string severity = ev.Severity.Replace(",", " ");
                        string msg = ev.Message.Replace("\"", "\"\"");

                        sb.AppendLine($"\"{time}\",\"{source}\",\"{severity}\",\"{msg}\"");
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("CSV exported successfully.", "Export Log",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to export CSV:\n" + ex.Message, "Export Log",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
