# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2019/7/2  19:18


class IManager(object):
    def init(self):
        raise NotImplementedError

    def update(self, delta):
        raise NotImplementedError

    def destroy(self):
        raise NotImplementedError
