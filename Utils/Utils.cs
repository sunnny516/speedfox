using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
//using MaxMind.GeoIP2;
//using Microsoft.Win32.TaskScheduler;
using Task = System.Threading.Tasks.Task;

namespace MuXunProxy.Utils;

public static class Utils
{
    public static string GetFileVersion(string file)
    {
        if (File.Exists(file))
            return FileVersionInfo.GetVersionInfo(file).FileVersion ?? "";

        return "";
    }
    #region 内存回收
    [DllImport("kernel32.dll")]
    public static extern bool SetProcessWorkingSetSize(IntPtr proc, IntPtr min, IntPtr max);

    internal static void ClearMemory()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, (IntPtr)(-1), (IntPtr)(-1));
    }
    #endregion

    public static IPAddress GetHostIp(string host)
    {
        if (IPAddress.TryParse(host, out IPAddress ip) == false)
        {
            try
            {
                ip = Dns.GetHostEntry(host).AddressList[0];
            }
            catch (Exception)
            {
            }
        }
        return ip;
    }
    public static string ReversalStr(this string str)
    {
        return new string(str.Select(delegate (char c)
        {
            if (!char.IsLetter(c))
            {
                return c;
            }
            if (!char.IsUpper(c))
            {
                return char.ToUpper(c);
            }
            return char.ToLower(c);
        }).ToArray<char>());
    }

    public static void InsertData(string file1Path, string file2Path, string targetList)
    {
        // 创建一个临时文件作为输出文件
        string tempFilePath = Path.GetTempFileName();

        try
        {
            using (StreamReader reader1 = new StreamReader(file1Path))
            using (StreamWriter writer = new StreamWriter(tempFilePath))
            {
                string line;

                // 逐行读取1号文件，找到目标列表的位置
                while ((line = reader1.ReadLine()) != null)
                {
                    if (line == $"{targetList}")
                    {
                        // 找到目标列表后，先将目标列表写入临时文件
                        writer.WriteLine(line);

                        // 读取2号文件并将数据插入到目标列表之前
                        using (StreamReader reader2 = new StreamReader(file2Path))
                        {
                            string line2;
                            while ((line2 = reader2.ReadLine()) != null)
                            {
                                writer.WriteLine(line2);
                            }
                        }
                    }

                    // 继续将1号文件的内容写入临时文件
                    writer.WriteLine(line);
                }
            }

            // 原始文件覆盖为临时文件（包含写入2号文件数据后的内容）
            File.Delete(file1Path);
            File.Move(tempFilePath, file1Path);
        }
        catch (Exception ex)
        {
            Console.WriteLine("写入文件时出现错误：" + ex.Message);
            // 发生错误后，可以根据实际需求进行异常处理
        }
        finally
        {
            // 删除临时文件
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }
        }
    }

    internal static async Task DownloadFileAsync(string url, string path)
    {
        try
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var request = WebRequest.Create(url);
            request.Proxy = null;
            using var response = await request.GetResponseAsync();

            var stream = response.GetResponseStream();
            using var reader = new StreamReader(stream, Encoding.UTF8);

            var encoding = new UTF8Encoding(false);
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            await using var writer = new StreamWriter(path, true, encoding);

            string value;
            while ((value = await reader.ReadLineAsync()) != null)
            {
                await writer.WriteLineAsync(value).ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
            // 处理异常信息
        }
    }
    public static class NativeMethods
    {
        [DllImport("dnsapi", EntryPoint = "DnsFlushResolverCache")]
        public static extern uint RefreshDNSCache();
    }

    public static string SHA256CheckSum(string filePath)
    {
        try
        {
            using var fileStream = File.OpenRead(filePath);
            return SHA256ComputeCore(fileStream);
        }
        catch (Exception e)
        {
            Log.Warning(e, $"Compute file \"{filePath}\" sha256 failed");
            return "";
        }
    }

    private static string SHA256ComputeCore(Stream stream)
    {
        using var sha256 = SHA256.Create();
        return string.Concat(sha256.ComputeHash(stream).Select(b => b.ToString("x2")));
    }

   
    public static int SubnetToCidr(string value)
    {
        var subnet = IPAddress.Parse(value);
        return SubnetToCidr(subnet);
    }

    public static int SubnetToCidr(IPAddress subnet)
    {
        return subnet.GetAddressBytes().Sum(b => Convert.ToString(b, 2).Count(c => c == '1'));
    }

   
}