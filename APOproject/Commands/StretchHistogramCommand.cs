using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace APOproject.Commands
{
    public class StretchHistogramCommand : ICommand
    {
        const int BRIGHTNESS_LEVELS_NUMBER = 256;

        public Bitmap Bitmap { get; set; }
        private LookUpTable lookUpTable;
        private ImageForm imageForm;

        public StretchHistogramCommand(LookUpTable lookUpTable, ImageForm imageForm)
        {
            this.lookUpTable = lookUpTable;
            this.imageForm = imageForm;
            Bitmap = imageForm.PictureBox.Image as Bitmap;            
        }

        public void execute()
        {
            modifyBitmapToStretchHistogram();
            lookUpTable.populateLUTs(Bitmap);
            imageForm.PictureBox.Image = Bitmap;
        }

        public void undo()
        {
            throw new NotImplementedException();
        }


        private void modifyBitmapToStretchHistogram()
        {
            LookUpTable lookUpTable = new LookUpTable(imageForm); //gets min and max values from 3 channels (RGB)
            int redNewValue;
            int greenNewValue;
            int blueNewValue;
            Color oldColor;

            for (int i = 0; i < lookUpTable.BitmapWidth; i++)
            {
                for (int j = 0; j < lookUpTable.BitmapHeight; j++)
                {
                    oldColor = Bitmap.GetPixel(i, j);

                    redNewValue = (oldColor.R - lookUpTable.MinR) * (BRIGHTNESS_LEVELS_NUMBER / (lookUpTable.MaxR - lookUpTable.MinR));
                    greenNewValue = (oldColor.G - lookUpTable.MinG) * (BRIGHTNESS_LEVELS_NUMBER / (lookUpTable.MaxG - lookUpTable.MinG));
                    blueNewValue = (oldColor.B - lookUpTable.MinB) * (BRIGHTNESS_LEVELS_NUMBER / (lookUpTable.MaxB - lookUpTable.MinB));

                    Bitmap.SetPixel(i, j, Color.FromArgb(redNewValue, greenNewValue, blueNewValue));
                }
            }
        }


        
    }
}
