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
