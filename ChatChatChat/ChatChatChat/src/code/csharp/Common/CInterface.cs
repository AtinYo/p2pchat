/************************************************************
     File      : CInterfaces.cs
     brief     : Reusable interfaces, abstract class.
     author    : Atin
     version   : 1.0
     date      : 2018/04/04 14:00:00
     copyright : 2018, Atin. All rights reserved.
**************************************************************/
using System;
namespace Core.src
{
    namespace Singleton
    {
        public abstract class TSingleton<T> where T : class
        {
            private static object mutex = new System.Object();
            protected static volatile T m_instance = null;//volatile允许任意线程修改
            public static T Instance
            {
                get
                {
                    if (m_instance == null)
                    {
                        lock (mutex)
                        {
                            if(m_instance == null)//不直接在第一次判断m_instance是否为空的外面lock是为了减少lock操作,在lock里面是为了保证不会重复new
                            {
                                var ctors = typeof(T).GetConstructors(System.Reflection.BindingFlags.Instance |
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Public);//指定搜索公有constructor是为了报异常
                                if (ctors.Length != 1)
                                {
                                    throw new InvalidOperationException(String.Format("Type {0} must have exactly one constructor.", typeof(T)));
                                }
                                if (ctors[0].GetParameters().Length != 0 || !ctors[0].IsPrivate)//构造函数必须是无参且私有的
                                {
                                    throw new InvalidOperationException(String.Format("The constructor for {0} must be private and take no parameters.", typeof(T)));
                                }
                                m_instance = ctors[0].Invoke(null) as T;
                            }
                        }
                    }
                    return m_instance;
                }
            }
        }
    }

    namespace CommonInterface
    {
        public interface ISystem
        {
            void Init();
            void Update(double deltaTime);
            void Destroy();
        }
    }
}
