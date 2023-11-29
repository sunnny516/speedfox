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
    #region �ڴ����
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
        // ����һ����ʱ�ļ���Ϊ����ļ�
        string tempFilePath = Path.GetTempFileName();

        try
        {
            using (StreamReader reader1 = new StreamReader(file1Path))
            using (StreamWriter writer = new StreamWriter(tempFilePath))
            {
                string line;

                // ���ж�ȡ1���ļ����ҵ�Ŀ���б��λ��
                while ((line = reader1.ReadLine()) != null)
                {
                    if (line == $"{targetList}")
                    {
                        // �ҵ�Ŀ���б���Ƚ�Ŀ���б�д����ʱ�ļ�
                        writer.WriteLine(line);

                        // ��ȡ2���ļ��������ݲ��뵽Ŀ���б�֮ǰ
                        using (StreamReader reader2 = new StreamReader(file2Path))
                        {
                            string line2;
                            while ((line2 = reader2.ReadLine()) != null)
                            {
                                writer.WriteLine(line2);
                            }
                        }
                    }

                    // ������1���ļ�������д����ʱ�ļ�
                    writer.WriteLine(line);
                }
            }

            // ԭʼ�ļ�����Ϊ��ʱ�ļ�������д��2���ļ����ݺ�����ݣ�
            File.Delete(file1Path);
            File.Move(tempFilePath, file1Path);
        }
        catch (Exception ex)
        {
            Console.WriteLine("д���ļ�ʱ���ִ���" + ex.Message);
            // ��������󣬿��Ը���ʵ����������쳣����
        }
        finally
        {
            // ɾ����ʱ�ļ�
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
            // �����쳣��Ϣ
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