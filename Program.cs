using System.Globalization;
using System.Reflection;
using System.Runtime.Versioning;
using Windows.Win32;
using Windows.Win32.Foundation;
//using Microsoft.VisualStudio.Threading;
using MuXunProxy.Controllers;
using MuXunProxy.Utils;
using Serilog.Events;
//using SingleInstance;
using System.Diagnostics;
using System.Security.Principal;
using System.Runtime.InteropServices;
using static MuXunProxy.Utils.Utils;
using WindowsFirewallHelper;
using log4net;
#if RELEASE
using Windows.Win32.UI.WindowsAndMessaging;
#endif

namespace MuXunProxy;

public static class Program
{
    /// <summary>
    /// 应用程序的主入口点。
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
        Console.WriteLine("Start SpeedProxy"); // 用中文写log就可以，反正用户也看不懂，用啥写都不会看
        //Firewall.RemoveRule();
        Task.WhenAll(Task.Run(Utils.Utils.NativeMethods.RefreshDNSCache), Task.Run(Firewall.AddRule));
        //判断当前登录用户是否为管理员
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new(identity);
        if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
        {
            //创建启动对象
            ProcessStartInfo startInfo = new()
            {
                UseShellExecute = true,
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = Assembly.GetExecutingAssembly().Location,
                //设置启动动作,确保以管理员身份运行
                Verb = "runas"
            };
            try
            {
                _ = Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                // LogHelper.Error(ex.Message);
                //    _ = MessageBox.Show("fuck", "程序无法获取Windows管理员身份 \n请手动使用Windows管理员身份运行!");
                Console.WriteLine("程序无法获取Windows管理员身份 请手动使用Windows管理员身份运行!" + ex.Message);
                return;
            }
            //退出
            System.Environment.Exit(0);
        }


        // 杀死相关进程，预防上次没关干净
        System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("SpeedMains");
        foreach (System.Diagnostics.Process p in process)
        {
            p.Kill();
        }
        System.Diagnostics.Process[] process2 = System.Diagnostics.Process.GetProcessesByName("SpeedFox.tun2socks");
        foreach (System.Diagnostics.Process p in process2)
        {
            p.Kill();
        }


        //Firewall.AddRule();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        // Firewall.AddNetchFwRules();
        //string pathtwo = FileUtil.accelerator_Path32in;
        //string Default_Path32 = @"C:\Program Files\Zcy7\accelerator\wfp\";
        string pathtwo = $@"{Environment.CurrentDirectory}";
        //设置当前目录
        Directory.SetCurrentDirectory(Application.StartupPath);
        var binPath = Path.Combine(pathtwo, "x64");
        Environment.SetEnvironmentVariable("PATH", $"{Environment.GetEnvironmentVariable("PATH")};{binPath}");

        Console.WriteLine("工作位置" + pathtwo);


        Console.WriteLine("读取启动配置");
        // 读取配置,因为路由表和进程有的游戏很多,直接传进来太多了,直接顶了,如果没有直接报错就好了,反正是用户乱搞的
        string SpeedProxy_config = File.ReadAllText("SpeedProxy.config.tmp");
        Console.WriteLine("启动配置:" + SpeedProxy_config);


        if (!string.IsNullOrEmpty(SpeedProxy_config))
        {
            // 用 @ 分割，组装成数组

            // 数组定义
            // 0:模式   进程模式0    路由模式1
            // 1:进程或路由
            // 2:dns
            // 3:排除服务器IP (路由模式如果吧服务器代理上了会无限死循环,进程模式没有带上也行，不带的话也必须有这个数组)
            // 4:工作目录



            string[] array = SpeedProxy_config.Split(new char[] { '@' });
            
            // 进程模式 取数组0
            if (array[0] is "0")
            {
                NFController nfcontroller = new NFController(array);

                // 安装修补 nf2 驱动
                NFController.CheckDrivers();

                // 启动加速进程 这个有点特殊，在c#环境无法直接运行

                nfcontroller.StartMains();
                return;
            }

            // 路由模式 取数组0
            if (array[0] is "1")
            {
                TUNController TUNController = new TUNController(array);

                // 安装修补 wintun.dll
                TUNController.CheckDrivers();

                // 启动路由加速
                TUNController.StartAsync();

                return;
            }





            // 下面的判断方式是陈年老屎，直接无视

            //NFController.CheckDrivers();
            //PrivoxyController privoxyontroller = new PrivoxyController();
            //privoxyontroller.Start();
            if (array[6] is "ss" or "sk5")
            {
                NFController nfcontroller = new NFController(array);
                nfcontroller.StartWai();
                //nfcontroller.StartRust();
                //nfcontroller.StartRusts();
                //nfcontroller.StartWais();
                nfcontroller.StartMains/*Jiu*/();
                //nfcontroller.StartSSRE/*Jiu*/();
                //nfcontroller.StartSyS();
            }
            else if (array[6] is "sk5exe")
            {
                NFController nfcontroller = new NFController(array);
                nfcontroller.StartSk5();
                //nfcontroller.StartSSRE();
                nfcontroller.StartMains/*Jiu*/();
            }
            else if (array[6] is "ssdll")
            {
                NFController nfcontroller = new NFController(array);
                nfcontroller.StartDLL();
                //nfcontroller.StartSSRE();
                nfcontroller.StartMains/*Jiu*/();
            }
            else if (array[6] is "ssr")
            {
                NFController nfcontroller = new NFController(array);
                nfcontroller.StartWai();
                //nfcontroller.StartSSRE();
                nfcontroller.StartMains/*Jiu*/();
            }
            else if (array[6] == "1")
            {
                //TUNController TUNController = new TUNController(array);
                //_ = TUNController.StartAsync();
                TUNController TUNController = new TUNController(array);
                NFController nfcontroller = new NFController(array);
                nfcontroller.StartWai();
                //nfcontroller.StartDLLSS();
                _ = TUNController.StartAsync();
                //nfcontroller.StartSyS();
            }
            else if (array[6] is "ssrtun")
            {
                TUNController TUNController = new TUNController(array);
                NFController nfcontroller = new NFController(array);
                nfcontroller.StartSk5();
                //nfcontroller.StartDLL();
                _ = TUNController.StartAsync();
            }
            else if (array[9] == "ss/tun")
            {
                TUNController TUNController = new TUNController(array);
                NFController nfcontroller = new NFController(array);
                nfcontroller.StartWai();
                _ = TUNController.StartAsync();
                nfcontroller.StartMains/*Jiu*/();
                //nfcontroller.StartSSRE/*Jiu*/();
                //nfcontroller.StartSyS();
            }
            //else if (array[9] == "ss/tun")
            //{
            //    TUNController TUNController = new TUNController(array);
            //    NFController nfcontroller = new NFController(array);
            //    _ = TUNController.Tun2Exe();
            //    nfcontroller.Start();
            //}
            //else if (array[6] == "ssr/tun")
            //{
            //    TUNController TUNController = new TUNController(array);
            //    NFController nfcontroller = new NFController(array);
            //    //nfcontroller.StartSSR();
            //    //nfcontroller.Start();
            //    _ = TUNController.Tun2Exe();
            //}
            else
            {
                return;
            }
            Utils.Utils.ClearMemory();
            Console.ReadKey();

        }

    }
    private static void ClearEnv()
    {
        CommandHelper.Windows(string.Empty, new string[] {
                $"setx http_proxy \"\" -m",
                $"setx https_proxy \"\" -m",
            });
    }
}