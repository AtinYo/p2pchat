# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2018-08-27
from server import Server
import threading
from net.protocolpacker import ProtocolEnum as pe
from base.baserpcwrapper import BaseRpcWrapper

s = Server()
s.InitConnection()
s.Start()


def TestA(a):
    print 'From Client Call, Server.TestA.... a = '+str(a)


def TestB():
    print 'From Client Call, Server.TestB....'


rpc = BaseRpcWrapper(s)
rpc.LoadRpcFuncList([TestA, TestB])


def fun():
    while 1:
        recv_data = s.RecvMsg()
        if recv_data and recv_data['protocol'] != pe.pe_heartbeat:
            print "Server recv : " + str(recv_data)
            pass


threading.Thread(target=fun).start()
# while 1:
#     s.SendMsg(pe.pe_msg, raw_input("send :"))

while 1:
    print 'enter msg:'
    send_msg = raw_input()

    # rpc msg test
    if send_msg.startswith('rpc'):
        send_msg = send_msg.split()
        if len(send_msg) > 1:
            rpc.TestA(send_msg[1])
        else:
            rpc.TestB()
    else:
        s.SendMsg(pe.pe_msg, send_msg)  # normal msg
