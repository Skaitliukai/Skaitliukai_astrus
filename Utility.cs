using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;

namespace Skaitliukai_astrus
{
    class Utility
    {
        //Jei nėra direktorijų nuotraukom saugot - sukuriam
        public static void checkForFolders()
        {
            string dir = Directory.GetCurrentDirectory();
            if (!Directory.Exists(Path.Combine(dir, ConfigurationManager.AppSettings["ImagesFolder"])))
            {
                Directory.CreateDirectory(Path.Combine(dir, ConfigurationManager.AppSettings["ImagesFolder"]));
                Directory.CreateDirectory(Path.Combine(dir, ConfigurationManager.AppSettings["CroppedImagesFolder"]));
                return;
            }
            else if (!Directory.Exists(Path.Combine(dir, ConfigurationManager.AppSettings["CroppedImagesFolder"])))
                Directory.CreateDirectory(Path.Combine(dir, ConfigurationManager.AppSettings["CroppedImagesFolder"]));
        }

        //Išsaugom foto laikinai - apdirbimui
        public static void saveTempImage(string source)
        {
            File.Copy(source, Path.Combine(Directory.GetCurrentDirectory(), "temp.png"), true);
        }

        //Pašalinam laikiną foto
        public static void deleteTempImage()
        {
            File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "temp.png"));
        }

        //Dujų skaitliuką reik paversti į negatyvą
        public static void Negate(Bitmap image)
        {
            const int RED_PIXEL = 2;
            const int GREEN_PIXEL = 1;
            const int BLUE_PIXEL = 0;

            BitmapData bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);

            try
            {
                int stride = bmData.Stride;
                int bytesPerPixel = (image.PixelFormat == PixelFormat.Format24bppRgb ? 3 : 4);

                unsafe
                {
                    byte* pixel = (byte*)(void*)bmData.Scan0;
                    int yMax = image.Height;
                    int xMax = image.Width;

                    for (int y = 0; y < yMax; y++)
                    {
                        int yPos = y * stride;
                        for (int x = 0; x < xMax; x++)
                        {
                            int pos = yPos + (x * bytesPerPixel);

                            pixel[pos + RED_PIXEL] = (byte)(255 - pixel[pos + RED_PIXEL]);
                            pixel[pos + GREEN_PIXEL] = (byte)(255 - pixel[pos + GREEN_PIXEL]);
                            pixel[pos + BLUE_PIXEL] = (byte)(255 - pixel[pos + BLUE_PIXEL]);
                        }

                    }
                }
            }
            finally
            {
                image.UnlockBits(bmData);
            }
        }
    }
}
