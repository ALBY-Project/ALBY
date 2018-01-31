using System;
using System.IO;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using Alby;



namespace Alby
{
    public class Generators
    {

        public static void GeneratePayload(string Template, string outfile, string Payload, string Action, string CompilerOptions, string RHOST, string RPORT)
        {
            try
            {
                File.WriteAllText(outfile, Template);
                string str = File.ReadAllText(outfile);

                // Inject payload if Payload it is not empty
                if (!(string.IsNullOrEmpty(Payload)))
                { 
                    str = str.Replace("!INSERTCODEHERE!", Payload);
                }

                // Inject payload if RHOST it is not empty
                if (!(string.IsNullOrEmpty(RHOST)))
                {
                    str = str.Replace("!INSERTRHOSTHERE!", RHOST);
                }

                // Inject payload if Payload it is not empty
                if (!(string.IsNullOrEmpty(RPORT)))
                {
                    str = str.Replace("!INSERTRPORTHERE!", RPORT);
                }

                if (Action == "Compile")
                {
                    CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                    CompilerParameters parameters = new CompilerParameters();
                    if (outfile.EndsWith(".dll"))
                    {
                        parameters.GenerateExecutable = false;
                    }
                    if (outfile.EndsWith(".exe"))
                    {
                        parameters.GenerateExecutable = true;
                    }
                    if(String.IsNullOrEmpty(CompilerOptions))
                    {

                    }
                    else
                    {
                        parameters.CompilerOptions = CompilerOptions;
                    }
                    parameters.OutputAssembly = outfile;
                    parameters.GenerateInMemory = false;
                    parameters.ReferencedAssemblies.Add("System.EnterpriseServices.dll");
                    parameters.ReferencedAssemblies.Add("System.Management.Automation.dll");
                    parameters.ReferencedAssemblies.Add("System.Core.dll");
                    parameters.ReferencedAssemblies.Add("System.Net.dll");
                    parameters.ReferencedAssemblies.Add("System.dll");
                    parameters.ReferencedAssemblies.Add("System.Configuration.dll");
                    parameters.ReferencedAssemblies.Add("System.Configuration.Install.dll");
                    parameters.ReferencedAssemblies.Add("System.ComponentModel.dll");
                    parameters.ReferencedAssemblies.Add("System.Runtime.InteropServices.dll");
                    


                    parameters.WarningLevel = 4;
                    CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, str);
                    Console.WriteLine("");
                }

                if(Action == "GenerateFile")
                {
                    File.WriteAllText(outfile, str);
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong! OMG!");
                Console.ResetColor();
            }
            return;
        }

