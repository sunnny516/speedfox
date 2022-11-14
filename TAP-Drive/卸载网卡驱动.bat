%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit
cd /d "%~dp0"

%~dp0\TAPTool.exe remove %~dp0\OemVista.inf tap0901