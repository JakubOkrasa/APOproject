using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace APOproject.Commands
{
    class FlattenHistogramCommand : ICommand
    {
        private LookUpTablesSet lookUpTable;
        private ImageForm imageForm;
        private HistogramForm histogramForm;

        public int FirstNonZeroValue { get; set; }
        public int PixelsNumber { get; set; }
        const int BRIGHTNESS_LEVELS_NUMBER = 256;

        public FlattenHistogramCommand(ImageForm imageForm, HistogramForm histogramForm)
        {
            lookUpTable = histogramForm.LookUpTablesSet;
            this.histogramForm = histogramForm;
            this.imageForm = imageForm;
           // this.histogramForm = histogramForm;
            FirstNonZeroValue = 0;

            foreach (int value in lookUpTable.MonoLUT)
            {
                PixelsNumber += value;
            }
            
        }

        public void execute()
        {
            lookUpTable.RedLUT = getDistributionFunction(lookUpTable.RedLUT);
            lookUpTable.GreenLUT = getDistributionFunction(lookUpTable.GreenLUT);
            lookUpTable.BlueLUT = getDistributionFunction(lookUpTable.BlueLUT);
            lookUpTable.MonoLUT = getDistributionFunction(lookUpTable.MonoLUT);

            lookUpTable.RedLUT = getEqualizedLUT(lookUpTable.RedLUT);
            lookUpTable.GreenLUT = getEqualizedLUT(lookUpTable.GreenLUT);
            lookUpTable.BlueLUT = getEqualizedLUT(lookUpTable.BlueLUT);
            lookUpTable.MonoLUT = getEqualizedLUT(lookUpTable.MonoLUT);

            Histogram monoHistogram = new Histogram(histogramForm.PctMonoHist, Color.DarkGray);
            Histogram redHistogram = new Histogram(histogramForm.PctRedHist, Color.Crimson);
            Histogram greenHistogram = new Histogram(histogramForm.PctGreenHist, Color.ForestGreen);
            Histogram blueHistogram = new Histogram(histogramForm.PctBlueHist, Color.RoyalBlue);

            monoHistogram.DrawHistogramData(lookUpTable.RedLUT);
            redHistogram.DrawHistogramData(lookUpTable.RedLUT);
            greenHistogram.DrawHistogramData(lookUpTable.GreenLUT);
            blueHistogram.DrawHistogramData(lookUpTable.BlueLUT);
        }

        public void undo()
        {
            throw new NotImplementedException();
        }

        private int[] getDistributionFunction(int[] lut)
        {
            FirstNonZeroValue = 0;
            
            int j = 0;
            int previousValue = 0;
            while (lut[j] == 0)
            {
                j++;
            }
            FirstNonZeroValue = lut[j];

            for (; j < 256; j++)
            {
                lut[j] = previousValue + lut[j];
                previousValue = lut[j];
            }
            return lut;

        }

        private int[] getEqualizedLUT(int[] lut)
        {
           
                // N - liczba pikseli obrazu //todo: tu chyba gdzies powinno byc uzyte N
                for (int j=0; j < 256; j++)
                {
                    lut[j] = ((lut[j] / PixelsNumber - FirstNonZeroValue) //warning: pixels number is from black-white LUT
                        / (1 - FirstNonZeroValue)) * (BRIGHTNESS_LEVELS_NUMBER - 1);
                }
            return lut;
        }
    }
}
