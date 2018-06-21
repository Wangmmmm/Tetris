using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace MyEvent
{
public delegate void EventDelegate<T>(object sender,T e) where T : EventArgs;
public class EventSystem  {

	

        readonly Dictionary<Type, Delegate> _delegates = new Dictionary<Type, Delegate>();

        public void AddListener<T>(EventDelegate<T> listener) where T : EventArgs
        {
            Delegate d;
            if (_delegates.TryGetValue(typeof(T), out d))
            {
                //委托链，将指定的多路广播（可组合）委托的调用列表连接起来。
                _delegates[typeof(T)] = Delegate.Combine(d, listener);
            }
            else
            {
                _delegates[typeof(T)] = listener;
            }
        }

        public void RemoveListener<T>(EventDelegate<T> listener) where T : EventArgs
        {
            Delegate d;
            if (_delegates.TryGetValue(typeof(T), out d))
            {
                Delegate currentDel = Delegate.Remove(d, listener);

                if (currentDel == null)
                {
                    _delegates.Remove(typeof(T));
                }
                else
                {
                    _delegates[typeof(T)] = currentDel;
                }
            }
        }

        // 触发
        public void Raise<T>(object sender,T e) where T : EventArgs
        {
            if (e == null)
            {

                throw new ArgumentException("e");
            }

            Delegate d;

            if (_delegates.TryGetValue(typeof(T), out d))
            {
                EventDelegate<T> callback = d as EventDelegate<T>;
                if (callback != null)
                {
                    callback(sender,e);
                }
            }
        }
    

}
}