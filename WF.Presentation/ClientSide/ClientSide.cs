using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserHelper;
using CL.Persistance;

namespace ClientSide
{
    public partial class ClientSide : ClientSideServiceForm
    {
        UserHelper.ClientSide ClientSocket;
        UserTransformation UT;
        int maxTime;
        public ClientSide()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            maxTime = 3600;
            timeCountDown.Start();
            lbTimer.Text = HandleCountDown(maxTime);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string[] result = txtMessage.Text.Split('-');
            UserTransformation UT = new UserTransformation();

            UT.UserCode = AppSession.UserName;
            UT.UserID = AppSession.UserID;

            UT.Status = Convert.ToInt32(result[0]);
            UT.Content = result[1];
            UT.ComputerName = AppSession.ComputerName;
            AddToView(UT);
            txtMessage.Clear();

            bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
            if (!uhRes)
            {
                MessageBox.Show("không thể kết nối đến server");
            }
        }

        private void AddToView(UserTransformation UT)
        {
            lstbTraceLog.Items.Add(string.Format("[{0}][{1}][{2}]: [{3}]-[{4}]", UT.UserID, UT.UserCode, UT.ComputerName, UT.Status, UT.Content));
        }

        private void ClientSide_Load(object sender, EventArgs e)
        {
            UT = new UserTransformation();
            UT.UserID = AppSession.UserID;

            UT.UserCode = AppSession.UserName;
            UT.ComputerName = AppSession.ComputerName;
            UT.Status = AppSession.Status;


            string IP = string.Empty;
            UserHelper.Ultis.GetCurrentIP(out IP);
            try
            {
                ClientSocket = new UserHelper.ClientSide(3001, IP);
            }
            catch
            {
                try
                {
                    ClientSocket = new UserHelper.ClientSide(3002, IP);
                }
                catch {
                    ClientSocket = new UserHelper.ClientSide(3003, IP);
                }
            }
            ClientSocket.Status = true;
            ClientSocket.Remote.Receive += Remote_Receive;
            ClientSocket.Remote.NoConnected += Remote_NoConnected;

            bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
            if (!uhRes)
            {
                DialogResult dResult = MessageBox.Show("không thể kết nối đến server");
                if (dResult.Equals(DialogResult.OK))
                {
                    Application.Exit();
                }
            }

        }

        void Remote_Receive(object sender, object data)
        {
            UserTransformation Recieve = UserHelper.Ultis.FromJSONToObject((string)data);
            if (Recieve.Status ==UserHelper.Common.STATUS_STARTED)
            {
                HandleTimer();

                // Cập nhật lại trạng thái đã nhận đc gói tin từ server
                ClientSocket.Status = false;
            }
            AddToView(Recieve);
        }
        void Remote_NoConnected(object sender, object data)
        {
            if (UT.Status != -1)
            {
                ClientSocket.Connect();
            }
        }

        private void ClientSide_FormClosing(object sender, FormClosingEventArgs e)
        {
            UT.Status = -1;
            if (ClientSocket != null) ClientSocket.Dispose();
        }
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
        private void HandleTimer()
        {
            maxTime = 3600;
            pACS.Visible = false;
        }
        private void timeCountDown_Tick(object sender, EventArgs e)
        {
            maxTime--;
            lbTimer.Text = HandleCountDown(maxTime);
            if (maxTime == 0)
            {
                timeCountDown.Stop();
            }
        }

        private void ClientSide_FormClosed(object sender, FormClosedEventArgs e)
        {
            UT.Status = -1;
            if (ClientSocket != null) ClientSocket.Dispose();
            Application.Exit();
        }

        private void lbTimer_Click(object sender, EventArgs e)
        {

        }
    }
}
