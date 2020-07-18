using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    /// <summary>
    /// A base class for classes hoped to achieve singleton when staying a MonoBehaviour
    /// 
    /// Note:
    /// Only used when global visibility is required!!!
    /// Need to insure only one component is in game. 
    /// </summary>
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T instance = null;
        public static T GetInstance() { return instance; }

        public virtual void AwakeInitSingleton()
        {
            if (instance == null)
            {
                instance = (T)this;
            }
        }

        private void Awake()
        {
            AwakeInitSingleton();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

