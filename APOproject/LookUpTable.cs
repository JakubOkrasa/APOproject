using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace APOproject
{
    public class LookUpTable
    {
        private ImageForm imageForm;

        public int BitmapHeight { get; set; }
        public int BitmapWidth { get; set; }
        private Bitmap bitmap;

        GraphicsUnit imageSizeUnit = GraphicsUnit.Pixel;

        const double RED_MULTIPLIER = 0.2126;
        const double GREEN_MULTIPLIER = 0.7152;
        const double BLUE_MULTIPLIER = 0.0722;
        const int BRIGHTNESS_LEVELS_NUMBER = 256;

        int bitmapHeight;
        int bitmapWidth;

        public int[,] RgbLUT { get; set; }
        public int[] MonoLUT { get; set; }
        public int[] RedLUT { get; set; }
        public int[] GreenLUT { get; set; }
        public int[] BlueLUT { get; set; }

        public int MinMono { get; set; }
        public int MaxMono { get; set; }
        public int MinR { get; set; }
        public int MaxR { get; set; }
        public int MinG { get; set; }
        public int MaxG { get; set; }
        public int MinB { get; set; }
        public int MaxB { get; set; }

        public LookUpTable(ImageForm imageForm)
        {
            this.imageForm = imageForm;  
            this.bitmap = imageForm.PictureBox.Image as Bitmap;

            
            MinR = bitmap.GetPixel(0, 0).R;
            MaxR = bitmap.GetPixel(0, 0).R;
            MinG = bitmap.GetPixel(0, 0).G;
            MaxG = bitmap.GetPixel(0, 0).G;
            MinB = bitmap.GetPixel(0, 0).B;
            MaxB = bitmap.GetPixel(0, 0).B;
            MinMono = (int)Math.Round(MinR * RED_MULTIPLIER + MinG * GREEN_MULTIPLIER + MinB * BLUE_MULTIPLIER, 0);
            MaxMono = (int)Math.Round(MaxR * RED_MULTIPLIER + MaxG * GREEN_MULTIPLIER + MaxB * BLUE_MULTIPLIER, 0);

            BitmapWidth = (int)bitmap.GetBounds(ref imageSizeUnit).Width;
            BitmapHeight = (int)bitmap.GetBounds(ref imageSizeUnit).Height;

            populateLUTs(bitmap);
        }



        private void setExtremums()
        {
            int redValue;
            int greenValue;
            int blueValue;
            int monoValue;
            for (int i = 0; i < BitmapWidth; i++)
            {
                for (int j = 0; j < BitmapHeight; j++)
                {
                    //RED
                    redValue = bitmap.GetPixel(i, j).R;
                    if (redValue < MinR) { MinR = redValue; } //find minimum
                    if (redValue > MaxR) { MaxR = redValue; } //find maximum

                    //GREEN
                    greenValue = bitmap.GetPixel(i, j).G;
                    if (greenValue < MinG) { MinG = greenValue; }
                    if (greenValue > MaxG) { MaxG = greenValue; }

                    //BLUE
                    blueValue = bitmap.GetPixel(i, j).B;
                    if (blueValue < MinB) { MinB = blueValue; }
                    if (blueValue > MaxB) { MaxB = blueValue; }

                    //MONOCHROMATIC
                    monoValue = (int)Math.Round((redValue * RED_MULTIPLIER + greenValue * GREEN_MULTIPLIER + blueValue * BLUE_MULTIPLIER), 0);
                    if (monoValue < MinMono) { MinMono = monoValue; }
                    if (monoValue > MaxMono) { MaxMono = monoValue; }

                }

            }
        }


        //populate black-white histogram LUT and RGB histogram LUT with data from bitmap
        public void populateLUTs(Bitmap bitmap)
        {
            RedLUT = new int[BRIGHTNESS_LEVELS_NUMBER];
            GreenLUT = new int[BRIGHTNESS_LEVELS_NUMBER];
            BlueLUT = new int[BRIGHTNESS_LEVELS_NUMBER];
            MonoLUT = new int[BRIGHTNESS_LEVELS_NUMBER];
            bitmapWidth = (int)bitmap.GetBounds(ref imageSizeUnit).Width;
            bitmapHeight = (int)bitmap.GetBounds(ref imageSizeUnit).Height;
            for (int i = 0; i < bitmapWidth; i++)
            {
                for (int j = 0; j < bitmapHeight; j++)
                {
                    Color pixel = bitmap.GetPixel(i, j);
                    RedLUT[pixel.R]++;
                    GreenLUT[pixel.G]++;
                    BlueLUT[pixel.B]++;
                    MonoLUT[(int)Math.Round(pixel.R * RED_MULTIPLIER + pixel.G * GREEN_MULTIPLIER + pixel.B * BLUE_MULTIPLIER, 0)]++;
                }
            }
        }
    }
}
