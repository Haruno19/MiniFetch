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
            new Fetch();
        }
    }

    class Fetch
    {
        public Fetch()
        {
            Console.Clear();
            PrintLogo();
            PrintInfo();
            Colors();
            Console.WriteLine();
            Console.WriteLine();
            Console.ResetColor();
            //Console.ReadKey();
        }

        void PrintLogo()
        {
            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = ConsoleColor.DarkGray;
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
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("U ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("{0}@{1}", Environment.UserName, Environment.MachineName);

            Console.SetCursorPosition(20, 3);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("O ");
            Console.ForegroundColor = ConsoleColor.Gray;
            ManagementObjectSearcher MyOSObj = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject objO in MyOSObj.Get())
            Console.Write(objO["Caption"]);

            Console.SetCursorPosition(20, 4);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("B ");
            Console.ForegroundColor = ConsoleColor.Gray;
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            var UBR = registryKey.GetValue("UBR").ToString();
            var CurrBuild = registryKey.GetValue("CurrentBuild").ToString();
            Console.Write(CurrBuild + "." + UBR);

            Console.SetCursorPosition(20, 5);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("T ");
            Console.ForegroundColor = ConsoleColor.Gray;
            var ms = Environment.TickCount;
            var hrs = ms/3600000;
            var mins = ms/60000 - 60*hrs;
            Console.WriteLine("{0}h {1}m", hrs, mins);

            Console.SetCursorPosition(20, 6);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("C ");
            Console.ForegroundColor = ConsoleColor.Gray;
            ManagementObjectSearcher MyCPUObj = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (ManagementObject objC in MyCPUObj.Get())
            Console.Write(objC["Name"]);

            Console.SetCursorPosition(20, 7);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("G ");
            Console.ForegroundColor = ConsoleColor.Gray;
            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach (ManagementObject objV in myVideoObject.Get())
            Console.WriteLine(objV["Name"]);
        }

        void Colors()
        {
            Console.SetCursorPosition(4, 10);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write("  ");

            Console.SetCursorPosition(8, 10);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("  ");

            Console.SetCursorPosition(12, 10);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("  ");

            Console.SetCursorPosition(16, 10);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("  ");

            Console.SetCursorPosition(20, 10);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write("  ");

            Console.SetCursorPosition(24, 10);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write("  ");

            Console.SetCursorPosition(28, 10);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("  ");

            Console.SetCursorPosition(32, 10);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("  ");

            Console.SetCursorPosition(36, 10);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write("  ");

            Console.SetCursorPosition(40, 10);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("  ");

            Console.SetCursorPosition(44, 10);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("  ");

            Console.SetCursorPosition(48, 10);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("  ");
        }
    }
}
