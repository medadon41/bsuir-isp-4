using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    class Program
    {
        [DllImport("winmm.dll")]
        public static extern bool PlaySound(string sound, IntPtr hmod, uint fdwSound);

        static void Main(string[] args)
        {
            bool cont = true;
            while (cont)
            {
                Console.Clear();
                Console.WriteLine("Choose what do you want to play: \n0. Default audio file. \n1. Your audio file.");
                string pick = Console.ReadLine();
                if (pick == "1")
                {
                    Console.Write("Enter the path to the .wav file: ");
                    string filename = Console.ReadLine();

                    FileInfo fileInf = new FileInfo(filename);

                    while (!fileInf.Exists)
                    {

                        Console.Write("Failed to load the file, try again: ");
                        fileInf = new FileInfo(Console.ReadLine());
                    }

                    filename = fileInf.FullName;

                    Console.WriteLine($"\nNow playing: {fileInf.Name}\n");

                    PlaySound(filename, IntPtr.Zero, 0x0001);

                    Console.WriteLine($"Press S to skip currently playing track: ");

                    while (Console.ReadKey().Key != ConsoleKey.S)
                    {
                        Console.ReadKey();
                    }

                    PlaySound(" ", IntPtr.Zero, 0x0001);

                }
                else if (pick == "0")
                {

                    Console.WriteLine($"\nNow playing: Valve Studio Orchestra - Rocket Jump Waltz\n");

                    PlaySound("../../../../default.wav", IntPtr.Zero, 0x0001);

                    Console.WriteLine($"Press S to skip currently playing track: ");
                    while (Console.ReadKey().Key != ConsoleKey.S)
                    {
                        Console.ReadKey();
                    }
                    PlaySound(" ", IntPtr.Zero, 0x0001);
                }
            }


        }
    }
}
