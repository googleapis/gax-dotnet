/*
 * Copyright 2024 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

#if NET462_OR_GREATER

using System.Runtime.InteropServices;
using System;

internal static class GrpcWindowsDetection
{
    // gRPC support on .NET Framework is complex.
    // - Some Windows platforms don't support it at all, in which case an exception is thrown
    //   in GrpcChannel.ForAddress, which is handled above.
    // - Other platforms support it partially - unary and server-streaming, but not
    //   bidi- or client-streaming.
    // - Other platforms support it fully.
    //
    // While in theory we could tailor the default instance for a given service to whether
    // streaming is required or not, that would lead to a very inconsistent experience.
    // We attempt to detect which version of Windows we're on, erring on the side of caution.
    // Code based on https://gist.github.com/tonydnewell/6a663b7258ce3599e6bdae5c4291b2a6
    internal static bool PlatformFullySupportsGrpc()
    {
        // If we're running on Mono or similar, all bets are off.
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return false;
        }
        // Older versions of .NET report an OSVersion.Version based on Windows compatibility settings.
        // For example, if an app running on Windows 11 is configured to be "compatible" with Windows 10
        // then the version returned is always Windows 10.
        //
        // Get correct Windows version directly from Windows by calling RtlGetVersion.
        // https://www.pinvoke.net/default.aspx/ntdll/RtlGetVersion.html

        DetectWindowsVersion(out var windowsVersion, out var windowsServer);

        const int Windows11BuildVersion = 22000;

        // Windows 11 has full support.
        // Currently, Windows Server (even 2022) doesn't fully support gRPC under .NET Framework.
        // When there's a version that does, we can update this check.
        return windowsVersion.Build >= Windows11BuildVersion;
    }

    /// <summary>
    /// Types for calling RtlGetVersion. See https://www.pinvoke.net/default.aspx/ntdll/RtlGetVersion.html
    /// </summary>
#pragma warning disable SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time
    [DllImport("ntdll.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern NTSTATUS RtlGetVersion(ref OSVERSIONINFOEX versionInfo);
#pragma warning restore SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time

    private static void DetectWindowsVersion(out Version version, out bool isWindowsServer)
    {
        // https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-osversioninfoexa
        const byte VER_NT_SERVER = 3;

        var osVersionInfo = new OSVERSIONINFOEX { OSVersionInfoSize = Marshal.SizeOf<OSVERSIONINFOEX>() };

        if (RtlGetVersion(ref osVersionInfo) != NTSTATUS.STATUS_SUCCESS)
        {
            throw new InvalidOperationException($"Failed to call internal {nameof(RtlGetVersion)}.");
        }

        version = new Version(osVersionInfo.MajorVersion, osVersionInfo.MinorVersion, osVersionInfo.BuildNumber, 0);
        isWindowsServer = osVersionInfo.ProductType == VER_NT_SERVER;
    }

    private enum NTSTATUS : uint
    {
        /// <summary>
        /// The operation completed successfully. 
        /// </summary>
        STATUS_SUCCESS = 0x00000000
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct OSVERSIONINFOEX
    {
        // The OSVersionInfoSize field must be set to Marshal.SizeOf(typeof(OSVERSIONINFOEX))
        public int OSVersionInfoSize;
        public int MajorVersion;
        public int MinorVersion;
        public int BuildNumber;
        public int PlatformId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string CSDVersion;
        public ushort ServicePackMajor;
        public ushort ServicePackMinor;
        public short SuiteMask;
        public byte ProductType;
        public byte Reserved;
    }
}
#endif
