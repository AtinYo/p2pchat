# -*- coding: utf-8 -*-
# encoding: utf-8
# @author: Atin
# @time: 2018-08-27
import struct
from utils import tools as tl


class ProtocolEnum(object):
    pe_none = 0
    pe_msg = 1
    pe_verify = 2
    pe_heartbeat = 3
    pe_rpc = 4
    pe_max = 5


class ProtocolPacker(object):
    HEAD_SIZE = 4  # 默认头部4个字节吧

    def __init__(self):
        pass

    @staticmethod
    def Pack(data):
        try:
            if data is not None:
                return struct.pack('i', len(data)) + data   # data数据长度用4个字节保存,打包后为 4字节 + data
            else:
                raise tl.CustomException("raw_data can't be None")
        except tl.CustomException:
            tl.Logger.LogTraceBack()
        except Exception as e:
            print(e)
            tl.Logger.LogTraceBack()
            pass

    @staticmethod
    def UnPack(data):
        try:
            if isinstance(data, str):
                total_len = len(data)
                if total_len >= ProtocolPacker.HEAD_SIZE:  # 至少要够一个包头才去解包
                    pkg = data[:ProtocolPacker.HEAD_SIZE]  # 只取出头部分
                    package_body_len = struct.unpack('i', pkg)[0]
                    package_total_len = ProtocolPacker.HEAD_SIZE + package_body_len
                    if total_len >= package_total_len:
                        pkg = data[ProtocolPacker.HEAD_SIZE:package_total_len]  # 只要数据部分,头部舍去
                        return package_total_len, pkg

            return None, None

        except BaseException as e:
            print e
            tl.Logger.LogTraceBack()
            return None, None



