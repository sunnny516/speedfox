using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MuXunProxy.Controllers
{
    internal static class RedirectorIn
    {
        internal enum NameList
        {
            TYPE_FILTERLOOPBACK,
            TYPE_FILTERICMP,
            TYPE_FILTERTCP,
            TYPE_FILTERUDP,

            TYPE_CLRNAME,
            TYPE_ADDNAME,
            TYPE_BYPNAME,

            TYPE_DNSHOST,

            TYPE_TCPLISN,
            TYPE_TCPTYPE,
            TYPE_TCPHOST,
            TYPE_TCPUSER,
            TYPE_TCPPASS,
            TYPE_TCPMETH,
            TYPE_TCPPROT,
            TYPE_TCPPRPA,
            TYPE_TCPOBFS,
            TYPE_TCPOBPA,

            TYPE_UDPLISN,
            TYPE_UDPTYPE,
            TYPE_UDPHOST,
            TYPE_UDPUSER,
            TYPE_UDPPASS,
            TYPE_UDPMETH,
            TYPE_UDPPROT,
            TYPE_UDPPRPA,
            TYPE_UDPOBFS,
            TYPE_UDPOBPA
        }

        internal static bool Dial(NameList name, string value)
        {
            return aio_dial(name, value);
        }

        internal static bool Free()
        {
            return aio_free();
        }
        internal static Task<bool> FreeAsync()
        {
            return Task.Run(aio_free);
        }
        internal static bool Init()
        {
            return aio_init();
        }
        //public const int UdpNameListOffset = (int)NameList.TYPE_UDPLISN - (int)NameList.TYPE_TCPLISN;

        //private const string Redirector_bin = "MuXunAcc.nfc.dll";

        //[DllImport(Redirector_bin, CallingConvention = CallingConvention.Cdecl)]
        //private static extern bool aio_dial(NameList name, [MarshalAs(UnmanagedType.LPWStr)] string value);

        //[DllImport(Redirector_bin, CallingConvention = CallingConvention.Cdecl)]
        //private static extern bool aio_init();

        //[DllImport(Redirector_bin, CallingConvention = CallingConvention.Cdecl)]
        //private static extern bool aio_free();

        //[DllImport(Redirector_bin, CallingConvention = CallingConvention.Cdecl)]
        //private static extern ulong aio_getUP();

        //[DllImport(Redirector_bin, CallingConvention = CallingConvention.Cdecl)]
        //private static extern ulong aio_getDL();

        //[DllImport("MuXun.dll", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern NF_STATUS nf_registerDriver(string driverName);

        //[DllImport("MuXun.dll", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern NF_STATUS nf_unRegisterDriver(string driverName);
        internal const int UdpNameListOffset = (int)NameList.TYPE_UDPLISN - (int)NameList.TYPE_TCPLISN;

        [DllImport("MuXunAcc.nfc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool aio_register([MarshalAs(UnmanagedType.LPWStr)] string value);

        [DllImport("MuXunAcc.nfc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool aio_unregister([MarshalAs(UnmanagedType.LPWStr)] string value);

        [DllImport("MuXunAcc.nfc.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool aio_dial(NameList name, [MarshalAs(UnmanagedType.LPWStr)] string value);

        [DllImport("MuXunAcc.nfc.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool aio_init();

        [DllImport("MuXunAcc.nfc.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool aio_free();

        [DllImport("MuXunAcc.nfc.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern ulong aio_getUP();

        [DllImport("MuXunAcc.nfc.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern ulong aio_getDL();


        // dllµ÷ÓÃ

        [DllImport("netfilter\\nfapi.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NF_STATUS nf_registerDriver(string driverName);

        [DllImport("netfilter\\nfapi.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern NF_STATUS nf_unRegisterDriver(string driverName);
    }
}