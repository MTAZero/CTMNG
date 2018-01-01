using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace EXONSYSTEM
{
    public partial class ucRowInfor : UserControl
    {
        public ucRowInfor()
        {
            InitializeComponent();
        }

        private void ucRowInfor_Load(object sender, EventArgs e)
        {
            lbTitle.Location = new Point(0, 0);
            lbContent.Top = 0;
            this.Width = lbContent.Right + 10;
        }
        public void HandleUC(string strTitle, string strContent)
        {
            UCDataProvider data = new UCDataProvider(strTitle, strContent);
            Binding dbTitle = new Binding("Text", data, "strTitle");
            lbTitle.DataBindings.Add(dbTitle);
            Binding dbContent = new Binding("Text", data, "strContent");
            lbContent.DataBindings.Add(dbContent);
            lbContent.Left = lbTitle.Width + 100;
        }
        public void ResettUC()
        {
            lbContent = new Label();
            lbTitle = new Label();
        }
    }
    public class UCDataProvider
    {
        public string strTitle { get; set; }
        public string strContent { get; set; }
        public UCDataProvider() { }
        public UCDataProvider(string strTitle,string strContent)
        {
            this.strContent = strContent;
            this.strTitle = strTitle;
        }
    }
}
