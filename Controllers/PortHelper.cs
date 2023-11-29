using MuXunProxy.Models;
using MuXunProxy.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace MuXunProxy.Controllers;

internal static class PortHelper
{
    private static readonly List<NumberRange> TCPReservedRanges = new();
    private static readonly List<NumberRange> UDPReservedRanges = new();
    private static readonly IPGlobalProperties NetInfo = IPGlobalProperties.GetIPGlobalProperties();

    //static PortHelper()
    //{
    //    try
    //    {
    //        GetReservedPortRange(PortType.TCP, ref TCPReservedRanges);
    //        GetReservedPortRange(PortType.UDP, ref UDPReservedRanges);
    //    }
    //    catch
    //    {
    //    }
    //}


    //internal static IEnumerable<Process> GetProcessByUsedTcpPort(ushort port, AddressFamily inet = AddressFamily.InterNetwork)
    //{
    //    if (port == 0)
    //    {
    //        throw new ArgumentOutOfRangeException();
    //    }

    //    switch (inet)
    //    {
    //        case AddressFamily.InterNetwork:
    //            {
    //                List<Process> process = new();
    //                unsafe
    //                {
    //                    uint err;
    //                    uint size = 0;
    //                    _ = PInvoke.GetExtendedTcpTable(default, ref size, false, (uint)inet, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_LISTENER, 0); // get size
    //                    MIB_TCPTABLE_OWNER_PID* tcpTable = (MIB_TCPTABLE_OWNER_PID*)Marshal.AllocHGlobal((int)size);

    //                    if ((err = PInvoke.GetExtendedTcpTable(tcpTable, ref size, false, (uint)inet, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_LISTENER, 0)) !=
    //                        0)
    //                    {
    //                        throw new Win32Exception((int)err);
    //                    }

    //                    for (int i = 0; i < tcpTable->dwNumEntries; i++)
    //                    {
    //                        MIB_TCPROW_OWNER_PID row = tcpTable->table.ReadOnlyItemRef(i);

    //                        if (row.dwOwningPid is 0 or 4)
    //                        {
    //                            continue;
    //                        }

    //                        if (PInvoke.ntohs((ushort)row.dwLocalPort) == port)
    //                        {
    //                            process.Add(Process.GetProcessById((int)row.dwOwningPid));
    //                        }
    //                    }
    //                }

    //                return process;
    //            }
    //        case AddressFamily.InterNetworkV6:
    //            throw new NotImplementedException();
    //        default:
    //            throw new InvalidOperationException();
    //    }
    //}


    //private static void GetReservedPortRange(PortType portType, ref List<NumberRange> targetList)
    //{

    //    Process process = new()
    //    {
    //        StartInfo = new ProcessStartInfo
    //        {
    //            FileName = "netsh",
    //            Arguments = $" int ipv4 show excludedportrange {portType}",
    //            RedirectStandardOutput = true,
    //            UseShellExecute = false,
    //            CreateNoWindow = true
    //        }
    //    };
    //    _ = process.Start();
    //}

    public static void PortCheck(ushort port, string portName, PortType portType = PortType.Both)
    {
        try
        {
            PortHelper.CheckPort(port, portType);
        }
        catch (PortInUseException)
        {
           
        }
        catch (PortReservedException)
        {
            
        }
    }


    /// <summary>
    ///     指定类型的端口是否已经被使用了
    /// </summary>
    /// <param name="port">端口</param>
    /// <param name="type">检查端口类型</param>
    /// <returns>是否被占用</returns>
    internal static void CheckPort(ushort port, PortType type = PortType.Both)
    {
        if (type != PortType.Both)
        {
            CheckPortInUse(port, type);
            CheckPortReserved(port, type);
        }
        else
        {
            CheckPort(port, PortType.TCP);
            CheckPort(port, PortType.UDP);
        }
    }

    private static void CheckPortInUse(ushort port, PortType type)
    {
        switch (type)
        {
            case PortType.TCP:
                if (NetInfo.GetActiveTcpListeners().Any(ipEndPoint => ipEndPoint.Port == port))
                {
                    throw new PortInUseException();
                }

                break;
            case PortType.UDP:
                if (NetInfo.GetActiveUdpListeners().Any(ipEndPoint => ipEndPoint.Port == port))
                {
                    throw new PortInUseException();
                }

                break;
            case PortType.Both:
                CheckPortInUse(port, PortType.TCP);
                CheckPortInUse(port, PortType.UDP);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    /// <summary>
    ///     检查端口是否是保留端口
    /// </summary>
    private static void CheckPortReserved(ushort port, PortType type)
    {
        switch (type)
        {
            case PortType.TCP:
                if (TCPReservedRanges.Any(range => range.InRange(port)))
                {
                    throw new PortReservedException();
                }

                break;
            case PortType.UDP:
                if (UDPReservedRanges.Any(range => range.InRange(port)))
                {
                    throw new PortReservedException();
                }

                break;
            case PortType.Both:
                CheckPortReserved(port, PortType.TCP);
                CheckPortReserved(port, PortType.UDP);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    internal static ushort GetAvailablePort(PortType portType = PortType.Both)
    {
        Random random = new();
        for (ushort num = 0; num < 55535; num += 1)
        {
            ushort num2 = (ushort)random.Next(10000, 65535);
            try
            {
                CheckPort(num2, portType);
                return num2;
            }
            catch (Exception)
            {
            }
        }
        throw new Exception();
    }

    internal static ushort GetAvailablePorts(PortType portType = PortType.Both)
    {
        RandomNumberGenerator rng = RandomNumberGenerator.Create();
        for (int i = 0; i < 1000; i++)
        {
            byte[] bytes = new byte[2];
            rng.GetBytes(bytes);
            ushort port = (ushort)(bytes[0] << 8 | bytes[1]);
            if (port < 1024 || port >= 65535)
            {
                continue;
            }
            try
            {
                CheckPort(port, portType);
                Console.WriteLine(port);
                return port;
            }
            catch (Exception)
            {
            }
        }
        throw new Exception("No available ports found.");
    }
}


internal class PortInUseException : Exception
{
    internal PortInUseException(string message) : base(message)
    {
    }

    internal PortInUseException()
    {
    }
}
internal class PortReservedException : Exception
{
    internal PortReservedException(string message) : base(message)
    {
    }

    internal PortReservedException()
    {
    }
}
