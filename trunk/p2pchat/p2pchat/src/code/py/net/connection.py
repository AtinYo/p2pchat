# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2018-08-27
import socket


def GetLocalIP():
    """
        查询本机ip地址
        socket.gethostbyname(socket.gethostname()) 这种写法可能拿到的是虚拟机的ip
        :return: ip
    """
    try:
        s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
        s.connect(('8.8.8.8', 80))
        ip = s.getsockname()[0]
    finally:
        if s:
            s.close()
    return ip


class Connection(object):
    STATE_DISCONNECTED = 0  # 连接断开.默认状态
    STATE_CONNECTED = 1  # 已连接

    def __init__(self, ip=None, port=23333, handle_connect=None,
                 handle_close=None, handle_accept=None, auto_reconnect_max_times=5):
        self.socket = None
        self.state = Connection.STATE_DISCONNECTED
        self.auto_reconnect_try_times = 0
        self.ip = ip
        self.port = port
        self.handle_connect = handle_connect
        self.handle_close = handle_close
        self.handle_accept = handle_accept
        self.auto_reconnect_max_times = auto_reconnect_max_times
        self.need_auto_reconnect = False
        self.temp = None

    def __del__(self):
        if self.socket:
            self.socket.close()

    def Connect(self, need_auto_reconnect=False):
        if self.state == Connection.STATE_CONNECTED:
            print("Connection is connected or connecting.")
            return
        else:
            try:
                print("start connect to %s, %s" % (self.ip, self.port))
                if self.socket is None:
                    self.socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
                    self.socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)

                self.socket.connect((self.ip, self.port))
                self.auto_reconnect_try_times = 0
                self.state = Connection.STATE_CONNECTED
                if self.handle_connect is not None and callable(self.handle_connect):
                    self.handle_connect()
                self.need_auto_reconnect = need_auto_reconnect
                return True

            except socket.error as msg:
                print(msg)
                self.DisConnect()

            except BaseException as msg:
                print(msg)
                self.DisConnect()

    def DisConnect(self):
        if self.state == Connection.STATE_CONNECTED:
            self.socket.close()
            self.socket = None
            self.state = Connection.STATE_DISCONNECTED
            self.auto_reconnect_try_times = 0
            if self.handle_close is not None and callable(self.handle_close):
                self.handle_close()

    def Accept(self, bind_port=23333):
        try:
            print("Connection accept...")
            self.temp = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
            self.temp.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
            self.temp.bind((GetLocalIP(), bind_port))
            self.temp.listen(1)  # because it is p2p connection.
            self.socket, self.ip = self.temp.accept()
            self.temp = None
            print("From ip = "+str(self.ip)+", port = "+str(bind_port)+" has been connected.")
            self.state = Connection.STATE_CONNECTED
            if self.handle_accept is not None and callable(self.handle_accept):
                self.handle_accept()
        except socket.error as msg:
            print msg
            self.DisConnect()

    # 尝试重连次数超过上限,就会调用这个函数
    def OnNoConnection(self):
        pass

    def Reconncet(self):
        if self.state == Connection.STATE_CONNECTED:
            return False

        if self.auto_reconnect_try_times <= self.auto_reconnect_max_times:
            self.auto_reconnect_try_times += 1
            self.Connect()
            return True
        else:
            self.need_auto_reconnect = False
            self.OnNoConnection() # 其实这里尝试重连那么多次还不行，就应该处理'无网络'的情况了,而不是继续重连

        return False

    def SendData(self, data):
        if data:
            try:
                if not self.state == Connection.STATE_CONNECTED:
                    raise socket.error("In Connection 'SendData', con.state must be connected when senddata.")
                self.socket.sendall(data)
            except socket.error as msg:
                print msg
                self.DisConnect()
                if self.need_auto_reconnect:
                    while self.Reconncet():
                        pass

    def RecvData(self):
        try:
            if self.state == Connection.STATE_CONNECTED:
                self.temp = self.socket.recv(4096)
                if self.temp:
                    return self.temp
                else:
                    raise socket.error("In Connection 'RecvData', socket is disconnect.")
        except socket.error as msg:
            print msg
            self.DisConnect()
            return None
        # 这里注意有坑,如果写成finally return None.顺序是先finally的return再执行try的return,这样就拿不到返回值了

    def IsConnected(self):
        return self.state == Connection.STATE_CONNECTED



