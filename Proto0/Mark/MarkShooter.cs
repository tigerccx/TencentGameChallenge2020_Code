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
        public Mark MarkInstance { get => markInstance; }

        private StateMachineMark smMark;
        public StateMachineMark SMMark { get => smMark; }

        [SerializeField]
        GameObject prefabRope;
        MarkRope rope;

        [SerializeField]
        SpeedController speedChangable;
        [SerializeField]
        float speedUpScale = 1.67f;

        public bool enableActiveSpeedUp = false;

        public event Action eventOnMarkDeploying; 
        public event Action eventOnMarkRetrieving; 
        public event Action eventOnMarkRetrieved;
        public event Action eventOnMarkBouncingBack;
        public event Action eventOnMarkBouncedBack; 
        public event Action eventOnMarkActivated;
        public event Action eventOnMarkDeactivated;

        // Start is called before the first frame update
        void Start()
        {
            
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
                markInstance.onDeactivated += OnMarkDeploying;
                markInstance.onRetrieving += OnMarkRetrieving;
                markInstance.onRetrieved += OnMarkRetrieved;
                markInstance.onBouncingBack += OnMarkBouncingBack;
                markInstance.onBouncedBack += OnMarkBouncedBack;
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
        public void SetToScaledSpeed()
        {
            speedChangable.SetSpeedScale(speedUpScale);
        }

        /// <summary>
        /// Restore normal character speed
        /// </summary>
        public void RestoreScaledSpeed()
        {
            speedChangable.RestoreSpeedScale();
        }

        private void OnMarkActivated()
        {
            eventOnMarkActivated?.Invoke();
        }
        private void OnMarkDeactivated()
        {
            eventOnMarkDeactivated?.Invoke();
        }
        private void OnMarkDeploying()
        {
            eventOnMarkDeploying?.Invoke();
        }
        private void OnMarkRetrieving()
        {
            eventOnMarkRetrieving?.Invoke();
        }
        private void OnMarkRetrieved()
        {
            eventOnMarkRetrieved?.Invoke();
        }
        private void OnMarkBouncingBack()
        {
            eventOnMarkBouncingBack?.Invoke();
        }
        private void OnMarkBouncedBack()
        {
            eventOnMarkBouncedBack?.Invoke();
        }
    }
}

