using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework.Util
{
    /// <summary>
    /// Message queue
    /// Note: MessageQueue is updated exclusively by MessageQueueManager
    /// </summary>
    public abstract class MessageQueue
    {
        public MessageQueue()
        {
            MessageQueueManager.GetInstance().RegisterQueue(this);
        }

        protected Queue<Message> queue = new Queue<Message>();

        public void Enqueue(string msgType, object param)
        {
            Message msg = new Message();
            msg.msg = msgType;
            msg.param = param;
            Enqueue(msg);
        }

        public void Enqueue(Message message)
        {
            queue.Enqueue(message);
        }

        public Message Dequeue()
        {
            if (queue.Count != 0)
                return queue.Dequeue();
            else
                return null;
        }

        public void Clear()
        {
            queue.Clear();
        }

        public void Update()
        {
            Message msg = Dequeue();
            while (msg != null)
            {
                HandleMessage(msg);
                msg = Dequeue();
            }
        }

        public abstract void HandleMessage(Message msg);

        ~MessageQueue()
        {
            MessageQueueManager.GetInstance().UnregisterQueue(this);
        }
    }

    public class Message
    {
        public string msg;
        public object param;
    }

}