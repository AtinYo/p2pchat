# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2018-08-27
from client import Client
import threading
from net.connection import GetLocalIP
from net.protocolpacker import ProtocolEnum as pe
from base.baserpcwrapper import BaseRpcWrapper

c = Client("Client")
c.InitConnection(GetLocalIP())
c.Start()


def TestA(a):
    print 'From Server Call, Client.TestA....'+str(a)


def TestB():
    print 'From Server Call, Client.TestB....'


rpc = BaseRpcWrapper(c)
rpc.LoadRpcFuncList([TestA, TestB])


def fun():
    while 1:
        recv_data = c.RecvMsg()
        if recv_data:
            # print "Client recv : " + str(recv_data)
            pass


threading.Thread(target=fun).start()
# while 1:
#     c.SendMsg(pe.pe_msg, raw_input("send :"))

while 1:
    print 'enter msg:'
    send_msg = raw_input()

    # rpc msg test
    if send_msg == 'rpc':
        send_msg = send_msg.split()
        if len(send_msg) > 1:
            rpc.TestA(send_msg[1])
        else:
            rpc.TestB()
    else:
        c.SendMsg(pe.pe_msg, send_msg)  # normal msg


