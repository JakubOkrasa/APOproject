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
        public static OpenFileDialog openFileDialog;
        List<ImageForm> imageForms = new List<ImageForm>();

        public MainForm()
        {
            InitializeComponent();
        }

        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openImage();
        }

        private void openImage()
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImageForm imageForm = new ImageForm(this, new Bitmap(openFileDialog.FileName));
                imageForms.Add(imageForm);
                imageForm.Show();
                imageForm.Activate();
            }
        }
        

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramForm hf = new HistogramForm(ActiveMdiChild as ImageForm);
            hf.ShowDialog();
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImage();
        }

        private void saveImage()
        {
            SaveFileDialog saveImage = new SaveFileDialog();
            saveImage.DefaultExt = "png";
            saveImage.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";


            if (saveImage.ShowDialog() == DialogResult.OK)
            {
                (ActiveMdiChild as ImageForm).PictureBox.Image.Save(saveImage.FileName, System.Drawing.Imaging.ImageFormat.Png); //other formats also works despite the second parameter

            }
        }

        private void mainPicture_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.O))
            {
                openImage();
                return true;
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                saveImage();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
