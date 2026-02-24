using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BasicFacebookFeatures.Decorators
{
    public interface IPhoto
    {
        Image GetImage();
    }

    public class FacebookPhoto : IPhoto
    {
        private Image m_Image;

        public FacebookPhoto(Image i_Image)
        {
            m_Image = i_Image;
        }

        public Image GetImage()
        {
            return (Image)m_Image.Clone();
        }
    }

    public abstract class PhotoFilterDecorator : IPhoto
    {
        protected IPhoto m_Photo;

        public PhotoFilterDecorator(IPhoto i_Photo)
        {
            m_Photo = i_Photo;
        }

        public virtual Image GetImage()
        {
            return m_Photo.GetImage();
        }
    }

    public class GrayscaleFilterDecorator : PhotoFilterDecorator
    {
        public GrayscaleFilterDecorator(IPhoto i_Photo) : base(i_Photo) { }

        public override Image GetImage()
        {
            Image originalImage = base.GetImage();
            Bitmap bmp = new Bitmap(originalImage);

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    int gray = (int)((c.R * 0.3) + (c.G * 0.59) + (c.B * 0.11));
                    bmp.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            return bmp;
        }
    }

    public class WatermarkFilterDecorator : PhotoFilterDecorator
    {
        public WatermarkFilterDecorator(IPhoto i_Photo) : base(i_Photo) { }

        public override Image GetImage()
        {
            Image img = base.GetImage();

            using (Graphics g = Graphics.FromImage(img))
            {
                Font font = new Font("Arial", 20, FontStyle.Bold);
                Brush brush = new SolidBrush(Color.FromArgb(150, 255, 255, 255));
                g.DrawString("Design Patterns", font, brush, new PointF(10, 10));
            }
            return img;
        }
    }
}
