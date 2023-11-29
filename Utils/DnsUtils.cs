﻿using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace MuXunProxy.Utils;

public static class DnsUtils
{
    /// <summary>
    ///     缓存
    /// </summary>
    private static readonly Hashtable Cache = new();
    private static readonly Hashtable Cache6 = new();

    public static async Task<IPAddress?> LookupAsync(string hostname, AddressFamily inet = AddressFamily.Unspecified, int timeout = 3000)
    {
        try
        {
            var cacheResult = inet switch
            {
                AddressFamily.Unspecified => (IPAddress?)(Cache[hostname] ?? Cache6[hostname]),
                AddressFamily.InterNetwork => (IPAddress?)Cache[hostname],
                AddressFamily.InterNetworkV6 => (IPAddress?)Cache6[hostname],
                _ => throw new ArgumentOutOfRangeException()
            };

            if (cacheResult != null)
                return cacheResult;

            return await LookupNoCacheAsync(hostname, inet, timeout);
        }
        catch (Exception e)
        {
            Log.Verbose(e, "Lookup hostname {Hostname} failed", hostname);
            return null;
        }
    }

    private static async Task<IPAddress?> LookupNoCacheAsync(string hostname, AddressFamily inet = AddressFamily.Unspecified, int timeout = 3000)
    {
        using var task = Dns.GetHostAddressesAsync(hostname);
        using var resTask = await Task.WhenAny(task, Task.Delay(timeout));

        if (resTask == task)
        {
            var addresses = await task;

            var result = addresses.FirstOrDefault(i => inet == AddressFamily.Unspecified || inet == i.AddressFamily);
            if (result == null)
                return null;

            switch (result.AddressFamily)
            {
                case AddressFamily.InterNetwork:
                    Cache.Add(hostname, result);
                    break;
                case AddressFamily.InterNetworkV6:
                    Cache6.Add(hostname, result);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }

        return null;
    }


}