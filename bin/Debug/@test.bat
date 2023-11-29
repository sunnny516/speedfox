@echo off
chcp 65001
%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit
cd /d "%~dp0"
echo ------------------調試開始bat-------------------
SpeedProxy.exe

echo ------------------調試结束bat-------------------
pause