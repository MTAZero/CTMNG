using DAO.DataProvider;
using EXONSYSTEM.Layout;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Drawing.Html;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Data.Entity;

namespace EXONSYSTEM.Common
{
	public class Controllers
	{
		private static Controllers instance;
		public static Controllers Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Controllers();
				}
				return instance;
			}
		}
		private Controllers() { }
		public string HandleCountDown(int timer)
		{
			string stringTime = string.Empty;
			int m = timer / 60;
			int s = timer - m * 60;
			stringTime += m < 10 ? "0" + m.ToString() : m.ToString();
			stringTime += ":";
			stringTime += s < 10 ? "0" + s.ToString() : s.ToString();

			return stringTime;
		}
		public string HandleDuration(int timer)
		{
			string stringTime = string.Empty;
			int m = timer / 60;
			stringTime += m < 10 ? "0" + m.ToString() : m.ToString();
			return stringTime;
		}
		public int ConvertDateTimeToUnix(DateTime dt)
		{
			return Convert.ToInt32((dt.Subtract(Constant.DATETIME_ORIGINAL_DATE)).TotalSeconds);
		}
		public DateTime ConvertUnixToDateTime(int unix)
		{
			DateTime dt = Constant.DATETIME_ORIGINAL_DATE;
			return dt.AddSeconds(unix);
		}

		public string ConvertToThreadName(int cType)
		{
			switch (cType)
			{
				// CONTROL_QUESTION
				case 1:
					return "CONTROL_QUESTION";
				// LAYOUT_QUESTION
				case 2:
					return "LAYOUT_QUESTION";
				// CONTROL_BUTTON
				case 3:
					return "CONTROL_BUTTON";
				// LAYOUT_BUTTON
				case 4:
					return "LAYOUT_BUTTON";
				// RADIO_PERFORMCLICK
				case 5:
					return "RADIO_PERFORMCLICK";
				default:
					return string.Empty;
			}
		}

		public string GetSex(int sex)
		{
			if (sex == 0)
			{
				return Properties.Resources.MSG_GUI_0031;
			}
			else
			{
				return Properties.Resources.MSG_GUI_0030;
			}
		}
		public string CapitalizeString(string str)
		{
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
		}
		public string FromListSubQuestionToJSON(List<SubQuestion> lstSubquest)
		{
			return new JavaScriptSerializer().Serialize(lstSubquest);
		}
		private List<SubQuestion> FromJSONToListSubQuestion(string json)
		{
			return new JavaScriptSerializer().Deserialize<List<SubQuestion>>(json);
		}
		public void GenerateConfigFile(ConfigApplication ca, out ErrorController EC)
		{
			try
			{
				// COMMON
				INIHelper.Instance.WRITE(Constant.SECTION_COMMON, "Password", Constant.ENCRYPT_PASS_HASH);

				// SUPERVISOR
				INIHelper.Instance.WRITE(Constant.SECTION_SUPERVISOR, "IP", ca.Supervisor.IP);
				INIHelper.Instance.WRITE(Constant.SECTION_SUPERVISOR, "PORT", ca.Supervisor.Port.ToString());

				// DATABASE
				INIHelper.Instance.WRITE(Constant.SECTION_DATABASE, "IP", ca.Database.IP);
				INIHelper.Instance.WRITE(Constant.SECTION_DATABASE, "PORT", ca.Database.Port.ToString());
				INIHelper.Instance.WRITE(Constant.SECTION_DATABASE, "DBName", ca.DBName);
				INIHelper.Instance.WRITE(Constant.SECTION_DATABASE, "Username", ca.UsernameDB);
				INIHelper.Instance.WRITE(Constant.SECTION_DATABASE, "Password", ca.PasswordDB);

				Encryption.Instance.EncryptConfigFile(Constant.PATH_CONFIG_FILE_TMP, Constant.PATH_CONFIG_FILE, out EC);
				if (EC.ErrorCode == Constant.STATUS_OK)
				{
					File.Delete(Constant.PATH_CONFIG_FILE_TMP);
					FileInfo configFile = new FileInfo(Constant.PATH_CONFIG_FILE);
					configFile.Attributes = FileAttributes.Hidden;
					EC = new ErrorController(Constant.STATUS_OK, "Config file created at " + Constant.PATH_CONFIG_FILE);
				}
			}
			catch (Exception ex)
			{
				EC = new ErrorController(Constant.STATUS_UNKOWN_EXCEPTION, string.Format(Constant.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
			}
		}
		public void GetConfigFile(out ConfigApplication rCA, out ErrorController EC)
		{
			try
			{
				if (File.Exists(Constant.PATH_CONFIG_FILE))
				{
					ConfigApplication ca = new ConfigApplication();

					// COMMON
					ca.Password = INIHelper.Instance.READ(Constant.SECTION_COMMON, "Password");
					if (ca.Password != Constant.ENCRYPT_PASS_HASH)
					{
						Constant.ENCRYPT_PASS_HASH = ca.Password;
					}

					// SUPERVISOR
					ca.Supervisor = new IPConfig(INIHelper.Instance.READ(Constant.SECTION_SUPERVISOR, "IP"), Convert.ToInt32(INIHelper.Instance.READ(Constant.SECTION_SUPERVISOR, "PORT")));

					// DATABASE
					ca.Database = new IPConfig(INIHelper.Instance.READ(Constant.SECTION_DATABASE, "IP"), Convert.ToInt32(INIHelper.Instance.READ(Constant.SECTION_DATABASE, "PORT")));
					ca.DBName = INIHelper.Instance.READ(Constant.SECTION_DATABASE, "DBName");
					ca.UsernameDB = INIHelper.Instance.READ(Constant.SECTION_DATABASE, "Username");
					ca.PasswordDB = INIHelper.Instance.READ(Constant.SECTION_DATABASE, "Password");
					rCA = ca;
					// Delete file tmp
					File.Delete(Constant.PATH_CONFIG_FILE_TMP);
					EC = new ErrorController(Constant.STATUS_OK, "GET config file successfully.");
				}
				else
				{
					rCA = null;
					EC = new ErrorController(Constant.STATUS_NORMAL, "Config file not found.");
				}
			}
			catch (Exception ex)
			{
				rCA = null;
				EC = new ErrorController(Constant.STATUS_UNKOWN_EXCEPTION, string.Format(Constant.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
			}
		}
		private FileAttributes RemoveAttribute
		(FileAttributes attributes, FileAttributes attributesToRemove)
		{
			return attributes & ~attributesToRemove;
		}
		public void SetCanChangeMetroPanelColor(MetroPanel mpn)
		{
			mpn.UseCustomBackColor = true;
			mpn.UseCustomForeColor = true;
		}
		public void SetStyleHtmlLabel(HtmlLabel hlb)
		{
			hlb.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT);
			hlb.BackColor = Constant.COLOR_WHITE;
			hlb.AutoSize = false;
		}
		public void SetStyleRadioButton(RadioButton mbtn, string LabelAnswer)
		{
			mbtn.Text = LabelAnswer;
			mbtn.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Bold);
			mbtn.BackColor = Constant.COLOR_WHITE;
		}
		public void SetCanChangeMetroButtonColor(MetroButton mbtn)
		{
			mbtn.UseCustomBackColor = true;
			mbtn.UseCustomForeColor = true;
			mbtn.FontSize = MetroButtonSize.Tall;
			mbtn.FontWeight = MetroButtonWeight.Bold;
			mbtn.Highlight = true;
			mbtn.Cursor = Cursors.Hand;
			mbtn.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Bold);
		}
		public int GetHeightBetter(int a, int b)
		{
			if (a >= b)
			{
				return a;
			}
			else
			{
				return b;
			}
		}
		public void ShowNotificationForm(int typeNotification, string content, Form formOwner)
		{
			DTO.NotificationForm = new frmNotification();
			if (typeNotification == Constant.TYPE_NOTIFICATION_WARNING)
			{
				DTO.NotificationForm.Header = Properties.Resources.MSG_MESS_0026;
				DTO.NotificationForm.Content = content;
				DTO.NotificationForm.TextMbtnOK = Properties.Resources.MSG_GUI_0033;
			}
			else if (typeNotification == Constant.TYPE_NOTIFICATION_YESNO)
			{
				DTO.NotificationForm.Header = Properties.Resources.MSG_MESS_0001;
				DTO.NotificationForm.Content = content;
				DTO.NotificationForm.TextMbtnOK = Properties.Resources.MSG_GUI_0045;
				DTO.NotificationForm.TextMbtnCancel = Properties.Resources.MSG_GUI_0046;
			}
			else if (typeNotification == Constant.TYPE_NOTIFICATION_INFO)
			{
				DTO.NotificationForm.Header = Properties.Resources.MSG_MESS_0001;
				DTO.NotificationForm.Content = content;
				DTO.NotificationForm.TextMbtnOK = Properties.Resources.MSG_GUI_0033;
			}
			else if (typeNotification == Constant.TYPE_NOTIFICATION_RESULT)
			{
				DTO.NotificationForm.Header = Properties.Resources.MSG_GUI_0050;
				DTO.NotificationForm.Content = content;
				DTO.NotificationForm.TextMbtnOK = Properties.Resources.MSG_GUI_0033;
			}
			DTO.NotificationForm.Owner = formOwner;
			DTO.NotificationForm.ShowDialog();
		}
		public void ExitApplicationFromNotificationForm(Form formClose)
		{
			if (DTO.NotificationForm.DialogResult == DialogResult.OK)
			{
				formClose.Close();
			}
		}
      
        public void HandleRichTextBoxStyle(RichTextBox rtb)
		{
            rtb.ReadOnly = true ;
            rtb.BackColor = Constant.COLOR_WHITE;
			rtb.BorderStyle = BorderStyle.None;
            rtb.ShortcutsEnabled = false;
        
            rtb.Cursor = Cursors.Hand;
			rtb.WordWrap = true;
            rtb.MouseWheel += new MouseEventHandler(RTB_MouseWheel);
            //rtb.SelectionProtected = true;
            //rtb.HideSelection = true;
            //   rtb.GotFocus += Rtb_GotFocus
           // rtb.MouseHover += Rtb_MouseHover;
            rtb.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(RichTexBox_ContentResized);
          
           

        }

        private void RTB_MouseWheel(object sender, MouseEventArgs e)
        {
            RichTextBox rtb = sender as RichTextBox;
             
            rtb.Parent.Focus();
        }

        private void Rtb_MouseHover(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RTBClick(object sender, EventArgs e)
        {
         
        }
        
        private void RichTexBox_ContentResized(object sender, ContentsResizedEventArgs e)
		{
            const int margin = 8;
            RichTextBox rch = sender as RichTextBox;
            rch.ClientSize = new Size(
            e.NewRectangle.Width + margin,
            e.NewRectangle.Height + margin);
        }
		public bool HandleCheckConnection(string ip, int port)
		{
			if (InternetHelper.Instance.IsConnectedToInternet())
			{
				//TcpClient client = new TcpClient(ip, port);
				TcpClient client = new TcpClient();
				IAsyncResult result = client.BeginConnect(ip, port, null, null);
				var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
				if (success)
				{
					client.Close();
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}
		public bool HandleCheckDB(string dbName, string IP, int port, string username, string password)
		{
            string connectString = DAO.Common.GetConnectString("EXON_SYSTEM_TESTEntities");
          //  string connectString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", IP, dbName, username, password);
			//string connectString = string.Format("Data Source={0},{1};Initial Catalog={2};User ID={3};Password={4};", IP, port, dbName, username, password);
			try
			{
				SQLHelper sql = new SQLHelper(connectString);
				if (sql.IsConnection)
				{
					return true;
				}
				else return false;
			}
			catch (Exception)
			{
				return false;
			}
		}
        public bool HandleCheckDB()
        {
            string connectString = DAO.Common.GetConnectString("EXON_SYSTEM_TESTEntities");
            //  string connectString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", IP, dbName, username, password);
            //string connectString = string.Format("Data Source={0},{1};Initial Catalog={2};User ID={3};Password={4};", IP, port, dbName, username, password);
            try
            {
                SQLHelper sql = new SQLHelper(connectString);
                if (sql.IsConnection)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string HandleStringErrorController(ErrorController EC)
		{
			return string.Format("{0}: {1}", EC.ErrorCode, EC.Message);
		}
	}
}
