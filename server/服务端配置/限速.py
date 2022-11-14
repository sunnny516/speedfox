#-.- coding:utf-8 -.-
import os
import sys



os.system("tc qdisc del dev eth0 root")
print('初始化tc')

os.system("tc qdisc add dev eth0 root handle 1: htb default 1")
print('网卡添加规则')

os.system("tc class add dev eth0 parent 1: classid 1:1 htb rate 10000mbps")
print('设置带宽')

os.system("tc class add dev eth0 parent 1:1 classid 1:5 htb rate 10mbps ceil 10mbps prio 1")
print('设置限速')

os.system("tc filter add dev eth0 parent 1:0 prio 1 protocol ip handle 5 fw flowid 1:5")
print('设置过滤器')

os.system("iptables -A OUTPUT -t mangle -p tcp --sport 10000:60000 -j MARK --set-mark 5")
print('操作防火墙限速10000-60000')

os.system("service iptables save")
print('保存防火墙')

os.system("systemctl restart iptables.service")
print('重启防火墙')
