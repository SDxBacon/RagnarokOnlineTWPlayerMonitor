using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using MetroFramework.Drawing;
using RagnarokMonitor_sysinfo;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;

namespace RagnarokMonitor_metro
{
    public partial class MainForm : MetroForm
    {
        private Quobject.SocketIoClientDotNet.Client.Socket UploadSocket;
        private sysinfo sysinfo = new sysinfo();
        private ragnarokMonitor monitor;
        private bool onListenFlag = false;
        
        /* delegate */
        public delegate void updateDataGridView(string val_1, string val_2, string val_3, string val_4);  
        public updateDataGridView updateDataGridView_Var;

        public delegate void notifyMonitorFinish();
        public notifyMonitorFinish notifyMonitorFinish_Var;

        internal delegate List<RagnarokServerInfo> getDataGridViewList();
        internal getDataGridViewList getDataGridViewList_Var;

        public delegate void uploadMonitorResult_callback();
        public uploadMonitorResult_callback uploadMonitorResult_callback_Var;

        public delegate void clearDataGridView();
        public clearDataGridView clearDataGridView_Var;

        public MainForm()
        {
            InitializeComponent();               
        }

        #region Mainform initialize methods region.
        private bool IsUserAdministrator()
        {
            //bool value to hold our return value
            bool isAdmin;
            WindowsIdentity user = null;
            try
            {
                //get the currently logged in user
                user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            finally
            {
                if (user != null)
                    user.Dispose();
            }
            return isAdmin;
        }

        private void initDelegate()
        {
            updateDataGridView_Var = new updateDataGridView(_updateDataGridView);
            notifyMonitorFinish_Var = new notifyMonitorFinish(_notifyMonitorFinish);
            getDataGridViewList_Var = new getDataGridViewList(_getDataGridView_List);
            uploadMonitorResult_callback_Var = new uploadMonitorResult_callback(_uploadMonitorResult_callback);
            clearDataGridView_Var = new clearDataGridView(_clearDataGridView);
        }

        private void initTargetIP_Textbox()
        {
            metro_TargetIP_TextBox.Text = sysinfo.RagnarokOfficialServer.IP;
            return;
        }

        private void initNetworkInterfaceList()
        {
            IPHostEntry HostEntry = Dns.GetHostEntry((Dns.GetHostName()));
            if (HostEntry.AddressList.Length > 0)
            {
                foreach (IPAddress ip in HostEntry.AddressList)
                {
                    if (IPAddress.Parse(ip.ToString()).AddressFamily == AddressFamily.InterNetwork)
                        nwInterfaceList.Items.Add(ip.ToString());
                }
            }
        }

        private void initFormStyleAndTheme()
        {
            metroStyleManager1.Theme = Properties.Settings.Default.MainTheme;
            metroStyleManager1.Style = Properties.Settings.Default.MainStyle;
            //metroStyleManager1.Theme = MetroThemeStyle.Dark;
            //metroStyleManager1.Style = MetroColorStyle.Green;
            Refresh();
        }

        private void initStyleManager()
        {
            this.StyleManager = metroStyleManager1;
            metroGrid1.StyleManager = metroStyleManager1;
            metroTabControl1.StyleManager = metroStyleManager1;
            metroTabPage1.StyleManager = metroStyleManager1;
            metroTabPage2.StyleManager = metroStyleManager1;
            metroTabPage3.StyleManager = metroStyleManager1;
            metroTile_formControl.StyleManager = metroStyleManager1;
            metroTile_gridControl.StyleManager = metroStyleManager1;
            metroTile_uploadResult.StyleManager = metroStyleManager1;
            metroLabel_author.StyleManager = metroStyleManager1;
            metroLabel_version.StyleManager = metroStyleManager1;
            metroLabel_releasedate.StyleManager = metroStyleManager1;
            metroLabel_contact.StyleManager = metroStyleManager1;
            metroLabel1.StyleManager = metroStyleManager1;
            metroLabel2.StyleManager = metroStyleManager1;
            metroLabel3.StyleManager = metroStyleManager1;
            metroLabel4.StyleManager = metroStyleManager1;
            metroLabel5.StyleManager = metroStyleManager1;
            metroLabel6.StyleManager = metroStyleManager1;
            metroButton_start.StyleManager = metroStyleManager1;
            metroButton_StyleChange.StyleManager = metroStyleManager1;
            metroButton_ThemeChange.StyleManager = metroStyleManager1;
            metroButton_gridStyleChange.StyleManager = metroStyleManager1;
            metroButton_gridThemeChange.StyleManager = metroStyleManager1;
            metroLabel_tips.StyleManager = metroStyleManager1;
            metroProgressSpinner_monitor.StyleManager = metroStyleManager1;
            metroTargetIPTile.StyleManager = metroStyleManager1;
            metro_TargetIP_TextBox.StyleManager = metroStyleManager1;
        }

        private void initSysInfo()
        {
            metroLabel_version.Text = sysinfo.Version;
            metroLabel_author.Text = sysinfo.Author;
            metroLabel_releasedate.Text = sysinfo.ReleaseDate;
            metroLabel_contact.Text = sysinfo.Contact;
        }

        #endregion

        #region MainForm Events region.
        private void MainForm_Load(object sender, EventArgs e)
        {
            /* Initital.*/
            initStyleManager();
            initSysInfo();
            initTargetIP_Textbox();
            initFormStyleAndTheme();
            initNetworkInterfaceList();

            /* Initial GridView Style.*/
            StyleGrid(Properties.Settings.Default.GridTheme, Properties.Settings.Default.GridStyle);

            /* Initial ragnarokMonitor.*/
            //monitor = new ragnarokMonitor(this, sysinfo.RagnarokOfficialServer.IP, sysinfo.RagnarokOfficialServer.Port);

            /* Initial delegate.*/
            initDelegate();

            /* check administrator priviliage.*/
            if (!IsUserAdministrator())
            {
                DialogResult result;
                result = MetroMessageBox.Show(this, "注意！您的權限不足，請重新對程式按右鍵，並選擇【以管理員身分執行】。", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            /* set upload toggle value with properties settings of the application. */
            //metroToggle_uploadResult.Checked = Properties.Settings.Default.UploadResult;
        }

        private void MainForm_onclosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Application.Exit();
        }

        private void MainForm_onClosed(object sender, FormClosedEventArgs e)
        {
            /* Save theme and style to settings.*/
            Properties.Settings.Default.MainTheme = metroStyleManager1.Theme;
            Properties.Settings.Default.MainStyle = metroStyleManager1.Style;
            Properties.Settings.Default.GridTheme = metroGrid1.Theme;
            Properties.Settings.Default.GridStyle = metroGrid1.Style;

            Properties.Settings.Default.Save();

            Environment.Exit(1);
        }
        #endregion

        #region Mainform methods.
        public string getNetworkInterfaceText()
        {
            return nwInterfaceList.Text;
        }

        private void uploadResult_Service()
        {
            string uploadServer_IP, uploadServer_Port;

            /* check upload server info.*/
            if (sysinfo.CollectServer == null)
                return;

            uploadServer_IP = sysinfo.CollectServer.IP;
            uploadServer_Port = sysinfo.CollectServer.Port.ToString();

            /* Socket.IO*/
            UploadSocket = IO.Socket("http://" + uploadServer_IP + ":" + uploadServer_Port);
            UploadSocket.On(Quobject.SocketIoClientDotNet.Client.Socket.EVENT_CONNECT, () =>
            {
                UploadSocket.Emit("UploadMonitorResult", JsonConvert.SerializeObject(_getDataGridView_List()));

            });

            UploadSocket.On("UploadSuccess", (data) =>
            {
                Console.WriteLine("Socket.IO Event:CollectSuccess, data:" + data);
                UploadSocket.Disconnect();
                UploadSocket = null;
            });
        }
   
        private void StyleGrid(MetroThemeStyle theme, MetroColorStyle style)
        {
            metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            metroGrid1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            metroGrid1.EnableHeadersVisualStyles = false;
            metroGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            metroGrid1.BackColor = MetroPaint.BackColor.Form(theme);
            metroGrid1.BackgroundColor = MetroPaint.BackColor.Form(theme);
            metroGrid1.GridColor = MetroPaint.BackColor.Form(theme);
            metroGrid1.ForeColor = MetroPaint.ForeColor.Button.Disabled(theme);
            metroGrid1.Font = new Font("Segoe UI", 11f, FontStyle.Regular, GraphicsUnit.Pixel);

            metroGrid1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            metroGrid1.ColumnHeadersDefaultCellStyle.BackColor = MetroPaint.GetStyleColor(style);
            metroGrid1.ColumnHeadersDefaultCellStyle.ForeColor = MetroPaint.ForeColor.Button.Press(theme);

            metroGrid1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            metroGrid1.RowHeadersDefaultCellStyle.BackColor = MetroPaint.GetStyleColor(style);
            metroGrid1.RowHeadersDefaultCellStyle.ForeColor = MetroPaint.ForeColor.Button.Press(theme);

            metroGrid1.DefaultCellStyle.BackColor = MetroPaint.BackColor.Form(theme);

            metroGrid1.DefaultCellStyle.SelectionBackColor = MetroPaint.GetStyleColor(style);
            metroGrid1.DefaultCellStyle.SelectionForeColor = (theme == MetroThemeStyle.Light) ? Color.FromArgb(17, 17, 17) : Color.FromArgb(255, 255, 255);

            metroGrid1.DefaultCellStyle.SelectionBackColor = MetroPaint.GetStyleColor(style);
            metroGrid1.DefaultCellStyle.SelectionForeColor = (theme == MetroThemeStyle.Light) ? Color.FromArgb(17, 17, 17) : Color.FromArgb(255, 255, 255);

            metroGrid1.RowHeadersDefaultCellStyle.SelectionBackColor = MetroPaint.GetStyleColor(style);
            metroGrid1.RowHeadersDefaultCellStyle.SelectionForeColor = (theme == MetroThemeStyle.Light) ? Color.FromArgb(17, 17, 17) : Color.FromArgb(255, 255, 255);

            metroGrid1.ColumnHeadersDefaultCellStyle.SelectionBackColor = MetroPaint.GetStyleColor(style);
            metroGrid1.ColumnHeadersDefaultCellStyle.SelectionForeColor = (theme == MetroThemeStyle.Light) ? Color.FromArgb(17, 17, 17) : Color.FromArgb(255, 255, 255);
        }

        private void metroButton_gridStyleChange_Click(object sender, EventArgs e)
        {
            var m = new Random();
            int next;
            do {
                next = m.Next(0, 13);
            } while ((MetroColorStyle)next == MetroColorStyle.Black || (MetroColorStyle)next == MetroColorStyle.White);
            
            StyleGrid(metroStyleManager1.Theme, (MetroColorStyle)next);
            Refresh();
        }

        private void metroButton_gridThemeChange_Click(object sender, EventArgs e)
        {
            metroGrid1.Theme = (metroGrid1.Theme == MetroThemeStyle.Dark) ? MetroThemeStyle.Light : MetroThemeStyle.Dark;
            StyleGrid(metroGrid1.Theme, metroStyleManager1.Style);
            Refresh();
        }

        private void metroButton_StyleChange_Click(object sender, EventArgs e)
        {
            var m = new Random();
            int next;
            do
            {
                next = m.Next(0, 13);
            } while ((MetroColorStyle)next == MetroColorStyle.Black 
            || (MetroColorStyle)next == MetroColorStyle.White
            || (MetroColorStyle)next == metroStyleManager1.Style);

            metroStyleManager1.Style = (MetroColorStyle)next;
            Refresh();
        }

        private void metroButton_ThemeChange_Click(object sender, EventArgs e)
        {
            metroStyleManager1.Theme = metroStyleManager1.Theme == MetroThemeStyle.Dark ? MetroThemeStyle.Light : MetroThemeStyle.Dark;
            Refresh();
        }

        private void metroButton_start_Click(object sender, EventArgs e)
        {
            if (nwInterfaceList.SelectedIndex == -1)
            {
                MetroMessageBox.Show(this, "請正確選擇一個網路介面卡後，再嘗試開啟監控。", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /* Haven't start monitoring. */           
            if ( !onListenFlag )
            {
                /* check Target IP.*/
                //check parse success or not.
                IPAddress address;
                if ( !IPAddress.TryParse(metro_TargetIP_TextBox.Text, out address) ) 
                {
                    
                    MetroMessageBox.Show(this, "您輸入的目標IP位址有錯誤，請重新輸入。", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //check IPv4
                if (address.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
                {              
                    MetroMessageBox.Show(this, "您輸入的目標IP位址不屬於IPv4，請重新輸入。", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // initial ragnarok monitor.
                monitor = new ragnarokMonitor(this, metro_TargetIP_TextBox.Text, sysinfo.RagnarokOfficialServer.Port);

                if (monitor != null)
                {
                    // show process spin and change button text.
                    metroProcessSpin_display(true);
                    metroButton_start.Text = "Stop";
                    monitor.Run();
                    onListenFlag = true;
                }
                
            }
            /* Monitoring.*/           
            else
            {
                // show process spin and change button text.
                metroProcessSpin_display(false);
                metroButton_start.Text = "Start";
                monitor.Run();
                onListenFlag = false;
                monitor = null;
            }


        }

        private void metroProcessSpin_display(bool val)
        {
            metroProgressSpinner_monitor.Spinning = val;
            metroProgressSpinner_monitor.Visible = val;
        }
        #endregion

        #region Mainform delegate methods region.

        private void _uploadMonitorResult_callback()
        {
            /* User choose to not to upload result to collection server.*/
            //if (!metroToggle_uploadResult.Checked)
            //    return;

            /* User want to upload result to collection server. */
            //uploadResult_Service();
        }

        internal List<RagnarokServerInfo> _getDataGridView_List()
        {
            int rowCount;
            List<RagnarokServerInfo> list = new List<RagnarokServerInfo>();

            rowCount = metroGrid1.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                DataGridViewRow row = metroGrid1.Rows[i];
                RagnarokServerInfo info = new RagnarokServerInfo();
                info.Name = row.Cells[0].Value.ToString();
                info.IP = row.Cells[1].Value.ToString();
                info.Port = row.Cells[2].Value.ToString();
                info.PlayersNumber = row.Cells[3].Value.ToString();
                list.Add(info);
            }
                      
            return list;
        }

        private void _notifyMonitorFinish()
        {
            // show process spin and change button text.
            metroProcessSpin_display(false);
            metroButton_start.Text = "Start";
            onListenFlag = false;
        }

        private void _clearDataGridView()
        {
            metroGrid1.Rows.Clear();
            metroGrid1.Refresh();
        }

        private void _updateDataGridView(string val_1, string val_2, string val_3, string val_4)
        {
            DataGridViewRowCollection rows = metroGrid1.Rows;
            rows.Add(new Object[] { val_1, val_2, val_3, val_4 });
        }

        private void _updateDataGridView_replace(string val_1, string val_2, string val_3, string val_4)
        {
            DataGridViewRow row = metroGrid1.Rows[metroGrid1.RowCount - 1];
            row.Cells[0].Value = val_1;
            row.Cells[1].Value = val_2;
            row.Cells[2].Value = val_3;
            row.Cells[3].Value = val_4;
        }

        private void _updateDataGridView_insert(string val_1, string val_2, string val_3, string val_4)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(metroGrid1, 4);
            row.Cells[0].Value = val_1;
            row.Cells[1].Value = val_2;
            row.Cells[2].Value = val_3;
            row.Cells[3].Value = val_4;
            metroGrid1.Rows.Insert(metroGrid1.RowCount - 1, row);
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
