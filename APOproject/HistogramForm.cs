using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APOproject
{
    public partial class HistogramForm : Form
    {
        const double RED_MULTIPLIER = 0.2126;
        const double GREEN_MULTIPLIER = 0.7152;
        const double BLUE_MULTIPLIER = 0.0722;

        public HistogramForm()
        {
            InitializeComponent();
            getLUT();
        }

        private int[] getLUT()
        {
            int[] blackWhiteLUT = new int[256]; // 256 poziomów jasności
            string imagePath = APOgui.openFileDialog.FileName;
            Bitmap bitmap = new Bitmap(imagePath);
            GraphicsUnit unit = GraphicsUnit.Pixel;
            int imageWidth = (int)bitmap.GetBounds(ref unit).Width;
            int imageHeight = (int)bitmap.GetBounds(ref unit).Height;
            for (int i=0; i<imageWidth; i++)
            {
                for (int j = 0; j<imageHeight; j++)
                {
                    Color pixel = bitmap.GetPixel(i, 0);
                    int brightness = (int)Math.Round(pixel.R * RED_MULTIPLIER + pixel.G * GREEN_MULTIPLIER + pixel.B * BLUE_MULTIPLIER, 0);
                    blackWhiteLUT[brightness]++;
                }              
            
            }

            return blackWhiteLUT;
        }
    }
}
