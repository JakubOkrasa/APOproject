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

        public int[] MonoLUT { get; set; }
        public int[] RedLUT { get; set; }
        public int[] GreenLUT { get; set; }
        public int[] BlueLUT { get; set; }


        // min and max existing brightness/color saturation in the image
        public int MinLevelMono { get; set; }
        public int MaxLevelMono { get; set; }
        public int MinLevelR { get; set; }
        public int MaxLevelR { get; set; }
        public int MinLevelG { get; set; }
        public int MaxLevelG { get; set; }
        public int MinLevelB { get; set; }
        public int MaxLevelB { get; set; }

        public int MaxOccurenceNumberMono { get; set; }
        public int MaxOccurenceNumberRed { get; set; }
        public int MaxOccurenceNumberGreen { get; set; }
        public int MaxOccurenceNumberBlue { get; set; }

        public LookUpTable(ImageForm imageForm)
        {
            this.imageForm = imageForm;  
            this.bitmap = imageForm.PictureBox.Image as Bitmap;

            
            MinLevelR = bitmap.GetPixel(0, 0).R;
            MaxLevelR = bitmap.GetPixel(0, 0).R;
            MinLevelG = bitmap.GetPixel(0, 0).G;
            MaxLevelG = bitmap.GetPixel(0, 0).G;
            MinLevelB = bitmap.GetPixel(0, 0).B;
            MaxLevelB = bitmap.GetPixel(0, 0).B;
            MinLevelMono = (int)Math.Round(MinLevelR * RED_MULTIPLIER + MinLevelG * GREEN_MULTIPLIER + MinLevelB * BLUE_MULTIPLIER, 0);
            MaxLevelMono = (int)Math.Round(MaxLevelR * RED_MULTIPLIER + MaxLevelG * GREEN_MULTIPLIER + MaxLevelB * BLUE_MULTIPLIER, 0);

            BitmapWidth = (int)bitmap.GetBounds(ref imageSizeUnit).Width;
            BitmapHeight = (int)bitmap.GetBounds(ref imageSizeUnit).Height;

            populateLUTs(bitmap);
            setExtremums();
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
                    if (redValue < MinLevelR) { MinLevelR = redValue; } //find minimum
                    if (redValue > MaxLevelR) { MaxLevelR = redValue; } //find maximum

                    //GREEN
                    greenValue = bitmap.GetPixel(i, j).G;
                    if (greenValue < MinLevelG) { MinLevelG = greenValue; }
                    if (greenValue > MaxLevelG) { MaxLevelG = greenValue; }

                    //BLUE
                    blueValue = bitmap.GetPixel(i, j).B;
                    if (blueValue < MinLevelB) { MinLevelB = blueValue; }
                    if (blueValue > MaxLevelB) { MaxLevelB = blueValue; }

                    //MONOCHROMATIC
                    monoValue = (int)Math.Round((redValue * RED_MULTIPLIER + greenValue * GREEN_MULTIPLIER + blueValue * BLUE_MULTIPLIER), 0);
                    if (monoValue < MinLevelMono) { MinLevelMono = monoValue; }
                    if (monoValue > MaxLevelMono) { MaxLevelMono = monoValue; }

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
