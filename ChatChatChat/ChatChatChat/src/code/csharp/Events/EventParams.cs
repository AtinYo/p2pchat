/************************************************************
     File      : EventParams.cs
     brief     : EventParams for EventManager.
     author    : Atin
     version   : 1.0
     date      : 2018/07/09 11:44:00
     copyright : 2018, Atin. All rights reserved.
**************************************************************/
using System;

namespace Core.src.Events
{
    public interface IHandlerEvent
    {
        void HandlerEvent();
    }

    public interface IGetEventType
    {
        EventType GetEventType();
    }

    public class EventParams : IHandlerEvent, IGetEventType
    {
        private EventType evtType = EventType.None;

        private TinyEvent<Action> tinyEvt;

        public EventParams(TinyEvent<Action> _tinyEvt, EventType _evtType)
        {
            evtType = _evtType;
            tinyEvt = _tinyEvt;
        }

        public void HandlerEvent()
        {
            if (tinyEvt != null)
            {
                tinyEvt.SendEvent();
            }
        }

        public EventType GetEventType()
        {
            return evtType;
        }
    }

    public class EventParams<T1> : IHandlerEvent, IGetEventType
    {
        private EventType evtType = EventType.None;

        private TinyEvent<Action<T1>> tinyEvt;

        private T1 value1;

        public EventParams(TinyEvent<Action<T1>> _tinyEvt, EventType _evtType, T1 _value1)
        {
            evtType = _evtType;
            tinyEvt = _tinyEvt;
            value1 = _value1;
        }

        public void HandlerEvent()
        {
            if (tinyEvt != null)
            {
                tinyEvt.SendEvent(value1);
            }
        }

        public EventType GetEventType()
        {
            return evtType;
        }
    }

    public class EventParams<T1, T2> : IHandlerEvent, IGetEventType
    {
        private EventType evtType = EventType.None;

        private TinyEvent<Action<T1, T2>> tinyEvt;

        private T1 value1;

        private T2 value2;

        public EventParams(TinyEvent<Action<T1, T2>> _tinyEvt, EventType _evtType, T1 _value1, T2 _value2)
        {
            evtType = _evtType;
            tinyEvt = _tinyEvt;
            value1 = _value1;
            value2 = _value2;
        }

        public void HandlerEvent()
        {
            if (tinyEvt != null)
            {
                tinyEvt.SendEvent(value1, value2);
            }
        }

        public EventType GetEventType()
        {
            return evtType;
        }
    }

    public class EventParams<T1, T2, T3> : IHandlerEvent, IGetEventType
    {
        private EventType evtType = EventType.None;

        private TinyEvent<Action<T1, T2, T3>> tinyEvt;

        private T1 value1;

        private T2 value2;

        private T3 value3;

        public EventParams(TinyEvent<Action<T1, T2, T3>> _tinyEvt, EventType _evtType, T1 _value1, T2 _value2, T3 _value3)
        {
            evtType = _evtType;
            tinyEvt = _tinyEvt;
            value1 = _value1;
            value2 = _value2;
            value3 = _value3;
        }

        public void HandlerEvent()
        {
            if (tinyEvt != null)
            {
                tinyEvt.SendEvent(value1, value2, value3);
            }
        }

        public EventType GetEventType()
        {
            return evtType;
        }
    }

    public class EventParams<T1, T2, T3, T4> : IHandlerEvent, IGetEventType
    {
        private EventType evtType = EventType.None;

        private TinyEvent<Action<T1, T2, T3, T4>> tinyEvt;

        private T1 value1;

        private T2 value2;

        private T3 value3;

        private T4 value4;

        public EventParams(TinyEvent<Action<T1, T2, T3, T4>> _tinyEvt, EventType _evtType, T1 _value1, T2 _value2, T3 _value3, T4 _value4)
        {
            evtType = _evtType;
            tinyEvt = _tinyEvt;
            value1 = _value1;
            value2 = _value2;
            value3 = _value3;
            value4 = _value4;
        }

        public void HandlerEvent()
        {
            if (tinyEvt != null)
            {
                tinyEvt.SendEvent(value1, value2, value3, value4);
            }
        }

        public EventType GetEventType()
        {
            return evtType;
        }
    }
}
