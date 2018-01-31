using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alby
{
    class BGInfo
    {

        public static void Menu()
        {
            //    Console.ForegroundColor = ConsoleColor.DarkMagenta;
            //    Console.WriteLine("NOT IMPLEMENTED YET - NEXT VERSION STUFF - BGINFO.EXE");
            //    Console.ResetColor();
                Console.WriteLine("1. Empire Native VBS Stager - BROKEN");
                Console.WriteLine("2. Empire StarFighter");
                Console.WriteLine("3. Metasploit VBSMeter");
                Console.WriteLine("4. Metasploit VBSWebMeter");
                Console.WriteLine("0.Back");
                string BGInfoSubChoice = Console.ReadLine();
                Console.WriteLine();
                
                if (BGInfoSubChoice == "1")
                {
                    
                    Generators.GenerateBGIFile("\\test\test", "C:\temp\test.bgi");
                    
                /* Default filename */
                //string Filename_BGInfoEmpireNativeStager_Default = "BGInfoEmpireStager.vbs";
                //
                //Helpers.WriteEmpireExample();
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("Important! --Must be a Base64 encoded string of the PowerShell commands you want to run--");
                //Console.ResetColor();
                //Console.WriteLine("Press Enter in an empty line to exit...");
                //
                //string BGInfo_Payload = Helpers.PasteToString();
                //string Outfile = Helpers.FileFolderLocation(Filename_BGInfoEmpireNativeStager_Default);
                //
                //Generators.GeneratePayload(Resources.Template_BGInfo_EmpireNative, Outfile, BGInfo_Payload, "GenerateFile", null);
                //Helpers.WriteBGInfoPayloadExample(Outfile);
                Console.ResetColor();
                    Helpers.PauseExecution();
                    
                }
            //
            //    if (BGInfoSubChoice == "2")
            //    {
            //        break;
            //        /* Default filename */
            //        string Filename_BGInfoEmpireStarFighter_Default = "BGInfoEmpireStarfighter.vbs";
            //
            //        Helpers.WriteEmpireExample();
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("Important! --Must be a Base64 encoded string of the PowerShell commands you want to run--");
            //        Console.ResetColor();
            //        Console.WriteLine("Press Enter in an empty line to exit...");
            //
            //        string BGInfo_Payload = Helpers.PasteToString();
            //        string Outfile = Helpers.FileFolderLocation(Filename_BGInfoEmpireStarFighter_Default);
            //
            //        Generators.GeneratePayload(Resources.Template_BGInfo_StarFighter, Outfile, BGInfo_Payload, "GenerateFile", null, null, null);
            //        Helpers.WriteBGInfoPayloadExample(Outfile);
            //        Console.ResetColor();
            //        Helpers.PauseExecution();
            //        break;
            //    }
            //    if (BGInfoSubChoice == "3")
            //    {
            //        break;
            //    }
            //
            //    if (BGInfoSubChoice == "4")
            //    {
            //        break;
            //    }
            //        if (String.IsNullOrEmpty(BGInfoSubChoice) || BGInfoSubChoice == "0")
            //    {
            //        break;
            //    }
                
        }

    }
}
