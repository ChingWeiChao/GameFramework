using System;
using UnityEngine;

namespace JWCore
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        protected static T m_Instance;
        public static T Instance { get { return CreateInstance(); } }

        [SerializeField] private bool isDestroyGameObjectWhenUnload = true;

        [SerializeField] private bool isAwakeAlreadyInScene = false;

        protected static T CreateInstance()
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType(typeof(T)) as T;
                if (m_Instance == null)
                {
                    m_Instance = new GameObject(string.Format("_{0}", typeof(T).Name)).AddComponent<T>();
                }
                if (m_Instance == null)
                {
                    throw new Exception(string.Format("Failed to create instance of{0}", typeof(T).FullName));
                }
                else
                {
                    m_Instance.OnCreate();
                }
            }
            return m_Instance;
        }

        protected virtual void Awake()
        {
            if (!m_Instance)
            {
                CreateInstance();
                if (!gameObject.transform.parent)
                {
                    DontDestroyOnLoad(gameObject);
                }
            }
            else if (isAwakeAlreadyInScene == false)
            {
                if (isDestroyGameObjectWhenUnload)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(this);
                }
            }
        }

        protected virtual void OnCreate() { }
    }
}
