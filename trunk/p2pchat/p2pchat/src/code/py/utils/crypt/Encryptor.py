# coding=utf-8
from Crypto import Random
from Crypto.Cipher import PKCS1_v1_5 as Cipher_pkcs1_v1_5
from Crypto.PublicKey import RSA


class Encryptor(object):
    def __init__(self):
        self.__private_key = None
        self.__public_key = None

    # 生成密钥对(公钥加密,私钥解密.把公钥发给对方,对方发消息用公钥加密,自己用私钥解密.
    # 要p2p就必须客户端和服务器都重复一遍
    def GenKeyPairs(self, bits=1024):
        rsa = RSA.generate(bits, Random.new().read)
        self.__private_key = rsa.exportKey()
        self.__public_key = rsa.publickey().exportKey()

    # 从指定文件路径导入密钥对,默认不自动生成
    # 若auto_gen=True,则自动生成密钥对并写入指定的文件路径
    def ImportKeys(self, file_path=None, auto_gen=False):
        try:
            with(open(file_path + 'public_key', 'r')) as f1:
                self.__public_key = f1.read()

            with(open(file_path + 'private_key', 'r')) as f2:
                self.__private_key = f2.read()

        except IOError:
            if auto_gen:
                self.GenKeyPairs()
                self.ExportKeys(file_path)
            else:
                print("Encryptor.ImportKeys raise a IOException.MayBe the file is not exist")

    # 导出密钥对到指定路径
    def ExportKeys(self, file_path):
        try:
            with(open(file_path + 'public_key', 'w')) as f1:
                f1.write(self.__public_key)
            with(open(file_path + 'private_key', 'w')) as f2:
                f2.write(self.__private_key)
        except IOError, e:
            print e

    # 加密数据.公钥加密
    def EncryptData(self, raw_data):
        if isinstance(raw_data, str) and self.__public_key is not None:
            return True, Cipher_pkcs1_v1_5.new(RSA.importKey(self.__public_key)).encrypt(raw_data)
        return False, raw_data

    # 解密数据.私钥解密
    def DecryptData(self, encrypt_data):
        if isinstance(encrypt_data, str) and self.__private_key is not None:
            cipher = Cipher_pkcs1_v1_5.new(RSA.importKey(self.__private_key))
            return True, cipher.decrypt(encrypt_data, Random.new().read)
        return False, encrypt_data
