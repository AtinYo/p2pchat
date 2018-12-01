# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2018-08-27


class Logger(object):
    @staticmethod
    def LogTraceBack():
        import traceback
        traceback.print_exc()

    @staticmethod
    def LogException(e):
        print(e)


class CustomException(BaseException):
    def __init__(self, strData=None):
        self._strData = strData

    def __str__(self):
        tmpStr = self._strData or "None"
        return tmpStr



