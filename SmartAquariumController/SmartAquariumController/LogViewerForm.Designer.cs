namespace SmartAquariumController
{
    partial class LogViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvEvents = new System.Windows.Forms.ListView();
            this.colIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilterSource = new System.Windows.Forms.Label();
            this.cboFilterSource = new System.Windows.Forms.ComboBox();
            this.lblFilterSeverity = new System.Windows.Forms.Label();
            this.cboFilterSeverity = new System.Windows.Forms.ComboBox();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.panelTop.Size = new System.Drawing.Size(884, 44);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 8);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Event Log Viewer";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(797, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.White;
            this.panelFilters.Controls.Add(this.btnExportCsv);
            this.panelFilters.Controls.Add(this.cboFilterSeverity);
            this.panelFilters.Controls.Add(this.lblFilterSeverity);
            this.panelFilters.Controls.Add(this.cboFilterSource);
            this.panelFilters.Controls.Add(this.lblFilterSource);
            this.panelFilters.Controls.Add(this.txtSearch);
            this.panelFilters.Controls.Add(this.lblSearch);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 44);
            this.panelFilters.Margin = new System.Windows.Forms.Padding(4);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Padding = new System.Windows.Forms.Padding(12, 8, 12, 12);
            this.panelFilters.Size = new System.Drawing.Size(884, 60);
            this.panelFilters.Height = 70;
            this.panelFilters.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(16, 13);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(53, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(76, 10);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(210, 25);
            this.txtSearch.TabIndex = 1;
            // 
            // lblFilterSource
            // 
            this.lblFilterSource.AutoSize = true;
            this.lblFilterSource.Location = new System.Drawing.Point(304, 13);
            this.lblFilterSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilterSource.Name = "lblFilterSource";
            this.lblFilterSource.Size = new System.Drawing.Size(54, 17);
            this.lblFilterSource.TabIndex = 2;
            this.lblFilterSource.Text = "Source:";
            // 
            // cboFilterSource
            // 
            this.cboFilterSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterSource.FormattingEnabled = true;
            this.cboFilterSource.Location = new System.Drawing.Point(366, 10);
            this.cboFilterSource.Margin = new System.Windows.Forms.Padding(4);
            this.cboFilterSource.Name = "cboFilterSource";
            this.cboFilterSource.Size = new System.Drawing.Size(150, 25);
            this.cboFilterSource.TabIndex = 3;
            // 
            // lblFilterSeverity
            // 
            this.lblFilterSeverity.AutoSize = true;
            this.lblFilterSeverity.Location = new System.Drawing.Point(528, 13);
            this.lblFilterSeverity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilterSeverity.Name = "lblFilterSeverity";
            this.lblFilterSeverity.Size = new System.Drawing.Size(60, 17);
            this.lblFilterSeverity.TabIndex = 4;
            this.lblFilterSeverity.Text = "Severity:";
            // 
            // cboFilterSeverity
            // 
            this.cboFilterSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterSeverity.FormattingEnabled = true;
            this.cboFilterSeverity.Location = new System.Drawing.Point(597, 10);
            this.cboFilterSeverity.Margin = new System.Windows.Forms.Padding(4);
            this.cboFilterSeverity.Name = "cboFilterSeverity";
            this.cboFilterSeverity.Size = new System.Drawing.Size(150, 25);
            this.cboFilterSeverity.TabIndex = 5;
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportCsv.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExportCsv.Location = new System.Drawing.Point(761, 9);
            this.btnExportCsv.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(99, 27);
            this.btnExportCsv.TabIndex = 6;
            this.btnExportCsv.Text = "Export CSV";
            this.btnExportCsv.UseVisualStyleBackColor = true;
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            // 
            // lvEvents
            // 
            this.lvEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIcon,
            this.colTime,
            this.colEvent});
            this.lvEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEvents.Location = new System.Drawing.Point(0, 104);
            this.lvEvents.Margin = new System.Windows.Forms.Padding(4);
            this.lvEvents.MultiSelect = false;
            this.lvEvents.Name = "lvEvents";
            this.lvEvents.Size = new System.Drawing.Size(884, 413);
            this.lvEvents.TabIndex = 2;
            this.lvEvents.UseCompatibleStateImageBehavior = false;
            this.lvEvents.View = System.Windows.Forms.View.Details;
            // 
            // colIcon
            // 
            this.colIcon.Text = "";
            this.colIcon.Width = 30;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.Width = 180;
            // 
            // colEvent
            // 
            this.colEvent.Text = "Event";
            this.colEvent.Width = 640;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBottom.Controls.Add(this.lblStatus);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 517);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.panelBottom.Size = new System.Drawing.Size(884, 30);
            this.panelBottom.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(12, 4);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(860, 22);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Loaded 0 events.";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 547);
            this.Controls.Add(this.lvEvents);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "LogViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Event Log Viewer";
            this.panelTop.ResumeLayout(false);
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvEvents;
        private System.Windows.Forms.ColumnHeader colIcon;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colEvent;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilterSource;
        private System.Windows.Forms.ComboBox cboFilterSource;
        private System.Windows.Forms.Label lblFilterSeverity;
        private System.Windows.Forms.ComboBox cboFilterSeverity;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Panel panelBottom;
    }
}
