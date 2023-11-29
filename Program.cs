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
                //    _ = MessageBox.Show("MuXunAccelerator", "程序无法获取Windows管理员身份 \n请手动使用Windows管理员身份运行!");
                return;
            }
            //退出
            System.Environment.Exit(0);
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


        // 这里的的启动方式基本属于报废，因为从nodejs启动带参数会导致子进程无法启动，不知道为什么
        //if (args.Length != 0)
        //{

        //    string text = NFController.Decrypt(args[0]);
        //    if (!string.IsNullOrEmpty(text))
        //    {
        //        string[] array = text.Split(new char[] { '~' });
        //        DateTime d = Convert.ToDateTime(array[0]);
        //        if ((DateTime.Now - d).TotalSeconds > 5.0)
        //        {
        //            Console.WriteLine("参数无效!");
        //        }
        //        else
        //        {
        //            //NFController.CheckDrivers();
        //            //PrivoxyController privoxyontroller = new PrivoxyController();
        //            //privoxyontroller.Start();
        //            if (array[6] is "ss" or "sk5")
        //            {
        //                NFController nfcontroller = new NFController(array);
        //                nfcontroller.StartWai();
        //                //nfcontroller.StartRust();
        //                //nfcontroller.StartRusts();
        //                //nfcontroller.StartWais();
        //                nfcontroller.StartMains/*Jiu*/();
        //                //nfcontroller.StartSSRE/*Jiu*/();
        //                //nfcontroller.StartSyS();
        //            }
        //            else if (array[6] is "sk5exe")
        //            {
        //                NFController nfcontroller = new NFController(array);
        //                nfcontroller.StartSk5();
        //                //nfcontroller.StartSSRE();
        //                nfcontroller.StartMains/*Jiu*/();
        //            }
        //            else if (array[6] is "ssdll")
        //            {
        //                NFController nfcontroller = new NFController(array);
        //                nfcontroller.StartDLL();
        //                //nfcontroller.StartSSRE();
        //                nfcontroller.StartMains/*Jiu*/();
        //            }
        //            else if (array[6] is "ssr")
        //            {
        //                NFController nfcontroller = new NFController(array);
        //                nfcontroller.StartWai();
        //                //nfcontroller.StartSSRE();
        //                nfcontroller.StartMains/*Jiu*/();
        //            }
        //            else if (array[6] == "1")
        //            {
        //                //TUNController TUNController = new TUNController(array);
        //                //_ = TUNController.StartAsync();
        //                TUNController TUNController = new TUNController(array);
        //                NFController nfcontroller = new NFController(array);
        //                nfcontroller.StartWai();
        //                //nfcontroller.StartDLLSS();
        //                _ = TUNController.StartAsync();
        //                //nfcontroller.StartSyS();
        //            }
        //            else if (array[6] is "ssrtun")
        //            {
        //                TUNController TUNController = new TUNController(array);
        //                NFController nfcontroller = new NFController(array);
        //                nfcontroller.StartSk5();
        //                //nfcontroller.StartDLL();
        //                _ = TUNController.StartAsync();
        //            }
        //            else if (array[9] == "ss/tun")
        //            {
        //                TUNController TUNController = new TUNController(array);
        //                NFController nfcontroller = new NFController(array);
        //                nfcontroller.StartWai();
        //                _ = TUNController.StartAsync();
        //                nfcontroller.StartMains/*Jiu*/();
        //                //nfcontroller.StartSSRE/*Jiu*/();
        //                //nfcontroller.StartSyS();
        //            }
        //            //else if (array[9] == "ss/tun")
        //            //{
        //            //    TUNController TUNController = new TUNController(array);
        //            //    NFController nfcontroller = new NFController(array);
        //            //    _ = TUNController.Tun2Exe();
        //            //    nfcontroller.Start();
        //            //}
        //            //else if (array[6] == "ssr/tun")
        //            //{
        //            //    TUNController TUNController = new TUNController(array);
        //            //    NFController nfcontroller = new NFController(array);
        //            //    //nfcontroller.StartSSR();
        //            //    //nfcontroller.Start();
        //            //    _ = TUNController.Tun2Exe();
        //            //}
        //            else
        //            {
        //                return;
        //            }
        //            Utils.Utils.ClearMemory();
        //            Console.ReadKey();
        //        }

        //    }
        //}
        //else
        //{

        //}

    }
    private static void ClearEnv()
    {
        CommandHelper.Windows(string.Empty, new string[] {
                $"setx http_proxy \"\" -m",
                $"setx https_proxy \"\" -m",
            });
    }
}