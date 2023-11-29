﻿using System.Net;
using Windows.Win32;

namespace MuXunProxy.Models;

public struct NetRoute
{
    public static NetRoute TemplateBuilder(string gateway, int interfaceIndex, int metric = 0)
    {
        return new()
        {
            Gateway = gateway,
            InterfaceIndex = interfaceIndex,
            Metric = metric
        };
    }

    public static NetRoute GetBestRouteTemplate()
    {
        if (PInvoke.GetBestRoute(BitConverter.ToUInt32(IPAddress.Parse("114.114.114.114").GetAddressBytes(), 0), 0, out var route) != 0)
            throw new MessageException("GetBestRoute 搜索失败");

        var gateway = new IPAddress(route.dwForwardNextHop);
        return TemplateBuilder(gateway.ToString(), (int)route.dwForwardIfIndex);
    }

    public int InterfaceIndex;

    public string Gateway;

    public string Network;

    public byte Cidr;

    public int Metric;

    public NetRoute FillTemplate(string network, byte cidr, int? metric = null)
    {
        var o = (NetRoute)MemberwiseClone();
        o.Network = network;
        o.Cidr = cidr;
        if (metric != null)
            o.Metric = (int)metric;

        return o;
    }
}