using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class MarkShooter : MonoBehaviour
    {
        [SerializeField]
        GameObject prefabMark;
        Mark markInstance;
        public Mark MarkInstance { get => markInstance; }

        [SerializeField]
        GameObject prefabRope;
        MarkRope rope;

        [SerializeField]
        SpeedChangable speedChangable;
        [SerializeField]
        float speedUpScale = 1.67f;

        public bool enableActiveSpeedUp = false;

        public event Action eventOnMarkActivated;
        public event Action eventOnMarkDeactivated;

        // Start is called before the first frame update
        void Start()
        {
            eventOnMarkActivated += SpeedUp;
            eventOnMarkDeactivated += RestoreSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        /// <summary>
        /// Deploy mark
        /// </summary>
        public void Deploy(Vector3 posW)
        {
            GameObject goMark = GameObject.Instantiate(prefabMark, transform.position, Quaternion.identity);

            markInstance = goMark.GetComponent<Mark>();
            markInstance.transMarkShooter = transform;
            markInstance.eventOnRetrieved += () => {
                if (rope != null) GameObject.Destroy(rope.gameObject); rope = null;
                if (markInstance != null) GameObject.Destroy(markInstance.gameObject); markInstance = null;
            };
            if (enableActiveSpeedUp)
            {
                markInstance.eventOnActivated += OnMarkActivated;
                markInstance.eventOnDeactivated += OnMarkDeactivated;
            }
            markInstance.MoveTowards(posW);

            GameObject goRope = GameObject.Instantiate(prefabRope);
            rope = goRope.GetComponent<MarkRope>();
            rope.transChara = transform;
            rope.transMark = markInstance.transform;
            rope.Update();
        }

        /// <summary>
        /// Retrieve mark
        /// </summary>
        public void Retrieve()
        {
            markInstance.MoveBack();
        }

        /// <summary>
        /// Speed up character by set scale
        /// </summary>
        private void SpeedUp()
        {
            speedChangable.ScaleSpeed(speedUpScale);
        }

        /// <summary>
        /// Restore normal character speed
        /// </summary>
        private void RestoreSpeed()
        {
            speedChangable.RestoreSpeed();
        }

        /// <summary>
        /// Triggered when mark is activated
        /// </summary>
        private void OnMarkActivated()
        {
            eventOnMarkActivated?.Invoke();
        }

        /// <summary>
        /// Triggered when mark is deactivated
        /// </summary>
        private void OnMarkDeactivated()
        {
            eventOnMarkDeactivated?.Invoke();
        }
    }
}

