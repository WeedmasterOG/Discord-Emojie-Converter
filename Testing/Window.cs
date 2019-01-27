using System;
using System.Text;

namespace Testing
{
    class Window
    {
        public static string GetActiveWindow()
        {
            IntPtr handle = NativeMethods.GetForegroundWindow();
            int intLength = NativeMethods.GetWindowTextLength(handle) + 1;
            StringBuilder stringBuilder = new StringBuilder(intLength);
            if (NativeMethods.GetWindowText(handle, stringBuilder, intLength) > 0)
            {
                return stringBuilder.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
