using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
//using System.Reactive;
using System.Text;
using System.Xml.Linq;
using MuXunProxy.Controllers;
using MuXunProxy.Models;
using MuXunProxy.Utils;

namespace MuXunProxy.Controllers;

public class TUNController
{
    private readonly DNSController _aioDnsController = new();
    public TUNConfig TUNTAP { get; set; } = new();
    internal string Receiveds { get; set; }
    private Process Instance;
    private IPAddress? _serverRemoteAddress;
    private TUNConfig _tunConfig = null!;
    private string decryptedRul;
    //private bool _routeSetuped = false;

    private NetRoute _tun;
    private NetworkInterface _tunNetworkInterface = null!;
    private NetRoute _outbound;


    private string[] number;
    public TUNController(string[] parameters)
    {
        number = parameters;
    }

    public async Task StartAsync()
    {
        Console.WriteLine("排除的服务器IP" + number[3]);
        _tunConfig = TUNTAP;


        _serverRemoteAddress = number[3].ValueOrDefault() != null ? await DnsUtils.LookupAsync(number[3]!) : await DnsUtils.LookupAsync(number[3]);

        if (_serverRemoteAddress != null && IPAddress.IsLoopback(_serverRemoteAddress))
        {
            _serverRemoteAddress = null;
        }

        _outbound = NetRoute.GetBestRouteTemplate();
        
        // CheckDriver();

        //if (number[9] == "ss" || number[9] == "ss/tun")
        //{
        //    byte[] mydata = Encoding.Default.GetBytes(NFController.Decrypt(number[4]));
        //    Receiveds = $"ss://{NFController.Decrypt(number[7])}:{System.Convert.ToBase64String(mydata)}@{NFController.Decrypt(number[1])}:{NFController.Decrypt(number[8])}";
        //}
        //else if (number[9] == "sk5tun" || number[9] == "sk5/tun")
        //{
        //    byte[] mydata = Encoding.Default.GetBytes(NFController.Decrypt(number[3]));
        //    byte[] mydata2 = Encoding.Default.GetBytes(NFController.Decrypt(number[4]));
        //    Receiveds = $"socks5://{System.Convert.ToBase64String(mydata)}:{System.Convert.ToBase64String(mydata2)}@{NFController.Decrypt(number[1])}:{NFController.Decrypt(number[2])}";
        //}
        //else
        //{
            Receiveds = $"socks5://{"127.0.0.1"}:{"16877"}";
        //}

        const string interfaceName = "SpeedFox";
        //var arguments = new object?[]
        //{
        //    // -device tun://aioCloud -proxy socks5://127.0.0.1:7890
        //    "-device", $"tun://{interfaceName}",
        //    "-proxy", Receiveds,
        //    "-mtu", "1500"
        //};

        StringBuilder arguments = new($"-device tun://{interfaceName}");
        _ = arguments.Append($" -proxy {Receiveds}");
        _ = arguments.Append($" -mtu 1500");

   
        this.Instance = new Process();
        this.Instance.StartInfo.FileName = $@"{Environment.CurrentDirectory}\\SpeedFox.tun2socks.exe";
        this.Instance.StartInfo.CreateNoWindow = false;// false
        this.Instance.StartInfo.UseShellExecute = false;
        this.Instance.EnableRaisingEvents = true;
        this.Instance.Exited += ProcessExited; // 注册进程退出事件处理程序
        this.Instance.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

        this.Instance.StartInfo.Arguments = arguments.ToString();

        Console.WriteLine("arguments:" + arguments);

        this.Instance.Start();

        if (this.Instance != null && !this.Instance.HasExited)
        {

        }
        else
        {
            this.Instance.Start();
            // 在此等待进程退出
            Instance.WaitForExit();

        }

        // Wait for adapter to be created
        Console.WriteLine("等待创建适配器");


        for (var i = 128; i > 0; i--)
        {
            //await 
            //Task.Delay(1000);
            try
            {
                _tunNetworkInterface = NetworkInterfaceUtils.Get(ni => ni.Name.StartsWith(interfaceName));
                Console.WriteLine("获取适配器成功！" + _tunNetworkInterface.GetIndex());
                break;
            }
            catch
            {
                Console.WriteLine("获取适配器失败 机会" + i);
            }
        }

        Console.WriteLine("获取适配器完成");

        if (_tunNetworkInterface == null)
            throw new MessageException("Create wintun adapter failed");


        var tunIndex = _tunNetworkInterface.GetIndex();
        _tun = NetRoute.TemplateBuilder(_tunConfig.Gateway, tunIndex);
        

        Console.WriteLine("配置本地路由");
        if (!RouteHelper.CreateUnicastIP(AddressFamily.InterNetwork,
                _tunConfig.Address,
                (byte)Utils.Utils.SubnetToCidr(_tunConfig.Netmask),
                (ulong)tunIndex))

        {
            Console.WriteLine("Create unicast IP failed");
        }

        Console.WriteLine("适配器初始化完成,即将开始写入路由表");

        //// 定义输出文件路径
        //string outputPath = @"C:\Users\MuXun\Desktop\app.txt";

        //// 创建并打开输出文件
        //using (StreamWriter writer = new StreamWriter(outputPath))
        //{
        //    // 将配置文件路径写入输出文件
        //    await writer.WriteLineAsync(decryptedRul);
        //}


        // 日路由表
        SetupRouteTableAsync(number[1]);


        // 上古屎，勿动
        switch (number[9])
        {
            case "ss/tun":
                string rulFilePaths = number[6];

                if (File.Exists(rulFilePaths))
                {
                    string encryptedRul = File.ReadAllText(rulFilePaths);
                    decryptedRul = NFController.Decrypt(encryptedRul); // 解密数据
                }
                else
                {
                    Console.WriteLine($"File {rulFilePaths} does not exist.");
                }
                await SetupRouteTableAsync(decryptedRul);
                break;
            default:
                string rulFilePath = number[5];
                if (File.Exists(rulFilePath))
                {
                    string encryptedRul = File.ReadAllText(rulFilePath);
                    decryptedRul = NFController.Decrypt(encryptedRul); // 解密数据
                }
                else
                {
                    Console.WriteLine($"File {rulFilePath} does not exist.");
                }
                await SetupRouteTableAsync(decryptedRul);
                break;
        }

    }


