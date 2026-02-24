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

    public class SepiaFilterDecorator : PhotoFilterDecorator
    {
        public SepiaFilterDecorator(IPhoto i_Photo) : base(i_Photo) { }

        public override Image GetImage()
        {
            Image originalImage = base.GetImage();
            Bitmap bmp = new Bitmap(originalImage);

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c = bmp.GetPixel(i, j);

                    int tr = (int)(0.393 * c.R + 0.769 * c.G + 0.189 * c.B);
                    int tg = (int)(0.349 * c.R + 0.686 * c.G + 0.168 * c.B);
                    int tb = (int)(0.272 * c.R + 0.534 * c.G + 0.131 * c.B);

                    int r = Math.Min(255, tr);
                    int g = Math.Min(255, tg);
                    int b = Math.Min(255, tb);

                    bmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            return bmp;
        }
    }

    public class CoolBlueFilterDecorator : PhotoFilterDecorator
    {
        public CoolBlueFilterDecorator(IPhoto i_Photo) : base(i_Photo) { }

        public override Image GetImage()
        {
            Image originalImage = base.GetImage();
            Bitmap bmp = new Bitmap(originalImage);

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c = bmp.GetPixel(i, j);

                    int r = Math.Max(0, c.R - 10);
                    int g = c.G;
                    int b = Math.Min(255, c.B + 40);

                    bmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            return bmp;
        }
    }

    public class BrightnessFilterDecorator : PhotoFilterDecorator
    {
        public BrightnessFilterDecorator(IPhoto i_Photo) : base(i_Photo) { }

        public override Image GetImage()
        {
            Image originalImage = base.GetImage();
            Bitmap bmp = new Bitmap(originalImage);
            int boost = 40;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c = bmp.GetPixel(i, j);

                    int r = Math.Min(255, c.R + boost);
                    int g = Math.Min(255, c.G + boost);
                    int b = Math.Min(255, c.B + boost);

                    bmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            return bmp;
        }
    }

    public class VignetteFilterDecorator : PhotoFilterDecorator
    {
        public VignetteFilterDecorator(IPhoto i_Photo) : base(i_Photo) { }

        public override Image GetImage()
        {
            Image originalImage = base.GetImage();
            Bitmap bmp = new Bitmap(originalImage);

            int centerX = bmp.Width / 2;
            int centerY = bmp.Height / 2;

            double maxDistance = Math.Sqrt((centerX * centerX) + (centerY * centerY));

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c = bmp.GetPixel(i, j);

                    double distance = Math.Sqrt(Math.Pow(i - centerX, 2) + Math.Pow(j - centerY, 2));

                    double factor = 1.0 - (distance / maxDistance);

                    factor = Math.Pow(factor, 0.5);

                    int r = (int)(c.R * factor);
                    int g = (int)(c.G * factor);
                    int b = (int)(c.B * factor);

                    bmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            return bmp;
        }
    }
}
