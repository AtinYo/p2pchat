# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2018/9/6  11:01
import time
from base.baseapplication import BaseApplication as BaseApplication
from net.protocolpacker import ProtocolEnum as pe
import threading


class Client(BaseApplication):
    def __init__(self, name):
        super(Client, self).__init__()
        self.hb_pkg_send_time = 0   # heartbeat pkg last send time.
        self.hb_pkg_send_stop_flag = False

    def DoStart(self):
        if self.con.Connect(True):
            threading.Thread(target=self._HeartBeatThread).start()

    def IsAllowSend(self):
        return not self.hb_pkg_send_stop_flag

    # 并不是真正每隔1s发送心跳包,因为是在线程里面
    def _HeartBeatThread(self):
        while 1:
            if not self.IsAllowSend():
                continue
            time_now = time.time()
            if time_now - self.hb_pkg_send_time > 1:
                self.hb_pkg_send_time = time_now
                self.SendMsg(pe.pe_heartbeat, '0')

    def OnConnect(self):
        print 'succeed to connect.'
        pass

    def OnDisconnect(self):
        print 'disconnect to server.'
        pass

    def InitConnection(self, ip=None, port=23333, auto_reconnect_max_times=5):
        super(Client, self).InitConnection(_ip=ip, _port=port,
                                           _handle_connect=self.OnConnect,
                                           _handle_close=self.OnDisconnect,
                                           _auto_reconnect_max_times=auto_reconnect_max_times)
