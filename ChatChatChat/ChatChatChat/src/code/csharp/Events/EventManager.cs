/************************************************************
     File      : EventManager.cs
     brief     : EventManager for common event mechanism.
     author    : Atin
     version   : 1.0
     date      : 2018/06/27 11:23:00
     copyright : 2018, Atin. All rights reserved.
**************************************************************/
using Core.src.Singleton;
using Core.src.CommonInterface;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.src.Events
{
    public class EventManager : TSingleton<EventManager>, ISystem
    {
        #region 数据
        private Dictionary<EventType, ArrayList> eventMapDic;//ArrayList存放的是不同T的Tiny<T>(比如说List有Tiny<T1>和Tiny<T2>等等),
                                                             //以便实现同一个eventType可以有不同的类型的handler[通过发事件传入的参数才确定类型]

        private Queue<object> eventParamsQue;//用于处理异步事件的事件参数队列

        private bool eventParamsQueMutex;//用于单线程内作加锁用(相当于TinyEvent的callnum)

        #endregion

        //构造函数
        private EventManager()
        {
            Init();
        }

        #region ISystem implement
        public void Init()
        {
            eventMapDic = new Dictionary<EventType, ArrayList>();
            eventParamsQue = new Queue<object>();
            eventParamsQueMutex = false;
        }

        private IHandlerEvent evtParams = null;
        public void Update(double deltaTime)
        {
            eventParamsQueMutex = true;
            while (eventParamsQue.Count > 0)
            {
                evtParams = eventParamsQue.Dequeue() as IHandlerEvent;
                if (evtParams != null)
                {
                    evtParams.HandlerEvent();
                    evtParams = null;
                }
            }
            eventParamsQueMutex = false;
        }

        public void Destroy()
        {
            eventMapDic.Clear();
            eventParamsQue.Clear();
            eventParamsQueMutex = false;
        }
        #endregion

        #region 事件注册/注销
        public bool RegisterEventHandler<T>(EventType eventType, T handler)
        {
            return AddEventHandler(eventType, handler);
        }

        public void UnRegisterEventHandler<T>(EventType eventType, T handler)
        {
            RemoveEventHandler(eventType, handler);
        }

        public void UnRegisterAllEventHandlerByEventType(EventType eventType)
        {
            RemoveEventHandlerByEventType(eventType);
        }
        #endregion

        #region 发事件消息
        /// <summary>
        /// 同步发事件.
        /// </summary>
        /// <param name="eventType"></param>
        public void SendEvnetSync(EventType eventType)
        {
            ArrayList list = null;
            TinyEvent<Action> tinyEvt = null;
            if (eventMapDic.ContainsKey(eventType))
            {
                list = eventMapDic[eventType];
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        tinyEvt = list[i] as TinyEvent<Action>;
                        if (tinyEvt != null)
                        {
                            tinyEvt.SendEvent();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 同步发事件.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="eventType"></param>
        /// <param name="arg1"></param>
        public void SendEvnetSync<T1>(EventType eventType, T1 arg1)
        {
            ArrayList list = null;
            TinyEvent<Action<T1>> tinyEvt = null;
            if (eventMapDic.ContainsKey(eventType))
            {
                list = eventMapDic[eventType];
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        tinyEvt = list[i] as TinyEvent<Action<T1>>;
                        if (tinyEvt != null)
                        {
                            tinyEvt.SendEvent(arg1);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 同步发事件.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="eventType"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public void SendEvnetSync<T1, T2>(EventType eventType, T1 arg1, T2 arg2)
        {
            ArrayList list = null;
            TinyEvent<Action<T1, T2>> tinyEvt = null;
            if (eventMapDic.ContainsKey(eventType))
            {
                list = eventMapDic[eventType];
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        tinyEvt = list[i] as TinyEvent<Action<T1, T2>>;
                        if (tinyEvt != null)
                        {
                            tinyEvt.SendEvent(arg1, arg2);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 同步发事件.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="eventType"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public void SendEvnetSync<T1, T2, T3>(EventType eventType, T1 arg1, T2 arg2, T3 arg3)
        {
            ArrayList list = null;
            TinyEvent<Action<T1, T2, T3>> tinyEvt = null;
            if (eventMapDic.ContainsKey(eventType))
            {
                list = eventMapDic[eventType];
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        tinyEvt = list[i] as TinyEvent<Action<T1, T2, T3>>;
                        if (tinyEvt != null)
                        {
                            tinyEvt.SendEvent(arg1, arg2, arg3);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 同步发事件.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="eventType"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="agr4"></param>
        public void SendEvnetSync<T1, T2, T3, T4>(EventType eventType, T1 arg1, T2 arg2, T3 arg3, T4 agr4)
        {
            ArrayList list = null;
            TinyEvent<Action<T1, T2, T3, T4>> tinyEvt = null;
            if (eventMapDic.ContainsKey(eventType))
            {
                list = eventMapDic[eventType];
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        tinyEvt = list[i] as TinyEvent<Action<T1, T2, T3, T4>>;
                        if (tinyEvt != null)
                        {
                            tinyEvt.SendEvent(arg1, arg2, arg3, agr4);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 异步发事件.现在的实现感觉不是很好,看以后有没有更好的方式
        /// </summary>
        /// <param name="eventType"></param>
        public void SendEvnetAsync(EventType eventType)
        {
            ArrayList list = null;
            TinyEvent<Action> tinyEvt = null;
            if (eventMapDic.ContainsKey(eventType))
            {
                list = eventMapDic[eventType];
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        tinyEvt = list[i] as TinyEvent<Action>;
                        if (tinyEvt != null)
                        {
                            eventParamsQue.Enqueue(new EventParams(tinyEvt, eventType));//这种new操作可以考虑用对象池分配,但是类型太多处理还要注意下
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 异步发事件.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="eventType"></param>
        /// <param name="arg1"></param>
        public void SendEvnetAsync<T1>(EventType eventType, T1 arg1)
        {
            ArrayList list = null;
            TinyEvent<Action<T1>> tinyEvt = null;
            if (eventMapDic.ContainsKey(eventType))
            {
                list = eventMapDic[eventType];
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        tinyEvt = list[i] as TinyEvent<Action<T1>>;
                        if (tinyEvt != null)
                        {
                            eventParamsQue.Enqueue(new EventParams<T1>(tinyEvt, eventType, arg1));//这种new操作可以考虑用对象池分配,但是类型太多处理还要注意下
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 异步发事件.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="eventType"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public void SendEvnetAsync<T1, T2>(EventType eventType, T1 arg1, T2 arg2)
        {
            ArrayList list = null;
            TinyEvent<Action<T1, T2>> tinyEvt = null;
            if (eventMapDic.ContainsKey(eventType))
            {
                list = eventMapDic[eventType];
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        tinyEvt = list[i] as TinyEvent<Action<T1, T2>>;
                        if (tinyEvt != null)
                        {
                            eventParamsQue.Enqueue(new EventParams<T1, T2>(tinyEvt, eventType, arg1, arg2));//这种new操作可以考虑用对象池分配,但是类型太多处理还要注意下
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 异步发事件.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="eventType"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public void SendEvnetAsync<T1, T2, T3>(EventType eventType, T1 arg1, T2 arg2, T3 arg3)
        {
            ArrayList list = null;
            TinyEvent<Action<T1, T2, T3>> tinyEvt = null;
            if (eventMapDic.ContainsKey(eventType))
            {
                list = eventMapDic[eventType];
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        tinyEvt = list[i] as TinyEvent<Action<T1, T2, T3>>;
                        if (tinyEvt != null)
                        {
                            eventParamsQue.Enqueue(new EventParams<T1, T2, T3>(tinyEvt, eventType, arg1, arg2, arg3));//这种new操作可以考虑用对象池分配,但是类型太多处理还要注意下
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 异步发事件.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="eventType"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        public void SendEvnetAsync<T1, T2, T3, T4>(EventType eventType, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            ArrayList list = null;
            TinyEvent<Action<T1, T2, T3, T4>> tinyEvt = null;
            if (eventMapDic.ContainsKey(eventType))
            {
                list = eventMapDic[eventType];
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        tinyEvt = list[i] as TinyEvent<Action<T1, T2, T3, T4>>;
                        if (tinyEvt != null)
                        {
                            eventParamsQue.Enqueue(new EventParams<T1, T2, T3, T4>(tinyEvt, eventType, arg1, arg2, arg3, arg4));//这种new操作可以考虑用对象池分配,但是类型太多处理还要注意下
                        }
                    }
                }
            }
        }
        #endregion

        #region 内部实现,不用关心
        private bool AddEventHandler<T>(EventType eventType, T handler)
        {
            ArrayList list = null;
            if (eventMapDic.ContainsKey(eventType))
            {
                list = eventMapDic[eventType];
                if (list == null)
                {
                    list = new ArrayList();
                    eventMapDic[eventType] = list;
                }
            }
            else
            {
                list = new ArrayList();
                eventMapDic.Add(eventType, list);
            }
            return AddTinyEvent(ref list, handler);
        }

        /// <summary>
        /// 看看eventType对应的事件处理List是否有T类型的TinyEvent,有就调用注册事件, 没有先加一个再注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        private bool AddTinyEvent<T>(ref ArrayList list, T handler)
        {
            TinyEvent<T> tinyEvent = null;
            bool isExist = false;
            for (int i = 0; i < list.Count; i++)
            {
                tinyEvent = list[i] as TinyEvent<T>;
                if (tinyEvent != null)
                {
                    isExist = true;
                }
            }
            if (!isExist)
            {
                //处理不存在事件的情况
                tinyEvent = new TinyEvent<T>();
                list.Add(tinyEvent);
            }
            return tinyEvent.RegisterEventHandler(handler);
        }

        private void RemoveEventHandler<T>(EventType eventType, T handler)
        {
            ArrayList list = null;
            if (eventMapDic.ContainsKey(eventType))
            {
                list = eventMapDic[eventType];
                if (list != null)
                {
                    RemoveTinyEvent(ref list, handler);
                }
            }
        }

        private void RemoveTinyEvent<T>(ref ArrayList list, T handler)
        {
            TinyEvent<T> tinyEvent = null;
            for (int i = 0; i < list.Count; i++)
            {
                tinyEvent = list[i] as TinyEvent<T>;
                if (tinyEvent != null)
                {
                    tinyEvent.UnRegisterEventHandler(handler);
                    //本应该清除事件参数队列相应的EventParams,但是这个参数是持有对TinyEvent的引用,通过SendEvent去处理的,在上面已经remove了TinyEvent的handler,所以不用处理貌似也没毛病
                }
            }
        }

        private void RemoveEventHandlerByEventType(EventType eventType)
        {
            eventMapDic.Remove(eventType);
            RemoveEvtParamsByEventType(eventType);//还要清除事件参数队列相应的EventParams
        }

        /// <summary>
        /// 消耗蛮高,调用频率尽量低一点.
        /// </summary>
        /// <param name="evtType"></param>
        private void RemoveEvtParamsByEventType(EventType evtType)
        {
            if (!eventParamsQueMutex)
            {
                eventParamsQueMutex = true;

                List<object> evtParamsList = new List<object>(eventParamsQue);
                if (evtParamsList != null)
                {
                    evtParamsList.RemoveAll(evtParam =>
                    {
                        return (evtParam as IGetEventType) != null && (evtParam as IGetEventType).GetEventType() == evtType;
                    });
                    eventParamsQue = new Queue<object>(evtParamsList);
                }

                eventParamsQueMutex = false;
            }
        }
        #endregion

    }
}
