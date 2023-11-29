using System.Runtime.InteropServices;

namespace MuXunProxy.Controllers;

/// <summary>
///     TUN/TAP 适配器配置类
/// </summary>
public class TUNConfig
{
    /// <summary>
    ///     地址
    /// </summary>
    public string Address { get; set; } = "10.0.236.10";

    /// <summary>
    ///     DNS
    /// </summary>
    public string DNS { get; set; } = SerializationHelper.DefaultPrimaryDNS;

    /// <summary>
    ///     网关
    /// </summary>
    public string Gateway { get; set; } = "10.0.236.1";

    /// <summary>
    ///     掩码
    /// </summary>
    public string Netmask { get; set; } = "255.255.255.0";

}