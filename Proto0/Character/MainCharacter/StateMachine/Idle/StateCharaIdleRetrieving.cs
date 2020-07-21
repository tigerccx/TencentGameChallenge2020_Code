using MyFramework.Charactor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class StateCharaIdleRetrieving : BaseStateChara
    {
        private bool toTransitToIdle = false;

        public StateCharaIdleRetrieving(StateParamChara param) : base(param) { }

        public override void OnEntrance()
        {
            Debug.Log("Chara Enter Idle Retrieving");

            // Animator
            param.animator.SetTrigger("ToIdle");

            param.chara.shooter.eventOnMarkRetrieved += ToIdle;
            param.chara.shooter.eventOnMarkBouncedBack += ToIdle;
        }

        public override IState Update()
        {
            // Move
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector3 dir = new Vector3(x, y, 0);
            if (dir.magnitude >= param.chara.thresMove)
            {
                if (dir.magnitude > 1)
                {
                    dir = dir.normalized;
                }
                dir *= Time.deltaTime;
                param.chara.controller.Move(dir);
                return new StateCharaMovingRetrieving(param); // StateCharaMovingRetrieving
            }

            if (toTransitToIdle)
            {
                return new StateCharaIdle(param); // StateCharaIdle
            }

            return null;
        }

        public override IState FixedUpdate()
        {
            return null;
        }

        public override void OnExit()
        {
            param.chara.shooter.eventOnMarkRetrieved -= ToIdle;
            param.chara.shooter.eventOnMarkBouncedBack -= ToIdle;
        }

        private void ToIdle()
        {
            toTransitToIdle = true;
        }
    }
}

