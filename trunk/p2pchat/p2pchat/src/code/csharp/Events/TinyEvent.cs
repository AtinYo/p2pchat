/************************************************************
     File      : TinyEvent.cs
     brief     : Event mechanism for communication between different modules.
     author    : Atin
     version   : 1.0
     date      : 2018/04/04 14:00:00
     copyright : 2018, Atin. All rights reserved.
**************************************************************/
using Core.Logger;
using System;
using System.Collections.Generic;
using System.Text;
namespace Core
{
    namespace Events
    {
        /// <summary>
        /// EventHandlerDelegate 处理事件函数的委托,可以有多个参数,但是没返回值
        /// </summary>
        /// <typeparam name="EventHandlerDelegate"></typeparam>
        public class TinyEvent<EventHandlerDelegate>
        {
            private List<EventHandlerDelegate> evtHandlerDelList = new List<EventHandlerDelegate>();
            private List<EventHandlerDelegate> addList = new List<EventHandlerDelegate>();
            private List<EventHandlerDelegate> removeList = new List<EventHandlerDelegate>();

            private static object syncListRoot = new object();
            private static object syncCallingNum = new object();
            private int callingNum = 0;//当前调用的delegate数目,不加lock的时候,这个变量用于控制在进入Invoke的时候,Invoke执行外部函数过程中无法修改时间回调列表.
            //举个例子,tinyEvent注册了func1,Invoke的时候调用func1,如果func1会修改evtHandlerDelList,就会破坏调用结构,所以才会有这么一个变量来处理

            public bool RegisterEventHandler(EventHandlerDelegate evtHandlerDel)
            {
                if (callingNum > 0)
                {
                    lock (syncListRoot)
                    {
                        if (!evtHandlerDelList.Contains(evtHandlerDel))
                        {
                            addList.Add(evtHandlerDel);
                            return true;
                        }
                        else
                        {
                            LogException(new Exception("The TinyEvent already has the del : " + evtHandlerDel.ToString()));
                            return false;
                        }
                    }
                }
                else
                {
                    lock (syncListRoot)
                    {
                        if (!evtHandlerDelList.Contains(evtHandlerDel))
                        {
                            evtHandlerDelList.Add(evtHandlerDel);
                            return true;
                        }
                        else
                        {
                            LogException(new Exception("The TinyEvent already has the del : " + evtHandlerDel.ToString()));
                            return false;
                        }
                    }
                }
            }

            public void UnRegisterEventHandler(EventHandlerDelegate evtHandlerDel)
            {
                try
                {
                    if (callingNum > 0)
                    {
                        lock (syncListRoot)
                        {
                            removeList.Add(evtHandlerDel);
                        }
                    }
                    else
                    {
                        lock (syncListRoot)
                        {
                            evtHandlerDelList.Remove(evtHandlerDel);
                        }
                    }
                }
                catch (Exception e)
                {
                    LogException(e);
                }
            }

            private void LogException(System.Exception exception)
            {
                //StringBuilder stringBuilder = new StringBuilder(512);
                //stringBuilder.Remove(0, stringBuilder.Length);
                //stringBuilder.AppendLine("Caught an exception while using TinyEvent.");
                //stringBuilder.AppendLine("Exception message :");
                //stringBuilder.AppendLine(exception.Message);
                //stringBuilder.AppendLine("Call stack :");
                //stringBuilder.Append(exception.StackTrace);
                //Debug.LogError(stringBuilder.ToString());
                Logger.Logger.Log(exception);
            }

            private void ModifyEvtHandlerDelList()
            {
                if (removeList != null && removeList.Count > 0)
                {
                    for (int i = 0; i < removeList.Count; i++)
                    {
                        evtHandlerDelList.Remove(removeList[i]);
                    }
                }

                if (addList != null && addList.Count > 0)
                {
                    for (int i = 0; i < addList.Count; i++)
                    {
                        evtHandlerDelList.Add(addList[i]);
                    }
                }
            }

            public void SendEvent()
            {
                lock (syncCallingNum)
                {
                    callingNum++;
                }

                try
                {
                    for (int i = 0; i < evtHandlerDelList.Count; i++)
                    {
                        Action ac = evtHandlerDelList[i] as Action;
                        if (ac != null)
                        {
                            ac();
                        }
                    }
                }
                catch (Exception e)
                {
                    LogException(e);
                }
                finally
                {
                    lock (syncCallingNum)
                    {
                        callingNum--;
                    }
                }

                ModifyEvtHandlerDelList();
            }

            public void SendEvent<T>(T arg0)
            {
                lock (syncCallingNum)
                {
                    callingNum++;
                }

                try
                {
                    for (int i = 0; i < evtHandlerDelList.Count; i++)
                    {
                        Action<T> ac = evtHandlerDelList[i] as Action<T>;
                        if (ac != null)
                        {
                            ac(arg0);
                        }
                    }
                }
                catch (Exception e)
                {
                    LogException(e);
                }
                finally
                {
                    lock (syncCallingNum)
                    {
                        callingNum--;
                    }
                }

                ModifyEvtHandlerDelList();
            }

            public void SendEvent<T0, T1>(T0 arg0, T1 arg1)
            {
                lock (syncCallingNum)
                {
                    callingNum++;
                }

                try
                {
                    for (int i = 0; i < evtHandlerDelList.Count; i++)
                    {
                        Action<T0, T1> ac = evtHandlerDelList[i] as Action<T0, T1>;
                        if (ac != null)
                        {
                            ac(arg0, arg1);
                        }
                    }
                }
                catch (Exception e)
                {
                    LogException(e);
                }
                finally
                {
                    lock (syncCallingNum)
                    {
                        callingNum--;
                    }
                }

                ModifyEvtHandlerDelList();
            }

            public void SendEvent<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2)
            {
                lock (syncCallingNum)
                {
                    callingNum++;
                }

                try
                {
                    for (int i = 0; i < evtHandlerDelList.Count; i++)
                    {
                        Action<T0, T1, T2> ac = evtHandlerDelList[i] as Action<T0, T1, T2>;
                        if (ac != null)
                        {
                            ac(arg0, arg1, arg2);
                        }
                    }
                }
                catch (Exception e)
                {
                    LogException(e);
                }
                finally
                {
                    lock (syncCallingNum)
                    {
                        callingNum--;
                    }
                }

                ModifyEvtHandlerDelList();
            }

            public void SendEvent<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
            {
                lock (syncCallingNum)
                {
                    callingNum++;
                }

                try
                {
                    for (int i = 0; i < evtHandlerDelList.Count; i++)
                    {
                        Action<T0, T1, T2, T3> ac = evtHandlerDelList[i] as Action<T0, T1, T2, T3>;
                        if (ac != null)
                        {
                            ac(arg0, arg1, arg2, arg3);
                        }
                    }
                }
                catch (Exception e)
                {
                    LogException(e);
                }
                finally
                {
                    lock (syncCallingNum)
                    {
                        callingNum--;
                    }
                }

                ModifyEvtHandlerDelList();
            }
        }
    }
}