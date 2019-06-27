# -*- coding: utf-8 -*-
# @author: Atin
# @time: 2018-08-27

import sys
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

            # 写文件
            f = open('..\\..\\src\\code\\py\\py_log.txt', 'a')
            f.write(content)
            f.close()

        except:
            import traceback
            traceback.print_exc()

    # # 清空本地log文件
    # def clearLocalFile(self):
    #     try:
    #         f = open('logAtin.txt', 'w')
    #         f.write('')
    #         f.close()
    #     except:
    #         import traceback
    #         traceback.print_exc()


