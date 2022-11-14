#!/bin/bash
#a simple example for "tc"
#set the param

DELAY=20
SPEED=$2
FLOW=0

#出口网卡
NETWORK_CARD=$(ip ro get 0.0.0.0 | grep eth | awk '{print $5}')

#服务器IP
IP_ADDRESS=0.0.0.0
start () {
    /sbin/tc qdisc add dev ${NETWORK_CARD} root handle 1: htb default 25
    /sbin/tc class add dev ${NETWORK_CARD} parent 1: classid 1:1 htb rate ${SPEED}kbps
    /sbin/tc qdisc add dev ${NETWORK_CARD} parent 1:1 netem delay ${DELAY}ms ${FLOW}ms
    /sbin/tc filter add dev ${NETWORK_CARD} parent 1: protocol ip prio 1 u32 match ip dst ${IP_ADDRESS}/32 flowid 1:1
}

stop () {
    /sbin/tc qdisc dele dev ${NETWORK_CARD} root
}

case "$1" in
    start)
        start
        ;;
    stop)
        stop
        ;;
    *)
        echo "Usage: `basename $0` {start|stop} speed(kb/s)"
esac