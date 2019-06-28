# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2019-06-26
# c#调用py文件的首入口

# import sys
# import os
# temp_list = os.path.abspath(__file__).split('\\')
# temp_list.pop(len(temp_list)-1)  # pop掉module
# temp_list.pop(len(temp_list)-1)  # pop掉debug或release
# temp_list.pop(len(temp_list)-1)  # pop掉bin
# APP_PATH = ''
# for temp in temp_list:
#     APP_PATH += (temp+'\\')
# PY_PATH = APP_PATH + 'src\\code\\py'
# sys.path.append(PY_PATH)  # 把py路径加入sys的path

# f = open('AtinPymain.txt', 'w')
# f.write('APP_PATH={}\n'.format(APP_PATH))

import utils.tools
from client.client import Client
from server.server import Server

# py的全局对象
ClientObj = None
ServerObj = None


def init():
    utils.tools.InitLogger()  # 初始化py部分的日志处理

    global ClientObj
    if ClientObj is None:
        print 'create, ClientObj!'
        ClientObj = Client('p2pchat_client')

    global ServerObj
    if ServerObj is None:
        print 'create, ServerObj!'
        ServerObj = Server()


def update(delta_time):
    pass


def destroy():
    pass


