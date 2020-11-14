using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Microsoft.Win32;

namespace MinimalFetch
{
    class Program
    {
        static void Main(string[] args)
        {
            new Fetch(args);
        }
    }

    class Fetch
    {
        string[] args;
        ConsoleColor    logoColor = ConsoleColor.DarkGray,
                        iconsColor = ConsoleColor.DarkRed,
                        infoColor = ConsoleColor.Gray;

        enum colorParam { black, darkblue, darkgreen, darkcyan, darkred, darkmagenta, darkyellow, gray, darkgray, blue, green, cyan, red, magenta, yellow, white};

        public Fetch(string[] args)
        {
            this.args = args;
            Console.Clear();
            if (args.Length > 0) CheckArgs();
            PrintLogo();
            PrintInfo();
            Colors();
            Console.WriteLine();
            Console.WriteLine();
            Console.ResetColor();
            //Console.ReadKey();
        }

        void CheckArgs()
        {
            string h = "-help";
            string lC = "-logo_color";
            int param;

            for (int i = 0; i < args.Length; i++)
                args[i] = args[i].ToLower();

            if (args.Any(h.Contains))
                PrintHelp();
            else if (string.Equals(args[0],lC))
            {
                try
                {
                    param = (int)System.Enum.Parse(typeof(colorParam), args[1]);
                    logoColor = (ConsoleColor)param;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("\nBad parameters usage!\n");
                    PrintHelp();
                }
            }


        }

        void PrintLogo()
        {
            Console.ForegroundColor = logoColor;

            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("   ┌─────┐┌─────┐");
                Console.WriteLine("   │     ││     │");
                Console.WriteLine("   │     ││     │");
                Console.WriteLine("   └─────┘└─────┘");
            }
        }

        void PrintInfo() 
        {
            Console.SetCursorPosition(20, 2);
            Console.ForegroundColor = iconsColor;
            Console.Write("U ");
            Console.ForegroundColor = infoColor;
            Console.Write("{0}@{1}", Environment.UserName, Environment.MachineName);

            Console.SetCursorPosition(20, 3);
            Console.ForegroundColor = iconsColor;
            Console.Write("O ");
            Console.ForegroundColor = infoColor;
            ManagementObjectSearcher MyOSObj = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject objO in MyOSObj.Get())
            Console.Write(objO["Caption"]);

            Console.SetCursorPosition(20, 4);
            Console.ForegroundColor = iconsColor;
            Console.Write("B ");
            Console.ForegroundColor = infoColor;
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            var UBR = registryKey.GetValue("UBR").ToString();
            var CurrBuild = registryKey.GetValue("CurrentBuild").ToString();
            Console.Write(CurrBuild + "." + UBR);

            Console.SetCursorPosition(20, 5);
            Console.ForegroundColor = iconsColor;
            Console.Write("T ");
            Console.ForegroundColor = infoColor;
            var ms = Environment.TickCount;
            var hrs = ms/3600000;
            var mins = ms/60000 - 60*hrs;
            Console.WriteLine("{0}h {1}m", hrs, mins);

            Console.SetCursorPosition(20, 6);
            Console.ForegroundColor = iconsColor;
            Console.Write("C ");
            Console.ForegroundColor = infoColor;
            ManagementObjectSearcher MyCPUObj = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (ManagementObject objC in MyCPUObj.Get())
            Console.Write(objC["Name"]);

            Console.SetCursorPosition(20, 7);
            Console.ForegroundColor = iconsColor;
            Console.Write("G ");
            Console.ForegroundColor = infoColor;
            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach (ManagementObject objV in myVideoObject.Get())
            Console.WriteLine(objV["Name"]);
        }

        void Colors()
        {
            Console.SetCursorPosition(3, 10);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write("  ");

            Console.SetCursorPosition(7, 10);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("  ");

            Console.SetCursorPosition(11, 10);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("  ");

            Console.SetCursorPosition(15, 10);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("  ");

            Console.SetCursorPosition(19, 10);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write("  ");

            Console.SetCursorPosition(23, 10);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write("  ");

            Console.SetCursorPosition(27, 10);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("  ");

            Console.SetCursorPosition(31, 10);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("  ");

            Console.SetCursorPosition(35, 10);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write("  ");

            Console.SetCursorPosition(39, 10);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("  ");

            Console.SetCursorPosition(43, 10);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("  ");

            Console.SetCursorPosition(47, 10);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("  ");
        }

        void PrintHelp()
        {
            Console.WriteLine("\nMiniFetch 2020 - github.com/Haruno19\n MinimalMiniFetch is a minimal system info for Windows written in C#");
            Console.WriteLine("\nUsage: minifetch [<command>] [<parameter>]");
            Console.WriteLine("\nAvailable commands:\n");
            Console.WriteLine(" -logo_color   changes the color of the printed logo to the selected color.");
            Console.WriteLine("               compatible parameters: white, yellow, magenta, red, cyan, green,");
            Console.WriteLine("               blue, gray, darkgray, darkyellow, darkmagenta, darkred, darkcyan,");
            Console.WriteLine("               darkgreen, darkblue, black.");
            //Console.WriteLine(" -version      shows the current version of MiniFetch and other information.\n");
            System.Environment.Exit(1);
        }
    }
}
