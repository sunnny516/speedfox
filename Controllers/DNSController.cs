using System;
using System.IO;
using System.Threading.Tasks;

namespace MuXunProxy.Controllers
{
    public class DNSController
    {
        public ushort ListenPort { get; set; } = 253;


        public async Task StartAsync()
        {
            PortHelper.PortCheck(ListenPort, "DNS");

            AioDNS.Dial(AioDNS.NameList.TYPE_REST, "");
            AioDNS.Dial(AioDNS.NameList.TYPE_LIST, "");
            AioDNS.Dial(AioDNS.NameList.TYPE_LISN, "127.0.0.1:253");
            AioDNS.Dial(AioDNS.NameList.TYPE_CDNS, "223.5.5.5:53");
            AioDNS.Dial(AioDNS.NameList.TYPE_ODNS, "1.1.1.1:53");

            if (!await AioDNS.InitAsync())
                throw new Exception("AioDNS start failed.");
        }
    }
}