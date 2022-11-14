@echo off
chcp 65001
:start

echo "正在移除离线用户"
curl.exe http://8.210.34.107:20081/api/user.php?mode=kill_5min_user
echo "ok"
ping -n 0 127.0.0.1>nul
goto start