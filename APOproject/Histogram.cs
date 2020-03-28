using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace APOproject
{
    class Histogram
    {
        const int BRIGHTNESS_LEVELS_NUMBER = 256;
        const int GRAPH_OUTER_MARGIN = 100;
        //const int GRAPH_INNER_TOP_MARGIN = 

        private PictureBox pictureBox;

        private Graphics graphics;
        private readonly Pen dataPen;
        private readonly Pen axisesPen;
        private float dataPenWidth;
        private readonly Font font;
        private readonly SolidBrush solidBrush;
        private Rectangle frame;
        
        public Histogram(PictureBox pictureBox, Color penColor)
        {
            this.pictureBox = pictureBox;
            graphics = pictureBox.CreateGraphics();
            axisesPen = new Pen(Color.Black, 1.0f);
            font = new Font("Arial", 10);
            solidBrush = new SolidBrush(Color.Black);

            PrepareGraph();
            dataPenWidth = ((float)frame.Right - frame.Left) / BRIGHTNESS_LEVELS_NUMBER;
            dataPen = new Pen(penColor, dataPenWidth);      
        }

        private void PrepareGraph()
        {
            frame = DrawGraphFrame();
            DrawCoordinates();
        }

        private Rectangle DrawGraphFrame()
        {
            //graph frame
            frame = new Rectangle(
                (int)Math.Round((float)GRAPH_OUTER_MARGIN / 2),
                (int)Math.Round((float)GRAPH_OUTER_MARGIN / 2),
                pictureBox.Width - GRAPH_OUTER_MARGIN,
                pictureBox.Height - GRAPH_OUTER_MARGIN
                );
            graphics.DrawRectangle(axisesPen, frame);
            return frame;


        }

        private void DrawCoordinates()
        {
            //X=255 text
            graphics.DrawString((BRIGHTNESS_LEVELS_NUMBER - 1).ToString(),
                                font,
                                solidBrush,
                                new Point(frame.Right - 10, frame.Bottom));
            //Y=255 text
            graphics.DrawString((BRIGHTNESS_LEVELS_NUMBER - 1).ToString() + " —",
                                font,
                                solidBrush,
                                new Point(frame.Left - 40, frame.Top + 30));
            //X=0 text
            graphics.DrawString("0",
                                font,
                                solidBrush,
                                new Point(frame.Left - 10, frame.Bottom));
        }

        public void DrawHistogramData(int[] data, int maxPixelsNumber)
        {
            Console.WriteLine("drawing data...");
            PointF startPosition = new PointF(frame.Left + 1, frame.Bottom);
            PointF endPosition = new PointF(startPosition.X, startPosition.Y);
            foreach (int pixelsNumber in data)
            {
                endPosition.Y -= pixelsNumber; 
                graphics.DrawLine(dataPen, startPosition, endPosition);
                startPosition.X+=dataPenWidth;
                endPosition.X = startPosition.X;
                endPosition.Y = startPosition.Y;
            }
        }
    }
}
