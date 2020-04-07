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
        private LookUpTablesSet lookUpTable;
        private ImageForm imageForm;

        public StretchHistogramCommand(LookUpTablesSet lookUpTable, ImageForm imageForm)
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
            int redNewValue;
            int greenNewValue;
            int blueNewValue;
            Color oldColor;

            for (int i = 0; i < lookUpTable.BitmapWidth; i++)
            {
                for (int j = 0; j < lookUpTable.BitmapHeight; j++)
                {
                    oldColor = Bitmap.GetPixel(i, j);

                    redNewValue = (oldColor.R - lookUpTable.MinLevelR) * (BRIGHTNESS_LEVELS_NUMBER / (lookUpTable.MaxLevelR - lookUpTable.MinLevelR));
                    greenNewValue = (oldColor.G - lookUpTable.MinLevelG) * (BRIGHTNESS_LEVELS_NUMBER / (lookUpTable.MaxLevelG - lookUpTable.MinLevelG));
                    blueNewValue = (oldColor.B - lookUpTable.MinLevelB) * (BRIGHTNESS_LEVELS_NUMBER / (lookUpTable.MaxLevelB - lookUpTable.MinLevelB));

                    Bitmap.SetPixel(i, j, Color.FromArgb(redNewValue, greenNewValue, blueNewValue));
                }
            }
        }


        
    }
}
