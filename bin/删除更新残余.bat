@echo off
%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit
cd /d "%~dp0"


chcp 65001

taskkill /f /im BrowserSubprocess.exe
taskkill /f /im SpeedFoxCore.exe
taskkill /f /im 极狐游戏加速器.exe
taskkill /f /im pcap2socks.exe
taskkill /f /im InternetBridge.exe
taskkill /f /im windowsdesktop.exe
taskkill /f /im simple-obfs.exe
echo 结束进程完成！

del /f /s /q %~dp0\Cache\*

windowsdesktop.exe /Q /NORESTART /lcid 1033