using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ServiceLauncher
{
    public class SaferProcess
    {
        //http://odetocode.com/Blogs/scott/archive/2004/10/28/602.aspx
        public static int CreateSaferProcess(String fileName, String arguments, SaferLevel saferLevel)
        {
            int output = -1;
            IntPtr saferLevelHandle = IntPtr.Zero;

            //Create a SaferLevel handle to match what was requested
            if (!WinSafer.SaferCreateLevel(
                  SaferLevelScope.User,
                  saferLevel,
                  SaferOpen.Open,
                  out saferLevelHandle,
                  IntPtr.Zero))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            try
            {
                //Generate the access token to use, based on the safer level handle.
                IntPtr hToken = IntPtr.Zero;

                if (!WinSafer.SaferComputeTokenFromLevel(
                      saferLevelHandle,  // SAFER Level handle
                      IntPtr.Zero,       // NULL is current thread token.
                      out hToken,        // Target token
                      SaferTokenBehaviour.Default,      // No flags
                      IntPtr.Zero))      // Reserved
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                try
                {
                    //Now that we have a security token, we can lauch the process
                    //using the standard CreateProcessAsUser API
                    ProcessUtility.STARTUPINFO si = new ProcessUtility.STARTUPINFO();
                    si.cb = Marshal.SizeOf(si);
                    si.lpDesktop = String.Empty;

                    ProcessUtility.SECURITY_ATTRIBUTES sa = new ProcessUtility.SECURITY_ATTRIBUTES();
                    sa.Length = Marshal.SizeOf(sa); 


                    ProcessUtility.PROCESS_INFORMATION pi = new ProcessUtility.PROCESS_INFORMATION();

                    // Spin up the new process
                    Boolean bResult = ProcessUtility.CreateProcessAsUser(
                          hToken,
                          fileName,
                          arguments,
                          ref sa, //process attributes
                          ref sa, //thread attributes
                          false, //inherit handles
                          0, //CREATE_NEW_CONSOLE
                          IntPtr.Zero, //environment
                          null, //current directory
                          ref si, //startup info
                          ref pi); //process info

                    output = pi.dwProcessID;

                    if (!bResult)
                        throw new Win32Exception(Marshal.GetLastWin32Error());

                    if (pi.hProcess != IntPtr.Zero)
                        ServiceLauncher.ProcessUtility.CloseHandle(pi.hProcess);

                    if (pi.hThread != IntPtr.Zero)
                        ServiceLauncher.ProcessUtility.CloseHandle(pi.hThread);
                }
                finally
                {
                    if (hToken != IntPtr.Zero)
                        ServiceLauncher.ProcessUtility.CloseHandle(hToken);
                }
            }
            finally
            {
                WinSafer.SaferCloseLevel(saferLevelHandle);
            }

            return output;
        }
    }
}