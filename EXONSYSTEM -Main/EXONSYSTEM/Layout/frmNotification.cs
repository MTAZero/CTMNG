using EXONSYSTEM.Common;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXONSYSTEM.Layout
{
	public partial class frmNotification : MetroForm
	{
		public string Content
		{
			set
			{
				lbContent.Text = value;
				lbContent.MaximumSize = new Size(this.Width - 10, 0);
				lbContent.Location = new Point(Convert.ToInt32((this.Width - lbContent.Width) / 2), 60);
			}
		}
		public string Header
		{
			set
			{
				this.Text = value;
			}
		}
		public string TextMbtnOK
		{
			set
			{
				mbtnOK.ForeColor = Constant.FORCECOLOR_BUTTON_SUBMIT;
				mbtnOK.BackColor = Constant.BACKCOLOR_BUTTON_CONTROLLER;
				mbtnOK.Text = value;
				mbtnOK.Cursor = Cursors.Hand;
				mbtnOK.Size = Constant.SIZE_BUTTON_DEFAULT;
				mbtnOK.DialogResult = DialogResult.OK;
				mbtnOK.Location = new Point(Convert.ToInt32((this.Width - mbtnOK.Width) / 2), lbContent.Bottom + 10);
				this.Height = mbtnOK.Bottom + 20;
			}
		}
		public string TextMbtnCancel
		{
			set
			{
				mbtnCancel.ForeColor = Constant.FORCECOLOR_BUTTON_SUBMIT;
				mbtnCancel.BackColor = Constant.BACKCOLOR_BUTTON_CONTROLLER;
				mbtnCancel.Text = value;
				mbtnCancel.Cursor = Cursors.Hand;
				mbtnCancel.Size = Constant.SIZE_BUTTON_DEFAULT;
				mbtnCancel.DialogResult = DialogResult.Cancel;
				mbtnCancel.Visible = true;
				mbtnCancel.Location = new Point(mbtnOK.Right + 20, mbtnOK.Top);
			}
		}
		public frmNotification()
		{
			InitializeComponent();
			this.Text = Properties.Resources.MSG_MESS_0001;
			this.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT + 2, FontStyle.Regular);
		}
	}
}
