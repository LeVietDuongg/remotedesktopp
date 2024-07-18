using System;
using System.Runtime.InteropServices;

namespace MirrorDriver
{
    public enum OperationType
    {
        dmf_dfo_IGNORE = 0,
        dmf_dfo_FROM_SCREEN = 1,
        dmf_dfo_FROM_DIB = 2,
        dmf_dfo_TO_SCREEN = 3,

        dmf_dfo_SCREEN_SCREEN = 11,
        dmf_dfo_BLIT = 12,
        dmf_dfo_SOLIDFILL = 13,
        dmf_dfo_BLEND = 14,
        dmf_dfo_TRANS = 15,
        dmf_dfo_PLG = 17,
        dmf_dfo_TEXTOUT = 18,

        dmf_dfo_Ptr_Engage = 48, 
        dmf_dfo_Ptr_Avert = 49,

        dmf_dfn_assert_on = 64, 
        dmf_dfn_assert_off = 65, 
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ChangesBuffer
    {
        public uint counter;

        public const int MAXCHANGES_BUF = 20000;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAXCHANGES_BUF)]
        public ChangesRecord[] pointrect;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ChangesRecord
    {
        public uint type;
        public Rectangle rect;
        public Rectangle origrect;
        public Point point;
        public uint color;
        public uint refcolor;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DisplayDevice
    {
        public int CallBack;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceString;
        public int StateFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceKey;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceMode
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmDeviceName;
        public short dmSpecVersion;
        public short dmDriverVersion;
        public short dmSize;
        public short dmDriverExtra;
        public int dmFields;
        public short dmOrientation;
        public short dmPaperSize;
        public short dmPaperLength;
        public short dmPaperWidth;
        public short dmScale;
        public short dmCopies;
        public short dmDefaultSource;
        public short dmPrintQuality;
        public short dmColor;
        public short dmDuplex;
        public short dmYResolution;
        public short dmTTOption;
        public short dmCollate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmFormName;
        public short dmLogPixels;
        public int dmBitsPerPel;
        public int dmPelsWidth;
        public int dmPelsHeight;
        public int dmDisplayFlags;
        public int dmDisplayFrequency;
        public int dmICMMethod;
        public int dmICMIntent;
        public int dmMediaType;
        public int dmDitherType;
        public int dmReserved1;
        public int dmReserved2;
        public int dmPanningWidth;
        public int dmPanningHeight;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct GetChangesBuffer
    {
        public IntPtr Buffer;
        public IntPtr UserBuffer;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int x;
        public int y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Rectangle
    {
        public int x1;
        public int y1;
        public int x2;
        public int y2;
    }
}
