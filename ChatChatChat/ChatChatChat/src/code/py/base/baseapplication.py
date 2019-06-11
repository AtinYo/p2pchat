# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2018/9/6  16:00
import threading
import Queue
from net.connection import Connection
import pickle
from net.protocolpacker import ProtocolPacker
from utils import tools as tl
import time
from cStringIO import StringIO
import net.verifier as vf
from utils.events.event import Event
from net.protocolpacker import ProtocolEnum as pe

class BaseApplication(object):
    def __init__(self):
        self.send_queue = Queue.Queue()  # Queue内部有做同步了,存的是字节流(字符串流)
        self.recv_queue = Queue.Queue()  # 存的是一个整包{'protocol':xxx, 'data': xxx}
        self._recv_buff = StringIO()
        self.temp = None
        self.con = None
        self.verify_state = vf.STATE_IDLE
        self.rpc_event = Event('BaseApplicationRpcEvent')

    def __del__(self):
        if self._recv_buff:
            self._recv_buff.close()
        if self.con:
            self.con.DisConnect()
        self.con = None
        self.send_queue = None
        self.recv_queue = None

    def IsAllowCorrespond(self):
        # return self.verify_state == vf.STATE_SUCCEED
        return True

    def SendMsg(self, protocol, data):
        if not self.IsAllowCorrespond():
            return
        # 序列化.加密,包体长度写进包头加上包头,进queue
        try:
            if data:
                # 序列化
                self.temp = pickle.dumps({
                    'protocol': protocol,
                    'data': data,
                })
                if self.temp:
                    # 加密还没加,模块导入后加上
                    self.temp = self.temp  # 这里加密
                    self.temp = ProtocolPacker.Pack(self.temp)  # 打包
                    if self.temp:
                        self.send_queue.put(self.temp)
        except BaseException as e:
            print e
        finally:
            self.temp = None

    def RegisterMsgHandler(self, handler, handle_callback):
        assert isinstance(self.rpc_event, Event)
        self.rpc_event.AddListener(handler, handle_callback)

    def UnRegisterMsgHandler(self, handler, handle_callback):
        assert isinstance(self.rpc_event, Event)
        self.rpc_event.RemoveCallBackByListener(handler, handle_callback)

    # 下面只是一个例子写法,真正用起来，是通过事件分发数据包的
    def RecvMsg(self):
        if not self.IsAllowCorrespond():
            return None
        if not self.recv_queue.empty():
            self.temp = self.recv_queue.get()
            if self.temp['protocol'] == pe.pe_rpc:
                self.rpc_event.Notify(self.temp['data'])
            return self.temp

    def _SendDataThread(self):
        while True:
            while not self.send_queue.empty():
                self.con.SendData(self.send_queue.get())
            time.sleep(0.5)

    def _RecvDataTread(self):  # 为什么Client在Server断开socket后能收到msg(好像是自己发的????
        try:
            while True:
                self.temp = self.con.RecvData()
                if self.temp:
                    self._recv_buff.write(self.temp)
                    while True:
                        total_str = self._recv_buff.getvalue(True)
                        total_len = len(total_str)
                        pkg_len, pkg = ProtocolPacker.UnPack(total_str)
                        if pkg_len and pkg:
                            # 取出包后剩余数据往前挪
                            self._recv_buff.seek(0)
                            self._recv_buff.write(total_str[pkg_len:])
                            self._recv_buff.seek(total_len - pkg_len)
                            # 这里写解密的对pkg
                            self.recv_queue.put(pickle.loads(pkg))  # 存的是一个整包{'protocol':xxx, 'data': xxx}
                        else:
                            time.sleep(0.5)
                            break
        except BaseException as e:
            self._recv_buff.seek(0)  # 清空buff
            print e
            tl.Logger.LogTraceBack()
        finally:
            self.temp = None

    def Verify(self):
        self.verify_state = vf.STATE_IDLE
        # 1.读取本地密钥(公
        # 2.发给socket对端
        # 3.接受对端的公钥
        # 4.互相发随机一串字符串验证.
        # 5.以上成功则进入succeed
        # 这里写完，然后把发包手包的加密解密写完，好像基本ok等pyqt了
        return True

    # 派生类必须实现
    def DoStart(self):
        raise NotImplementedError

    def InitConnection(self, _ip=None, _port=23333, _handle_connect=None, _handle_close=None,
                       _handle_accept=None, _auto_reconnect_max_times=5):

        self.con = Connection(ip=_ip, port=_port, handle_connect=_handle_connect,
                              handle_close=_handle_close, handle_accept=_handle_accept,
                              auto_reconnect_max_times=_auto_reconnect_max_times)

    def Start(self):
        self.DoStart()
        if not self.Verify():
            return
        try:
            threading.Thread(
                target=self._SendDataThread,
            ).start()

            threading.Thread(
                target=self._RecvDataTread,
            ).start()

        except BaseException as e:
            print e
            tl.Logger.LogTraceBack()

    def Stop(self):
        if self.con:
            self.con.DisConnect()

