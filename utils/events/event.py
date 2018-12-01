# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2018-08-27
import utils.tools as tl
import types

try:
    event_map
except NameError:
    event_map = {}


def GetEventByName(event_name):
    return event_map.get(event_name)


# Event对象是一个被观察者, 观察者通过将自身的回调函数绑定到被观察者身上来实现监听
# 所有绑定到Event对象身上的回调函数的参数是一致的
# 因为是自己用所以暂时不做 调用时禁止调用add/remove的判断处理
class Event(object):
    def __init__(self, name=None):
        self.__name = name
        self.__dListener = {}
        # self.__callingLock = object() 暂时用协程做异步,以后要用多线程再做同步
        pass

    def AddListener(self, listener, callback):
        """
        :param listener: listener is None when callback is function or staticmethod, is the instance when callback
        is a instancemethod.(中文不好对应类型说明就英文带过了)
        :param callback: function, staticmethod or instancemethod.
        :return: nothing
        """
        try:
            if callback is None:
                raise tl.CustomException("In Event.AddListener, arg 'callback' can't be None!")
            elif not isinstance(callback, types.FunctionType) and not isinstance(callback, types.MethodType):
                raise tl.CustomException("In Event.AddListener, arg 'callback' must be function or instancemethod!")
            else:
                if listener not in self.__dListener.keys():
                    lCallBack = self.__dListener[listener] = []
                else:
                    lCallBack = self.__dListener[listener]

                if callback in lCallBack:
                    raise tl.CustomException("In Event.AddListener, callback:" + callback.__name__ +
                                             " is already exist!")
                else:
                    lCallBack.append(callback)
            pass
        except tl.CustomException:
            tl.Logger.LogTraceBack()

    def RemoveListener(self, listener):
        if listener in self.__dListener.keys():
            del self.__dListener[listener]

    def RemoveCallBackByListener(self, listener, callback):
        if listener in self.__dListener.keys():
            self.__dListener[listener].remove(callback)

    def RemoveAllListener(self):
        self.__dListener.clear()

    def Notify(self, *args):
        try:
            for k, v in self.__dListener.items():
                for cb in v:
                    if isinstance(cb, types.FunctionType):
                        cb(*args)
                    elif isinstance(cb, types.MethodType):
                        # for method,if the cb.__self is None,use the listener as the first argument.
                        if cb.__self__ is None:
                            cb(k, *args)
                        else:
                            cb(*args)
                    else:
                        raise tl.CustomException("In Notify, calling a uncertain type CallBack?")
                    pass

        except BaseException as e:
            print(e)
            tl.Logger.LogTraceBack()

    def GetEventName(self):
        return self.__name


# just for no-listener pass callback, like function, or object.method
# which can locate the listener by callback itself
# or just don't need a listener.
# don't use it to register the Class.method(not staticmethod)
# e.g: class A has a method name Test. A.Test is a Class.method(just can't locate the listener by itself)
# usage:
# from utils.events.event import Event
# @Event.event_decorator("ClickEvent")
# def HandleClickEvent():
#     print("test")
    @staticmethod
    def event_decorator(event_name):
        try:
            if not isinstance(event_name, str):
                raise tl.CustomException("event_name must be a string.")

            def regist_event_wrapper(callback):
                if event_name not in event_map.keys():
                    event_map[event_name] = Event(event_name)
                event_map[event_name].AddListener(None, callback)
                return callback

        except tl.CustomException:
            print tl.Logger.LogTraceBack()

        return regist_event_wrapper