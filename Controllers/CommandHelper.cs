﻿using System.Diagnostics;

namespace MuXunProxy.Controllers
{
    public sealed class CommandHelper
    {
        public static string Windows(string arg, string[] commands)
        {
            return Execute("cmd.exe", arg, commands);
        }

        public static string Execute(string fileName, string arg, string[] commands)
        {
            Process proc = new Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.Arguments = arg;
            proc.StartInfo.Verb = "runas";
            proc.Start();

            if (commands.Length > 0)
            {
                for (int i = 0; i < commands.Length; i++)
                {
                    proc.StandardInput.WriteLine(commands[i]);
                }
            }

            proc.StandardInput.AutoFlush = true;
            proc.StandardInput.WriteLine("exit");
            string output = proc.StandardOutput.ReadToEnd();
            proc.StandardError.ReadToEnd();
            proc.WaitForExit();
            proc.Close();
            proc.Dispose();

            return output;
        }
    }
}
