using System;
using System.Runtime.InteropServices;

namespace ServiceLauncher
{
    public class WinSafer
    {
        /// <summary>
        /// The SaferCreateLevel function opens a SAFER_LEVEL_HANDLE.
        /// </summary>
        /// <param name="scopeId">The scope of the level to be created.</param>
        /// <param name="levelId">The level of the handle to be opened.</param>
        /// <param name="openFlags">Must be SaferOpenFlags.Open</param>
        /// <param name="levelHandle">The returned SAFER_LEVEL_HANDLE. When you have finished using the handle, release it by calling the SaferCloseLevel function.</param>
        /// <param name="reserved">This parameter is reserved for future use. IntPtr.Zero</param>
        /// <returns></returns>
        [DllImport("advapi32", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool SaferCreateLevel(SaferLevelScope scopeId, SaferLevel levelId, SaferOpen openFlags,
              out IntPtr levelHandle, IntPtr reserved);

        /// <summary>
        /// The SaferComputeTokenFromLevel function restricts a token using restrictions specified by a SAFER_LEVEL_HANDLE.
        /// </summary>
        /// <param name="levelHandle">SAFER_LEVEL_HANDLE that contains the restrictions to place on the input token. Do not pass handles with a LevelId of SAFER_LEVELID_FULLYTRUSTED or SAFER_LEVELID_DISALLOWED to this function. This is because SAFER_LEVELID_FULLYTRUSTED is unrestricted and SAFER_LEVELID_DISALLOWED does not contain a token.</param>
        /// <param name="inAccessToken">Token to be restricted. If this parameter is NULL, the token of the current thread will be used. If the current thread does not contain a token, the token of the current process is used.</param>
        /// <param name="outAccessToken">The resulting restricted token.</param>
        /// <param name="flags">Specifies the behavior of the method.</param>
        /// <param name="lpReserved">Reserved for future use. This parameter should be set to IntPtr.EmptyParam.</param>
        /// <returns></returns>
        [DllImport("advapi32", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool SaferComputeTokenFromLevel(IntPtr levelHandle, IntPtr inAccessToken,
              out IntPtr outAccessToken, SaferTokenBehaviour flags, IntPtr lpReserved);

        /// <summary>
        /// The SaferCloseLevel function closes a SAFER_LEVEL_HANDLE that was opened by using the SaferIdentifyLevel function or the SaferCreateLevel function.</summary>
        /// <param name="levelHandle">The SAFER_LEVEL_HANDLE to be closed.</param>
        /// <returns>TRUE if the function succeeds; otherwise, FALSE. For extended error information, call GetLastWin32Error.</returns>
        [DllImport("advapi32", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool SaferCloseLevel(IntPtr levelHandle);
    } //class WinSafer

    /// <summary>
    /// Specifies the behaviour of the SaferComputeTokenFromLevel method
    /// </summary>
    public enum SaferTokenBehaviour : uint
    {
        /// <summary></summary>
        Default = 0x0,
        /// <summary>If the OutAccessToken parameter is not more restrictive than the InAccessToken parameter, the OutAccessToken parameter returns NULL.</summary>
        NullIfEqual = 0x1,
        /// <summary></summary>
        CompareOnly = 0x2,
        /// <summary></summary>
        MakeInert = 0x4,
        /// <summary></summary>
        WantFlags = 0x8
    }

    /// <summary>
    /// The level of the handle to be opened.
    /// </summary>
    public enum SaferLevel : uint
    {
        /// <summary>Software will not run, regardless of the user rights of the user.</summary>
        Disallowed = 0,
        /// <summary>Allows programs to execute with access only to resources granted to open well-known groups, blocking access to Administrator and Power User privileges and personally granted rights.</summary>
        Untrusted = 0x1000,
        /// <summary>Software cannot access certain resources, such as cryptographic keys and credentials, regardless of the user rights of the user.</summary>
        Constrained = 0x10000,
        /// <summary>Allows programs to execute as a user that does not have Administrator or Power User user rights. Software can access resources accessible by normal users.</summary>
        NormalUser = 0x20000,
        /// <summary>Software user rights are determined by the user rights of the user.</summary>
        FullyTrusted = 0x40000
    }

    /// <summary>
    /// The scope of the level to be created.
    /// </summary>
    public enum SaferLevelScope : uint
    {
        /// <summary>The created level is scoped by computer.</summary>
        Machine = 1,
        /// <summary>The created level is scoped by user.</summary>
        User = 2
    }

    public enum SaferOpen : uint
    {
        Open = 1
    }
} //namespace PInvoke
