# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2019/7/12 22:54 
# @description: 直接用Server跑在真正的服务器物理机上,然后客户端连上,服务器这边直接发客户端的外网ip/port给客户端.短链接
# 发完就close.

import socket
import threading


class ConnectSupporterServer(object):
    def __init__(self):
        self.con = None
        self.clientList = None

    def Accept(self):
        while True:
            client_socket, ip_port_tuple = self.con.accept()
            self.OnOneClientConnect(client_socket, ip_port_tuple)

    def Star(self, bind_port=23333):
        try:
            self.con = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
            self.con.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
            ip = '0.0.0.0'
            print 'listen ip={}'.format(ip)
            self.con.bind((ip, bind_port))
            self.con.listen(10)
            threading.Thread(target=self.Accept).start()
        except:
            import traceback
            print traceback.format_exc()

    def OnOneClientConnect(self, client_socket, ip):
        try:
            print 'client from {}, has connect!'.format(ip)
            client_socket.sendall(str(ip))
            client_socket.close()
        except BaseException, e:
            import traceback
            traceback.print_stack()
            print e


supporter = ConnectSupporterServer()
supporter.Star()