    private static void ProcessExited(object sender, EventArgs e)
    {
        //Process[] processee = Process.GetProcessesByName("MuXunHttp");
        //try
        //{
        //    foreach (Process item in processee)
        //    {
        //        item.Kill();
        //    }
        //}
        //catch
        //{

        //}

        System.Environment.Exit(0);
    }



    public async Task StartAsyncIn()
    {
        
        _tunConfig = TUNTAP;

        _serverRemoteAddress = NFController.Decrypt(number[1]).ValueOrDefault() != null ? await DnsUtils.LookupAsync(NFController.Decrypt(number[1])!) : await DnsUtils.LookupAsync(NFController.Decrypt(number[1]));

        if (_serverRemoteAddress != null && IPAddress.IsLoopback(_serverRemoteAddress))
        {
            _serverRemoteAddress = null;
        }

        _outbound = NetRoute.GetBestRouteTemplate();
       
        CheckDrivers();
       
        tun2socks.Dial(tun2socks.NameList.TYPE_ADAPMTU, "1500");
        tun2socks.Dial(tun2socks.NameList.TYPE_BYPBIND, _outbound.Gateway);
        tun2socks.Dial(tun2socks.NameList.TYPE_BYPLIST, "disabled");

        #region Server

        tun2socks.Dial(tun2socks.NameList.TYPE_TCPREST, "");
        tun2socks.Dial(tun2socks.NameList.TYPE_TCPTYPE, "Socks5");

        tun2socks.Dial(tun2socks.NameList.TYPE_UDPREST, "");
        tun2socks.Dial(tun2socks.NameList.TYPE_UDPTYPE, "Socks5");

        tun2socks.Dial(tun2socks.NameList.TYPE_TCPHOST, "127.0.0.1:16877");

        tun2socks.Dial(tun2socks.NameList.TYPE_UDPHOST, "127.0.0.1:16877");

        //if (server.Auth())
        //{
        //    tun2socks.Dial(tun2socks.NameList.TYPE_TCPUSER, server.Username!);
        //    tun2socks.Dial(tun2socks.NameList.TYPE_TCPPASS, server.Password!);

        //    tun2socks.Dial(tun2socks.NameList.TYPE_UDPUSER, server.Username!);
        //    tun2socks.Dial(tun2socks.NameList.TYPE_UDPPASS, server.Password!);
        //}

        #endregion

        #region DNS

        //if (_tunConfig.UseCustomDNS)
        //{
        //tun2socks.Dial(tun2socks.NameList.TYPE_DNSADDR, "1.1.1.1");
        await _aioDnsController.StartAsync();
        tun2socks.Dial(tun2socks.NameList.TYPE_DNSADDR, $"127.0.0.1:253");
        //}
        //else
        //{
        //    await _aioDnsController.StartAsync();
        //    tun2socks.Dial(NameList.TYPE_DNSADDR, $"127.0.0.1:{Global.Settings.AioDNS.ListenPort}");
        //}

        #endregion

        if (!tun2socks.Init())
            throw new MessageException("tun2socks start failed.");

        var tunIndex = (int)RouteHelperIn.ConvertLuidToIndex(tun2socks.tun_luid());
        _tun = NetRoute.TemplateBuilder(_tunConfig.Gateway, tunIndex);

        RouteHelperIn.CreateUnicastIP(AddressFamily.InterNetwork,
            _tunConfig.Address,
            (byte)Utils.Utils.SubnetToCidr(_tunConfig.Netmask),
            (ulong)tunIndex);


        string rulFilePath = number[5];
        string decryptedRul = string.Empty;

        if (File.Exists(rulFilePath))
        {
            string encryptedRul = File.ReadAllText(rulFilePath);
            decryptedRul = NFController.Decrypt(encryptedRul); // 解密数据
        }
        else
        {
            Console.WriteLine($"File {rulFilePath} does not exist.");
        }
        //switch (number[9])
        //{
        //    case "ss":
        //        await SetupRouteTableAsyncs(decryptedRul);
        //        break;
        //    case "ss/tun":
        //        await SetupRouteTableAsyncs(number[6]);
        //        break;
        //    default:
                await SetupRouteTableAsyncs(decryptedRul);
        //        break;
        //}
    }

