# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2018/9/6  16:00
from base.baseapplication import BaseApplication as BaseApplication


class Server(BaseApplication):
    def DoStart(self):
        self.con.Accept()

    def OnAccept(self):
        print 'succeed to accpet.'
        pass

    def OnDisconnect(self):
        print 'disconnect to client.'
        # 这里考虑要不要重开服务器.
        pass

    def InitConnection(self):
        super(Server, self).InitConnection(_handle_close=self.OnDisconnect,
                                           _handle_accept=self.OnAccept)
