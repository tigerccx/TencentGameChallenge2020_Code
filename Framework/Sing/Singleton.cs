using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    /// <summary>
    /// A base class for classes hoped to achieve singleton
    /// </summary>
    public class Singleton<T> where T : class, new()
    {
        private static T instance;
        public static T GetInstance()
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}

