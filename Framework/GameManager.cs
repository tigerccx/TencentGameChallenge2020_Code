using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyFramework.Util;

namespace MyFramework
{
    public class GameManager : MonoBehaviour
    {
        private List<IManager> managers = new List<IManager>();

        private void Awake()
        {
            //
            //TODO: Add managers in list with order
            //
            // PropertyAnimationManager
            managers.Add(PropertyAnimationManager.GetInstance());
            // MessageQueueManager
            managers.Add(MessageQueueManager.GetInstance());

            //Awake
            foreach (var manager in managers)
            {
                manager.Awake();
            }
        }

        private void Start()
        {
            foreach (var manager in managers)
            {
                manager.Start();
            }
        }

        private void Update()
        {
            foreach (var manager in managers)
            {
                manager.Update();
            }
        }

        private void FixedUpdate()
        {
            foreach (var manager in managers)
            {
                manager.FixedUpdate();
            }
        }

        private void LateUpdate()
        {
            foreach (var manager in managers)
            {
                manager.LateUpdate();
            }
        }

        private void OnDestroy()
        {
            foreach (var manager in managers)
            {
                manager.Destroy();
            }
        }

        /// <summary>
        /// Add a manager to managers with priority (begin from 0)
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="priority"></param>
        public void AddManager(IManager manager, int priority, bool toInitManager)
        {
            lock (managers)
            {
                managers.Insert(priority, manager);
                if (toInitManager)
                {
                    manager.Awake();
                    manager.Start();
                }
            }
        }

        /// <summary>
        /// Remove a manager from managers
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public bool RemoveManager(IManager manager)
        {
            manager.Destroy();
            return managers.Remove(manager);
        }
    }
}