        public static void GenerateBGIFile(string ScriptPath, string outfile)
        {
            try
            {
                /* uncertain if this will work with newer BGInfo than 4.22 */
                //string BGITemplate = "CwAAAEJhY2tncm91bmQABAAAAAQAAAAAAAAACQAAAFBvc2l0aW9uAAQAAAAEAAAA/gMAAAgAAABNb25pdG9yAAQAAAAEAAAAXAQAAA4AAABUYXNrYmFyQWRqdXN0AAQAAAAEAAAAAQAAAAsAAABUZXh0V2lkdGgyAAQAAAAEAAAAwHsAAAsAAABPdXRwdXRGaWxlAAEAAAASAAAAJVRlbXAlXEJHSW5mby5ibXAACQAAAERhdGFiYXNlAAEAAAABAAAAAAwAAABEYXRhYmFzZU1SVQABAAAABAAAAAAAAAAKAAAAV2FsbHBhcGVyAAEAAAABAAAAAA0AAABXYWxscGFwZXJQb3MABAAAAAQAAAAFAAAADgAAAFdhbGxwYXBlclVzZXIABAAAAAQAAAABAAAADQAAAE1heENvbG9yQml0cwAEAAAABAAAAAAAAAAMAAAARXJyb3JOb3RpZnkABAAAAAQAAAAAAAAACwAAAFVzZXJTY3JlZW4ABAAAAAQAAAABAAAADAAAAExvZ29uU2NyZWVuAAQAAAAEAAAAAAAAAA8AAABUZXJtaW5hbFNjcmVlbgAEAAAABAAAAAAAAAAOAAAAT3BhcXVlVGV4dEJveAAEAAAABAAAAAAAAAAEAAAAUlRGAAEAAADWAAAAe1xydGYxXGFuc2lcYW5zaWNwZzEyNTJcZGVmZjBcZGVmbGFuZzEwNDR7XGZvbnR0Ymx7XGYwXGZuaWxcZmNoYXJzZXQwIEFyaWFsO319DQp7XGNvbG9ydGJsIDtccmVkMjU1XGdyZWVuMjU1XGJsdWUyNTU7fQ0KXHZpZXdraW5kNFx1YzFccGFyZFxmaS0yODgwXGxpMjg4MFx0eDI4ODBcY2YxXGJccHJvdGVjdFxmczI0IDxGaWVsZD5ccHJvdGVjdDBccGFyDQpccGFyDQp9DQoAAAsAAABVc2VyRmllbGRzAACAAIAAAAAABgAAAEZpZWxkAAEAAAAOAAAANFRlbXBsYXRlLnZicwAAAAAAAYAAgAAAAAA=";
                

                byte [] Sarray = Convert.FromBase64String("CwAAAEJhY2tncm91bmQABAAAAAQAAAAAAAAACQAAAFBvc2l0aW9uAAQAAAAEAAAA/gMAAAgAAABNb25pdG9yAAQAAAAEAAAAXAQAAA4AAABUYXNrYmFyQWRqdXN0AAQAAAAEAAAAAQAAAAsAAABUZXh0V2lkdGgyAAQAAAAEAAAAwHsAAAsAAABPdXRwdXRGaWxlAAEAAAASAAAAJVRlbXAlXEJHSW5mby5ibXAACQAAAERhdGFiYXNlAAEAAAABAAAAAAwAAABEYXRhYmFzZU1SVQABAAAABAAAAAAAAAAKAAAAV2FsbHBhcGVyAAEAAAABAAAAAA0AAABXYWxscGFwZXJQb3MABAAAAAQAAAAFAAAADgAAAFdhbGxwYXBlclVzZXIABAAAAAQAAAABAAAADQAAAE1heENvbG9yQml0cwAEAAAABAAAAAAAAAAMAAAARXJyb3JOb3RpZnkABAAAAAQAAAAAAAAACwAAAFVzZXJTY3JlZW4ABAAAAAQAAAABAAAADAAAAExvZ29uU2NyZWVuAAQAAAAEAAAAAAAAAA8AAABUZXJtaW5hbFNjcmVlbgAEAAAABAAAAAAAAAAOAAAAT3BhcXVlVGV4dEJveAAEAAAABAAAAAAAAAAEAAAAUlRGAAEAAADWAAAAe1xydGYxXGFuc2lcYW5zaWNwZzEyNTJcZGVmZjBcZGVmbGFuZzEwNDR7XGZvbnR0Ymx7XGYwXGZuaWxcZmNoYXJzZXQwIEFyaWFsO319DQp7XGNvbG9ydGJsIDtccmVkMjU1XGdyZWVuMjU1XGJsdWUyNTU7fQ0KXHZpZXdraW5kNFx1YzFccGFyZFxmaS0yODgwXGxpMjg4MFx0eDI4ODBcY2YxXGJccHJvdGVjdFxmczI0IDxGaWVsZD5ccHJvdGVjdDBccGFyDQpccGFyDQp9DQoAAAsAAABVc2VyRmllbGRzAACAAIAAAAAABgAAAEZpZWxkAAEAAAAOAAAANFRlbXBsYXRlLnZicwAAAAAAAYAAgAAAAAA=");
                // Need to parse this binary file somehow!?!
                

                /* Static part of template */
                //byte[] Part1 = Array;   //(0, 745);
                
            }
            
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong! OMG!");
                Console.ResetColor();
            }
            return;
        }

    }
}
