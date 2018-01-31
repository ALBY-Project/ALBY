// NOTES TO MYSELF
// TODO before version 1: 
// More bypasses and payloads
// Better C# code from me (need to learn more)
// Error handeling
// Enum methods should be implemented in methods to ensure correct input...
// Ability to add Metasploit, Empire payload and store it for later use.
// Ability to reset added Metasploit and Empire payloads
// Generate payloads with input from cmd. Like "Alby.exe generateall" 
// Include system.management.automation.dll in the alby.exe if possible
// Save commands to execute payload to a txt file 
// Rewrite to objects (Bypass objects with common commands...)
// Meta.snk - Remove that it is needed on disk for regasm to work.

// Version 2:
// Server/Agent
// More payloads and Bypasses

using System;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace Alby
{
    class Program
    {
        static public int DisplayMenu()
        {
            Program.PrintBanner();
            Helpers.AlbyAddToBanner("Main menu");
            Console.WriteLine(" 1.  Msbuild.exe");
            Console.WriteLine(" 2.  Regsvcs.exe/regasm.exe");
            Console.WriteLine(" 3.  InstallUtil.exe");
            Console.WriteLine(" 4.  MSHTA.exe");
            // Console.WriteLine("4.  TODO: BGinfo.exe");
            // Console.WriteLine("5.  TODO: Presentationhost.exe");
            // Console.WriteLine("6.  TODO: Regsvr32.exe");
            // Console.WriteLine("7.  TODO: Rundll32.exe");
            // Console.WriteLine("8.  TODO: ADS execution");

            Console.WriteLine();
            Console.WriteLine(" 0. Exit");
            Console.WriteLine(" 1337. Credits and thanks");
            Console.Write("\nEnter choice: ");
            var result = Console.ReadLine();
            Console.WriteLine();

            try
            {
                return Convert.ToInt32(result);
            }
            catch
            {
                return 0;
            }
        }


        public static void Main()
        {
            Console.Title = "AppLocker Bypass Generator";
            Console.SetWindowSize(Math.Min(100, Console.LargestWindowWidth), Math.Min(40, Console.LargestWindowHeight));

            // Fix to remove limit of readline
            byte[] inputBuffer = new byte[8192];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));

            int userInput = 0;

            do
            {
                
                userInput = DisplayMenu();

                switch (userInput)
                {
                    case 1:
                        MSBuild.Menu();
                        break;
                    case 2:
                        RegsvcsRegasm.Menu();
                        break;
                    case 3:
                        InstallUtil.Menu();
                        break;
                    case 4:
                        MSHTA.Menu();
                        break;
                    case 1337:
                        //Info about tool authors - Love these guys!
                        Credits.Menu();
                        Helpers.PauseExecution();
                        break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nGoodbye, and be nice! ;-)");
                        Console.ResetColor();
                        Helpers.PauseExecution();
                        break;
                }
            } while (userInput != 0);

        }

        public static void PrintBanner(string[] toPrint = null)
        {
            Console.Clear();
            Console.WriteLine("               AAA               LLLLLLLLLLL             BBBBBBBBBBBBBBBBB   YYYYYYY       YYYYYYY");
            Console.WriteLine("              A:::A              L:::::::::L             B::::::::::::::::B  Y:::::Y       Y:::::Y");
            Console.WriteLine("             A:::::A             L:::::::::L             B::::::BBBBBB:::::B Y:::::Y       Y:::::Y");
            Console.WriteLine("            A:::::::A            LL:::::::LL             BB:::::B     B:::::BY::::::Y     Y::::::Y");
            Console.WriteLine("           A:::::::::A             L:::::L                 B::::B     B:::::BYYY:::::Y   Y:::::YYY");
            Console.WriteLine("          A:::::A:::::A            L:::::L                 B::::B     B:::::B   Y:::::Y Y:::::Y   ");
            Console.WriteLine("         A:::::A A:::::A           L:::::L                 B::::BBBBBB:::::B     Y:::::Y:::::Y    ");
            Console.WriteLine("        A:::::A   A:::::A          L:::::L                 B:::::::::::::BB       Y:::::::::Y     ");
            Console.WriteLine("       A:::::A     A:::::A         L:::::L                 B::::BBBBBB:::::B       Y:::::::Y      ");
            Console.WriteLine("      A:::::AAAAAAAAA:::::A        L:::::L                 B::::B     B:::::B       Y:::::Y       ");
            Console.WriteLine("     A:::::::::::::::::::::A       L:::::L                 B::::B     B:::::B       Y:::::Y       ");
            Console.WriteLine("    A:::::AAAAAAAAAAAAA:::::A      L:::::L         LLLLLL  B::::B     B:::::B       Y:::::Y       ");
            Console.WriteLine("   A:::::A             A:::::A   LL:::::::LLLLLLLLL:::::LBB:::::BBBBBB::::::B       Y:::::Y       ");
            Console.WriteLine("  A:::::A               A:::::A  L::::::::::::::::::::::LB:::::::::::::::::B     YYYY:::::YYYY    ");
            Console.WriteLine(" A:::::A                 A:::::A L::::::::::::::::::::::LB::::::::::::::::B      Y:::::::::::Y    ");
            Console.WriteLine("AAAAAAA                   AAAAAAALLLLLLLLLLLLLLLLLLLLLLLLBBBBBBBBBBBBBBBBB       YYYYYYYYYYYYY    ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Tool     :: ALBY (AppLocker BYpass generator)");
            Console.WriteLine("Author   :: Oddvar Moe");
            Console.WriteLine("Twitter  :: @OddvarMoe");
            Console.WriteLine("Blog     :: https://oddvar.moe");
            Console.WriteLine("License  :: BSD 3-clause");
            Console.WriteLine("Version  :: 0.70");
            Console.WriteLine("Beta version");
            Console.WriteLine();


            if (toPrint != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                foreach (string item in toPrint)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}

