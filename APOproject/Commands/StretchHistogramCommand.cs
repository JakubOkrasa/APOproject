﻿using System;
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
        HistogramCreator histogramCreator;
        private ImageForm imageForm;

        public StretchHistogramCommand(HistogramCreator histogramCreator, ImageForm imageForm)
        {
            this.histogramCreator = histogramCreator;
            this.imageForm = imageForm;
            Bitmap = imageForm.PictureBox.Image as Bitmap;            
        }

        public void execute()
        {
            modifyBitmapToStretchHistogram(Bitmap);
            histogramCreator.populateLUTs(Bitmap);
            imageForm.PictureBox.Image = Bitmap;
        }

        public void undo()
        {
            throw new NotImplementedException();
        }


        private void modifyBitmapToStretchHistogram(Bitmap bitmap)
        {
            BoundaryValues boundaryValues = new BoundaryValues(Bitmap); //gets min and max values from 3 channels (RGB)
            int redNewValue;
            int greenNewValue;
            int blueNewValue;
            Color oldColor;

            for (int i = 0; i < boundaryValues.BitmapWidth; i++)
            {
                for (int j = 0; j < boundaryValues.BitmapHeight; j++)
                {
                    oldColor = Bitmap.GetPixel(i, j);

                    redNewValue = (oldColor.R - boundaryValues.MinR) * (BRIGHTNESS_LEVELS_NUMBER / (boundaryValues.MaxR - boundaryValues.MinR));
                    greenNewValue = (oldColor.G - boundaryValues.MinG) * (BRIGHTNESS_LEVELS_NUMBER / (boundaryValues.MaxG - boundaryValues.MinG));
                    blueNewValue = (oldColor.B - boundaryValues.MinB) * (BRIGHTNESS_LEVELS_NUMBER / (boundaryValues.MaxB - boundaryValues.MinB));

                    Bitmap.SetPixel(i, j, Color.FromArgb(redNewValue, greenNewValue, blueNewValue));
                }
            }
        }


        
    }
}