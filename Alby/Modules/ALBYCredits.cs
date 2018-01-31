using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alby
{
    class Credits
    {

        public static void Menu()
        {
            Console.Clear();
            ThanksBanner();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Thanks and credits to all the people on this list (And the rest of the infosec community) ");
            Console.WriteLine("I have borrowed code and knowledge from you all");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Casey Smith @subtee");
            Console.WriteLine("Matt Nelson @enigma0x3");
            Console.WriteLine("Cn33liz @Cneelis");
            Console.WriteLine("Jared Atkinson @jaredcatkinson");
            Console.WriteLine("James Forshaw @tiraniddo");
            Console.WriteLine("Will Schroeder @harmj0y");
            Console.WriteLine("Justin Warner @sixdub");
            Console.WriteLine("Steve Borosh @424f424f");
            Console.WriteLine("Alex Rymdeko-harvey @killswitch_gui");
            Console.WriteLine("Chris Ross @xorrior");
            Console.WriteLine("Matt Graeber @mattifestation");
            Console.WriteLine("");
            Console.WriteLine("If you are not in the list, but your code is part of the project - Please let me know.");
            Console.WriteLine("I have not excluded someone on purpose.");
        }

        private static void ThanksBanner()
        {
            Console.WriteLine("▄▄▄█████▓ ██░ ██  ▄▄▄       ███▄    █  ██ ▄█▀  ██████ ");
            Console.WriteLine("▓  ██▒ ▓▒▓██░ ██▒▒████▄     ██ ▀█   █  ██▄█▒ ▒██    ▒ ");
            Console.WriteLine("▒ ▓██░ ▒░▒██▀▀██░▒██  ▀█▄  ▓██  ▀█ ██▒▓███▄░ ░ ▓██▄   ");
            Console.WriteLine("░ ▓██▓ ░ ░▓█ ░██ ░██▄▄▄▄██ ▓██▒  ▐▌██▒▓██ █▄   ▒   ██▒");
            Console.WriteLine("  ▒██▒ ░ ░▓█▒░██▓ ▓█   ▓██▒▒██░   ▓██░▒██▒ █▄▒██████▒▒");
            Console.WriteLine("  ▒ ░░    ▒ ░░▒░▒ ▒▒   ▓▒█░░ ▒░   ▒ ▒ ▒ ▒▒ ▓▒▒ ▒▓▒ ▒ ░");
            Console.WriteLine("    ░     ▒ ░▒░ ░  ▒   ▒▒ ░░ ░░   ░ ▒░░ ░▒ ▒░░ ░▒  ░ ░");
        }
    }
}
