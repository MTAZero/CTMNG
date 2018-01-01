using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralManagement.Supervisors
{
    public partial class TaskWindowControl : UserControl
    {
        public TaskWindowControl(string FullName, string ComputerName,string RoomTestName)
        {
            InitializeComponent();
            metroTile1.Text = "Thí sinh " + FullName + " tại vị trí " + ComputerName + " phòng " + RoomTestName + " thông báo lỗi ";
        }
    }
}
