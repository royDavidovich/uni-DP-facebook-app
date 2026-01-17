using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace BasicFacebookFeatures.Utilities
{
    /// Note - this was created with the help of AI, because it was only for UI purposes,
    /// in order to "view" images we had to shrink their size

    /// <summary>
    /// Utility class for image loading and manipulation operations
    /// Provides memory-efficient image loading with automatic resizing
    /// </summary>
    public static class ImageHelper
    {
        private const long k_MaxSizeInBytes = 5 * 1024 * 1024; //5MB
        private const int k_MaxImageDimension = 800;
        private const int k_PreviewWidth = 100;
        private const int k_PreviewHeight = 100;

        /// <summary>
        /// Load an image with memory optimization
        /// Automatically resizes large images to prevent out-of-memory exceptions
        /// </summary>
        /// <param name="i_ImagePath">Path to the image file</param>
        /// <returns>Loaded and optionally resized Image object, or null if invalid</returns>
        public static Image LoadImageWithMemoryManagement(string i_ImagePath)
        {
            if (string.IsNullOrEmpty(i_ImagePath) || !File.Exists(i_ImagePath))
            {
                return null;
            }

            try
            {
                FileInfo fileInfo = new FileInfo(i_ImagePath);
                long fileSizeInBytes = fileInfo.Length;

                if (fileSizeInBytes > k_MaxSizeInBytes)
                {
                    MessageBox.Show(
                        $"Image file size ({fileSizeInBytes / (1024 * 1024)}MB) is large. Resizing for preview...",
                        "Large File",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }

                using (FileStream fileStream = new FileStream(i_ImagePath, FileMode.Open, FileAccess.Read))
                {
                    Image originalImage = Image.FromStream(fileStream);

                    // Check if resizing is needed
                    if (originalImage.Width > k_MaxImageDimension || originalImage.Height > k_MaxImageDimension)
                    {
                        Image resizedImage = ResizeImage(originalImage, k_PreviewWidth, k_PreviewHeight);
                        originalImage.Dispose();
                        return resizedImage;
                    }

                    return originalImage;
                }
            }
            catch (OutOfMemoryException)
            {
                throw new OutOfMemoryException("Image is too large to load.");
            }
        }

        /// <summary>
        /// Resize an image while maintaining aspect ratio
        /// Uses high-quality bicubic interpolation for best results
        /// </summary>
        /// <param name="i_Image">Image to resize</param>
        /// <param name="i_MaxWidth">Maximum width in pixels</param>
        /// <param name="i_MaxHeight">Maximum height in pixels</param>
        /// <returns>Resized Bitmap object</returns>
        public static Image ResizeImage(Image i_Image, int i_MaxWidth, int i_MaxHeight)
        {
            if (i_Image == null)
            {
                throw new ArgumentNullException(nameof(i_Image));
            }

            if (i_MaxWidth <= 0 || i_MaxHeight <= 0)
            {
                throw new ArgumentException("Max width and height must be greater than zero.");
            }

            try
            {
                // Calculate aspect ratio
                double ratioX = (double)i_MaxWidth / i_Image.Width;
                double ratioY = (double)i_MaxHeight / i_Image.Height;
                double ratio = Math.Min(ratioX, ratioY);

                // Calculate new dimensions
                int newWidth = (int)(i_Image.Width * ratio);
                int newHeight = (int)(i_Image.Height * ratio);

                // Create resized bitmap
                Bitmap resizedBitmap = new Bitmap(newWidth, newHeight);
                Graphics graphics = Graphics.FromImage(resizedBitmap);

                // Use high-quality interpolation
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(i_Image, 0, 0, newWidth, newHeight);

                graphics.Dispose();

                return resizedBitmap;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to resize image: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Validate image file existence and format
        /// </summary>
        /// <param name="i_ImagePath">Path to validate</param>
        /// <returns>True if valid image file, false otherwise</returns>
        public static bool IsValidImageFile(string i_ImagePath)
        {
            if (string.IsNullOrEmpty(i_ImagePath))
            {
                return false;
            }

            if (!File.Exists(i_ImagePath))
            {
                return false;
            }

            try
            {
                string extension = Path.GetExtension(i_ImagePath).ToLower();
                return extension == ".jpg" || extension == ".jpeg" ||
                       extension == ".png" || extension == ".gif" ||
                       extension == ".bmp";
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Dispose image safely
        /// </summary>
        /// <param name="i_Image">Image to dispose</param>
        public static void SafeDisposeImage(ref Image i_Image)
        {
            if (i_Image != null)
            {
                i_Image.Dispose();
                i_Image = null;
            }
        }
    }
}