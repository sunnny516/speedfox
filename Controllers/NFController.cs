using Microsoft.Win32;
using MuXunProxy.Models;
using MuXunProxy.Utils;
using nfapinet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security;
using System.Security.Cryptography;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
//using System.Web.UI.WebControls;
////using Vanara.Extensions;
using static System.Windows.Forms.AxHost;
//using Vanara.PInvoke;
//using static Vanara.PInvoke.Kernel32.FILE_REMOTE_PROTOCOL_INFO;

namespace MuXunProxy.Controllers;

internal class NFController
{
    private string dirverPath;

    private const string dirverName = "opwfp.sys";

    private const string original_dirName = "netfilter2.sys";

    private string regDirExe = "nfregdrv.exe";

    private readonly string SystemDirPath;

    private int breakerCounter;

    private const int breakerThreshold = 2;

    private int filedelbreakerCounter;

    private const int filedelbreakerThreshold = 2;
    public static string JinChenMoShi6 { get; set; }
    private static readonly ServiceController NFService = new("netfilter2");
    //private static string BinDriver = "C:\\Program Files\\Zcy7\\accelerator\\wfp\\x32\\MuXunSpeed.sys";
    //private static string BinDriver = $@"{Environment.CurrentDirectory}\" + (Environment.Is64BitOperatingSystem ? "x64" : "x86") + "\\MuXunSpeed.sys";
    //private const string Binnfapi = "C:\\Program Files\\MuXun\\accelerator\\wfp\\x64\\MuXun.dll";
    //private const string BinNFCApi = "C:\\Program Files\\Zcy7\\accelerator\\wfp\\x32\\MuXun.dll";

    private static string BinDriver = $@"{Environment.CurrentDirectory}\\netfilter\\netfilter2.sys";
    private static string BinNFCApi = $@"{Environment.CurrentDirectory}\\netfilter\\nfapi.dll";



    private static readonly string SystemDriver = $"{Environment.SystemDirectory}\\drivers\\netfilter2.sys";
    private string[] string_0;
    public Process controller;
    public Process Instance { get; private set; }
    public static bool IsSuperMode { get; set; }
    //static NFController()
    //{
    //    string fileName;
    //    switch ($"{Environment.OSVersion.Version.Major}.{Environment.OSVersion.Version.Minor}")
    //    {
    //        case "10.0":
    //            fileName = "Win-10.sys";
    //            break;
    //        case "6.3":
    //        case "6.2":
    //            fileName = "Win-8.sys";
    //            break;
    //        case "6.1":
    //        case "6.0":
    //            fileName = "Win-7.sys";
    //            break;
    //        default:
    //            throw new MessageException($"不支持的系统版本：{Environment.OSVersion.Version}");
    //    }

    //    BinDriver = "x64\\" + fileName;
    //}

    public NFController(string[] parameters)
    {
        string_0 = parameters;



        if (smethod_1())
        {
            this.SystemDirPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\Sysnative\\drivers\\netfilter2.sys";
        }
        else
        {
            this.SystemDirPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\drivers\\netfilter2.sys";
        }


        //string path = $@"C:\Users\MuXun\Desktop\sk";
        //var filename = $"sk.txt";
        //if (!Directory.Exists(path))
        //    Directory.CreateDirectory(path);
        //TextWriter tw = new StreamWriter(Path.Combine(path, filename), true); //true在文件末尾添加数据
        //tw.WriteLine(string_0[1]);
        //tw.WriteLine(string_0[2]);
        //tw.Close();
        // Port = PortHelper.GetAvailablePort();
    }
    [DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string methodName);

