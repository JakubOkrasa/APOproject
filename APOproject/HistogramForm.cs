using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APOproject.Commands;
using System.Windows.Forms.DataVisualization.Charting;

namespace APOproject
{ 
    public partial class HistogramForm : Form
    {
        ImageForm imageForm;
        List<Histogram> histograms;
        LookUpTable lookUpTable;
        StretchHistogramCommand stretchHistogramCommand;
        FlattenHistogramCommand flattenHistogramCommand;

        public PictureBox PctMonoHist
        {
            get { return pctMonoHist; }
            set { pctMonoHist = value; }
        }

        public PictureBox PctRedHist
        {
            get { return pctRedHist; }
            set { pctRedHist = value; }
        }

        public PictureBox PctGreenHist
        {
            get { return pctGreenHist; }
            set { pctGreenHist = value; }
        }

        public PictureBox PctBlueHist
        {
            get { return pctBlueHist; }
            set { pctBlueHist = value; }
        }




        public HistogramForm(ImageForm imageForm)
        {
            
            InitializeComponent();
            this.imageForm = imageForm;
            lookUpTable = new LookUpTable(imageForm);
            histograms = new List<Histogram>(4);
            PctMonoHist.Visible = true;
            PctRedHist.Visible = false;
            PctGreenHist.Visible = false;
            PctBlueHist.Visible = false;
            Shown += HistogramForm_Shown;
        }

        private void HistogramForm_Shown(object sender, EventArgs e)
        {
            Refresh();
            showMonoHistogram();
        }

        private void showMonoHistogram()
        {
            Refresh();
            Histogram monoHistogram = new Histogram(PctMonoHist, Color.DarkGray);
            monoHistogram.DrawHistogramData(lookUpTable.MonoLUT, lookUpTable.MaxMono);
            histograms.Add(monoHistogram);
        }

        private void showRgbHistogram()
        {
            //todo: show rgb histogram
            //Refresh();
            //Histogram redHistogram = new Histogram(PctRedHist, Color.MediumVioletRed);
            //redHistogram.DrawHistogramData(histogramCreator.RgbLUT.get, 100);
            //histograms.Add(monoHistogram); //todo stworzyc klase lookupTable z 4 tablicami LUT
           
        }
        

        private void rbBlackWhiteHist_CheckedChanged(object sender, EventArgs e)
        {
            PctRedHist.Visible = false;
            PctGreenHist.Visible = false;
            PctBlueHist.Visible = false;
            PctMonoHist.Visible = true;
            showMonoHistogram();

            btnSaveHistogram.Visible = true;
        }

        private void rbRGBhist_CheckedChanged(object sender, EventArgs e)
        {
            PctMonoHist.Visible = false;
            PctRedHist.Visible = true;
            PctGreenHist.Visible = true;
            PctBlueHist.Visible = true;
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
                PctMonoHist.Image.Save(saveBwHistDialog.FileName, System.Drawing.Imaging.ImageFormat.Png); //(todo) inne formaty tez dzialaja, ale nie powinny
            }


        }

        private void btnStretchHistogram_Click(object sender, EventArgs e)
        {
            stretchHistogramCommand = new StretchHistogramCommand(lookUpTable, imageForm);
            stretchHistogramCommand.execute();
            if(rbBlackWhiteHist.Checked)
            {
                showMonoHistogram();
            }
            else
            {
                showRgbHistogram();
            }
            //this.mainForm.MainPictureImage
            
            /// refresh image
        }

        private void btnEqHistogram_Click(object sender, EventArgs e)
        {
            flattenHistogramCommand = new FlattenHistogramCommand(lookUpTable, imageForm, this);
            flattenHistogramCommand.execute();
        }

       
        

    }
}
