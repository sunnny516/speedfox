#-.- coding:utf-8 -.-
import os
import sys

print('下载gfw文件')
os.system("wget http://100.100.100.1/gfw.txt")


f = open("gfw.txt") # 读取文件
line = f.readline() # 调用文件的 readline()方法
while line:
    line = line.replace('\n','')# 替换记事本里的换行
    line = line.replace('\r\n','')# 替换记事本里的换行
    
    line = 'iptables -A FORWARD -p tcp -m string --string "'+line+'"  --algo bm    -j REJECT --reject-with tcp-reset'
    print('操作指令:' + line)
    os.system(line)
    print('指令完成')




    line = f.readline()




f.close()
print('设置开机启动')
os.system("systemctl enable iptables.service")

print('启动防火墙')
os.system("systemctl start iptables")

print('保存配置')
os.system("service iptables save")

print('重启防火墙')
os.system("systemctl restart iptables.service")

os.system("cat /etc/sysconfig/iptables")
print('防火墙配置位置 /etc/sysconfig/iptables')