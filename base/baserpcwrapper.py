# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2018/10/27 12:19 
# @description:
from baseapplication import BaseApplication
from net.protocolpacker import ProtocolEnum as pe


class BaseRpcWrapper(object):
    def __init__(self, application=None):
        self.application = None
        self.func_map = {}
        self.Init(application)
        pass

    def __getattr__(self, method_name):
        func = self.__GenerateFunc(method_name)
        setattr(self, method_name, func)
        return func

    def __GenerateFunc(self, method_name):
        def func(*args):
            if self.application is not None:
                self.application.SendMsg(pe.pe_rpc, [method_name, args])
            else:
                print 'error: RcpWrapper is unbind to application.'
        return func
        # 这里可以这么改. rpcwrapper里面加一个funclist,加一个callback.
        # 这样就可以实现多层函数调用+有回调(可以拿到返回值)
        # 比如rpcwrapper.A().B().C().RPCSend(callback)
        # 不断地保存A,B,C,并且返回rpcwrapper自身,直到遇到RPCSend的时候,就把方法通过con传到对端,传完就清空funclist
        # 其中callback就是对端用来调用本端函数,这样就形成了回调
        # 不要质疑上面注释,是可以实现的(现成代码的优化版本),目前没空,以后再写.

    def Init(self, app):
        if app is not None:
            self.BinApplication(app)

    def Destroy(self):
        self.UnBindApplication()
        self.func_map = None

    def BinApplication(self, app):
        assert isinstance(app, BaseApplication)
        self.application = app
        self.application.RegisterMsgHandler(self, self.__HandlerMsg)

    def UnBindApplication(self):
        if isinstance(self.application, BaseApplication):
            self.application.UnRegisterMsgHandler(self, self.__HandlerMsg)
        self.application = None

    def RegisterFunc(self, func):
        if callable(func):
            key = func.__name__
            if key not in self.func_map:
                self.func_map[key] = func

    def UnRegisterFunc(self, func):
        if callable(func):
            key = func.__name__
            if key in self.func_map:
                self.func_map[key] = None

    def __HandlerMsg(self, data):
        if data is not None:
            key = data[0]
            if key in self.func_map:
                if len(data) > 0 and data[1]:
                    self.func_map[key](data[1])
                else:
                    self.func_map[key]()

    # for test
    def LoadRpcFuncList(self, func_list):
        assert isinstance(func_list, list)
        for func in func_list:
            self.RegisterFunc(func)
