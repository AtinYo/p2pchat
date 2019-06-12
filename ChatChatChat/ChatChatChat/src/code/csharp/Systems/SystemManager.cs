using Core.src.CommonInterface;
using Core.src.Singleton;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ChatChatChat.src.code.csharp.Systems
{
    public class SystemManager : TSingleton<SystemManager>, ISystem
    {
        public static bool HasInit { get; private set; }
        private List<ISystem> sysInstList = new List<ISystem>();
        //构造函数
        private SystemManager()
        {

        }
        
        //所有实现了ISystem的,并且派生自TSingleton<>的都会被调用Init()
        public void Init()
        {
            // 其实最好的方式是subSystem单独做成一个c#dll工程,这边load dll去处理,避免遍历一些不必要的类型,也方便热更(虽然不会有这一步估计),先这样做
            Assembly asm = Assembly.GetExecutingAssembly();
            Type t = null;
            ISystem sysInst = null;
            var allTypes = asm.GetTypes();
            for (int i = 0; i < allTypes.Length; i++)
            {
                t = allTypes[i];
                if (t.IsInterface || t == typeof(SystemManager))
                {
                    continue;
                }
                if (typeof(ISystem).IsAssignableFrom(t))
                {
                    var tBase = t.BaseType;
                    if (tBase.IsGenericType && tBase.GetGenericTypeDefinition() == typeof(TSingleton<>))
                    {
                        //既要实现ISystem接口的,又要继承于TSingleton<>的
                        sysInst = tBase.GetProperties()[0].GetValue(null) as ISystem;
                        if (sysInst != null && !sysInstList.Contains(sysInst))
                        {
                            sysInst.Init();
                            sysInstList.Add(sysInst);
                        }
                    }
                }
            }
            HasInit = true;
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
            foreach(var sysInst in sysInstList)
            {
                sysInst.Destroy();
            }
            sysInstList.Clear();
        }
    }
}
