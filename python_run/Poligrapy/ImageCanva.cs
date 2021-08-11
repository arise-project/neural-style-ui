using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using python_run.Poligragy.Size;

namespace python_run.Poligragy
{
    public class ImageCanva
    {
        public void Add(string fileName)
        {
             using(FileStream pngStream = new FileStream(fileName,FileMode.Open, FileAccess.ReadWrite))
            using(var image = new Bitmap(pngStream))
            {
                var dpi = (int)image.HorizontalResolution;
                var k = A._72DPI.Keys.ToArray();
                A a = null;
                for(int i = k.Length - 1; i > 0; i--)
                {
                    var key = k[i];
                    if(A.Get(key, dpi).Width > image.Width)
                    {
                        a = A.Get(key, dpi);
                    }
                }

                var w = image.Width;
                var h = (image.Width * a.Height) / a.Width;
                
                var resized = new Bitmap(w, h);
                using (var graphics = Graphics.FromImage(resized))
                {
                    graphics.CompositingQuality = CompositingQuality.HighSpeed;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.DrawImage(image, 0, (h - image.Height)/2, image.Width, image.Height);
                    resized.Save(pngStream, ImageFormat.Png);
                }       
            } 
 
        }
    }
}
