using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace JWCore
{

    public class EventManager
    {
        Dictionary<string, EventManagerObject> groups = new Dictionary<string, EventManagerObject>();

        public void Remove(string groupName = "Default")
        {
            if (groups.ContainsKey(groupName) == true)
            {
                groups.Remove(groupName);
            }
        }

        public void ClearAllNoDefault()
        {
            //EventManager.Instance.Clear(EmitGroup.Game);
            //EventManager.Instance.Clear(EmitGroup.Lobby);
            //EventManager.Instance.Clear(EmitGroup.Login);
            //EventManager.Instance.Clear(EmitGroup.Network);
        }


        public void Clear(string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].Clear();
        }

        public void checkGroup(string groupName)
        {
            if (groups.ContainsKey(groupName) == false)
            {
                groups.Add(groupName, new EventManagerObject(groupName));
            }
        }

        public void on(string eventName, Action listener, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].on(eventName, listener);
        }

        public void on(string eventName, Action<object> listener, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].on(eventName, listener);
        }

        public void on(string eventName, Action<object, object> listener, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].on(eventName, listener);
        }

        public void on(string eventName, Action<object, object, object> listener, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].on(eventName, listener);
        }

        public void on(string eventName, Action<object, object, object, object> listener, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].on(eventName, listener);
        }

        public void emit(string eventName, params object[] args)
        {
            emit(false, eventName, args);
        }

        /// <param name="eventName">Event.</param>
        /// <param name="args">Arguments.</param>
        public void emit(bool isThread, string eventName, params object[] args)
        {
            emit("Default", isThread, eventName, args);
        }

        public void emit(string groupName, bool isThread, string eventName, params object[] args)
        {
            checkGroup(groupName);
            groups[groupName].emit(isThread, eventName, args);
        }

        public void off(string eventName, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].off(eventName);
        }

        public void off(string eventName, Action listener, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].off(eventName);
        }

        public void off(string eventName, Action<object> listener, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].off(eventName);
        }

        public void off(string eventName, Action<object, object> listener, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].off(eventName);
        }

        public void off(string eventName, Action<object, object, object> listener, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].off(eventName);
        }

        public void off(string eventName, Action<object, object, object, object> listener, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].off(eventName);
        }

        public void once(string eventName, Action listener, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].once(eventName, listener);
        }

        public void once(string eventName, Action<object> listener, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].once(eventName, listener);
        }

        public void once(string eventName, Action<object, object> listener, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].once(eventName, listener);
        }

        public void once(string eventName, Action<object, object, object> listener, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].once(eventName, listener);
        }

        public void once(string eventName, Action<object, object, object, object> listener, string groupName = "Default")
        {
            checkGroup(groupName);
            groups[groupName].once(eventName, listener);
        }

        void Update()
        {
            if (groups.Count > 0)
            {
                foreach (string groupName in groups.Keys)
                {
                    if (groups[groupName].ThreadEmitEventSave.Count > 0)
                    {
                        foreach (EmitEventData emitEvent in groups[groupName].ThreadEmitEventSave)
                        {
                            groups[groupName].emit(false, emitEvent.EventName, emitEvent.Args);
                        }
                    }

                    groups[groupName].ThreadEmitEventSave.Clear();
                }
            }
        }

        class EmitEventData
        {
            public string EventName;
            public object[] Args;

            public EmitEventData(string eventName, object[] args)
            {
                EventName = eventName;
                Args = args;
            }
        }


        class EventManagerObject
        {

            public string GroupName = "Default";

            public List<EmitEventData> ThreadEmitEventSave = new List<EmitEventData>();

            private Dictionary<string, Action> dict;
            private Dictionary<string, Action<object>> dictOne;
            private Dictionary<string, Action<object, object>> dictTwo;
            private Dictionary<string, Action<object, object, object>> dictThree;
            private Dictionary<string, Action<object, object, object, object>> dictFour;
            private Dictionary<string, List<Delegate>> dictOnce;

            public EventManagerObject(string groupName)
            {
                GroupName = groupName;
            }

            public void Clear()
            {
                if (dict != null)
                    dict.Clear();
                if (dictOne != null)
                    dictOne.Clear();
                if (dictTwo != null)
                    dictTwo.Clear();
                if (dictFour != null)
                    dictFour.Clear();
                if (dictOnce != null)
                    dictOnce.Clear();

                ThreadEmitEventSave.Clear();
            }

            public void on(string eventName, Action listener)
            {
                if (dict == null)
                    dict = new Dictionary<string, Action>();

                if (dict.ContainsKey(eventName))
                {
                    dict[eventName] += listener;
                }
                else
                {
                    dict.Add(eventName, listener);
                }
            }

            public void on(string eventName, Action<object> listener)
            {
                if (dictOne == null)
                    dictOne = new Dictionary<string, Action<object>>();

                if (dictOne.ContainsKey(eventName))
                {
                    dictOne[eventName] += listener;
                }
                else
                {
                    dictOne.Add(eventName, listener);
                }
            }

            public void on(string eventName, Action<object, object> listener)
            {
                if (dictTwo == null)
                    dictTwo = new Dictionary<string, Action<object, object>>();

                if (dictTwo.ContainsKey(eventName))
                {
                    dictTwo[eventName] += listener;
                }
                else
                {
                    dictTwo.Add(eventName, listener);
                }
            }

            public void on(string eventName, Action<object, object, object> listener)
            {
                if (dictThree == null)
                    dictThree = new Dictionary<string, Action<object, object, object>>();

                if (dictThree.ContainsKey(eventName))
                {
                    dictThree[eventName] += listener;
                }
                else
                {
                    dictThree.Add(eventName, listener);
                }
            }

            public void on(string eventName, Action<object, object, object, object> listener)
            {
                if (dictFour == null)
                    dictFour = new Dictionary<string, Action<object, object, object, object>>();

                if (dictFour.ContainsKey(eventName))
                {
                    dictFour[eventName] += listener;
                }
                else
                {
                    dictFour.Add(eventName, listener);
                }
            }

            /// <param name="eventName">Event.</param>
            /// <param name="args">Arguments.</param>
            public void emit(bool isThread, string eventName, params object[] args)
            {

#if HotUpdate
        if (eventName != HUEvent.CheckHUVersion) {
            EventManager.Instance.emit(HUEvent.CheckHUVersion);
        }
#endif

                if (isThread == true)
                {
                    ThreadEmitEventSave.Add(new EmitEventData(eventName, args));
                    return;
                }

                bool success = false;


                if (args.Length == 0 && dict != null && dict.ContainsKey(eventName))
                {
                    success = true;
                    if (dict[eventName] != null)
                        dict[eventName].Invoke();
                }
                else if (args.Length == 1 && dictOne != null && dictOne.ContainsKey(eventName))
                {
                    success = true;
                    if (dictOne[eventName] != null)
                        dictOne[eventName].Invoke(args[0]);
                }
                else if (args.Length == 2 && dictTwo != null && dictTwo.ContainsKey(eventName))
                {
                    success = true;
                    if (dictTwo[eventName] != null)
                        dictTwo[eventName].Invoke(args[0], args[1]);
                }
                else if (args.Length == 3 && dictThree != null && dictThree.ContainsKey(eventName))
                {
                    success = true;
                    if (dictThree[eventName] != null)
                        dictThree[eventName].Invoke(args[0], args[1], args[2]);
                }
                else if (args.Length == 4 && dictFour != null && dictFour.ContainsKey(eventName))
                {
                    success = true;
                    if (dictFour[eventName] != null)
                        dictFour[eventName].Invoke(args[0], args[1], args[2], args[3]);
                }

                if (dictOnce != null && dictOnce.ContainsKey(eventName))
                {

                    List<Delegate> saveDictOnce = new List<Delegate>();

                    for (int i = 0; i < dictOnce[eventName].Count; i++)
                    {

                        bool needRemove = false;

                        Type type = dictOnce[eventName][i].GetType();

                        if (args.Length == 0 && type.Equals(typeof(Action)))
                        {
                            needRemove = true;
                        }
                        else if (args.Length == 1 && type.Equals(typeof(Action<object>)))
                        {
                            needRemove = true;
                        }
                        else if (args.Length == 2 && type.Equals(typeof(Action<object, object>)))
                        {
                            needRemove = true;
                        }
                        else if (args.Length == 3 && type.Equals(typeof(Action<object, object, object>)))
                        {
                            needRemove = true;
                        }
                        else if (args.Length == 4 && type.Equals(typeof(Action<object, object, object, object>)))
                        {
                            needRemove = true;
                        }

                        if (needRemove == true)
                        {
                            removeEvent(eventName, dictOnce[eventName][i]);
                        }
                        else
                        {
                            saveDictOnce.Add(dictOnce[eventName][i]);
                        }
                    }

                    if (saveDictOnce.Count == 0)
                    {
                        dictOnce.Remove(eventName);
                    }
                    else
                    {
                        dictOnce[eventName] = saveDictOnce;
                    }
                }

                if (success == false)
                {
                    string paramsContent = "";

                    foreach (var obj in args)
                    {
                        if (obj == null)
                            paramsContent += " # null";
                        else
                            paramsContent += " # " + obj.ToString();
                    }

                    if (paramsContent != "")
                    {
                        paramsContent = " ###" + paramsContent;
                    }

                    //DebugW.LogWarning(GroupName + " ### emit no success by event : " + eventName + paramsContent);
                }
            }

            public void off(string eventName)
            {
                if (dict != null && dict.ContainsKey(eventName))
                    dict.Remove(eventName);
                if (dictOne != null && dictOne.ContainsKey(eventName))
                    dictOne.Remove(eventName);
                if (dictTwo != null && dictTwo.ContainsKey(eventName))
                    dictTwo.Remove(eventName);
                if (dictThree != null && dictThree.ContainsKey(eventName))
                    dictThree.Remove(eventName);
                if (dictFour != null && dictFour.ContainsKey(eventName))
                    dictFour.Remove(eventName);
            }

            public void off(string eventName, Action listener)
            {
                if (dict != null && dict.ContainsKey(eventName))
                {
                    dict[eventName] -= listener;
                }
            }

            public void off(string eventName, Action<object> listener)
            {

                if (dictOne != null && dictOne.ContainsKey(eventName))
                {
                    dictOne[eventName] -= listener;
                }
            }

            public void off(string eventName, Action<object, object> listener)
            {
                if (dictTwo != null && dictTwo.ContainsKey(eventName))
                    dictTwo[eventName] -= listener;
            }

            public void off(string eventName, Action<object, object, object> listener)
            {
                if (dictThree != null && dictThree.ContainsKey(eventName))
                    dictThree[eventName] -= listener;
            }

            public void off(string eventName, Action<object, object, object, object> listener)
            {

                if (dictFour != null && dictFour.ContainsKey(eventName))
                    dictFour[eventName] -= listener;
            }

            private void removeEvent(string eventName, Delegate listener)
            {
                Type type = listener.GetType();

                if (type.Equals(typeof(Action)))
                {
                    off(eventName, listener as Action);
                }
                else if (type.Equals(typeof(Action<object>)))
                {
                    off(eventName, listener as Action<object>);
                }
                else if (type.Equals(typeof(Action<object, object>)))
                {
                    off(eventName, listener as Action<object, object>);
                }
                else if (type.Equals(typeof(Action<object, object, object>)))
                {
                    off(eventName, listener as Action<object, object, object>);
                }
                else if (type.Equals(typeof(Action<object, object, object, object>)))
                {
                    off(eventName, listener as Action<object, object, object, object>);
                }
            }

            public void once(string eventName, Action listener)
            {
                once<Action>(eventName, listener);
            }

            public void once(string eventName, Action<object> listener)
            {
                once<Action<object>>(eventName, listener);
            }

            public void once(string eventName, Action<object, object> listener)
            {
                once<Action<object, object>>(eventName, listener);
            }

            public void once(string eventName, Action<object, object, object> listener)
            {
                once<Action<object, object, object>>(eventName, listener);
            }

            public void once(string eventName, Action<object, object, object, object> listener)
            {
                once<Action<object, object, object, object>>(eventName, listener);
            }

            private void once<T>(string eventName, T listener)
            {

                if (dictOnce == null)
                    dictOnce = new Dictionary<string, List<Delegate>>();

                if (dictOnce.ContainsKey(eventName))
                {
                    //dictOnce[eventName] += listener;
                    if (dictOnce[eventName] == null)
                        dictOnce[eventName] = new List<Delegate>();
                }
                else
                {
                    dictOnce.Add(eventName, new List<Delegate>());
                }

                dictOnce[eventName].Add(listener as Delegate);

                addEvent(eventName, listener as Delegate);
            }

            private void addEvent(string eventName, Delegate listener)
            {
                Type type = listener.GetType();

                if (type.Equals(typeof(Action)))
                {
                    on(eventName, listener as Action);
                }
                else if (type.Equals(typeof(Action<object>)))
                {
                    on(eventName, listener as Action<object>);
                }
                else if (type.Equals(typeof(Action<object, object>)))
                {
                    on(eventName, listener as Action<object, object>);
                }
                else if (type.Equals(typeof(Action<object, object, object>)))
                {
                    on(eventName, listener as Action<object, object, object>);
                }
                else if (type.Equals(typeof(Action<object, object, object, object>)))
                {
                    on(eventName, listener as Action<object, object, object, object>);
                }
            }
        }

    }

}
