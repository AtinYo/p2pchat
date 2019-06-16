# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2018-08-27
import traceback

try:
    event_map
except NameError:
    event_map = {}

# 获取事件
def GetEventByName(event_name):
    try:
        if event_name is None or not isinstance(event_name, str):
            raise Exception('event_name must be str!')
        return event_map.get(event_name)
    except:
        traceback.print_exc()


# 移除事件
def RemoveEvent(event_name):
    if event_name in event_map:
        event_map[event_name].RemoveAllListener()
        del event_map[event_name]


# 发事件
def SendEvent(event_name, *args):
    event = GetEventByName(event_name)
    if event:
        event.Notify(*args)


# 注册事件的监听者
def RegisterEventListener(event_name, listener, callback):
    if event_name not in event_map.keys():
        event_map[event_name] = Event(event_name)
    event_map[event_name].AddListener(listener, callback)


# 移除事件的指定监听者
def RemoveEventListener(event_name, listener):
    if event_name not in event_map.keys():
        event_map[event_name] = Event(event_name)
    event_map[event_name].RemoveListener(listener)


# 移除事件的指定监听者的指定函数
def RemoveEventCallBackByListener(event_name, listener, callback):
    if event_name not in event_map.keys():
        event_map[event_name] = Event(event_name)
    event_map[event_name].RemoveCallBackByListener(listener, callback)


# 移除事件的所有监听者
def RemoveEventAllListener(event_name):
    if event_name not in event_map.keys():
        event_map[event_name] = Event(event_name)
    event_map[event_name].RemoveAllListener()


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
                raise Exception("In Event.AddListener, arg 'callback' can't be None!")
            elif not callable(callback):
                raise Exception("In Event.AddListener, arg 'callback' must be callable!")
            else:
                if listener not in self.__dListener:
                    self.__dListener[listener] = []

                lCallBack = self.__dListener[listener]

                if callback in lCallBack:
                    raise Exception("In Event.AddListener, callback:" + callback.__name__ + " is already exist!")
                else:
                    lCallBack.append(callback)
        except:
            traceback.print_exc()

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
            for callbacklist in self.__dListener.values():
                for cb in callbacklist:
                    if len(args) > 0:
                        cb(*args)
                    else:
                        cb()
        except:
            traceback.print_exc()

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
# 说人话就是用下面修饰符修饰的只能是函数或者不依赖队友的对象方法
    @staticmethod
    def event_decorator(event_name):
        try:
            if not isinstance(event_name, str):
                raise Exception("event_name must be a string.")

            def regist_event_wrapper(callback):
                if event_name not in event_map.keys():
                    event_map[event_name] = Event(event_name)
                event_map[event_name].AddListener(None, callback)
                return callback

        except:
            traceback.print_exc()

        return regist_event_wrapper