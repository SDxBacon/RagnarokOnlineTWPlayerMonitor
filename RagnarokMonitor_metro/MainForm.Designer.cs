namespace RagnarokMonitor_metro
{
    partial class MainForm
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.colServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServerPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlayerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroButton_gridStyleChange = new MetroFramework.Controls.MetroButton();
            this.metroButton_start = new MetroFramework.Controls.MetroButton();
            this.nwInterfaceList = new MetroFramework.Controls.MetroComboBox();
            this.metroButton_StyleChange = new MetroFramework.Controls.MetroButton();
            this.metroButton_ThemeChange = new MetroFramework.Controls.MetroButton();
            this.metroButton_gridThemeChange = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroProgressSpinner_monitor = new MetroFramework.Controls.MetroProgressSpinner();
            this.metroLabel_tips = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metro_TargetIP_TextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroTargetIPTile = new MetroFramework.Controls.MetroTile();
            this.metroTile_uploadResult = new MetroFramework.Controls.MetroTile();
            this.metroTile_gridControl = new MetroFramework.Controls.MetroTile();
            this.metroTile_formControl = new MetroFramework.Controls.MetroTile();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.metroLabel_contact = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_releasedate = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_author = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_version = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToAddRows = false;
            this.metroGrid1.AllowUserToDeleteRows = false;
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colServerName,
            this.colServerIP,
            this.colServerPort,
            this.colPlayerNumber});
            this.metroGrid1.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(301, 18);
            this.metroGrid1.Margin = new System.Windows.Forms.Padding(4);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.ReadOnly = true;
            this.metroGrid1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid1.RowHeadersVisible = false;
            this.metroGrid1.RowHeadersWidth = 51;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.RowTemplate.Height = 24;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(681, 211);
            this.metroGrid1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroGrid1.TabIndex = 0;
            this.metroGrid1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroGrid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_CellContentClick);
            // 
            // colServerName
            // 
            this.colServerName.HeaderText = "伺服器名稱";
            this.colServerName.MinimumWidth = 6;
            this.colServerName.Name = "colServerName";
            this.colServerName.ReadOnly = true;
            // 
            // colServerIP
            // 
            this.colServerIP.HeaderText = "IP";
            this.colServerIP.MinimumWidth = 6;
            this.colServerIP.Name = "colServerIP";
            this.colServerIP.ReadOnly = true;
            // 
            // colServerPort
            // 
            this.colServerPort.HeaderText = "Port";
            this.colServerPort.MinimumWidth = 6;
            this.colServerPort.Name = "colServerPort";
            this.colServerPort.ReadOnly = true;
            // 
            // colPlayerNumber
            // 
            this.colPlayerNumber.HeaderText = "伺服器人數";
            this.colPlayerNumber.MinimumWidth = 6;
            this.colPlayerNumber.Name = "colPlayerNumber";
            this.colPlayerNumber.ReadOnly = true;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            // 
            // metroButton_gridStyleChange
            // 
            this.metroButton_gridStyleChange.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton_gridStyleChange.Location = new System.Drawing.Point(245, 82);
            this.metroButton_gridStyleChange.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton_gridStyleChange.Name = "metroButton_gridStyleChange";
            this.metroButton_gridStyleChange.Size = new System.Drawing.Size(137, 54);
            this.metroButton_gridStyleChange.TabIndex = 1;
            this.metroButton_gridStyleChange.Text = "Style Change";
            this.metroButton_gridStyleChange.UseSelectable = true;
            this.metroButton_gridStyleChange.Click += new System.EventHandler(this.metroButton_gridStyleChange_Click);
            // 
            // metroButton_start
            // 
            this.metroButton_start.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton_start.Location = new System.Drawing.Point(131, 169);
            this.metroButton_start.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton_start.Name = "metroButton_start";
            this.metroButton_start.Size = new System.Drawing.Size(163, 60);
            this.metroButton_start.TabIndex = 2;
            this.metroButton_start.Text = "Start";
            this.metroButton_start.UseSelectable = true;
            this.metroButton_start.Click += new System.EventHandler(this.metroButton_start_Click);
            // 
            // nwInterfaceList
            // 
            this.nwInterfaceList.FormattingEnabled = true;
            this.nwInterfaceList.ItemHeight = 24;
            this.nwInterfaceList.Location = new System.Drawing.Point(25, 109);
            this.nwInterfaceList.Margin = new System.Windows.Forms.Padding(4);
            this.nwInterfaceList.Name = "nwInterfaceList";
            this.nwInterfaceList.Size = new System.Drawing.Size(267, 30);
            this.nwInterfaceList.TabIndex = 4;
            this.nwInterfaceList.UseSelectable = true;
            // 
            // metroButton_StyleChange
            // 
            this.metroButton_StyleChange.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton_StyleChange.Location = new System.Drawing.Point(245, 21);
            this.metroButton_StyleChange.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton_StyleChange.Name = "metroButton_StyleChange";
            this.metroButton_StyleChange.Size = new System.Drawing.Size(137, 54);
            this.metroButton_StyleChange.TabIndex = 7;
            this.metroButton_StyleChange.Text = "Style Change";
            this.metroButton_StyleChange.UseSelectable = true;
            this.metroButton_StyleChange.Click += new System.EventHandler(this.metroButton_StyleChange_Click);
            // 
            // metroButton_ThemeChange
            // 
            this.metroButton_ThemeChange.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton_ThemeChange.Location = new System.Drawing.Point(409, 21);
            this.metroButton_ThemeChange.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton_ThemeChange.Name = "metroButton_ThemeChange";
            this.metroButton_ThemeChange.Size = new System.Drawing.Size(141, 54);
            this.metroButton_ThemeChange.TabIndex = 8;
            this.metroButton_ThemeChange.Text = "Theme Change";
            this.metroButton_ThemeChange.UseSelectable = true;
            this.metroButton_ThemeChange.Click += new System.EventHandler(this.metroButton_ThemeChange_Click);
            // 
            // metroButton_gridThemeChange
            // 
            this.metroButton_gridThemeChange.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton_gridThemeChange.Location = new System.Drawing.Point(409, 82);
            this.metroButton_gridThemeChange.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton_gridThemeChange.Name = "metroButton_gridThemeChange";
            this.metroButton_gridThemeChange.Size = new System.Drawing.Size(141, 54);
            this.metroButton_gridThemeChange.TabIndex = 9;
            this.metroButton_gridThemeChange.Text = "Theme Change";
            this.metroButton_gridThemeChange.UseSelectable = true;
            this.metroButton_gridThemeChange.Click += new System.EventHandler(this.metroButton_gridThemeChange_Click);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.metroTabControl1.Location = new System.Drawing.Point(23, 60);
            this.metroTabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(997, 311);
            this.metroTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.metroProgressSpinner_monitor);
            this.metroTabPage1.Controls.Add(this.metroLabel_tips);
            this.metroTabPage1.Controls.Add(this.nwInterfaceList);
            this.metroTabPage1.Controls.Add(this.metroButton_start);
            this.metroTabPage1.Controls.Add(this.metroGrid1);
            this.metroTabPage1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 12;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 44);
            this.metroTabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(989, 263);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Monitor";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 13;
            // 
            // metroProgressSpinner_monitor
            // 
            this.metroProgressSpinner_monitor.Location = new System.Drawing.Point(77, 185);
            this.metroProgressSpinner_monitor.Margin = new System.Windows.Forms.Padding(4);
            this.metroProgressSpinner_monitor.Maximum = 100;
            this.metroProgressSpinner_monitor.Name = "metroProgressSpinner_monitor";
            this.metroProgressSpinner_monitor.Size = new System.Drawing.Size(45, 44);
            this.metroProgressSpinner_monitor.Spinning = false;
            this.metroProgressSpinner_monitor.TabIndex = 6;
            this.metroProgressSpinner_monitor.UseSelectable = true;
            this.metroProgressSpinner_monitor.Value = 35;
            this.metroProgressSpinner_monitor.Visible = false;
            // 
            // metroLabel_tips
            // 
            this.metroLabel_tips.AutoSize = true;
            this.metroLabel_tips.ForeColor = System.Drawing.Color.Tomato;
            this.metroLabel_tips.Location = new System.Drawing.Point(20, 59);
            this.metroLabel_tips.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel_tips.Name = "metroLabel_tips";
            this.metroLabel_tips.Size = new System.Drawing.Size(233, 20);
            this.metroLabel_tips.TabIndex = 5;
            this.metroLabel_tips.Text = "請選擇網路介面卡後，點選開始";
            this.metroLabel_tips.UseCustomForeColor = true;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroLabel6);
            this.metroTabPage2.Controls.Add(this.metroLabel5);
            this.metroTabPage2.Controls.Add(this.metro_TargetIP_TextBox);
            this.metroTabPage2.Controls.Add(this.metroTargetIPTile);
            this.metroTabPage2.Controls.Add(this.metroTile_uploadResult);
            this.metroTabPage2.Controls.Add(this.metroTile_gridControl);
            this.metroTabPage2.Controls.Add(this.metroTile_formControl);
            this.metroTabPage2.Controls.Add(this.metroButton_gridThemeChange);
            this.metroTabPage2.Controls.Add(this.metroButton_ThemeChange);
            this.metroTabPage2.Controls.Add(this.metroButton_gridStyleChange);
            this.metroTabPage2.Controls.Add(this.metroButton_StyleChange);
            this.metroTabPage2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 12;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 44);
            this.metroTabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(989, 263);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Settings";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 13;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BackColor = System.Drawing.SystemColors.Control;
            this.metroLabel6.Enabled = false;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(841, 225);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(96, 25);
            this.metroLabel6.TabIndex = 19;
            this.metroLabel6.Text = "2019/11/1";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Enabled = false;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(245, 205);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(127, 25);
            this.metroLabel5.TabIndex = 18;
            this.metroLabel5.Text = "219.84.200.54";
            this.metroLabel5.Click += new System.EventHandler(this.metroLabel5_Click);
            // 
            // metro_TargetIP_TextBox
            // 
            // 
            // 
            // 
            this.metro_TargetIP_TextBox.CustomButton.Image = null;
            this.metro_TargetIP_TextBox.CustomButton.Location = new System.Drawing.Point(277, 1);
            this.metro_TargetIP_TextBox.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.metro_TargetIP_TextBox.CustomButton.Name = "";
            this.metro_TargetIP_TextBox.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.metro_TargetIP_TextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metro_TargetIP_TextBox.CustomButton.TabIndex = 1;
            this.metro_TargetIP_TextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metro_TargetIP_TextBox.CustomButton.UseSelectable = true;
            this.metro_TargetIP_TextBox.CustomButton.Visible = false;
            this.metro_TargetIP_TextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metro_TargetIP_TextBox.Lines = new string[] {
        "metroTextBox1"};
            this.metro_TargetIP_TextBox.Location = new System.Drawing.Point(245, 158);
            this.metro_TargetIP_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.metro_TargetIP_TextBox.MaxLength = 32767;
            this.metro_TargetIP_TextBox.Name = "metro_TargetIP_TextBox";
            this.metro_TargetIP_TextBox.PasswordChar = '\0';
            this.metro_TargetIP_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metro_TargetIP_TextBox.SelectedText = "";
            this.metro_TargetIP_TextBox.SelectionLength = 0;
            this.metro_TargetIP_TextBox.SelectionStart = 0;
            this.metro_TargetIP_TextBox.ShortcutsEnabled = true;
            this.metro_TargetIP_TextBox.Size = new System.Drawing.Size(305, 29);
            this.metro_TargetIP_TextBox.TabIndex = 15;
            this.metro_TargetIP_TextBox.Text = "metroTextBox1";
            this.metro_TargetIP_TextBox.UseSelectable = true;
            this.metro_TargetIP_TextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metro_TargetIP_TextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTargetIPTile
            // 
            this.metroTargetIPTile.ActiveControl = null;
            this.metroTargetIPTile.Location = new System.Drawing.Point(28, 144);
            this.metroTargetIPTile.Margin = new System.Windows.Forms.Padding(4);
            this.metroTargetIPTile.Name = "metroTargetIPTile";
            this.metroTargetIPTile.Size = new System.Drawing.Size(173, 42);
            this.metroTargetIPTile.TabIndex = 14;
            this.metroTargetIPTile.Text = "Target IP";
            this.metroTargetIPTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTargetIPTile.UseSelectable = true;
            // 
            // metroTile_uploadResult
            // 
            this.metroTile_uploadResult.ActiveControl = null;
            this.metroTile_uploadResult.Location = new System.Drawing.Point(28, 194);
            this.metroTile_uploadResult.Margin = new System.Windows.Forms.Padding(4);
            this.metroTile_uploadResult.Name = "metroTile_uploadResult";
            this.metroTile_uploadResult.Size = new System.Drawing.Size(173, 42);
            this.metroTile_uploadResult.TabIndex = 12;
            this.metroTile_uploadResult.Text = "IP Ref.";
            this.metroTile_uploadResult.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile_uploadResult.UseSelectable = true;
            // 
            // metroTile_gridControl
            // 
            this.metroTile_gridControl.ActiveControl = null;
            this.metroTile_gridControl.Location = new System.Drawing.Point(28, 82);
            this.metroTile_gridControl.Margin = new System.Windows.Forms.Padding(4);
            this.metroTile_gridControl.Name = "metroTile_gridControl";
            this.metroTile_gridControl.Size = new System.Drawing.Size(173, 54);
            this.metroTile_gridControl.TabIndex = 11;
            this.metroTile_gridControl.Text = "Grid Control";
            this.metroTile_gridControl.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile_gridControl.UseSelectable = true;
            // 
            // metroTile_formControl
            // 
            this.metroTile_formControl.ActiveControl = null;
            this.metroTile_formControl.Location = new System.Drawing.Point(28, 21);
            this.metroTile_formControl.Margin = new System.Windows.Forms.Padding(4);
            this.metroTile_formControl.Name = "metroTile_formControl";
            this.metroTile_formControl.Size = new System.Drawing.Size(173, 54);
            this.metroTile_formControl.TabIndex = 10;
            this.metroTile_formControl.Text = "Form Control";
            this.metroTile_formControl.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile_formControl.UseSelectable = true;
            this.metroTile_formControl.UseTileImage = true;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.metroLink1);
            this.metroTabPage3.Controls.Add(this.metroLabel_contact);
            this.metroTabPage3.Controls.Add(this.metroLabel_releasedate);
            this.metroTabPage3.Controls.Add(this.metroLabel_author);
            this.metroTabPage3.Controls.Add(this.metroLabel_version);
            this.metroTabPage3.Controls.Add(this.metroLabel4);
            this.metroTabPage3.Controls.Add(this.metroLabel3);
            this.metroTabPage3.Controls.Add(this.metroLabel2);
            this.metroTabPage3.Controls.Add(this.metroLabel1);
            this.metroTabPage3.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 12;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 44);
            this.metroTabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(989, 263);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "About";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 13;
            // 
            // metroLink1
            // 
            this.metroLink1.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.metroLink1.Location = new System.Drawing.Point(365, 191);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(628, 33);
            this.metroLink1.TabIndex = 1;
            this.metroLink1.Text = "N/A";
            this.metroLink1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink1.UseSelectable = true;
            this.metroLink1.Click += new System.EventHandler(this.metroLink1_Click);
            // 
            // metroLabel_contact
            // 
            this.metroLabel_contact.Location = new System.Drawing.Point(0, 0);
            this.metroLabel_contact.Name = "metroLabel_contact";
            this.metroLabel_contact.Size = new System.Drawing.Size(100, 23);
            this.metroLabel_contact.TabIndex = 2;
            // 
            // metroLabel_releasedate
            // 
            this.metroLabel_releasedate.AutoSize = true;
            this.metroLabel_releasedate.Enabled = false;
            this.metroLabel_releasedate.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel_releasedate.Location = new System.Drawing.Point(365, 139);
            this.metroLabel_releasedate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel_releasedate.Name = "metroLabel_releasedate";
            this.metroLabel_releasedate.Size = new System.Drawing.Size(43, 25);
            this.metroLabel_releasedate.TabIndex = 8;
            this.metroLabel_releasedate.Text = "N/A";
            // 
            // metroLabel_author
            // 
            this.metroLabel_author.AutoSize = true;
            this.metroLabel_author.Enabled = false;
            this.metroLabel_author.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel_author.Location = new System.Drawing.Point(365, 34);
            this.metroLabel_author.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel_author.Name = "metroLabel_author";
            this.metroLabel_author.Size = new System.Drawing.Size(43, 25);
            this.metroLabel_author.TabIndex = 7;
            this.metroLabel_author.Text = "N/A";
            // 
            // metroLabel_version
            // 
            this.metroLabel_version.AutoSize = true;
            this.metroLabel_version.Enabled = false;
            this.metroLabel_version.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel_version.Location = new System.Drawing.Point(365, 86);
            this.metroLabel_version.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel_version.Name = "metroLabel_version";
            this.metroLabel_version.Size = new System.Drawing.Size(43, 25);
            this.metroLabel_version.TabIndex = 6;
            this.metroLabel_version.Text = "N/A";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(59, 191);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(78, 25);
            this.metroLabel4.TabIndex = 5;
            this.metroLabel4.Text = "Contact";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(59, 139);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(122, 25);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Release Date";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(59, 34);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(72, 25);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Author";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(59, 86);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(75, 25);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Version";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1041, 396);
            this.Controls.Add(this.metroTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(0, 75, 0, 0);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.SystemShadow;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Ragnarok線上人數監控";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_onClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroGrid metroGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServerIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServerPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlayerNumber;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroButton metroButton_gridStyleChange;
        private MetroFramework.Controls.MetroButton metroButton_start;
        private MetroFramework.Controls.MetroComboBox nwInterfaceList;
        private MetroFramework.Controls.MetroButton metroButton_StyleChange;
        private MetroFramework.Controls.MetroButton metroButton_ThemeChange;
        private MetroFramework.Controls.MetroButton metroButton_gridThemeChange;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTile metroTile_formControl;
        private MetroFramework.Controls.MetroTile metroTile_uploadResult;
        private MetroFramework.Controls.MetroTile metroTile_gridControl;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel_contact;
        private MetroFramework.Controls.MetroLabel metroLabel_releasedate;
        private MetroFramework.Controls.MetroLabel metroLabel_author;
        private MetroFramework.Controls.MetroLabel metroLabel_version;
        private MetroFramework.Controls.MetroLabel metroLabel_tips;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner_monitor;
        private MetroFramework.Controls.MetroTile metroTargetIPTile;
        private MetroFramework.Controls.MetroTextBox metro_TargetIP_TextBox;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLink metroLink1;
    }
}

