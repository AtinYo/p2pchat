using Core.src.CommonInterface;
using Core.src.Singleton;
using System;
using System.Collections.Generic;

namespace ChatChatChat.src.code.csharp.Systems
{
    public class SystemManager : TSingleton<SystemManager>, ISystem
    {
        public static bool HasInit { get; private set; }
        private List<ISystem> sysInstList = new List<ISystem>();
        //构造函数
        private SystemManager()
        {
            Init();
        }

        public void Init()
        {
            HasInit = true;
            先把catch 主进程的exception和update处理了
            再继续逻辑
            反射获取subsystem目录下所有实例
            throw new NotImplementedException();
        }

        public void Update(double deltaTime)
        {
            try
            {
                for (int i = 0; i < sysInstList.Count; i++)
                {
                    sysInstList[i].Update(deltaTime);
                }
            }
            catch (Exception e)
            {
                Logger.Logger.Log(e);
            }
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
