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
        public List<HistogramDrafter> Histograms { get; set; }
        public LookUpTablesSet LookUpTablesSet { get; set; }
        StretchHistogramCommand stretchHistogramCommand;
        FlattenHistogramCommand flattenHistogramCommand;
        const int BRIGHTNESS_LEVELS_NUMBER = 256;

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

        public HistogramDrafter MonoHistogram { get; set; }
        public HistogramDrafter RedHistogram { get; set; }
        public HistogramDrafter GreenHistogram { get; set; }
        public HistogramDrafter BlueHistogram { get; set; }





        public HistogramForm(ImageForm imageForm)
        {
            
            InitializeComponent();
            this.imageForm = imageForm;
            //this.lookUpTable = lookUpTable;
            this.LookUpTablesSet = new LookUpTablesSet(imageForm);
            Histograms = new List<HistogramDrafter>(4);
            PctMonoHist.Visible = true;
            PctRedHist.Visible = false;
            PctGreenHist.Visible = false;
            PctBlueHist.Visible = false;
            Shown += HistogramForm_Shown;
            MonoHistogram = new HistogramDrafter(PctMonoHist, Color.DarkGray);
            RedHistogram = new HistogramDrafter(PctRedHist, Color.Crimson);
            GreenHistogram = new HistogramDrafter(PctGreenHist, Color.ForestGreen);
            BlueHistogram = new HistogramDrafter(PctBlueHist, Color.RoyalBlue);
            Histograms.Add(MonoHistogram);
            Histograms.Add(RedHistogram);
            Histograms.Add(GreenHistogram);
            Histograms.Add(BlueHistogram);
        }

        private void HistogramForm_Shown(object sender, EventArgs e)
        {
            Refresh();
            showMonoHistogram();
        }

        private void showMonoHistogram()
        {
            Refresh();
            MonoHistogram.DrawGraphFrame();
            MonoHistogram.DrawHistogramData(LookUpTablesSet.MonoLUT);
        }

        private void showRgbHistogram()
        {
            Refresh();
            RedHistogram.DrawGraphFrame();
            GreenHistogram.DrawGraphFrame();
            BlueHistogram.DrawGraphFrame();
            RedHistogram.DrawHistogramData(LookUpTablesSet.RedLUT);
            GreenHistogram.DrawHistogramData(LookUpTablesSet.GreenLUT);
            BlueHistogram.DrawHistogramData(LookUpTablesSet.BlueLUT);            
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
            stretchHistogram();
            tbStretch.Enabled = true;
            upDownStretch.Enabled = true;
        }

        private void stretchHistogram(int brightnessLevelsNumber=BRIGHTNESS_LEVELS_NUMBER)
        {
            stretchHistogramCommand = new StretchHistogramCommand(LookUpTablesSet, imageForm);
            stretchHistogramCommand.execute(brightnessLevelsNumber);
            if (rbBlackWhiteHist.Checked)
            {
                showMonoHistogram();
            }
            else
            {
                showRgbHistogram();
            }
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

        private void upDownStretch_ValueChanged(object sender, EventArgs e)
        {
            tbStretch.Value = Convert.ToInt32(upDownStretch.Value);
            stretchHistogram(tbStretch.Value);
        }

        private void tbStretch_Scroll(object sender, EventArgs e)
        {
            upDownStretch.Value = tbStretch.Value;
            stretchHistogram(tbStretch.Value);
        }
    }
}
