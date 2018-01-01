using EXONSYSTEM.Common;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXONSYSTEM.Layout
{
	public partial class frmLoading : MetroForm
	{
		public int TotalProgress { get; set; }
		private int CurrentProgess = 0;
		public frmLoading()
		{
			InitializeComponent();
			this.Text = Properties.Resources.MSG_GUI_0027;
		}
		void ProcessImport(IProgress<int> progress)
		{
            Debug.WriteLine(CurrentProgess + "/" + TotalProgress);
            progress.Report(CurrentProgess * 100 / TotalProgress);
        }
		public void HandleWorking(bool flag)
		{
			if (flag)
			{
				this.CurrentProgess++;
				var progressReport = new Progress<int>();
				progressReport.ProgressChanged += (o, report) =>
				{
					mlbLoading.Text = string.Format(Properties.Resources.MSG_GUI_0028, report);
					mlbLoading.Update();
					mpgLoading.Value = report;
					mpgLoading.Update();
					this.Update();
					if (this.CurrentProgess == TotalProgress)
					{
						Thread.Sleep(300);
						this.Close();
					}
				};
				ProcessImport(progressReport);
			}

		}
	}
}
