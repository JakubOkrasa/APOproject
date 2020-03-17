using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APOproject
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        public Image MainPictureImage
        {
           get { return mainPicture.Image; }
           set { mainPicture.Image = value; }
        }



        public static OpenFileDialog openFileDialog;

        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mainPicture.Image = new Bitmap(openFileDialog.FileName);
            }
        }
        //private void InitHistogramForm()
        //{
        //    HistogramForm hf = new HistogramForm(this, histogramCreator);
        //    hf.ShowDialog();

        //}

        

        

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramForm hf = new HistogramForm(this);
            hf.ShowDialog();
            //using (WaitingForm wf = new WaitingForm(InitHistogramForm))
            //{
            //    wf.ShowDialog(this);
            //}

        }

        
    }
}
