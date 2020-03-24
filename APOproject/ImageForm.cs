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
    public partial class ImageForm : Form
    {
        public PictureBox PictureBox
        {
            get { return pictureBox; }
            set { pictureBox = value; }
        }

        public ImageForm(MainForm mainForm, Bitmap bitmap)
        {
            InitializeComponent();
            this.MdiParent = mainForm;
            PictureBox.Image = bitmap;
        }

        public ImageForm()
        {
            InitializeComponent();
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine("ImageForm load");
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