    [DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Auto)]
    private static extern IntPtr GetModuleHandle(string modName);

    [SecurityCritical]
    private static bool smethod_0(string moduleName, string methodName)
    {
        IntPtr moduleHandle = GetModuleHandle(moduleName);
        return !(moduleHandle == IntPtr.Zero) && GetProcAddress(moduleHandle, methodName) != IntPtr.Zero;
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsWow64Process([In] IntPtr hProcess, out bool lpSystemInfo);

    public static bool smethod_1()
    {
        bool result;
        using (Process currentProcess = Process.GetCurrentProcess())
        {
            bool flag;
            result = IntPtr.Size == 8 || (smethod_0("kernel32.dll", "IsWow64Process") && IntPtr.Size == 4 && IsWow64Process(currentProcess.Handle, out flag) && flag);
        }
        return result;
    }

    internal void StartJiu()
    {
        //StopTime();
        CheckDriverm();
        #region aio_dial

        aio_dial((int)NameList.TYPE_FILTERLOOPBACK, "false");
        aio_dial((int)NameList.TYPE_TCPLISN, "3901");

        aio_dial((int)NameList.TYPE_FILTERUDP, "true");
        aio_dial((int)NameList.TYPE_FILTERTCP, "true");
        SetServer(PortType.Both);

        //if (!CheckRule(mode.FullRule, out var list))
        //    throw new MessageException($"\"{string.Join("", list.Select(s => s + "\n"))}\" does not conform to C++ regular expression syntax");

        Dial_NamesJiu(string_0[5]);

        #endregion

        if (false)
            aio_dial((int)NameList.TYPE_REDIRCTOR_DNS, "8.8.8.8");

        if (false)
            aio_dial((int)NameList.TYPE_REDIRCTOR_ICMP, "1.2.4.8");

        aio_dial((int)NameList.TYPE_FILTERCHILDPROC, "false");

        if (!aio_init())
            throw new MessageException("Redirector Start failed, run Netch with \"-console\" argument");
    }

    private void SetServer(in PortType portType)
    {
        if (portType == PortType.Both)
        {
            SetServer(PortType.TCP);
            SetServer(PortType.UDP);
            return;
        }

        int offset;
        //Server server;
        //IServerController controller;

        if (portType == PortType.UDP)
        {
            offset = UdpNameListOffset;
        }
        else
        {
            offset = 0;
        }
        aio_dial((int)NameList.TYPE_TCPTYPE + offset, "Socks5");
        aio_dial((int)NameList.TYPE_TCPHOST + offset, $"127.0.0.1:{"16877"}");
        aio_dial((int)NameList.TYPE_TCPUSER + offset, string.Empty);
        aio_dial((int)NameList.TYPE_TCPPASS + offset, string.Empty);
        aio_dial((int)NameList.TYPE_TCPMETH + offset, string.Empty);
    }
    #region NativeMethods

    private const int UdpNameListOffset = (int)NameList.TYPE_UDPTYPE - (int)NameList.TYPE_TCPTYPE;

    [DllImport("Redirector.bin", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool aio_dial(int name, [MarshalAs(UnmanagedType.LPWStr)] string value);

    [DllImport("Redirector.bin", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool aio_init();

    [DllImport("Redirector.bin", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool aio_free();

    [DllImport("Redirector.bin", CallingConvention = CallingConvention.Cdecl)]
    private static extern ulong aio_getUP();

    [DllImport("Redirector.bin", CallingConvention = CallingConvention.Cdecl)]
    private static extern ulong aio_getDL();

    public enum NameList
    {
        //bool
        TYPE_FILTERLOOPBACK,
        TYPE_FILTERTCP,
        TYPE_FILTERUDP,
        TYPE_FILTERIP,
        TYPE_FILTERCHILDPROC,//子进程捕获

        TYPE_TCPLISN,
        TYPE_TCPTYPE,
        TYPE_TCPHOST,
        TYPE_TCPUSER,
        TYPE_TCPPASS,
        TYPE_TCPMETH,

        TYPE_UDPTYPE,
        TYPE_UDPHOST,
        TYPE_UDPUSER,
        TYPE_UDPPASS,
        TYPE_UDPMETH,

        TYPE_ADDNAME,
        TYPE_ADDFIP,

        TYPE_BYPNAME,

        TYPE_CLRNAME,
        TYPE_CLRFIP,

        //str addr x.x.x.x only ipv4
        TYPE_REDIRCTOR_DNS,
        TYPE_REDIRCTOR_ICMP
    }

    #endregion
    internal void Start()
    {
        StopTime();
        CheckDrivers();


        RedirectorIn.Dial(RedirectorIn.NameList.TYPE_FILTERLOOPBACK, "false");
        RedirectorIn.Dial(RedirectorIn.NameList.TYPE_FILTERICMP, "true");
        ushort availablePort = PortHelper.GetAvailablePort(PortType.Both);
        RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPLISN, availablePort.ToString());
        RedirectorIn.Dial(RedirectorIn.NameList.TYPE_UDPLISN, availablePort.ToString());
        RedirectorIn.Dial(RedirectorIn.NameList.TYPE_FILTERUDP, "true");
        RedirectorIn.Dial(RedirectorIn.NameList.TYPE_FILTERTCP, "true");
        PortType portType = PortType.Both;
        DialServer(portType);
        Dial_Names(string_0[5]);
        RedirectorIn.Dial(RedirectorIn.NameList.TYPE_DNSHOST, "1.1.1.1:53");
        if (!RedirectorIn.Init())
        {
            throw new Exception("驱动初始化失败!");
        }

        StopTime();
        ClearMemory();
    }


    //#endregion
    internal void StartDLL()
    {
        var client = Encoding.UTF8.GetBytes($"{"127.0.0.1"}:{"16877"}");
        var remote = Encoding.UTF8.GetBytes($"{Decrypt(string_0[1])}:{Decrypt(string_0[7])}");
        var passwd = Encoding.UTF8.GetBytes($"{Decrypt(string_0[4])}");
        var method = Encoding.UTF8.GetBytes($"{Decrypt(string_0[8])}");

        if (!ShadowsocksDLL.Info(client, remote, passwd, method))
        {
            throw new Exception("DLL SS INFO 设置失败！");
        }


        if (!ShadowsocksDLL.Start())
        {
            throw new Exception("DLL SS 启动失败！");
        }

        return;
    }

    internal void StartDLLSS()
    {
        var client = Encoding.UTF8.GetBytes($"{"127.0.0.1"}:{"16877"}");
        var remote = Encoding.UTF8.GetBytes($"{Decrypt(string_0[1])}:{Decrypt(string_0[8])}");
        var passwd = Encoding.UTF8.GetBytes($"{Decrypt(string_0[4])}");
        var method = Encoding.UTF8.GetBytes($"{Decrypt(string_0[7])}");

        if (!ShadowsocksDLL.Info(client, remote, passwd, method))
        {
            throw new Exception("DLL SS INFO 设置失败！");
        }


        if (!ShadowsocksDLL.Start())
        {
            throw new Exception("DLL SS 启动失败！");
        }

        return;
    }
    internal void StartSyS()
    {
        SetEnv($"socks5://{"127.0.0.1"}:{"16877"}", "", "");
    }

    private void SetEnv(string proxyUrl, string username, string password)
    {
        CommandHelper.Windows(string.Empty, new string[] { $"setx http_proxy \"{proxyUrl}\" -m", $"setx https_proxy \"{proxyUrl}\" -m" });
        if (string.IsNullOrWhiteSpace(username) == false)
        {
            CommandHelper.Windows(string.Empty, new string[] {
                    $"setx http_proxy_user {username} -m",
                    $"setx http_proxy_pass {password} -m",
                    $"setx https_proxy_user {username} -m",
                    $"setx https_proxy_pass {password} -m",
               });
        }
    }


    internal void StartSSRE()
    {
        StopTime();

        CheckDriver();
        //IPAddress ip = Utils.Utils.GetHostIp();
        _ = Redirector.Dial(Redirector.NameList.AIO_FILTERLOOPBACK, "false");
        _ = Redirector.Dial(Redirector.NameList.AIO_FILTERINTRANET, "false");
        _ = Redirector.Dial(Redirector.NameList.AIO_FILTERPARENT, "false");
        //if (GlobalCache.CurrentGame.HuoName is "开")
        //{
        _ = Redirector.Dial(Redirector.NameList.AIO_FILTERICMP, "false");
        _ = Redirector.Dial(Redirector.NameList.AIO_ICMPING, "10");
        //}
        //else
        //    _ = Redirector.Dial(Redirector.NameList.AIO_FILTERICMP, "false");
        _ = Redirector.Dial(Redirector.NameList.AIO_FILTERTCP, "true");
        _ = Redirector.Dial(Redirector.NameList.AIO_FILTERUDP, "true");

        _ = Redirector.Dial(Redirector.NameList.AIO_FILTERDNS, "false");//true
        _ = Redirector.Dial(Redirector.NameList.AIO_DNSONLY, "false");//true
        _ = Redirector.Dial(Redirector.NameList.AIO_DNSPROX, "false");
        if (false)
        {
            _ = Redirector.Dial(Redirector.NameList.AIO_DNSHOST, "8.8.8.8");
            _ = Redirector.Dial(Redirector.NameList.AIO_DNSPORT, "53");
        }
        //if (GlobalCache.CurrentGame.JiaSuFangShi is "sk5")
        //{
        //    _ = Redirector.Dial(Redirector.NameList.AIO_TGTHOST, $"{GlobalCache.CurrentSSR.HostName}");
        //    _ = Redirector.Dial(Redirector.NameList.AIO_TGTPORT, $"{GlobalCache.CurrentSSR.Port}");
        //    _ = Redirector.Dial(Redirector.NameList.AIO_TGTUSER, GlobalCache.CurrentSSR.Password);
        //    _ = Redirector.Dial(Redirector.NameList.AIO_TGTPASS, GlobalCache.CurrentSSR.Method);
        //}
        //else
        //{
        _ = Redirector.Dial(Redirector.NameList.AIO_TGTHOST, "127.0.0.1");
        _ = Redirector.Dial(Redirector.NameList.AIO_TGTPORT, $"{"16877"}");
        _ = Redirector.Dial(Redirector.NameList.AIO_TGTUSER, string.Empty);
        _ = Redirector.Dial(Redirector.NameList.AIO_TGTPASS, string.Empty);
        //}

        Dial_Name(string_0[5]);

        if (!Redirector.Init())
        {
            throw new Exception("驱动初始化失败!");
        }
        StopTime();
        ClearMemory();
    }



    #region 内存回收
    [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
    internal static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
    private static void ClearMemory()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            _ = SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
    }
    #endregion

    private static void Dial_NamesJiu(string mode)
    {
        aio_dial((int)NameList.TYPE_CLRNAME, "");
        List<string> list = mode.Split(new char[] { ',' }).ToList<string>();
        List<string> list2 = new List<string>();
        foreach (string text in list)
        {
            if (text.StartsWith("!"))
            {
                if (!aio_dial((int)NameList.TYPE_BYPNAME, text.Substring(1)))
                    list2.Add(text);
            }
            else if (!aio_dial((int)NameList.TYPE_ADDNAME, text))
                list2.Add(text);
        }
        //string currentDirectory = Environment.CurrentDirectory;
        //Directory.SetCurrentDirectory(Directory.GetParent(currentDirectory).FullName);
        //_ = Directory.GetCurrentDirectory();
        if (list2.Any<string>())
            throw new Exception(GenerateInvalidRulesMessage(list2));
    }

    private static void Dial_Names(string mode)
    {
        _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_CLRNAME, "");
        List<string> list = mode.Split(new char[] { ',' }).ToList<string>();
        List<string> list2 = new List<string>();
        foreach (string text in list)
        {
            if (text.StartsWith("!"))
            {
                if (!RedirectorIn.Dial(RedirectorIn.NameList.TYPE_BYPNAME, text.Substring(1)))
                    list2.Add(text);
            }
            else if (!RedirectorIn.Dial(RedirectorIn.NameList.TYPE_ADDNAME, text))
                list2.Add(text);
        }
        //string currentDirectory = Environment.CurrentDirectory;
        //Directory.SetCurrentDirectory(Directory.GetParent(currentDirectory).FullName);
        //_ = Directory.GetCurrentDirectory();
        if (list2.Any<string>())
            throw new Exception(GenerateInvalidRulesMessage(list2));
    }

    private void Dial_Name(string mode)
    {
        _ = Redirector.Dial(Redirector.NameList.AIO_CLRNAME, "");
        List<string> list = mode.Split(new char[] { ',' }).ToList<string>();
        List<string> list2 = new List<string>();
        foreach (string text in list)
        {
            if (text.StartsWith("!"))
            {
                if (!Redirector.Dial(Redirector.NameList.AIO_BYPNAME, text.Substring(1)))
                    list2.Add(text);
            }
            else if (!Redirector.Dial(Redirector.NameList.AIO_ADDNAME, text))
                list2.Add(text);
        }
        //string currentDirectory = Environment.CurrentDirectory;
        //Directory.SetCurrentDirectory(Directory.GetParent(currentDirectory).FullName);
        //_ = Directory.GetCurrentDirectory();
        if (list2.Any<string>())
            throw new Exception(GenerateInvalidRulesMessage(list2));
    }

    private void DialServer(in PortType portType)
    {
        StopTime();
        if (portType == PortType.Both)
        {
            PortType portType2 = PortType.TCP;
            DialServer(portType2);
            portType2 = PortType.UDP;
            DialServer(portType2);
        }
        else
        {
            int num = portType != PortType.UDP ? 0 : 10;
            //if (string_0[6] == "ss")
            //{
            //    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPTYPE + num, "Shadowsocks");
            //    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPHOST + num, Decrypt(string_0[1]) + ":" + Decrypt(string_0[7]));
            //    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPUSER + num, string.Empty);
            //    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPMETH + num, Decrypt(string_0[8]));
            //    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPPASS + num, Decrypt(string_0[4]));
            //}
            //else if (string_0[9] == "ss/tun")
            //{
            //    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPTYPE + num, "Shadowsocks");
            //    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPHOST + num, Decrypt(string_0[1]) + ":" + Decrypt(string_0[8]));
            //    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPUSER + num, string.Empty);
            //    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPMETH + num, Decrypt(string_0[7]));
            //    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPPASS + num, Decrypt(string_0[4]));
            //}
            //else if (string_0[6] == "sk5")
            //{
            //    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPTYPE + num, "Socks5");
            //    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPHOST + num, Decrypt(string_0[1]) + ":" + Decrypt(string_0[2]));
            //    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPUSER + num, Decrypt(string_0[3]));
            //    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPPASS + num, Decrypt(string_0[4]));
            //    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPMETH + num, string.Empty);
            //}
            ////else if (string_0[6] == "ssdll")
            ////{
            ////    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPTYPE + num, "Socks5");
            ////    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPHOST + num, $"{"127.0.0.1"}:{Port}");
            ////    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPUSER + num, string.Empty);
            ////    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPPASS + num, string.Empty);
            ////    _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPMETH + num, string.Empty);
            ////}
            //else
            //{
            _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPTYPE + num, "Socks5");
            _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPHOST + num, $"{"127.0.0.1"}:{"16877"}");
            _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPUSER + num, string.Empty);
            _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPPASS + num, string.Empty);
            _ = RedirectorIn.Dial(RedirectorIn.NameList.TYPE_TCPMETH + num, string.Empty);
            //}
            StopTime();
        }
    }


    private static async Task ReplaceRuls(string url)
    {
        string file1Path = "data.db.bak";
        string file2Path = "data.db";

        await Utils.Utils.DownloadFileAsync(url, file1Path);
        await Utils.Utils.DownloadFileAsync("http://39.104.201.162/Games/ruls.txt", file2Path);

        Utils.Utils.InsertData(file2Path, file1Path, "cdn.playcaliber.com");
        //FileInfo fileInfo = new(tmpPath);
        //if (File.Exists(hostsPath))
        //    File.SetAttributes(hostsPath, File.GetAttributes(hostsPath) & ~FileAttributes.ReadOnly);

        //fileInfo.CopyTo(hostsPath, true);
        //fileInfo.Delete();
    }
    public bool StartWai()
    {
        if (string_0[9] == "ss/tun")
            ReplaceRuls(string_0[10]);
        else
            ReplaceRuls(string_0[11]);

        try
        {
            if (!File.Exists("MuXunProxy.exe"))
            {
                Log.Logger.Error("not found MuXunProxy.exe");
                return false;
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Process.GetProcessesByName(Path.GetFileNameWithoutExtension("MuXunProxy.exe")).ToList<Process>().ForEach(delegate (Process app)
                    {
                        try
                        {
                            app.Kill();
                        }
                        catch
                        {
                        }
                    });
                    if (!Process.GetProcessesByName(Path.GetFileNameWithoutExtension("MuXunProxy.exe")).Any<Process>())
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                }
                if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension("MuXunProxy.exe")).Any<Process>())
                {
                    Log.Logger.Error("未能正确关闭 MuXunProxy");
                    return false;
                }
                else
                {
                    string originalString;
                    string me = Decrypt(string_0[8]);
                    string meself = Decrypt(string_0[7]);
                    if (string_0[6] == "1" || string_0[9] == "ss/tun")
                    {
                        if (meself == "aes-256-cfb")
                            originalString = $"local_address:0.0.0.0,local_port:16877,server:{Decrypt(string_0[1])},server_port:{Decrypt(string_0[8])},method:{Decrypt(string_0[7])},password:{Decrypt(string_0[4])},mx_head_str:com.win64.oppc.game.common";
                        else
                            originalString = $"local_address:0.0.0.0,local_port:16877,server:{Decrypt(string_0[1])},server_port:{Decrypt(string_0[8])},method:{Decrypt(string_0[7])},password:{Decrypt(string_0[4])}";

                    }
                    else
                    {
                        if (me == "aes-256-cfb")
                            originalString = $"local_address:0.0.0.0,local_port:16877,server:{Decrypt(string_0[1])},server_port:{Decrypt(string_0[7])},method:{Decrypt(string_0[8])},password:{Decrypt(string_0[4])},mx_head_str:com.win64.oppc.game.common";
                        else
                            originalString = $"local_address:0.0.0.0,local_port:16877,server:{Decrypt(string_0[1])},server_port:{Decrypt(string_0[7])},method:{Decrypt(string_0[8])},password:{Decrypt(string_0[4])}";

                    }

                    // 匹配键值对模式
                    Regex regex = new Regex(@"(\w+):(.+?)(?=,\w+:|$)");

                    string modifiedString = regex.Replace(originalString, match =>
                    {
                        string key = match.Groups[1].Value.Trim();
                        string value = match.Groups[2].Value.Trim();

                        if (key == "local_port" || key == "server_port")
                        {
                            // 添加双引号
                            return $"\"{key}\":{value}";
                        }
                        else
                        {
                            // 添加双引号
                            value = value.Contains("{") ? $"{value}" : $"\"{value}\"";
                            return $"\"{key}\":{value}";
                        }
                    });

                    string arguments;
                    string text = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{{{modifiedString}}}")).ReversalStr(); ;
                    //if()
                    //string arguments = $"--mx " + text + " -u";
                    //string arguments = $"--mx " + text + " -u";
                    if (!string.IsNullOrWhiteSpace(string_0[10]) || !string.IsNullOrWhiteSpace(string_0[11]))
                        //arguments = $"--mx " + text + " -u --no-delay --fast-open" + " --acl " + "data.db";
                        arguments = $"--mx " + text + " -u";
                    else
                         arguments = $"--mx " + text + " -u --no-delay --fast-open";

                    //--no-delay --fast-open" + " --acl " + "data.db"
                    //string arguments = $"--mx " + text + " -u";
                    //string arguments = $"--mx " + text + " -u";
                    //string arguments = $"--mx " + text + " -u";  + " --acl " + "data.db"
                    this.Instance = new Process();
                    this.Instance.StartInfo.FileName = "MuXunProxy.exe";
                    this.Instance.StartInfo.CreateNoWindow = true;
                    this.Instance.StartInfo.UseShellExecute = false;
                    this.Instance.EnableRaisingEvents = true;
                    this.Instance.Exited += ProcessExited; // 注册进程退出事件处理程序
                    this.Instance.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    this.Instance.StartInfo.Arguments = arguments;

                    // 检查文件是否存在
                    //if (File.Exists("data.db"))
                    //{
                    //    // 读取文件内容
                    //    string fileContent = File.ReadAllText("data.db");

                    //    if (!string.IsNullOrWhiteSpace(fileContent)) // 判断文件内容是否为空或仅包含空白字符
                    //    {

                    //    }
                    //    else
                    //    {
                    //        return false;
                    //    }
                    //}
                    //else
                    //{
                    //    return false;
                    //}
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

                }
            }
        }
        catch (Exception exception)
        {
            Log.Logger.Error(exception, MethodBase.GetCurrentMethod().Name);
            return false;
        }
        return true;
    }
    public bool StartWais()
    {
        //if (string_0[9] == "ss/tun")
        //    ReplaceRuls(string_0[10]);
        //else
        //    ReplaceRuls(string_0[11]);

        try
        {
            if (!File.Exists("MuXunProxys.exe"))
            {
                Log.Logger.Error("not found MuXunProxys.exe");
                return false;
            }
            else
            {
                //for (int i = 0; i < 5; i++)
                //{
                //    Process.GetProcessesByName(Path.GetFileNameWithoutExtension("MuXunProxys.exe")).ToList<Process>().ForEach(delegate (Process app)
                //    {
                //        try
                //        {
                //            app.Kill();
                //        }
                //        catch
                //        {
                //        }
                //    });
                //    if (!Process.GetProcessesByName(Path.GetFileNameWithoutExtension("MuXunProxys.exe")).Any<Process>())
                //    {
                //        break;
                //    }
                //    Thread.Sleep(1000);
                //}
                //if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension("MuXunProxys.exe")).Any<Process>())
                //{
                //    Log.Logger.Error("未能正确关闭 MuXunProxys");
                //    return false;
                //}
                //else
                //{
                    string originalString;
                    string me = Decrypt(string_0[8]);
                    string meself = Decrypt(string_0[7]);
                    if (string_0[6] == "1" || string_0[9] == "ss/tun")
                    {
                        if (meself == "aes-256-cfb")
                            originalString = $"local_address:0.0.0.0,local_port:16878,server:{Decrypt(string_0[9])},server_port:{Decrypt(string_0[2])},method:{Decrypt(string_0[3])},password:{Decrypt(string_0[10])},mx_head_str:com.win64.oppc.game.common";
                        else
                            originalString = $"local_address:0.0.0.0,local_port:16878,server:{Decrypt(string_0[9])},server_port:{Decrypt(string_0[2])},method:{Decrypt(string_0[3])},password:{Decrypt(string_0[10])}";

                    }
                    else
                    {
                        if (me == "aes-256-cfb")
                            originalString = $"local_address:0.0.0.0,local_port:16878,server:{Decrypt(string_0[9])},server_port:{Decrypt(string_0[2])},method:{Decrypt(string_0[3])},password:{Decrypt(string_0[10])},mx_head_str:com.win64.oppc.game.common";
                        else
                            originalString = $"local_address:0.0.0.0,local_port:16878,server:{Decrypt(string_0[9])},server_port:{Decrypt(string_0[2])},method:{Decrypt(string_0[3])},password:{Decrypt(string_0[10])}";

                    }

                    // 匹配键值对模式
                    Regex regex = new Regex(@"(\w+):(.+?)(?=,\w+:|$)");

                    string modifiedString = regex.Replace(originalString, match =>
                    {
                        string key = match.Groups[1].Value.Trim();
                        string value = match.Groups[2].Value.Trim();

                        if (key == "local_port" || key == "server_port")
                        {
                            // 添加双引号
                            return $"\"{key}\":{value}";
                        }
                        else
                        {
                            // 添加双引号
                            value = value.Contains("{") ? $"{value}" : $"\"{value}\"";
                            return $"\"{key}\":{value}";
                        }
                    });


                    string text = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{{{modifiedString}}}")).ReversalStr(); ;
                    //if()
                    //string arguments = $"--mx " + text + " -u";
                    //string arguments = $"--mx " + text + " -u";
                    string arguments = $"--mx " + text + " --no-delay --fast-open" + " --acl " + "data.db";
                    //string arguments = $"--mx " + text + " -u";
                    //string arguments = $"--mx " + text + " -u";
                    //string arguments = $"--mx " + text + " -u";  + " --acl " + "data.db"
                    this.Instance = new Process();
                    this.Instance.StartInfo.FileName = "MuXunProxys.exe";
                    this.Instance.StartInfo.CreateNoWindow = true;
                    this.Instance.StartInfo.UseShellExecute = false;
                    this.Instance.EnableRaisingEvents = true;
                    this.Instance.Exited += ProcessExited; // 注册进程退出事件处理程序
                    this.Instance.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    this.Instance.StartInfo.Arguments = arguments;

                    // 检查文件是否存在
                    //if (File.Exists("data.db"))
                    //{
                    //    // 读取文件内容
                    //    string fileContent = File.ReadAllText("data.db");

                    //    if (!string.IsNullOrWhiteSpace(fileContent)) // 判断文件内容是否为空或仅包含空白字符
                    //    {

                    //    }
                    //    else
                    //    {
                    //        return false;
                    //    }
                    //}
                    //else
                    //{
                    //    return false;
                    //}
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

                }
            //}
        }
        catch (Exception exception)
        {
            Log.Logger.Error(exception, MethodBase.GetCurrentMethod().Name);
            return false;
        }
        return true;
    }
    public bool StartRust()
    {
        if (string_0[9] == "ss/tun")
            ReplaceRuls(string_0[10]);
        else
            ReplaceRuls(string_0[11]);

        try
        {
            if (!File.Exists("MuXunProxy.exe"))
            {
                Log.Logger.Error("not found MuXunProxy.exe");
                return false;
            }
            else
            {
                //for (int i = 0; i < 5; i++)
                //{
                //    Process.GetProcessesByName(Path.GetFileNameWithoutExtension("MuXunProxy.exe")).ToList<Process>().ForEach(delegate (Process app)
                //    {
                //        try
                //        {
                //            app.Kill();
                //        }
                //        catch
                //        {
                //        }
                //    });
                //    if (!Process.GetProcessesByName(Path.GetFileNameWithoutExtension("MuXunProxy.exe")).Any<Process>())
                //    {
                //        break;
                //    }
                //    Thread.Sleep(1000);
                //}
                //if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension("MuXunProxy.exe")).Any<Process>())
                //{
                //    Log.Logger.Error("未能正确关闭 MuXunProxy");
                //    return false;
                //}
                //else
                //{
                    string originalString;
                    string text = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Decrypt(string_0[4])}")).ReversalStr();
                    if (string_0[6] == "1" || string_0[9] == "ss/tun")
                    {
                        originalString = $"-s{Decrypt(string_0[1])}:{Decrypt(string_0[8])} -b{"0.0.0.0"}:16877 -m{Decrypt(string_0[7])} -k{text}";
                    }
                    else
                    {
                        originalString = $"-s{Decrypt(string_0[1])}:{Decrypt(string_0[7])} -b{"0.0.0.0"}:16877 -m{Decrypt(string_0[8])} -k{text}";
                    }

                    //if()
                    //string arguments = $"--mx " + text + " -u";
                    //string arguments = $"--mx " + text + " -u";
                    string arguments = $"{originalString} -U --no-delay --fast-open" + " --acl " + "data.db";
                    //string arguments = $"--mx " + text + " -u";
                    //string arguments = $"--mx " + text + " -u";
                    //string arguments = $"--mx " + text + " -u";  + " --acl " + "data.db"
                    this.Instance = new Process();
                    this.Instance.StartInfo.FileName = "MuXunProxy.exe";
                    this.Instance.StartInfo.CreateNoWindow = true;
                    this.Instance.StartInfo.UseShellExecute = false;
                    this.Instance.EnableRaisingEvents = true;
                    this.Instance.Exited += ProcessExited; // 注册进程退出事件处理程序
                    this.Instance.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    this.Instance.StartInfo.Arguments = arguments;

                    // 检查文件是否存在
                    //if (File.Exists("data.db"))
                    //{
                    //    // 读取文件内容
                    //    string fileContent = File.ReadAllText("data.db");

                    //    if (!string.IsNullOrWhiteSpace(fileContent)) // 判断文件内容是否为空或仅包含空白字符
                    //    {

                    //    }
                    //    else
                    //    {
                    //        return false;
                    //    }
                    //}
                    //else
                    //{
                    //    return false;
                    //}
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

                //}
            }
        }
        catch (Exception exception)
        {
            Log.Logger.Error(exception, MethodBase.GetCurrentMethod().Name);
            return false;
        }
        return true;
    }
    public bool StartRusts()
    {
        if (string_0[9] == "ss/tun")
            ReplaceRuls(string_0[10]);
        else
            ReplaceRuls(string_0[11]);

        try
        {
            if (!File.Exists("MuXunProxy.exe"))
            {
                Log.Logger.Error("not found MuXunProxy.exe");
                return false;
            }
            else
            {
                //for (int i = 0; i < 5; i++)
                //{
                //    Process.GetProcessesByName(Path.GetFileNameWithoutExtension("MuXunProxy.exe")).ToList<Process>().ForEach(delegate (Process app)
                //    {
                //        try
                //        {
                //            app.Kill();
                //        }
                //        catch
                //        {
                //        }
                //    });
                //    if (!Process.GetProcessesByName(Path.GetFileNameWithoutExtension("MuXunProxy.exe")).Any<Process>())
                //    {
                //        break;
                //    }
                //    Thread.Sleep(1000);
                //}
                //if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension("MuXunProxy.exe")).Any<Process>())
                //{
                //    Log.Logger.Error("未能正确关闭 MuXunProxy");
                //    return false;
                //}
                //else
                //{
                    string originalString;
                    string text = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Decrypt(string_0[10])}")).ReversalStr();
                    if (string_0[6] == "1" || string_0[9] == "ss/tun")
                    {
                        originalString = $"-s{Decrypt(string_0[9])}:{Decrypt(string_0[2])} -b{"0.0.0.0"}:16878 -m{Decrypt(string_0[3])} -k{text}";
                    }
                    else
                    {
                        originalString = $"-s{Decrypt(string_0[9])}:{Decrypt(string_0[2])} -b{"0.0.0.0"}:16878 -m{Decrypt(string_0[3])} -k{text}";
                    }

                    //if()
                    //string arguments = $"--mx " + text + " -u";
                    //string arguments = $"--mx " + text + " -u";
                    string arguments = $"{originalString} --no-delay --fast-open" + " --acl " + "data.db";
                    //string arguments = $"--mx " + text + " -u";
                    //string arguments = $"--mx " + text + " -u";
                    //string arguments = $"--mx " + text + " -u";  + " --acl " + "data.db"
                    this.Instance = new Process();
                    this.Instance.StartInfo.FileName = "MuXunProxy.exe";
                    this.Instance.StartInfo.CreateNoWindow = true;
                    this.Instance.StartInfo.UseShellExecute = false;
                    this.Instance.EnableRaisingEvents = true;
                    this.Instance.Exited += ProcessExited; // 注册进程退出事件处理程序
                    this.Instance.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    this.Instance.StartInfo.Arguments = arguments;

                    // 检查文件是否存在
                    //if (File.Exists("data.db"))
                    //{
                    //    // 读取文件内容
                    //    string fileContent = File.ReadAllText("data.db");

                    //    if (!string.IsNullOrWhiteSpace(fileContent)) // 判断文件内容是否为空或仅包含空白字符
                    //    {

                    //    }
                    //    else
                    //    {
                    //        return false;
                    //    }
                    //}
                    //else
                    //{
                    //    return false;
                    //}
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

                }
            //}
        }
        catch (Exception exception)
        {
            Log.Logger.Error(exception, MethodBase.GetCurrentMethod().Name);
            return false;
        }
        return true;
    }
    public async Task<bool> StartMains()
    {
        // CheckDrivers(); 在外面检查过了，不用测了
        //for (; ; )
        //{

        // 检查nf2驱动是否整好
        var result = RedirectorIn.nf_registerDriver("netfilter2");
        if (result == NF_STATUS.NF_STATUS_SUCCESS)
        {
            Console.WriteLine("netfilter2 驱动状态成功！");
            Console.WriteLine("NF2<====>OK");// 配置成功输出这个，让前端抓取
        }
        else
        {
            Console.WriteLine($"netfilter2  驱动状态失败,卸载...");
            UninstallDrivers();
        }


        // 启动外部模块,这个模块是从别人手里买的，直接启动调用就行
        // string_0 是从上面带进来的数组 
        Console.WriteLine("加速的进程:" + string_0[1]);

        this.Instance = new Process();
        this.Instance.StartInfo.FileName = "SpeedMains.exe";
        this.Instance.StartInfo.WorkingDirectory = "" + string_0[4];  // 该模块对工作目录敏感，需要带入工作目录
        this.Instance.StartInfo.CreateNoWindow = false;
        this.Instance.StartInfo.UseShellExecute = false;
        this.Instance.EnableRaisingEvents = true;
        this.Instance.Exited += ProcessExited; // 注册进程退出事件处理程序
        this.Instance.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        string dns = "1.1.1.1";  // 获取的dns值

        //string arguments = $"-u 127.0.0.1:16877 -t {Decrypt(string_0[9])}:{Decrypt(string_0[2])} -user {Decrypt(string_0[3])} -pass {Decrypt(string_0[10])} -p \"{string_0[5]}\" -dns \"{dns}\"";
        string arguments = $"-l 127.0.0.1:16780 -s {"127.0.0.1"}:{16780} -p \"{string_0[1]}\"";
        //string arguments = $"-l 127.0.0.1:16877 -s {"127.0.0.1"}:{16877} -p \"{string_0[1]}\" -dns \"{dns}\"";

        this.Instance.StartInfo.Arguments = arguments;
        this.Instance.Start();

        Console.WriteLine("启动的变量:" + arguments);

        //if (this.Instance == null || this.Instance.HasExited)
        //{
        //    break;
        //}




        if (this.Instance != null && !this.Instance.HasExited)
        {
            Console.WriteLine("Instance:111" );
        }
        else
        {
            Console.WriteLine("Instance:222");
            this.Instance.Start();
            // 在此等待进程退出
            Instance.WaitForExit();

        }

        Console.WriteLine("主程序全部运行完成，等待不退出");
        //实例化对象
        EventWaitHandle _waitHandle = new AutoResetEvent(false);
        //在线程函数中
        while(true)
        {
            _waitHandle.WaitOne();
            //事件发生后要做的任务
        }

        //for (int i = 0; i < 20; i++)
        //{
        //    await Task.Delay(300);
        //    try
        //    {
        //        _tunNetworkInterface = NetworkInterfaceUtils.Get(ni => ni.Name.StartsWith("MuXun"));
        //        break;
        //    }
        //    catch
        //    {
        //        // ignored
        //    }
        //}
        //if (_tunNetworkInterface == null)
        //{
        //    //  LogHelper.Error("Create unicast IP failed");
        //    throw new Exception("创建路由驱动失败");
        //}
        //else
        //{
        //    _tunNetworkInterface.SetDns("1.1.1.1");
        //}

        return false;
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




    public bool StartSk5()
    {
        //string HostName = ssr.HostName;
        //string Port = ssr.Port;
        //string Password = ssr.Password;
        //string Method = ssr.Method;
        //string Protocol = ssr.Protocol;
        //string ProtocolParam = ssr.ProtocolParam;
        //string Obfs = ssr.OBFS;
        //string OBFSParam = ssr.OBFSParam;

        //byte[] myport = Encoding.Default.GetBytes("16877");
        string L = $"socks5://:{"16877"}?udp=true";
        //string All = $"socks5+tls://{Decrypt(string_0[3]) + ":" + Decrypt(string_0[4]) + "@" + Decrypt(string_0[1]) + ":" + Decrypt(string_0[2])}";
        string All = $"socks5+tls://{Decrypt(string_0[3]) + ":" + Decrypt(string_0[10]) + "@" + Decrypt(string_0[9]) + ":" + Decrypt(string_0[2])}";
        byte[] MyAll = Encoding.Default.GetBytes(All);
        byte[] MyL = Encoding.Default.GetBytes(L);
        string arguments = $"-L {Convert.ToBase64String(MyL)} -F {Convert.ToBase64String(MyAll)}";

        this.Instance = new Process();
        this.Instance.StartInfo.FileName = "MxNetProxy.exe";
        this.Instance.StartInfo.CreateNoWindow = true;
        this.Instance.StartInfo.UseShellExecute = false;
        this.Instance.EnableRaisingEvents = true;
        this.Instance.Exited += ProcessExited; // 注册进程退出事件处理程序
        this.Instance.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

        this.Instance.StartInfo.Arguments = arguments;
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

        return true;
    }
    public bool StartSk5SS()
    {
        //string HostName = ssr.HostName;
        //string Port = ssr.Port;
        //string Password = ssr.Password;
        //string Method = ssr.Method;
        //string Protocol = ssr.Protocol;
        //string ProtocolParam = ssr.ProtocolParam;
        //string Obfs = ssr.OBFS;
        //string OBFSParam = ssr.OBFSParam;

        //byte[] myport = Encoding.Default.GetBytes("16877");
        string L = $"socks5://:{"16877"}?udp=true";
        //string All = $"socks5+tls://{Decrypt(string_0[3]) + ":" + Decrypt(string_0[4]) + "@" + Decrypt(string_0[1]) + ":" + Decrypt(string_0[2])}";
        string All = $"socks5+tls://{Decrypt(string_0[3]) + ":" + Decrypt(string_0[11]) + "@" + Decrypt(string_0[10]) + ":" + Decrypt(string_0[2])}";
        byte[] MyAll = Encoding.Default.GetBytes(All);
        byte[] MyL = Encoding.Default.GetBytes(L);
        string arguments = $"-L {Convert.ToBase64String(MyL)} -F {Convert.ToBase64String(MyAll)}";
        //if (!string.IsNullOrEmpty(Protocol))
        //{
        //arguments += $" -O {"origin"}";
        //if (!string.IsNullOrEmpty(ProtocolParam)) arguments += $" -G \"{ProtocolParam}\"";
        //}
        //if (!string.IsNullOrEmpty(Obfs))
        //{
        //arguments += $" -o {"plain"}";
        //if (!string.IsNullOrEmpty(OBFSParam)) arguments += $" -g \"{OBFSParam}\"";
        //}
        controller = new Process();
        controller.StartInfo.FileName = "MxNetProxy.exe";
        controller.StartInfo.Arguments = arguments.ToString();
        controller.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
        controller.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
        controller.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
        controller.StartInfo.CreateNoWindow = true;//不显示程序窗口

        controller.Start();
        return true;
    }
    public bool StartSSR()
    {
        //string HostName = ssr.HostName;
        //string Port = ssr.Port;
        //string Password = ssr.Password;
        //string Method = ssr.Method;
        //string Protocol = ssr.Protocol;
        //string ProtocolParam = ssr.ProtocolParam;
        //string Obfs = ssr.OBFS;
        //string OBFSParam = ssr.OBFSParam;
        byte[] mypwd = Encoding.Default.GetBytes(Decrypt(string_0[4]));
        byte[] myport = Encoding.Default.GetBytes("16877");
        byte[] myportss = Encoding.Default.GetBytes(Decrypt(string_0[7]));
        byte[] myme = Encoding.Default.GetBytes(Decrypt(string_0[8]));
        byte[] myhost = Encoding.Default.GetBytes(Decrypt(string_0[1]));
        string arguments = $"-s {Convert.ToBase64String(myhost)} -p {Convert.ToBase64String(myportss)} -k {Convert.ToBase64String(mypwd)} -m {Convert.ToBase64String(myme)} -b {"127.0.0.1"} -l {Convert.ToBase64String(myport)} ";
        //if (!string.IsNullOrEmpty(Protocol))
        //{
        //arguments += $" -O {"origin"}";
        //if (!string.IsNullOrEmpty(ProtocolParam)) arguments += $" -G \"{ProtocolParam}\"";
        //}
        //if (!string.IsNullOrEmpty(Obfs))
        //{
        //arguments += $" -o {"plain"}";
        //if (!string.IsNullOrEmpty(OBFSParam)) arguments += $" -g \"{OBFSParam}\"";
        //}

        this.Instance = new Process();
        this.Instance.StartInfo.FileName = "MXProxy.exe";
        this.Instance.StartInfo.CreateNoWindow = true;
        this.Instance.StartInfo.UseShellExecute = false;
        this.Instance.EnableRaisingEvents = true;
        this.Instance.Exited += ProcessExited; // 注册进程退出事件处理程序
        this.Instance.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

        this.Instance.StartInfo.Arguments = arguments;
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
        return true;
    }

    private class ShadowsocksDLL
    {
        [DllImport("MXProxy", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Info(byte[] client, byte[] remote, byte[] passwd, byte[] method);

        [DllImport("MXProxy", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Start();

        [DllImport("MXProxy", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Stop();
    }

    #region CheckRule

    /// <summary>
    /// </summary>
    /// <param name="rules"></param>
    /// <param name="results"></param>
    /// <returns>No Problem true</returns>
    private static bool CheckRule(IEnumerable<string> rules, out IEnumerable<string> results)
    {
        results = rules.Where(r => !CheckCppRegex(r, false));
        _ = Redirector.Dial(Redirector.NameList.AIO_CLRNAME, "");
        return !results.Any<string>();
    }

    /// <summary>
    /// </summary>
    /// <param name="r"></param>
    /// <param name="clear"></param>
    /// <returns>No Problem true</returns>

    private static bool CheckCppRegex(string r, bool clear = true)
    {
        bool result;
        try
        {
            result = r.StartsWith("!") ? Redirector.Dial(Redirector.NameList.AIO_ADDNAME, r.Substring(1)) : Redirector.Dial(Redirector.NameList.AIO_ADDNAME, r);
        }
        finally
        {
            if (clear)
            {
                _ = Redirector.Dial(Redirector.NameList.AIO_CLRNAME, "");
            }
        }
        return result;
    }

    private static string GenerateInvalidRulesMessage(IEnumerable<string> rules)
    {
        return string.Join("\n", rules) + "\nAbove rules does not conform to C++ regular expression syntax";
    }
    #endregion

    #region DriverUtil
    internal static void CheckDrivers()
    {
        string fileVersion = Utils.Utils.GetFileVersion(BinDriver);
        string fileVersion2 = Utils.Utils.GetFileVersion(SystemDriver);

        Console.WriteLine("检查 netfilter2 驱动 客户端:" + fileVersion + "用户:" + fileVersion2);

        if (!File.Exists(SystemDriver))
        {
            Console.WriteLine("未找到 netfilter2 重新安装");
            InstallDrivers();
            return;
        }
        bool flag = false;
        if (!Version.TryParse(fileVersion, out Version version) || !Version.TryParse(fileVersion2, out Version version2))
        {
            if (!fileVersion2.Equals(fileVersion))
                flag = true;
        }
        else if (version.CompareTo(version2) > 0)
            flag = true;
        else if (version2.Major != version.Major)
            flag = true;

        if (!flag)
        {
            if (!File.Exists(BinNFCApi))
            {
                // _ = MessageBox.Show("加速失败,缺少内置驱动程序文件,请联系管理员:QQ702533698!");
                //LogHelper.Error("加速失败,缺少内置驱动程序文件,请联系管理员:QQ702533698!");
            }
            return;
        }

        _ = UninstallDrivers();
        InstallDrivers();
    }
    /// <summary>
    ///     安装 NF 驱动
    /// </summary>
    /// <returns>驱动是否安装成功</returns>
    private static void InstallDrivers()
    {
        Console.WriteLine("操作安装 netfilter2");
        try
        {
            File.Copy(BinDriver, SystemDriver);
        }
        catch (Exception ex)
        {
            // 文件拷贝失败报错
            Console.WriteLine("Copy NF driver file failed\n" + ex.Message);
        }

        // 启动nf2
        var result = RedirectorIn.nf_registerDriver("netfilter2");
        if (result == NF_STATUS.NF_STATUS_SUCCESS)
        {
            Console.WriteLine("NF_STATUS" + result); // nf2启动成功
        }
        else
        {
            Console.WriteLine($"Register NF driver failed\n{result}"); // nf2启动失败
        }
    }
    /// <summary>
    ///     卸载 NF 驱动
    /// </summary>
    /// <returns>是否成功卸载</returns>
    private static bool UninstallDrivers()
    {
        try
        {
            if (NFService.Status == ServiceControllerStatus.Running)
            {
                NFService.Stop();
                NFService.WaitForStatus(ServiceControllerStatus.Stopped);
            }
        }
        catch (Exception)
        {
        }
        if (!File.Exists(SystemDriver))
        {
            return true;
        }

        _ = RedirectorIn.nf_unRegisterDriver("netfilter2");
        File.Delete(SystemDriver);

        return true;
    }
    #endregion

    #region DriverUtil
    private static void CheckDriver()
    {
        string fileVersion = Utils.Utils.GetFileVersion(BinDriver);
        string fileVersion2 = Utils.Utils.GetFileVersion(SystemDriver);
        if (!File.Exists(SystemDriver))
        {
            InstallDriver();
            return;
        }
        bool flag = false;
        if (!Version.TryParse(fileVersion, out Version version) || !Version.TryParse(fileVersion2, out Version version2))
        {
            if (!fileVersion2.Equals(fileVersion))
            {
                flag = true;
            }
        }
        else if (version.CompareTo(version2) > 0)
        {
            flag = true;
        }
        else if (version2.Major != version.Major)
        {
            flag = true;
        }

        if (!flag)
        {
            if (!File.Exists(BinNFCApi))
            {
                //_ = MessageBox.Show("加速失败,缺少内置驱动程序文件,请联系管理员:QQ702533698!");
                //LogHelper.Error("加速失败,缺少内置驱动程序文件,请联系管理员:QQ702533698!");
            }
            return;
        }

        _ = UninstallDriver();
        InstallDriver();
    }
    /// <summary>
    ///     安装 NF 驱动
    /// </summary>
    /// <returns>驱动是否安装成功</returns>
    private static void InstallDriver()
    {
        if (!File.Exists(BinDriver))
        {
            //_ = new MessageWindow("加速失败,缺少内置驱动程序文件,请联系管理员:QQ702533698!").ShowDialog();
            //LogHelper.Error("加速失败,缺少内置驱动程序文件,请联系管理员:QQ702533698!");
        }
        try
        {
            File.Copy(BinDriver, SystemDriver);
        }
        catch (Exception ex)
        {
            // _ = new MessageWindow("Copy NF driver file failed\n" + ex.Message).ShowDialog();
        }


        if (Redirector.aio_register("netfilter2"))
        {
        }
        else
        {
            //_ = MessageBox.Show("加速失败,请联系管理员:QQ702533698!");
            //LogHelper.Error("加速失败,请联系管理员:QQ702533698!");
        }
    }
    /// <summary>
    ///     卸载 NF 驱动
    /// </summary>
    /// <returns>是否成功卸载</returns>
    internal static bool UninstallDriver()
    {
        try
        {
            if (NFService.Status == ServiceControllerStatus.Running)
            {
                NFService.Stop();
                NFService.WaitForStatus(ServiceControllerStatus.Stopped);
            }
        }
        catch (Exception)
        {
        }
        if (!File.Exists(SystemDriver))
        {
            return true;
        }

        _ = Redirector.aio_unregister("netfilter2");
        File.Delete(SystemDriver);

        return true;
    }
    #endregion


    public static string Decrypt(string original, string key)
    {
        return Decrypt(original, key, Encoding.Default);
    }

    public static string Decrypt(string original)
    {
        return Decrypt(original, string.Empty, Encoding.Default);
    }
    public static string Decrypt(string encrypted, string key, Encoding encoding)
    {
        if (encrypted != null && !(encrypted == string.Empty))
        {
            try
            {
                byte[] encrypted2 = Convert.FromBase64String(encrypted);
                byte[] bytes = Encoding.Default.GetBytes(key + "Z10S6V547QRYZHAO6WE4DUZCYMZCYN53YQ5QAJ9S0QV2MUXUNZ");
                return encoding.GetString(Decrypt(encrypted2, bytes));
            }
            catch
            {
                return string.Empty;
            }
        }
        return string.Empty;
    }

    public static byte[] Decrypt(byte[] encrypted, byte[] key)
    {
        return new TripleDESCryptoServiceProvider
        {
            Key = MakeMD5(key),
            Mode = CipherMode.ECB
        }.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
    }

    public static byte[] MakeMD5(byte[] original)
    {
        MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
        return md5CryptoServiceProvider.ComputeHash(original);
    }
    internal static string Encrypt(string original)
    {
        if (original == null || original == string.Empty)
        {
            return string.Empty;
        }
        else
        {
            byte[] buff = Encoding.Default.GetBytes(original);
            byte[] kb = Encoding.Default.GetBytes("W10S6V547QRYZHAO6WE4DUZCYMZCYN53YQ5QAJ9S0QSFAGHNZ");
            return Convert.ToBase64String(Encrypt(buff, kb));
        }
    }
    internal static byte[] Encrypt(byte[] original, byte[] key)
    {
        return new TripleDESCryptoServiceProvider
        {
            Key = MakeMD5(key),
            Mode = CipherMode.ECB
        }.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
    }
    private void StopTime()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(Encrypt(Guid.NewGuid().ToString()));
        }
    }



    #region Utils
    private static void CheckDriverm()
    {
        var binFileVersion = Utils.Utils.GetFileVersion(BinDriver);
        var systemFileVersion = Utils.Utils.GetFileVersion(SystemDriver);


        if (!File.Exists(SystemDriver))
        {
            InstallDriverm();
            return;
        }

        var reinstallFlag = false;
        if (Version.TryParse(binFileVersion, out var binResult) && Version.TryParse(systemFileVersion, out var systemResult))
        {
            if (binResult.CompareTo(systemResult) > 0)
                // Bin greater than Installed
                reinstallFlag = true;
            else if (systemResult.Major != binResult.Major)
                // Installed greater than Bin but Major Version Difference (has breaking changes), do downgrade
                reinstallFlag = true;
        }
        else
        {
            if (!systemFileVersion.Equals(binFileVersion))
                reinstallFlag = true;
        }

        if (!reinstallFlag)
            return;

        UninstallDriverm();
        InstallDriverm();
    }

    /// <summary>
    ///     安装 NF 驱动
    /// </summary>
    /// <returns>驱动是否安装成功</returns>
    public static void InstallDriverm()
    {

        if (!File.Exists(BinDriver))
            throw new MessageException("builtin driver files missing, can't install NF driver");

        try
        {
            File.Copy(BinDriver, SystemDriver);
        }
        catch (Exception e)
        {
            throw new MessageException($"Copy NF driver file failed\n{e.Message}");
        }

        // 注册驱动文件
        var result = NFAPI.nf_registerDriver("netfilter2");
        if (result == nfapinet.NF_STATUS.NF_STATUS_SUCCESS)
        {

        }
        else
        {
            throw new MessageException($"Register NF driver failed\n{result}");
        }
    }

    /// <summary>
    ///     卸载 NF 驱动
    /// </summary>
    /// <returns>是否成功卸载</returns>
    public static bool UninstallDriverm()
    {
        try
        {
            if (NFService.Status == ServiceControllerStatus.Running)
            {
                NFService.Stop();
                NFService.WaitForStatus(ServiceControllerStatus.Stopped);
            }
        }
        catch (Exception)
        {
            // ignored
        }

        if (!File.Exists(SystemDriver))
            return true;

        NFAPI.nf_unRegisterDriver("netfilter2");
        File.Delete(SystemDriver);

        return true;
    }

    #endregion



    public bool IsUpdateDir()
    {
        string localDirPath = this.GetLocalDirPath();
        if (!File.Exists(localDirPath))
        {
            Log.Logger.Error("not found dir");
            return false;
        }
        return !this.IsValidFileContent(this.SystemDirPath, localDirPath);
    }

    public NetFilterStatus SetupDirver()
    {
        if (this.IsUpdateDir())
        {
            if (!File.Exists(this.regDirExe))
            {
                Log.Logger.Error(this.regDirExe + " not found");
                return NetFilterStatus.FileMissing;
            }
            if (File.Exists(this.SystemDirPath))
            {
                this.UnInstallDir();
            }
            string text = this.InstallDir();
            if (text == "-1")
            {
                if (this.breakerCounter < 2)
                {
                    Thread.Sleep(2000);
                    this.breakerCounter++;
                    return this.SetupDirver();
                }
                return NetFilterStatus.NetFilterConflict;
            }
            else if (text.IndexOf("577") > 0)
            {
                return NetFilterStatus.CertificateError;
            }
        }
        if (this.ExcuteCmd("/c sc query netfilter2", "cmd.exe", "").msg.ToLower().IndexOf("1060") > 0)
        {
            this.InstallDir();
        }
        if (this.ExcuteCmd("/c sc query netfilter2", "cmd.exe", "").msg.ToLower().IndexOf("running") != -1)
        {
            Log.Logger.Information("wfp server is run");
            return NetFilterStatus.OK;
        }
        if (File.Exists(this.SystemDirPath))
        {
            CmdCalBack cmdCalBack = this.ExcuteCmd("/c net start netfilter2", "cmd.exe", "");
            Log.Logger.Information("start nf -> " + cmdCalBack.msg.Replace("\r\n", ""));
            if (cmdCalBack.msg.IndexOf("577") > 0)
            {
                return NetFilterStatus.CertificateError;
            }
            NetFilterStatus result;
            if (cmdCalBack.msg.IndexOf("2") > 0)
            {
                if (this.breakerCounter < 2)
                {
                    try
                    {
                        using (RegistryKey registryKey = RegistryKeyHelper.OpenKey("SYSTEM\\CurrentControlSet\\Services\\netfilter2", RegistryHive.LocalMachine))
                        {
                            if (registryKey != null)
                            {
                                object value = registryKey.GetValue("ImagePath");
                                if (value != null && Path.GetFileName(value.ToString()) != "netfilter2.sys")
                                {
                                    ILogger logger = Log.Logger;
                                    DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
                                    defaultInterpolatedStringHandler.AppendLiteral("wfp reg image path ->");
                                    defaultInterpolatedStringHandler.AppendFormatted<object>(value);
                                    logger.Warning(defaultInterpolatedStringHandler.ToStringAndClear());
                                    RegistryKey registryKey2 = RegistryKeyHelper.OpenKey("SYSTEM\\CurrentControlSet\\Services\\", RegistryHive.LocalMachine);
                                    registryKey2.DeleteSubKeyTree("netfilter2");
                                    registryKey2.Close();
                                    return this.SetupDirver();
                                }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        Log.Logger.Error(exception, "clear netfilter2 reg");
                    }
                    this.UnInstallDir();
                    this.breakerCounter++;
                    return this.SetupDirver();
                }
                return NetFilterStatus.NotFoundNetfilter;
            }
            else
            {
                if (cmdCalBack.msg.IndexOf("3") > 0)
                {
                    ILogger logger2 = Log.Logger;
                    DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
                    defaultInterpolatedStringHandler.AppendLiteral("wfp dirver exists->");
                    defaultInterpolatedStringHandler.AppendFormatted<bool>(File.Exists(this.SystemDirPath));
                    logger2.Information(defaultInterpolatedStringHandler.ToStringAndClear());
                    return NetFilterStatus.SystemErrNotFoundPath;
                }
                if (cmdCalBack.msg.IndexOf("net") <= 0)
                {
                    return NetFilterStatus.Err;
                }
                try
                {
                    ServiceController serviceController = new ServiceController("netfilter2");
                    if (serviceController.Status != ServiceControllerStatus.Running)
                    {
                        serviceController.Start();
                    }
                    result = NetFilterStatus.OK;
                }
                catch (Exception exception2)
                {
                    Log.Logger.Error(exception2, "start acc service err");
                    return NetFilterStatus.Err;
                }
            }
            return result;
        }
        return NetFilterStatus.Err;
    }
    public class CmdCalBack
    {
     
        public string code { get; private set; }

       
        public string msg { get; private set; }

        public CmdCalBack(string _code, string _msg)
        {
            this.code = _code;
            this.msg = _msg;
        }
    }
    public string InstallDir()
    {
        string value = this.GetLocalDirPath() ?? "";
        DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 2);
        defaultInterpolatedStringHandler.AppendLiteral("/c copy \"");
        defaultInterpolatedStringHandler.AppendFormatted(value);
        defaultInterpolatedStringHandler.AppendLiteral("\" \"");
        defaultInterpolatedStringHandler.AppendFormatted(this.SystemDirPath);
        defaultInterpolatedStringHandler.AppendLiteral("\"");
        CmdCalBack cmdCalBack = this.ExcuteCmd(defaultInterpolatedStringHandler.ToStringAndClear(), "cmd.exe", "");
        Log.Logger.Information("copy " + cmdCalBack.msg.Replace("\r\n", ""));
        CmdCalBack cmdCalBack2 = this.ExcuteCmd("netfilter2", this.regDirExe, Directory.GetCurrentDirectory());
        if (!string.IsNullOrWhiteSpace(cmdCalBack2.code))
        {
            Log.Logger.Information("install dirver code -> " + cmdCalBack2.code.Replace("\r\n", ""));
        }
        return cmdCalBack2.code;
    }

    public void UnInstallDir()
    {
        CmdCalBack cmdCalBack = this.ExcuteCmd("/c sc stop netfilter2", "cmd.exe", "");
        Log.Logger.Information("stop server" + cmdCalBack.msg);
        if (this.ExcuteCmd("/c sc stop netfilter2", "cmd.exe", "").msg.ToLower().IndexOf("1061") > 0 && this.filedelbreakerCounter < 2)
        {
            Thread.Sleep(3000);
            this.filedelbreakerCounter++;
            this.UnInstallDir();
            return;
        }
        CmdCalBack cmdCalBack2 = this.ExcuteCmd("-u netfilter2", this.regDirExe, Directory.GetCurrentDirectory());
        if (cmdCalBack2.code != "0")
        {
            Log.Logger.Information("uninstall dirver code-> " + cmdCalBack2.code + " msg -> " + cmdCalBack2.msg.Replace("\r\n", ""));
        }
        if (this.ExcuteCmd("/c sc query netfilter2", "cmd.exe", "").msg.ToLower().IndexOf("1060") < 0)
        {
            this.ExcuteCmd("/c sc delete netfilter2", "cmd.exe", "");
        }
        CmdCalBack cmdCalBack3 = this.ExcuteCmd("/c del " + this.SystemDirPath, "cmd.exe", "");
        if (!string.IsNullOrWhiteSpace(cmdCalBack3.msg))
        {
            Log.Logger.Information("del " + cmdCalBack3.msg);
        }
    }

    private CmdCalBack ExcuteCmd(string cmd, string runexe = "cmd.exe", string workdir = "")
    {
        Process process = new Process();
        if (!string.IsNullOrWhiteSpace(workdir))
        {
            process.StartInfo.WorkingDirectory = workdir;
        }
        process.StartInfo.FileName = runexe;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardInput = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.Arguments = cmd;
        process.Start();
        process.WaitForExit();
        return new CmdCalBack(process.ExitCode.ToString(), process.StandardOutput.ReadToEnd() + process.StandardError.ReadToEnd());
    }
  
    public static string GetOSVersionAndCaptionCmd()
    {
        Process process = new Process();
        try
        {
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c ver";
            process.Start();
            string input = string.Empty;
            process.WaitForExit(2000);
            input = process.StandardOutput.ReadLine();
            Regex regex = new Regex("\\d+(\\.\\d+)*", RegexOptions.IgnoreCase);
            return regex.Match(input).Value;
        }
        catch (Exception exception)
        {
            Log.Error(exception, MethodBase.GetCurrentMethod().Name);
        }
        return "";
    }
    public static string GetOSVersionAndCaption()
    {
        string result;
        try
        {
            result = Environment.OSVersion.Version.ToString();
        }
        catch (Exception exception)
        {
            Log.Error(exception, MethodBase.GetCurrentMethod().Name);
            result = GetOSVersionAndCaptionCmd();
        }
        return result;
    }
    private string GetLocalDirPath()
    {
        string value = (smethod_1() ? "amd64" : "i386");
        string text = GetOSVersionAndCaption();
        Log.Logger.Information("current windows ver->" + text);
        if (string.IsNullOrEmpty(text))
        {
            text = "10.0";
            Log.Warning("verinfo is null");
        }
        string[] array = ((text != null) ? text.Split('.', StringSplitOptions.None) : null);
        string text2 = array[0] + "." + array[1];
        DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
        if (text2 == "10.0")
        {
            defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 3);
            defaultInterpolatedStringHandler.AppendFormatted(this.dirverPath);
            defaultInterpolatedStringHandler.AppendLiteral("win10\\");
            defaultInterpolatedStringHandler.AppendFormatted(value);
            defaultInterpolatedStringHandler.AppendLiteral("\\");
            defaultInterpolatedStringHandler.AppendFormatted("opwfp.sys");
            return defaultInterpolatedStringHandler.ToStringAndClear();
        }
        if (text2 == "6.3")
        {
            defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 3);
            defaultInterpolatedStringHandler.AppendFormatted(this.dirverPath);
            defaultInterpolatedStringHandler.AppendLiteral("win7\\");
            defaultInterpolatedStringHandler.AppendFormatted(value);
            defaultInterpolatedStringHandler.AppendLiteral("\\");
            defaultInterpolatedStringHandler.AppendFormatted("opwfp.sys");
            return defaultInterpolatedStringHandler.ToStringAndClear();
        }
        if (text2 == "6.2")
        {
            defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 3);
            defaultInterpolatedStringHandler.AppendFormatted(this.dirverPath);
            defaultInterpolatedStringHandler.AppendLiteral("win7\\");
            defaultInterpolatedStringHandler.AppendFormatted(value);
            defaultInterpolatedStringHandler.AppendLiteral("\\");
            defaultInterpolatedStringHandler.AppendFormatted("opwfp.sys");
            return defaultInterpolatedStringHandler.ToStringAndClear();
        }
        if (text2 == "6.1")
        {
            defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 3);
            defaultInterpolatedStringHandler.AppendFormatted(this.dirverPath);
            defaultInterpolatedStringHandler.AppendLiteral("win7\\");
            defaultInterpolatedStringHandler.AppendFormatted(value);
            defaultInterpolatedStringHandler.AppendLiteral("\\");
            defaultInterpolatedStringHandler.AppendFormatted("opwfp.sys");
            return defaultInterpolatedStringHandler.ToStringAndClear();
        }
        if (!(text2 == "6.0"))
        {
            Log.Warning("this system version is not supported osver:" + text2);
            defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 3);
            defaultInterpolatedStringHandler.AppendFormatted(this.dirverPath);
            defaultInterpolatedStringHandler.AppendLiteral("Win10\\");
            defaultInterpolatedStringHandler.AppendFormatted(value);
            defaultInterpolatedStringHandler.AppendLiteral("\\");
            defaultInterpolatedStringHandler.AppendFormatted("opwfp.sys");
            return defaultInterpolatedStringHandler.ToStringAndClear();
        }
        defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 3);
        defaultInterpolatedStringHandler.AppendFormatted(this.dirverPath);
        defaultInterpolatedStringHandler.AppendLiteral("win7\\");
        defaultInterpolatedStringHandler.AppendFormatted(value);
        defaultInterpolatedStringHandler.AppendLiteral("\\");
        defaultInterpolatedStringHandler.AppendFormatted("opwfp.sys");
        return defaultInterpolatedStringHandler.ToStringAndClear();
    }


    public bool IsValidFileContent(string local, string remote)
    {
        if (!File.Exists(local))
        {
            Log.Warning("local driver not found");
        }
        if (!File.Exists(remote))
        {
            Log.Warning("client driver not found");
            return false;
        }
        string text = MD5File(local);
        string text2 = MD5File(remote);
        Log.Information("driver md5 local " + text);
        Log.Information("driver md5 client " + text2 + " file " + remote);
        return text.Equals(text2);
    }
    public static string MD5File(string fileName)
    {
        return HashFile(fileName, "md5");
    }

    public static string SHA1File(string fileName)
    {
        return HashFile(fileName, "sha1");
    }
    private static string HashFile(string fileName, string algName)
    {
        if (!File.Exists(fileName))
        {
            return string.Empty;
        }
        FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        byte[] buf = HashData(fileStream, algName);
        fileStream.Close();
        return ByteArrayToHexString(buf);
    }
    private static byte[] HashData(Stream stream, string algName)
    {
        if (algName == null)
        {
            throw new ArgumentNullException("algName 不能为 null");
        }
        HashAlgorithm hashAlgorithm;
        if (string.Compare(algName, "sha1", true) == 0)
        {
            hashAlgorithm = SHA1.Create();
        }
        else
        {
            if (string.Compare(algName, "md5", true) != 0)
            {
                throw new Exception("algName 只能使用 sha1 或 md5");
            }
            hashAlgorithm = MD5.Create();
        }
        return hashAlgorithm.ComputeHash(stream);
    }

    private static string ByteArrayToHexString(byte[] buf)
    {
        return BitConverter.ToString(buf).Replace("-", "");
    }

