# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2018-08-27

import sys
import time
import os
# Python脚本层的旧的标准输出对象
__console__ = None


# 将Python脚本层的标准输出重定向
def InitLogger():
    global __console__
    __console__ = sys.stdout
    sys.stdout = LogRedirect()
    sys.stderr = LogRedirect()


#
# Log重定向类（仅处理Python脚本层的输出重定向）
#
class LogRedirect(object):
    def __init__(self):
        super(LogRedirect, self).__init__()
        self.a = 0
        # self.clearLocalFile()

    # -------------------------------------------------------------------------
    # 外部使用接口
    # -------------------------------------------------------------------------

    # 覆盖父接口：输出
    def write(self, data):
        # todo: 若需要屏蔽所有python层的print输出log

        # 保持原有的标准输出
        __console__.write(data)

        # # 写入本地log文件中，方便查看
        self.WriteToLocalFile(data)

    # -------------------------------------------------------------------------
    # 内部接口
    # -------------------------------------------------------------------------

    # 写入本地log文件中，方便查看
    def WriteToLocalFile(self, content):
        try:
            # 转换编码
            if type(content) == str:
                pass

            if content == '\n' or len(content) <= 0 or content == '\t' or content == '\r':
                # 不知道为什么print的时候会额外输入一些奇奇怪怪的东西
                return

            # 写文件
            log_file_name = '..\\..\\src\\code\\py\\pylogfile\\pylog_{}.txt'.format(time.strftime('%Y_%m_%d', time.localtime(time.time())))
            if not os.path.exists(log_file_name):
                f = open(log_file_name, 'w')
            else:
                f = open(log_file_name, 'a')
            f.write(self.getTimeStr() + content + '\n')
            self.a += 1
            f.close()

        except:
            pass

    def getTimeStr(self):
        return '[{}]\t'.format(time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time())))


