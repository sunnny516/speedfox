%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit
cd /d "%~dp0"

%~dp0\TAP-Drive-SocksProxy.exe -tunAddr="10.8.8.10" -tunGw="10.8.8.1" -proxyType="socks" -proxyServer="127.0.0.1:3066" -dnsServer="1.1.1.1,8.8.8.8"
ping 127.0.0.1