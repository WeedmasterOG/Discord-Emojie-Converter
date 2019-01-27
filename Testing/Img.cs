using System;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace Testing
{
    class Img
    {
        public static Bitmap bitmap;

        public static async Task PrepairImage(string FileName, float GreyScaleThreshHold, Size size)
        {
            using (Stream bmpStream = File.Open(FileName, FileMode.Open))
            {
                using (Image image = Image.FromStream(bmpStream))
                {
                    bitmap = new Bitmap(image, size);
                }
            }

            using (Graphics gr = Graphics.FromImage(bitmap)) // SourceImage is a Bitmap object
            {
                using (var ia = new ImageAttributes())
                {
                    ia.SetColorMatrix(new ColorMatrix(new float[][]
                    {
                        new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                        new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                        new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                        new float[] { 0,      0,      0,      1, 0 },
                        new float[] { 0,      0,      0,      0, 1 }
                    }));

                    ia.SetThreshold(GreyScaleThreshHold);

                    await Task.Run(() => gr.DrawImage(
                        bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0,
                        bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, ia)
                    );
                }
            }
        }
    }
}
