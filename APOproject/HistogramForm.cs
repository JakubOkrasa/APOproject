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
        public List<Histogram> Histograms { get; set; }
        public LookUpTablesSet LookUpTable { get; set; }
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
            //this.lookUpTable = lookUpTable;
            this.LookUpTable = new LookUpTablesSet(imageForm);
            Histograms = new List<Histogram>(4);
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
            monoHistogram.DrawHistogramData(LookUpTable.MonoLUT);
            Histograms.Add(monoHistogram);
        }

        private void showRgbHistogram()
        {
            Refresh();
            Histogram redHistogram = new Histogram(PctRedHist, Color.Crimson);
            Histogram greenHistogram = new Histogram(PctGreenHist, Color.ForestGreen);
            Histogram blueHistogram = new Histogram(PctBlueHist, Color.RoyalBlue);
            redHistogram.DrawHistogramData(LookUpTable.RedLUT);
            greenHistogram.DrawHistogramData(LookUpTable.GreenLUT);
            blueHistogram.DrawHistogramData(LookUpTable.BlueLUT);

            Histograms.Add(redHistogram);
            Histograms.Add(greenHistogram);
            Histograms.Add(blueHistogram);
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
            stretchHistogramCommand = new StretchHistogramCommand(LookUpTable, imageForm);
            stretchHistogramCommand.execute();
            if(rbBlackWhiteHist.Checked)
            {
                showMonoHistogram();
            }
            else
            {
                showRgbHistogram();
            }
            
            /// refresh image
        }

        private void btnEqHistogram_Click(object sender, EventArgs e)
        {
            PctRedHist.Image = null;
            PctBlueHist.Image = null;
            PctGreenHist.Image = null;
            Refresh();
            flattenHistogramCommand = new FlattenHistogramCommand(imageForm, this);
            flattenHistogramCommand.execute();
        }

       
        

    }
}
