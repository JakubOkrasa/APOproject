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
{ //TODO: rozdzielić logikę od widoku
    // ładowanie tablic LUT do pamięci podr. np. po wciśnięciu opcji Histogram. Wykorzystanie rgbLUT przy tworzeniu blackWhiteLUT
    public partial class HistogramForm : Form
    {
        MainForm mainForm;
        HistogramCreator histogramCreator;

        public HistogramForm(MainForm mainForm)
        {
            
            InitializeComponent();
            histogramCreator = new HistogramCreator(mainForm);
            blackWhiteHistogram.Visible = true;
            redHistogram.Visible = false;
            greenHistogram.Visible = false;
            blueHistogram.Visible = false;
            showBlackWhiteHistogram();

            this.mainForm = mainForm as MainForm;
           // this.histogramCreator = histogramCreator as HistogramCreator;
        }

        private void showBlackWhiteHistogram()
        {
            int[] blackWhiteLUT = histogramCreator.BlackWhiteLUT;
            for (int i = 0; i < 256; i++)
            {
                blackWhiteHistogram.Series["Brightness"].Points.AddXY(i, blackWhiteLUT[i]);
            }
        }

        private void showRgbHistogram()
        {
            int[,] rgbLUT = histogramCreator.RgbLUT;
            for (int i = 0; i < 256; i++)
            {
                redHistogram.Series["Red"].Points.AddXY(i, rgbLUT[i, 0]);
                greenHistogram.Series["Green"].Points.AddXY(i, rgbLUT[i, 1]);
                blueHistogram.Series["Blue"].Points.AddXY(i, rgbLUT[i, 2]);
            }
        }
        

        private void rbBlackWhiteHist_CheckedChanged(object sender, EventArgs e)
        {
            redHistogram.Visible = false;
            greenHistogram.Visible = false;
            blueHistogram.Visible = false;
            blackWhiteHistogram.Visible = true;
            showBlackWhiteHistogram();

            btnSaveHistogram.Visible = true;
        }

        private void rbRGBhist_CheckedChanged(object sender, EventArgs e)
        {
            blackWhiteHistogram.Visible = false;
            redHistogram.Visible = true;
            greenHistogram.Visible = true;
            blueHistogram.Visible = true;
            showRgbHistogram();

            btnSaveHistogram.Visible = false;
        }

        private void btnSaveHistogram_Click(object sender, EventArgs e)
        {
            saveBwHistDialog = new SaveFileDialog();
            saveBwHistDialog.DefaultExt = "png";
            saveBwHistDialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
            if (saveBwHistDialog.ShowDialog() == DialogResult.OK)
            {
                // System.IO.Path.GetExtension(saveBwHistDialog.FileName)
                blackWhiteHistogram.SaveImage(saveBwHistDialog.FileName, System.Drawing.Imaging.ImageFormat.Png); //(todo) inne formaty tez dzialaja, ale nie powinny
            }


        }

        private void btnStretchHistogram_Click(object sender, EventArgs e)
        {
            histogramCreator.stretchHistogram();
            if(rbBlackWhiteHist.Checked)
            {
                showBlackWhiteHistogram();
            }
            else
            {
                showRgbHistogram();
            }
            //this.mainForm.MainPictureImage
            
            /// refresh image
        }
    }
}
