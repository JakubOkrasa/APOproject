using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace APOproject
{
    public class HistogramCreator
    {
        MainForm mainForm;
        private Bitmap Bitmap { get; set; }

        public HistogramCreator(MainForm mainForm)
        {
            Bitmap = new Bitmap(mainForm.MainPictureImage);
            this.mainForm = mainForm as MainForm;
            populateLUTs(Bitmap);
        }

        const double RED_MULTIPLIER = 0.2126;
        const double GREEN_MULTIPLIER = 0.7152;
        const double BLUE_MULTIPLIER = 0.0722;
        const int BRIGHTNESS_LEVELS_NUMBER = 256;

        GraphicsUnit imageSizeUnit = GraphicsUnit.Pixel;
        int bitmapHeight;
        int bitmapWidth;

        public int[,] RgbLUT { get; set; }
        public int[] BlackWhiteLUT { get; set; }

        

        //populate black-white histogram LUT and RGB histogram LUT with data from bitmap
        private void populateLUTs(Bitmap bitmap)
        {
            int[,] rgbLUT = new int[BRIGHTNESS_LEVELS_NUMBER, 3]; //3 kolory - RGB
            int[] blackWhiteLUT = new int[BRIGHTNESS_LEVELS_NUMBER];
            bitmapWidth = (int)Bitmap.GetBounds(ref imageSizeUnit).Width;
            bitmapHeight = (int)Bitmap.GetBounds(ref imageSizeUnit).Height;
            for (int i = 0; i < bitmapWidth; i++)
            {
                for (int j = 0; j < bitmapHeight; j++)
                {
                    Color pixel = Bitmap.GetPixel(i, j);
                    rgbLUT[pixel.R, 0]++;
                    rgbLUT[pixel.G, 1]++;
                    rgbLUT[pixel.B, 2]++;
                    blackWhiteLUT[(int)Math.Round(pixel.R * RED_MULTIPLIER + pixel.G * GREEN_MULTIPLIER + pixel.B * BLUE_MULTIPLIER, 0)]++;
                }
            }
            RgbLUT = rgbLUT;
            BlackWhiteLUT = blackWhiteLUT;
        }


        public void stretchHistogram()
        {
            BoundaryValues boundaryValues = new BoundaryValues(Bitmap); //gets min and max values from 3 channels (RGB)
            int redNewValue;
            int greenNewValue;
            int blueNewValue;
            Color oldColor;

            for (int i = 0; i < bitmapWidth; i++)
            {
                for (int j = 0; j < bitmapHeight; j++)
                {               
                    oldColor = Bitmap.GetPixel(i, j);
                             
                    redNewValue =   (oldColor.R - boundaryValues.MinR) * (BRIGHTNESS_LEVELS_NUMBER / (boundaryValues.MaxR - boundaryValues.MinR));
                    greenNewValue = (oldColor.G - boundaryValues.MinG) * (BRIGHTNESS_LEVELS_NUMBER / (boundaryValues.MaxG - boundaryValues.MinG));
                    blueNewValue =  (oldColor.B - boundaryValues.MinB) * (BRIGHTNESS_LEVELS_NUMBER / (boundaryValues.MaxB - boundaryValues.MinB));

                    Bitmap.SetPixel(i, j, Color.FromArgb(redNewValue, greenNewValue, blueNewValue));
                }
            }
            populateLUTs(Bitmap);
            mainForm.MainPictureImage = Bitmap;
        }

        

    }
}