    private void CheckDriver()
    {
        var f = $@"{Environment.SystemDirectory}\wintun.dll";
        try
        {
            if (File.Exists(f))
            {
                Log.Information($"Remove unused \"{f}\"");
                File.Delete(f);
            }
        }
        catch
        {
            // ignored
        }
    }

    internal static void CheckDrivers()
    {
        string binDriver = "wintun.dll";
        string sysDriver = $@"{Environment.SystemDirectory}\wintun.dll";


        var binHash = Utils.Utils.SHA256CheckSum(binDriver);
        var sysHash = Utils.Utils.SHA256CheckSum(sysDriver);


        // 这b玩意好像有的版本号一样但是里面内容不一样，不能靠版本号识别，草了
        string fileVersion = Utils.Utils.GetFileVersion(binDriver);
        string fileVersion2 = Utils.Utils.GetFileVersion(sysDriver);

        Console.WriteLine("检查 wintun.dll 客户端:" + fileVersion + "用户:" + fileVersion2);
        Console.WriteLine("检查 wintun.dll 客户端:" + binHash + "用户:" + sysHash);


        //Log.Information("Built-in  wintun.dll Hash: {Hash}", binHash);
        //Log.Information("Installed wintun.dll Hash: {Hash}", sysHash);
        if (binHash + fileVersion == sysHash + fileVersion2)
        {

        }
        else 
        {
            Console.WriteLine("wintun.dll 不一样或者没有 重新安装");
        };

        try
        {
            //Log.Information("Copy wintun.dll to System Directory");
            File.Copy(binDriver, sysDriver, true);
        }
        catch (Exception e)
        {
            //Log.Error(e, "Copy wintun.dll failed");
            throw new MessageException($"wintun.dll拷贝失败: {e.Message}");
        }
    }

    #region Route



    private async Task SetupRouteTableAsyncs(string mode)
    {
        List<string> list = mode.Split(new char[] { ',' }).ToList<string>();
        List<string> list2 = new List<string>();
        foreach (string text in list)
        {
            list2.Add(text);
            Console.WriteLine("路由表:" + text);
        }


        var tunNetworkInterface = NetworkInterfaceUtils.Get(_tun.InterfaceIndex);
        // Server Address
        if (_serverRemoteAddress != null)
            RouteUtils.CreateRoute(_outbound.FillTemplate(_serverRemoteAddress.ToString(), 32));

        RouteUtils.CreateRouteFill(_tun, list2);

        // dns
        // NOTICE: DNS metric is network interface metric
        
        tunNetworkInterface.SetDns("1.1.1.1");
        //RouteUtils.CreateRoute(_tun.FillTemplate("1.1.1.1", 32));


        NetworkInterfaceUtils.SetInterfaceMetric(_tun.InterfaceIndex, 0);
    }


    private async Task SetupRouteTableAsync(string mode)
    {
        // 操作路由表，用，分割，组成数组
        List<string> list = mode.Split(new char[] { ',' }).ToList<string>();
        List<string> list2 = new List<string>();
        foreach (string text in list)
        {
            list2.Add(text);
            Console.WriteLine("路由表:" + text);
        }

        if (_serverRemoteAddress != null)
            RouteUtils.CreateRoute(_outbound.FillTemplate(_serverRemoteAddress.ToString(), 32));


        // RouteUtils.CreateRouteFill(_outbound, _tunConfig.BypassIPs);
        RouteUtils.CreateRouteFill(_tun, list2);


        RouteUtils.CreateRoute(_tun.FillTemplate(_tunConfig.DNS, 32));

        // Console.WriteLine("==============dns================" + number[2]);
        // _tunNetworkInterface.SetDns("1.1.1.1");
        _tunNetworkInterface.SetDns(number[2]);

        // set tun interface's metric to the highest to let Windows use the interface's DNS
        NetworkInterfaceUtils.SetInterfaceMetric(_tun.InterfaceIndex, 0);
    }

    

    #endregion
}