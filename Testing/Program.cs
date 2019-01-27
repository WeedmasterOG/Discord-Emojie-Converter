using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Globalization;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            bool InvertColors = false;
            bool SafetyOn = true;

            while (true)
            {
                Write("Image path", ConsoleColor.White);

                // User input
                string ImagePath = Console.ReadLine();

                if (File.Exists(ImagePath))
                {
                    // User input
                    Console.Clear();
                    Write("Size(18 recommended): ", ConsoleColor.White);
                    int size = int.Parse(Console.ReadLine());

                    if (size > 20)
                    {
                        Console.Clear();
                        Write("Warning: maximum size possible is 20x20", ConsoleColor.Yellow);
                        Thread.Sleep(2500);
                    }

                    Console.Clear();

                    // User input
                    Write("GreyScale(0.5 recommended): ", ConsoleColor.White);
                    float GreyScale = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);

                    if (Path.GetExtension(ImagePath) == ".png")
                    {
                        Console.Clear();
                        Write("Warning! Make sure the PNG file dosnt contain any transparent pixels", ConsoleColor.Yellow);
                        Thread.Sleep(3500);
                    }

                    Img.PrepairImage(ImagePath, GreyScale, new Size(size, size)).Wait();
                    Console.Clear();
                    Write("Writing...", ConsoleColor.White);
                    Thread.Sleep(3500);

                    if (Window.GetActiveWindow().Contains("Discord") == true || SafetyOn == false)
                    {
                        Emojies.Write(InvertColors);
                    }
                } else
                {
                    Console.Clear();
                    Write("Error: file not found", ConsoleColor.DarkRed);
                    Thread.Sleep(2500);
                }

                Console.Clear();
            }
        }

        private static void Write(string Text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(Text);
        }
    }
}
