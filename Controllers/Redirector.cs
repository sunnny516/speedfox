using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MuXunProxy.Controllers
{
    internal static class Redirector
    {
        internal enum NameList
        {
            AIO_FILTERLOOPBACK,
            AIO_FILTERINTRANET,
            AIO_FILTERPARENT,
            AIO_FILTERICMP,
            AIO_FILTERTCP,
            AIO_FILTERUDP,
            AIO_FILTERDNS,

            AIO_ICMPING,

            AIO_DNSONLY,
            AIO_DNSPROX,
            AIO_DNSHOST,
            AIO_DNSPORT,

            AIO_TGTHOST,
            AIO_TGTPORT,
            AIO_TGTUSER,
            AIO_TGTPASS,

            AIO_CLRNAME,
            AIO_ADDNAME,
            AIO_BYPNAME
        }
        internal static bool Dial(NameList name, bool value)
        {
            return aio_dial(name, value.ToString().ToLower());
        }
        internal static bool Dial(NameList name, string value)
        {
            return aio_dial(name, value);
        }
        internal static bool Init()
        {
            return aio_init();
        }
        internal static Task<bool> FreeAsync()
        {
            return Task.Run(aio_free);
        }

        [DllImport("MuXunAcc.nfcs.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool aio_register([MarshalAs(UnmanagedType.LPWStr)] string value);

        [DllImport("MuXunAcc.nfcs.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool aio_unregister([MarshalAs(UnmanagedType.LPWStr)] string value);

        [DllImport("MuXunAcc.nfcs.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool aio_dial(NameList name, [MarshalAs(UnmanagedType.LPWStr)] string value);

        [DllImport("MuXunAcc.nfcs.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool aio_init();

        [DllImport("MuXunAcc.nfcs.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool aio_free();

        [DllImport("MuXunAcc.nfcs.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern ulong aio_getUP();

        [DllImport("MuXunAcc.nfcs.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern ulong aio_getDL();
    }

}