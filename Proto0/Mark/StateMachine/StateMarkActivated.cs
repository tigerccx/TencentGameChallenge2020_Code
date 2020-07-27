using System.Collections;
using System.Collections.Generic;
using MyFramework.Charactor;
using UnityEngine;

namespace Proto0
{
    public class StateMarkActivated : BaseStateMark
    {
        private float durTemp;
        private bool toRetrieve = false;

        public StateMarkActivated(StateParamMark param) : base(param) { }

        public override void OnEntrance()
        {
            Debug.Log("Activated");

            // Animator
            param.animator.SetTrigger("ToEnergized");

            param.mark.GoZone.SetActive(true);
            durTemp = 0;
            param.isActive = true;
            param.mark.onActivated?.Invoke();
        }

        public override IState Update()
        {
            if (toRetrieve)
            {
                return new StateMarkRetrieving(param);
            }
            if (param.mark.toLimitActiveTime)
            {
                durTemp += Time.deltaTime;
                if (durTemp >= param.mark.durActive)
                {
                    return new StateMarkRetrieving(param);
                }
            }
            return null;
        }

        public override IState FixedUpdate()
        {
            return null;
        }

        public override void OnExit()
        {
            param.mark.GoZone.SetActive(false);
            param.isActive = false;
            param.mark.onDeactivated?.Invoke();
        }

        public void Retrieve()
        {
            toRetrieve = true;
        }
    }
}

