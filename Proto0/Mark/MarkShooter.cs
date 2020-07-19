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
        private Mark markInstance;

        [SerializeField]
        private StateMachineMark smMark;
        public StateMachineMark SMMark { get => smMark; }

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
            // Create Mark
            GameObject goMark = GameObject.Instantiate(prefabMark, transform.position, Quaternion.identity);

            // 
            // Init Mark
            //
            markInstance = goMark.GetComponent<Mark>();

            Action onEnd = () => {
                if (rope != null) GameObject.Destroy(rope.gameObject); rope = null;
                markInstance = null;
            };
            markInstance.onBouncedBack += onEnd;
            markInstance.onRetrieved += onEnd;
            if (enableActiveSpeedUp)
            {
                markInstance.onActivated += OnMarkActivated;
                markInstance.onDeactivated += OnMarkDeactivated;
            }

            //
            // Init StateMachineMark
            //
            smMark = goMark.GetComponent<StateMachineMark>();
            StateParamMark param = new StateParamMark();
            param.mark = markInstance;
            param.transformMarkShooter = transform;
            param.posTarg = posW;
            smMark.paramMark = param;

            //
            // Create Rope
            //
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
            smMark.ManualRetrieve();
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

