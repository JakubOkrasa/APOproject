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
        const double GRAPH_MARGIN = 100;

        private PictureBox pictureBox;

        private Graphics graphics;
        private readonly Pen dataPen;
        private readonly Pen axisesPen;
        private Color penColor;
        private float penWidth;
        private readonly Font font;
        private readonly SolidBrush solidBrush;
        private Rectangle frame;
        private List<Point> points;

        private int[] data =
        {
            68, 32, 130, 60, 253, 230, 241, 194, 107, 48, 249, 14, 199, 221, 1, 228, 136, 117, 52, 162, 15, 11, 13, 4, 195, 110, 216, 14, 113, 224, 253, 119, 176, 118, 112, 235, 148, 11, 213, 51, 95
            , 151, 61, 170, 216, 97, 155, 145, 255, 201, 17, 245, 124, 206, 212, 88, 187, 191, 44, 224,
            5, 83, 201, 189, 250, 15, 240, 22, 157, 201, 87, 86, 116, 6, 102, 118, 207, 176, 180, 235,
            7, 2, 196, 66, 105, 218, 28, 246, 186, 102, 211, 248, 182, 212, 177, 0, 169, 234, 14, 117, 90
            , 92, 46, 130, 16, 36, 42, 8, 231, 7, 143, 127, 137, 56, 94, 176, 148, 35, 85, 81, 130, 86,
            39, 150, 232, 164, 254, 242, 58, 12, 159, 197, 175, 215, 96, 132, 55, 129, 107, 221, 10, 115,
             9, 203, 74, 18, 82, 228, 218, 112, 230, 114, 15, 202, 164, 218, 30, 152, 64, 108, 24, 156,
            6, 39, 158, 152, 81, 213, 129, 66, 4, 19, 111, 235, 87, 19, 193, 102, 177, 50, 105, 221, 99,
            252, 53, 199, 151, 255, 8, 166, 205, 144, 9, 80, 102, 167, 69, 173, 219, 109, 136, 49, 194,
            76, 248, 120, 33, 20, 43, 68, 86, 85, 109, 137, 170, 130, 188, 173, 174, 58, 149, 120, 250,
            9, 53, 164, 20, 208, 37, 194, 75, 64, 174, 58, 193, 39, 114, 41, 136, 186, 151, 58, 234, 141,
             55, 23, 151, 6, 7, 46, 211, 58, 20, 96, 122, 215
        };

        public Histogram(PictureBox pictureBox, Color color)
        {
            this.pictureBox = pictureBox;
            graphics = pictureBox.CreateGraphics();

            penWidth = (frame.Right - frame.Left) / BRIGHTNESS_LEVELS_NUMBER;
            penColor = color;
            dataPen = new Pen(penColor, penWidth);
            axisesPen = new Pen(Color.Black, 1.0f);

            font = new Font("Arial", 10);
            solidBrush = new SolidBrush(Color.Black);

            PrepareGraph();
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
                (int)Math.Round(GRAPH_MARGIN / 2),
                (int)Math.Round(GRAPH_MARGIN / 2),
                (int)(pictureBox.Width - GRAPH_MARGIN),
                (int)(pictureBox.Height - GRAPH_MARGIN));
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
            Point startPosition = new Point(frame.Left + 1, frame.Bottom);
            Point endPosition = new Point(startPosition.X, startPosition.Y);
            foreach (int pixelsNumber in data)
            {
                endPosition.Y -= pixelsNumber;
                graphics.DrawLine(dataPen, startPosition, endPosition);
                startPosition.X++;
                endPosition.X = startPosition.X;
                endPosition.Y = startPosition.Y;
            }
        }
    }
}
