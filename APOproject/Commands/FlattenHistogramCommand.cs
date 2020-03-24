using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOproject.Commands
{
    class FlattenHistogramCommand : ICommand
    {
        HistogramCreator histogramCreator;
        ImageForm imageForm;
        HistogramForm histogramForm;

        public int[] FirstNonZeroValues { get; set; }
        public int PixelsNumber { get; set; }
        const int BRIGHTNESS_LEVELS_NUMBER = 256;

        public FlattenHistogramCommand(HistogramCreator histogramCreator, ImageForm imageForm, HistogramForm histogramForm)
        {
            this.histogramCreator = histogramCreator;
            this.imageForm = imageForm;
            this.histogramForm = histogramForm;
            FirstNonZeroValues = new int[3];

            foreach (int value in histogramCreator.BlackWhiteLUT)
            {
                PixelsNumber += value;
            }
        }

        public void execute()
        {
            
            histogramCreator.RgbLUT = getDistributionFunction(histogramCreator.RgbLUT);
            histogramCreator.RgbLUT = getEqualizedLUT(histogramCreator.RgbLUT);
            //temporary copied code:
            histogramForm.RedHistogram.Series["Red"].Points.Clear();
            histogramForm.GreenHistogram.Series["Green"].Points.Clear();
            histogramForm.BlueHistogram.Series["Blue"].Points.Clear();
            for (int i = 0; i < 256; i++)
            {
                histogramForm.RedHistogram.Series["Red"].Points.AddXY(i, histogramCreator.RgbLUT[i, 0]);
                histogramForm.GreenHistogram.Series["Green"].Points.AddXY(i, histogramCreator.RgbLUT[i, 1]);
                histogramForm.BlueHistogram.Series["Blue"].Points.AddXY(i, histogramCreator.RgbLUT[i, 2]);
            }
            //temporary copied code end
        }

        public void undo()
        {
            throw new NotImplementedException();
        }

        private int[,] getDistributionFunction(int[,] lut)
        {
            int[] firstNonZeroValues = new int[3];
            int j;
            for (int i = 0; i < lut.GetLength(1); i++) {
                j = 0;
                int previousValue = 0;
                while (lut[j, i] == 0)
                {
                    j++;
                }
                Console.WriteLine("lut["+j+", " + i + "] = " + lut[j, i]);
                FirstNonZeroValues[i] = lut[j, i];
                
                for (; j<256; j++)
                {
                    lut[j, i] = previousValue + lut[j, i];
                    previousValue = lut[j, i];
                }
            }
            return lut;
        }

        private int[,] getEqualizedLUT(int[,] lut)
        {
           
            for (int i = 0; i < lut.GetLength(1); i++)
            {                 
                // N - liczba pikseli obrazu
                for (int j=0; j < 256; j++)
                {
                    lut[j, i] = ((lut[j, i] / PixelsNumber - FirstNonZeroValues[i]) //warning: pixels number is from black-white LUT
                        / (1 - FirstNonZeroValues[i])) * (BRIGHTNESS_LEVELS_NUMBER - 1);
                }
            }
            return lut;
        }
    }
}
