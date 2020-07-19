using System;
using System.Collections;
using System.Collections.Generic;
using MyFramework;
using MyFramework.Charactor;
using UnityEngine;

namespace Proto0
{
    public class StateMarkDeploying : BaseStateMark
    {
        public StateMarkDeploying(StateParamMark paramMark) : base(paramMark) { }
        public event Action eventOnDeploying;

        bool toBeActivated = false;
        bool toBounceBack = false;

        public override void OnEntrance()
        {
            Debug.Log("Deploy");

            param.mark.GoZone.SetActive(false);

            PropertyAnimationManager.GetInstance().StartAnimatingPropertyVector3(param.mark.transform, "position", 
                (val) => { param.mark.transform.position = val; }, 
                () => { return param.mark.transform.position; }, param.mark.transform.position, param.posTarg, param.mark.durDeploy,
                null, null, null, CallbackOnDeployed);

            param.isDeploying = true;
            param.mark.onDeploying?.Invoke();
        }

        public override IState Update()
        {
            if (toBounceBack)
            {
                PropertyAnimationManager.GetInstance().EndAnimatingPropertyVector3(param.mark.transform, "position", PropertyAnimationManager.EndPropertyState.Keep);
                return new StateMarkBouncingBack(param);
            }
            if (toBeActivated)
            {
                return new StateMarkActivated(param);
            }
            return null;
        }

        public override IState FixedUpdate()
        {
            return null;
        }

        public override void OnExit()
        {
            param.isDeploying = false;
        }

        private void CallbackOnDeployed(PropertyAnimationManager.EndPropertyState state)
        {
            if (state == PropertyAnimationManager.EndPropertyState.Targ)
            {
                toBeActivated = true;
            }
            else if (state == PropertyAnimationManager.EndPropertyState.Keep)
            {
                toBounceBack = true;
            }
        }

        public void BounceBack()
        {
            toBounceBack = true;
        }
    }
}

