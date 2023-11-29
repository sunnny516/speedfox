using MuXunProxy.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace MuXunProxy.Controllers
{
    public class PrivoxyController
    {
        public Process? Instance { get; private set; }
        public Process controller; 
        protected bool RedirectStd { get; set; } = true;
        protected virtual Encoding? InstanceOutputEncoding { get; } = null;
        public PrivoxyController()
        {
            
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public void Start()
        {
            var text = new StringBuilder(File.ReadAllText("default.conf"));
        
            text.Replace("_BIND_PORT_", "16878");
            text.Replace("0.0.0.0", "127.0.0.1"); /* BIND_HOST */

            //if (server is Socks5 socks5 && !socks5.Auth())
            //{
            //    text.Replace("/ 127.0.0.1", $"/ {server.AutoResolveHostname()}"); /* DEST_HOST */
            //    text.Replace("_DEST_PORT_", socks5.Port.ToString());
            //}

            text.Replace("_DEST_PORT_", "16877");


            File.WriteAllText("defaults.conf", text.ToString());

            StartInstanceAuto("defaults.conf");
            //string arguments = ("defaults.conf");
            //controller = new Process();
            //controller.StartInfo.FileName = "ss_privoxy.exe";
            //controller.StartInfo.Arguments = arguments.ToString();
            //controller.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            //controller.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            //controller.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            //controller.StartInfo.CreateNoWindow = true;//不显示程序窗口
            //controller.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //将程序窗口最小化到任务栏


            //controller.Start();

            //// 隐藏进程的控制台窗口
            //ShowWindow(GetConsoleWindow(), 0);
        }

        protected virtual void InitInstance(string argument)
        {
            Instance = new Process
            {
                StartInfo =
                {
                    FileName = Path.GetFullPath("ss_privoxy.exe"),
                    Arguments = argument,
                    CreateNoWindow = true,
                    UseShellExecute = !RedirectStd,
                    RedirectStandardOutput = RedirectStd,
                    StandardOutputEncoding = RedirectStd ? InstanceOutputEncoding : null,
                    RedirectStandardError = RedirectStd,
                    StandardErrorEncoding = RedirectStd ? InstanceOutputEncoding : null,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };

        }
        protected void StartInstanceAuto(string argument, ProcessPriorityClass priority = ProcessPriorityClass.Normal)
        {
            // 初始化程序
            InitInstance(argument);


            // 启动程序
            Instance!.Start();
            if (priority != ProcessPriorityClass.Normal)
                Instance.PriorityClass = priority;

            //if (RedirectStd)
            //{
            //    Task.Run(() => ReadOutput(Instance.StandardOutput));
            //    Task.Run(() => ReadOutput(Instance.StandardError));

            //    if (!StartedKeywords.Any())
            //    {
            //        State = State.Started;
            //        return;
            //    }
            //}
            //else
            //{
            //    return;
            //}

            //// 等待启动
            //for (var i = 0; i < 1000; i++)
            //{
            //    Thread.Sleep(10);
            //    switch (State)
            //    {
            //        case State.Started:
            //            Task.Run(OnKeywordStarted);
            //            return;
            //        case State.Stopped:
            //            Stop();
            //            CloseLogFile();
            //            OnKeywordStopped();
            //            throw new MessageException($"{Name} 控制器启动失败");
            //    }
            //}

            //Stop();
            //OnKeywordTimeout();
            //throw new MessageException($"{Name} 控制器启动超时");
        }
    }
}