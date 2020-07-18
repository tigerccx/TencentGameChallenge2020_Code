using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework.Util
{
    public class MessageQueueManager : Singleton<MessageQueueManager>, IManager
    {
        HashSet<MessageQueue> queues = new HashSet<MessageQueue>();

        public void Awake()
        {
            
        }

        public void Start()
        {

        }

        public void Update()
        {
            // !!! CAN CAUSE DIFFERENT UPDATE ORDER !!!
            foreach(MessageQueue queue in queues)
            {
                queue.Update();
            }
        }

        public void FixedUpdate()
        {
            
        }

        public void LateUpdate()
        {
            
        }

        public void Destroy()
        {
            if (queues.Count > 0)
            {
                Debug.LogWarning("MessageQueueManager has been destroyed, but there are still message queues in scene. They will NOT be updated.");
            }
        }

        public void RegisterQueue(MessageQueue queue)
        {
            if (!queues.Contains(queue))
            {
                queues.Add(queue);
            }
        }

        public void UnregisterQueue(MessageQueue queue)
        {
            if (queues.Contains(queue))
            {
                queues.Remove(queue);
            }
        }
    }
}

