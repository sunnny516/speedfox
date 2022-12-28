var NetChConfig = `{
  "Redirector": {
    "FilterProtocol": "Both",
    "DNSHijack": false,
    "DNSHijackHost": "1.1.1.1:53",
    "ICMPDelay": 5,
    "FilterICMP": false,
    "ChildProcessHandle": false
  },
  "Server": [
    {
      "Password": "",
      "Username": "",
      "Type": "Socks5",
      "Group": "NONE",
      "Hostname": "127.0.0.1",
      "Port": 16780,
      "Rate": 1,
      "Remark": "speedfox"
    }
  ],
  "AioDNS": {
    "ChinaDNS": "tcp://--DnsServer--:53",
    "OtherDNS": "tcp://--DnsServer--:53",
    "ListenPort": 253
  },
  "CheckBetaUpdate": false,
  "CheckUpdateWhenOpened": true,
  "DetectionTick": 10,
  "ExitWhenClosed": true,
  "HTTPLocalPort": 2802,
  "Language": "zh-CN",
  "LocalAddress": "127.0.0.1",
  "MinimizeWhenStarted": true,
  "ModeComboBoxSelectedIndex": 90,
  "ProfileCount": 4,
  "Profiles": [],
  "ProfileTableColumnCount": 5,
  "RequestTimeout": 10000,
  "RunAtStartup": false,
  "ServerComboBoxSelectedIndex": 0,
  "ServerTCPing": true,
  "Socks5LocalPort": 2801,
  "StartedPingInterval": -1,
  "StartWhenOpened": true,
  "StopWhenExited": true,
  "STUN_Server": "stun.syncthing.net",
  "STUN_Server_Port": 3478,
  "Subscription": [],
  "TUNTAP": {
    "Address": "10.0.236.10",
    "HijackDNS": "tcp://--DnsServer--:53",
    "Gateway": "10.0.236.1",
    "Netmask": "255.255.255.0",
    "ProxyDNS": false,
    "UseCustomDNS": false,
    "BypassIPs": [
      "--DnsServer--/32",
      "--ServerIP--/32"
    ]
  },
  "UpdateServersWhenOpened": false,
  "V2RayConfig": {
    "AllowInsecure": false,
    "KcpConfig": {
      "congestion": false,
      "downlinkCapacity": 100,
      "mtu": 1350,
      "readBufferSize": 2,
      "tti": 50,
      "uplinkCapacity": 12,
      "writeBufferSize": 2
    },
    "UseMux": false,
    "V2rayNShareLink": true,
    "XrayCone": true
  },
  "NoSupportDialog": true
}`