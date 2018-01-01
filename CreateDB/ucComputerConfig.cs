using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CreateDB
{
    public partial class ucComputerConfig : UserControl
    {
       
        public ucComputerConfig()
        {
            InitializeComponent();
        }
      public  Main.ROOMDIAGRAM roomdia;
        public delegate Main.ROOMDIAGRAM ClickHandler(Main.ROOMDIAGRAM _roomdia);
     
        public ucComputerConfig(Main.ROOMDIAGRAM _roomdia)
        {
            roomdia = new Main.ROOMDIAGRAM();
            this.roomdia = _roomdia;
           InitializeComponent();
            Color color = new Color();
            if (roomdia.Status == 4003)
            {
                ptbImage.Image = Properties.Resources.monitor_dubi;
                lbStatus.Text += "Dự bị";
                color = Color.Yellow;
                lbStatus.ForeColor = color;
            }
            else if(roomdia.Status==4002)
            {
                ptbImage.Image = Properties.Resources.monitor_hong;
                color = Color.Red;
                lbStatus.Text += " Hỏng";
                lbStatus.ForeColor = color;
            }
            else
            {
                lbStatus.Text += " Tốt";
                color = Color.Green;
                lbStatus.ForeColor = color;
            }

            lbComputername.Text = roomdia.ComputerName;

        }
        private void lbStatus_Click(object sender, EventArgs e)
        {

        }

        private void ucComputerConfig_Click(object sender, EventArgs e)
        {

           
        }

        private void ucComputerConfig_Load(object sender, EventArgs e)
        {
           
        }
        //private EventHandler Click_PictureBox;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmRoomConfig parentForm = (frmRoomConfig) this.ParentForm;
            ClickHandler click = new ClickHandler(parentForm.ClickUC);
            click(roomdia);
        }
    }
}
