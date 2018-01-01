using CL.Persistance;
using CL.Services.Impl;
using CL.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    public partial class ClientSideServiceForm : Form
    {
        ISupervisorService supervisorService = new SupervisorService();

        public ClientSideServiceForm()
        {
            InitializeComponent();
        }

        private void ClientSideServiceForm_Load(object sender, EventArgs e)
        {

        }

        public CONTESTANT GetContestantByCode(string code)
        {
            return supervisorService.GetContestantByCode(code);
        }

    }
}