public class RegistryKeyHelper
    {
        
        public static RegistryKey CreatKey(string path, RegistryHive registry)
        {
            RegistryKey result;
            try
            {
                RegistryKey registryKey = RegistryKey.OpenBaseKey(registry, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                RegistryKey registryKey2 = registryKey.CreateSubKey(path, true);
                result = registryKey2;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, ex.TargetSite.Name);
                result = null;
            }
            return result;
        }

        
        public static RegistryKey OpenKey(string path, RegistryHive registry)
        {
            RegistryKey result;
            try
            {
                RegistryKey registryKey = RegistryKey.OpenBaseKey(registry, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                RegistryKey registryKey2 = registryKey.OpenSubKey(path, true);
                result = registryKey2;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, ex.TargetSite.Name);
                result = null;
            }
            return result;





            //if (accStartStatus.Status != null)
            //{
            //    if (accStartStatus.Status.GetType() == typeof(NetFilterStatus))
            //    {
            //        switch ((NetFilterStatus)accStartStatus.Status)
            //        {
            //            case NetFilterStatus.CertificateError:
            //                appErrInfo = new AppErrInfo
            //                {
            //                    ErrType = AppErrType.CertificateError,
            //                    ErrMsg = "驱动证书无法识别 win7请安装 kb3033929 系统补丁."
            //                };
            //                this.SendMsg(new AccelerateEventArgs(this.CurrentAccGame, this.CurrentNodeInfo, appErrInfo.ErrMsg, this.GameAccStatus, 0));
            //                break;
            //            case NetFilterStatus.NotFoundNetfilter:
            //                appErrInfo = new AppErrInfo
            //                {
            //                    ErrType = AppErrType.NotFoundNetfilter,
            //                    ErrMsg = "加速服务启动失败,请(重启)电脑并关闭杀毒软件或系统防火墙."
            //                };
            //                this.SendMsg(new AccelerateEventArgs(this.CurrentAccGame, this.CurrentNodeInfo, appErrInfo.ErrMsg, this.GameAccStatus, 0));
            //                break;
            //            case NetFilterStatus.FileMissing:
            //                appErrInfo = new AppErrInfo
            //                {
            //                    ErrType = AppErrType.FileMissing,
            //                    ErrMsg = "加速文件丢失请重新安装客户端."
            //                };
            //                this.SendMsg(new AccelerateEventArgs(this.CurrentAccGame, this.CurrentNodeInfo, appErrInfo.ErrMsg, this.GameAccStatus, 0));
            //                break;
            //            case NetFilterStatus.SystemErrNotFoundPath:
            //                appErrInfo = new AppErrInfo
            //                {
            //                    ErrType = AppErrType.SystemErrNotFoundPath,
            //                    ErrMsg = "系统找不到加速服务路径启动失败,请(重启)电脑并关闭杀毒软件或系统防火墙."
            //                };
            //                this.SendMsg(new AccelerateEventArgs(this.CurrentAccGame, this.CurrentNodeInfo, appErrInfo.ErrMsg, this.GameAccStatus, 0));
            //                break;
            //            case NetFilterStatus.NetFilterConflict:
            //                appErrInfo = new AppErrInfo
            //                {
            //                    ErrType = AppErrType.NetFilterConflict,
            //                    ErrMsg = "检测到其它加速服务正在运行，请停止其它加速工具后重试."
            //                };
            //                this.SendMsg(new AccelerateEventArgs(this.CurrentAccGame, this.CurrentNodeInfo, appErrInfo.ErrMsg, this.GameAccStatus, 0));
            //                break;
            //            case NetFilterStatus.const_7:
            //                appErrInfo = new AppErrInfo
            //                {
            //                    ErrType = AppErrType.NetFilterLenovoConflict,
            //                    ErrMsg = "检测到联想smart服务占用加速服务，请停止后重试."
            //                };
            //                this.SendMsg(new AccelerateEventArgs(this.CurrentAccGame, this.CurrentNodeInfo, appErrInfo.ErrMsg, this.GameAccStatus, 0));
            //                break;
            //            default:
            //                appErrInfo = new AppErrInfo
            //                {
            //                    ErrType = AppErrType.Unknown,
            //                    ErrMsg = "未知异常"
            //                };
            //                this.SendMsg(new AccelerateEventArgs(this.CurrentAccGame, this.CurrentNodeInfo, "加速失败,请查看日志.", this.GameAccStatus, 0));
            //                break;
            //        }
            //    }
            //}
            //else
            //{
            //    appErrInfo = new AppErrInfo
            //    {
            //        ErrType = AppErrType.Unknown,
            //        ErrMsg = "未知异常"
            //    };
            //    this.SendMsg(new AccelerateEventArgs(this.CurrentAccGame, this.CurrentNodeInfo, "加速失败,请查看日志.", this.GameAccStatus, 0));
            //}
        }




    }

}