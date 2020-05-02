using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IPA_test.Services
{
    public class ImageAlteringService
    {
        public void WriteTextToImage(string sourceImage, string text, string targetImage, ImageFormat fmt)
        {
            try
            {
                //draw text on image
                using FileStream source = new FileStream(sourceImage, FileMode.Open);
                using Image img = Image.FromStream(source);
                using Graphics graphics = Graphics.FromImage(img);
                using Font font = new Font("Arial", 20, GraphicsUnit.Pixel);

                graphics.DrawString(text, font, Brushes.Black, new PointF(10f, 10f));
                img.Save(targetImage, fmt);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}
