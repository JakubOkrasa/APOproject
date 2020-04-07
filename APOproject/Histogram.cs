using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace APOproject
{
    public class Histogram
    {
        const int BRIGHTNESS_LEVELS_NUMBER = 256;
        const int GRAPH_OUTER_MARGIN = 50;
        const int GRAPH_OUTER_LEFT_EXTRA_MARGIN = 20;
        const int GRAPH_INNER_TOP_MARGIN = 10;

        private PictureBox pictureBox;
        // private maxPixelsNumber //todo: global var to use in drawCoordinates (not only drawHistogramData)

        private Graphics graphics;
        private readonly Pen dataPen;
        private readonly Pen axisesPen;
        private float dataPenWidth;
        private readonly Font font;
        private readonly SolidBrush solidBrush;
        private Rectangle frame;
        public int HistogramMaximum { get; set; } //maximum in the histogram
        
        private Pen testPen;
        
        public Histogram(PictureBox pictureBox, Color penColor)
        {
            this.pictureBox = pictureBox;
            graphics = pictureBox.CreateGraphics();
            axisesPen = new Pen(Color.Black, 1.0f);
            font = new Font("Arial", 10);
            solidBrush = new SolidBrush(Color.Black);

            PrepareGraph();
            dataPenWidth = ((float)(frame.Right-1) - frame.Left) / BRIGHTNESS_LEVELS_NUMBER;
            dataPen = new Pen(penColor, dataPenWidth);

            testPen = new Pen(Color.Red, 2.0f);
        }

        public void Clear()
        {
            graphics.Clear(Color.Teal);
        }

        private void PrepareGraph()
        {
            frame = DrawGraphFrame();
        }

        private Rectangle DrawGraphFrame()
        {
            //graph frame
            frame = new Rectangle(
                (int)Math.Round((float)GRAPH_OUTER_MARGIN / 2) + GRAPH_OUTER_LEFT_EXTRA_MARGIN,
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
            //Y=max number of pixels text
            graphics.DrawString((HistogramMaximum).ToString() + " —",
                                font,
                                solidBrush,
                                new Point(frame.Left - 40, frame.Top + GRAPH_INNER_TOP_MARGIN));
            //X=0 text
            graphics.DrawString("0",
                                font,
                                solidBrush,
                                new Point(frame.Left - 10, frame.Bottom));
        }

        public void DrawHistogramData(int[] data)
        {
            HistogramMaximum = data.Max();
            Console.WriteLine("max pixels number: " + HistogramMaximum);
            Console.WriteLine("drawing data...");
            Console.WriteLine("distance: " + (frame.Bottom - frame.Top + GRAPH_INNER_TOP_MARGIN));
            float pixelsNumberMultiplier = (frame.Bottom - frame.Top + GRAPH_INNER_TOP_MARGIN) / (float)HistogramMaximum; //todo: integracja inner top margin z podzialka na wykresie

            graphics.DrawLine(testPen, new PointF(frame.Left - 10, frame.Bottom), new PointF(frame.Left-10, frame.Bottom-pixelsNumberMultiplier*HistogramMaximum));

            PointF startPosition = new PointF(frame.Left + 1, frame.Bottom);
            PointF endPosition = new PointF(startPosition.X, startPosition.Y);
            Console.WriteLine("multiplier: " + pixelsNumberMultiplier);
            foreach (int pixelsNumber in data)
            {
                endPosition.Y -= pixelsNumber*pixelsNumberMultiplier; 
                graphics.DrawLine(dataPen, startPosition, endPosition);
                startPosition.X+=dataPenWidth;
                endPosition.X = startPosition.X;
                endPosition.Y = startPosition.Y;
            }
            DrawCoordinates();
        }
    }
}
