using System.Diagnostics;
using WindowsFirewallHelper;
using WindowsFirewallHelper.COMInterop;
using WindowsFirewallHelper.FirewallRules;

namespace MuXunProxy.Utils;

public static class Firewall
{
    private const string RuleName = "MuXun.Proxy";
    private static string ass = "1";
    private static string auu = "1";
    /// <summary>
    /// 添加 `MuXun.Proxy` 程序及其子目录中的所有 `.exe` 文件到防火墙规则中
    /// </summary>
    /// 
    public static void AddRule()
    {
        if(RuleExists(RuleName) == true)
        {
            return;
        }

        if (!FirewallWAS.IsLocallySupported)
        {
            return;
        }

        try
        {
            var rules = FirewallManager.Instance.Rules.Where(rule => rule.Name == RuleName).ToList();
            foreach (var path in Directory.GetFiles(Application.StartupPath, "*.exe", SearchOption.AllDirectories))
            {
                // 如果规则已经存在，不需要调用 AddRule() 方法
                if (rules.Any(rule => rule.ApplicationName?.Equals(path, StringComparison.OrdinalIgnoreCase) == true))
                {
                    continue;
                }

                AddRuleTcp(path);
                AddRulesUdp(path);
            }

            // 删除不再需要的规则
            foreach (var rule in rules)
            {
                if (!Directory.GetFiles(Application.StartupPath, "*.exe", SearchOption.AllDirectories)
                    .Any(path => rule.ApplicationName?.Equals(path, StringComparison.OrdinalIgnoreCase) == true))
                {
                    FirewallManager.Instance.Rules.Remove(rule);
                }
            }
        }
        catch
        {
            // handle exception
        }
    }

    // 判断规则是否已存在的方法
    static bool RuleExists(string ruleName)
    {
        Process process = new Process();
        process.StartInfo.FileName = "netsh";
        process.StartInfo.Arguments = $"advfirewall firewall show rule name=\"{ruleName}\"";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        return output.Contains(ruleName);
    }
    public static void RemoveRule()
    {
        if (!FirewallWAS.IsLocallySupported)
        {
            return;
        }

        try
        {
            var rules = FirewallManager.Instance.Rules.Where(rule =>
                rule.Name == RuleName || rule.ApplicationName?.StartsWith(Application.StartupPath) == true);
            foreach (var rule in rules)
            {
                FirewallManager.Instance.Rules.Remove(rule);
            }
        }
        catch
        {
            // handle exception
        }
    }

    private static void AddRuleTcp(string path)
    {
        if (ass == "1")
        {
            var rule = new FirewallWASRule(
            RuleName, // 名称
            path, // 应用程序路径
            FirewallAction.Allow, // 允许入站流量
            FirewallDirection.Inbound, // 入站规则
            FirewallProfiles.Public // 应用于公共网络配置文件
        );
            rule.Protocol = FirewallProtocol.TCP; // 将协议设置为TCP
            FirewallManager.Instance.Rules.Add(rule);
            ass = "2";
        }
    }

    private static void AddRulesUdp(string path)
    {
        if (auu == "1")
        {
            var rule = new FirewallWASRule(
            RuleName, // 名称
            path, // 应用程序路径
            FirewallAction.Allow, // 允许入站流量
            FirewallDirection.Inbound, // 入站规则
            FirewallProfiles.Public // 应用于公共网络配置文件
        );
            rule.Protocol = FirewallProtocol.UDP; // 将协议设置为TCP
            FirewallManager.Instance.Rules.Add(rule);
            auu = "2";
        }
    }

}