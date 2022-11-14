#-.- coding:utf-8 -.-
import os
import sys


# 打包操作:   pyinstaller -F           pyinstaller -F --uac-admin


"""
防火墙操作

systemctl start iptables #启动

systemctl status iptables #查看运行状态

systemctl restart iptables.service #重启

systemctl stop iptables.service #停止

systemctl enable iptables.service #设置开机启动

systemctl disable iptables.service #禁止开机启动


iptables -A INPUT -p tcp --dport 10000:20000 -j ACCEPT
iptables -A OUTPUT -p tcp --sport 10000:20000 -j ACCEPT



service iptables save #保存配置

iptables -A FORWARD -p tcp -m string --string "www.baidu.com"  --algo bm    -j REJECT --reject-with tcp-reset
iptables -A FORWARD -p tcp -m string --string "t.cn/h5mwx"  --algo bm    -j REJECT --reject-with tcp-reset


iptables -A OUTPUT -t mangle -p tcp --sport 10000:20000 -j MARK --set-mark 5
"""


print('极狐加速器服务端配置工具V1.0.0')
print('防火墙版本号:')
os.system("iptables -V")

print('开放端口范围:  50000 - 60000')

print('\n\n\n\n\n\n')

print('1.关闭出厂的 firewalld')
print('2.批量设置限速')





msg = input("选择模式:")
if msg == 1:
    print('重新配置防火墙')
    print('firewalld状态:')
    os.system("systemctl status firewalld")
    print('关闭出场的firewalld')
    os.system("systemctl stop firewalld")
    print('关闭开机启动firewalld')
    os.system("systemctl disable firewalld")
    print('firewalld状态:')
    os.system("systemctl status firewalld")






    





f = open("gfw.txt") # 读取文件
line = f.readline() # 调用文件的 readline()方法
while line:
    line = line.replace('\n','')# 替换记事本里的换行
    line = line.replace('\r\n','')# 替换记事本里的换行
    

    
    # line = 'iptables -A OUTPUT -m string --string "' + line + '" --algo bm --to 65535 -j DROP'

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