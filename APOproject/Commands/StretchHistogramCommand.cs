using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace APOproject.Commands
{
    public class StretchHistogramCommand
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

        public void execute(int brightnessLevelsNumber=BRIGHTNESS_LEVELS_NUMBER)
        {
            modifyBitmapToStretchHistogram(brightnessLevelsNumber);
            lookUpTable.populateLUTs(Bitmap);
            imageForm.PictureBox.Image = Bitmap;
        }

        public void undo()
        {
            throw new NotImplementedException();
        }


        private void modifyBitmapToStretchHistogram(int brightnessLevelsNumber=BRIGHTNESS_LEVELS_NUMBER)
        {
            int redNewValue;
            int greenNewValue;
            int blueNewValue;
            Color oldColor;
            float redStretchMultiplier = (float)(brightnessLevelsNumber-1) / (lookUpTable.MaxLevelR - lookUpTable.MinLevelR);
            float greenStretchMultiplier = (float)(brightnessLevelsNumber-1) / (lookUpTable.MaxLevelG - lookUpTable.MinLevelG);
            float blueStretchMultiplier = (float)(brightnessLevelsNumber-1) / (lookUpTable.MaxLevelB - lookUpTable.MinLevelB);
            

            for (int i = 0; i < lookUpTable.BitmapWidth; i++)
            {
                for (int j = 0; j < lookUpTable.BitmapHeight; j++)
                {
                    oldColor = Bitmap.GetPixel(i, j);
                    redNewValue = (int)Math.Round((oldColor.R - lookUpTable.MinLevelR) * redStretchMultiplier, 0);
                    greenNewValue = (int)Math.Round((oldColor.G - lookUpTable.MinLevelG) * greenStretchMultiplier, 0);
                    blueNewValue = (int)Math.Round((oldColor.B - lookUpTable.MinLevelB) * blueStretchMultiplier, 0);                    
                    Bitmap.SetPixel(i, j, Color.FromArgb(redNewValue, greenNewValue, blueNewValue));
                }
            }
        }


        
    }
}
