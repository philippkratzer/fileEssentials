using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEssentials.Util
{
   public static class ImageUtil
    {
        public static void ResizeFile(string path, string pathNew, int longSize)
        {
            using (Image img = Image.FromFile(path))
            {
                SaveBitmap(ResizeMe(img, longSize), pathNew);
            }
        }

        private static Bitmap ResizeMe(Image srcImg, double longone)
        {
            double newWidth;
            double dblFac;
            double newHeight;

            if (srcImg.Height > srcImg.Width)
            {
                newHeight = longone;
                dblFac = newHeight / srcImg.Height;
                newWidth = dblFac * srcImg.Width;
            }
            else
            {
                newWidth = longone;
                dblFac = newWidth / srcImg.Width;
                newHeight = dblFac * srcImg.Height;
            }

            // Bild bearbeiten
            Bitmap resizedImg = new Bitmap((int)newWidth, (int)newHeight);
            using (Graphics gNew = Graphics.FromImage(resizedImg))
            {
                gNew.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gNew.DrawImage(srcImg, new Rectangle(0, 0, (int)newWidth, (int)newHeight));
            }
            return resizedImg;
        }

        private static void SaveBitmap(Bitmap bitmap, string path)
        {
            ImageCodecInfo myImageCodecInfo;
            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;

            Directory.CreateDirectory(new FileInfo(path).DirectoryName);

            // Get an ImageCodecInfo object that represents the JPEG codec.
            myImageCodecInfo = GetEncoderInfo("image/jpeg");

            // Create an Encoder object based on the GUID 

            // for the Quality parameter category.
            myEncoder = System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object. 

            // An EncoderParameters object has an array of EncoderParameter 

            // objects. In this case, there is only one 

            // EncoderParameter object in the array.
            myEncoderParameters = new EncoderParameters(1);

            // Save the bitmap as a JPEG file with quality level 25.
            myEncoderParameter = new EncoderParameter(myEncoder, 75L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bitmap.Save(path, myImageCodecInfo, myEncoderParameters);
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}
