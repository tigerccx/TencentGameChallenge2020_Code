﻿using System.Collections;
using System.Collections.Generic;
using MyFramework;
using MyFramework.Charactor;
using UnityEngine;

namespace Proto0
{
    public class StateMarkBouncingBack : BaseStateMark
    {
        private float durTemp;
        private float durLeft;
        private bool toEnd;

        public StateMarkBouncingBack(StateParamMark param) : base(param) { }

        public override void OnEntrance()
        {
            Debug.Log("Bounce back");

            // Animator
            param.animator.SetTrigger("ToFail");

            param.mark.ColliderMark.enabled = false;
            param.mark.Inflicter.enabled = false;

            durTemp = 0;
            durLeft = param.mark.durRetrieve;

            PropertyAnimationManager.GetInstance().StartAnimatingPropertyVector3(param.mark.transform, "position", 
                (val) => { param.mark.transform.position = val; }, () => { return param.mark.transform.position; },
                param.mark.transform.position, param.transformMarkShooter.position, durLeft,
                null, null, null, CallbackOnEachFrame);

            param.isBouncingBack = true;
            param.mark.onBouncingBack?.Invoke();
        }

        public override IState Update()
        {
            durTemp += Time.deltaTime;
            PropertyAnimationManager.GetInstance().EndAnimatingPropertyVector3(param.mark.transform, "position", PropertyAnimationManager.EndPropertyState.Keep);

            if (toEnd)
            {
                return new StateEnd();
            }
            return null;
        }

        public override IState FixedUpdate()
        {
            return null;
        }

        public override void OnExit()
        {
            param.isBouncingBack = false;
            param.mark.onBouncedBack?.Invoke();
        }

        private void CallbackOnEachFrame(PropertyAnimationManager.EndPropertyState state)
        {
            if (state == PropertyAnimationManager.EndPropertyState.Keep)
            {
                durLeft -= durTemp;
                durTemp = 0f;
                Vector3 pos = param.transformMarkShooter.position;

                PropertyAnimationManager.GetInstance().StartAnimatingPropertyVector3(param.mark.transform, "position",
                (val) => { param.mark.transform.position = val; }, () => { return param.mark.transform.position; },
                param.mark.transform.position, param.transformMarkShooter.position, durLeft,
                null, null, null, CallbackOnEachFrame);
            }

            else if (state == PropertyAnimationManager.EndPropertyState.Targ)
            {
                toEnd = true;
            }

            else
            {
                Debug.LogError("不可能存在Src的啊");
            }
        }
    }

}
