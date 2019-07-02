# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2019/7/2  19:24
from base.imanager import IManager
import utils.tools


class Connector(IManager):
    def __init__(self):
        pass

    def init(self):
        pass

    def update(self, delta):
        pass

    def destroy(self):
        pass

    # 获取本机的连接码(由ip/port生成). 默认port为23333
    def getConnectCode(self):
        ip = utils.tools.GetLocalIP()
        port = 23333
