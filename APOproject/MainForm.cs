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

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveImage = new SaveFileDialog();
            saveImage.DefaultExt = "png";
            saveImage.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
            if (saveImage.ShowDialog() == DialogResult.OK)
            {
                // System.IO.Path.GetExtension(saveBwHistDialog.FileName)
                mainPicture.Image.Save(saveImage.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
