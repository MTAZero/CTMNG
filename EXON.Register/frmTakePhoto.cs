using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
namespace EXON.Register
{
    public partial class frmTakePhoto : Form
    {
        public byte[] img = new byte[] { };
        
        FilterInfoCollection captureDevice;
        VideoCaptureDevice finalFrame;
        public frmTakePhoto()
        {
            InitializeComponent();
        }

        private void frmTakePhoto_Load(object sender, EventArgs e)
        {
            captureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            for(int i=0;i<captureDevice.Count;i++)
            {
                cboCam.Items.Add(captureDevice[i].Name);
            }
            cboCam.SelectedIndex = 0;
           
            
        }
       
        void finalframe_new(object sender, NewFrameEventArgs e)
        {
            //throw new NotImplementedException();
            ptbWebcam.Image = (Bitmap)e.Frame.Clone(); 
        }

        private void frmTakePhoto_FormClosed(object sender, FormClosedEventArgs e)
        {
            
           
        }

        public event EventHandler btnDoneClick;
        private void btnDone_Click(object sender, EventArgs e)
        {
            if (ptbImage.Image != null)
                img = ImageToByteArray(ptbImage.Image);
            else img = new byte[]{};
            if (btnDoneClick != null)
                btnDoneClick(this, e);
            this.Close();
        }

        private void btnTakePhoto_Click(object sender, EventArgs e)
        {
            ptbImage.Image = ptbWebcam.Image;
            
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            img = new byte[] { };
            this.Close();
        }

        private void frmTakePhoto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finalFrame.IsRunning)
            {
                finalFrame.Stop();
            }
        }

        private void cboCam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if  (finalFrame!=null && finalFrame.IsRunning )
            {
                finalFrame.Stop();
            }
            finalFrame = new VideoCaptureDevice(captureDevice[cboCam.SelectedIndex].MonikerString);
            finalFrame.NewFrame += new NewFrameEventHandler(finalframe_new);
            finalFrame.Start();
        }
    }
}
