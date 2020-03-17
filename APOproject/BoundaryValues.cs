using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace APOproject
{
    class BoundaryValues
    {
        public int MinR { get; set; }
        public int MaxR { get; set; }
        public int MinG { get; set; }
        public int MaxG { get; set; }
        public int MinB { get; set; }
        public int MaxB { get; set; }

        public int BitmapHeight { get; set; }
        public int BitmapWidth { get; set; }
        public Bitmap Bitmap { get; set; }

        GraphicsUnit imageSizeUnit = GraphicsUnit.Pixel;
        

        public BoundaryValues(Bitmap bitmap)
        {
            Bitmap = bitmap;

            MinR = Bitmap.GetPixel(0, 0).R;
            MaxR = Bitmap.GetPixel(0, 0).R;
            MinG = Bitmap.GetPixel(0, 0).G;
            MaxG = Bitmap.GetPixel(0, 0).G;
            MinB = Bitmap.GetPixel(0, 0).B;
            MaxB = Bitmap.GetPixel(0, 0).B;

            BitmapWidth = (int)Bitmap.GetBounds(ref imageSizeUnit).Width;
            BitmapHeight = (int)Bitmap.GetBounds(ref imageSizeUnit).Height;

            for (int i = 0; i < BitmapWidth; i++)
            {
                for (int j = 0; j < BitmapHeight; j++)
                {
                    //RED
                    if (Bitmap.GetPixel(i, j).R < MinR) { MinR = Bitmap.GetPixel(i, j).R; } //find minimum
                    if (Bitmap.GetPixel(i, j).R > MaxR) { MaxR = Bitmap.GetPixel(i, j).R; } //find maximum

                    //GREEN
                    if (Bitmap.GetPixel(i, j).G < MinG) { MinG = Bitmap.GetPixel(i, j).G; }
                    if (Bitmap.GetPixel(i, j).G > MaxG) { MaxG = Bitmap.GetPixel(i, j).G; }

                    //BLUE
                    if (Bitmap.GetPixel(i, j).B < MinB) { MinB = Bitmap.GetPixel(i, j).B; }
                    if (Bitmap.GetPixel(i, j).B > MaxB) { MaxB = Bitmap.GetPixel(i, j).B; }

                }

            }
        }
    }
}
