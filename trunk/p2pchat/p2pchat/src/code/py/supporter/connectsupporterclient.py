# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2019/7/12 22:54 
# @description: 连接服务器获取自己外网Ip/port

import socket
import threading
import utils.tools


class ConnectSupporterClient(object):
    def __init__(self):
        self.con = None

    def Star(self, ip, port=23333):
        try:
            if self.con is None:
                self.con = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
                self.con.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
            self.con.connect((ip, port))
            threading.Thread(target=self.RecvDataFromServer).start()
        except:
            import traceback
            print traceback.format_exc()

    def RecvDataFromServer(self):
        try:
            ip_port_tuple = self.con.recv(4096)
            print 'ip_port_tuple={}'.format(ip_port_tuple)
            self.con.close()
        except BaseException, e:
            import traceback
            traceback.print_stack()
            print e


test_ip = utils.tools.GetLocalIP()
client = ConnectSupporterClient()
client.Star(test_ip)
