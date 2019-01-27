using System;
using System.Threading;
using System.Windows.Forms;

namespace Testing
{
    class Cboard
    {
        public static string GetSet(string getset, string Text)
        {
            string text = null;

            Thread thread = new Thread(() =>
            {
                if (getset == "Set" && Text != null)
                {
                    Clipboard.SetText(Text);
                } else
                {
                    text = Clipboard.GetText();
                }

                Thread.CurrentThread.IsBackground = true;
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            return text;
        }
    }
}
