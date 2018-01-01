using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CL.Services;
using CL.Persistance;
using CL.Services.Interface;
using CL.Services.Impl;

namespace GeneralManagement
{
    public partial class GeneralServiceForm : Form
    {
        IGeneralService GeneralService = new GeneralService();
        IGeneralService generalService = new GeneralService();
        ISupervisorService supervisorService = new SupervisorService();

        public GeneralServiceForm()
        {
            InitializeComponent();
        }

        protected bool CheckLogin(string user, string pass, out int per)
        {
            return GeneralService.CheckLogin(user, pass, out per);
        }

        private void GeneralServiceForm_Load(object sender, EventArgs e)
        {

        }
        //protected STAFF GetNameAccount(string user, string pass)
        //{
        //    return supervisorService.GetNameAccount(user, pass);
        //}

       


    }
}
