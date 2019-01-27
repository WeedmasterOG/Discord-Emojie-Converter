using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Testing
{
    class Emojies
    {
        public static void Write(bool Invert)
        {
            Color col = new Color();
            string Emojies = "";
            int counter = 0;
            string Clip = Cboard.GetSet("Get", null);
            List<int> RgbValues = new List<int>(new int[] { 255, 255, 255 });

            if (Invert == true)
            {
                RgbValues[0] = 0;
                RgbValues[1] = 0;
                RgbValues[2] = 0;
            }

            for (int i = 0; i < Img.bitmap.Height; i++)
            {
                for (int f = 0; f < Img.bitmap.Width; f++)
                {
                    col = Img.bitmap.GetPixel(f, i);

                    if (col.R == RgbValues[0] && col.G == RgbValues[1] && col.B == RgbValues[2])
                    {
                        Emojies += ":black_circle:";
                    }
                    else
                    {
                        Emojies += ":red_circle:";
                    }
                }

                Thread.Sleep(500);

                Cboard.GetSet("Set", Emojies);
                SendKeys.SendWait("^{v}");

                Thread.Sleep(50);

                if (counter == 5)
                {
                    SendKeys.SendWait("{ENTER}");
                    counter = 0;
                }
                else
                {
                    SendKeys.SendWait("+{ENTER}");
                }

                Emojies = "";
                counter++;
            }

            SendKeys.SendWait("{ENTER}");

            Cboard.GetSet("Set", Clip);
        }
    }
}
