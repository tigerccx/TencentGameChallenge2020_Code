using MyFramework.Charactor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class StateCharaIdleDeployed : BaseStateChara
    {
        private bool toTransitToIdleRetrieving = false;

        public StateCharaIdleDeployed(StateParamChara param) : base(param) { }

        public override void OnEntrance()
        {
            Debug.Log("Chara Enter Idle Deployed");

            // Animator
            param.animator.SetTrigger("ToIdle");

            param.chara.shooter.SetToScaledSpeed();
            param.chara.shooter.eventOnMarkDeactivated += ToIdleRetrieving;
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
                return new StateCharaFastMoving(param); // StateCharaFastMoving
            }

            // Retrieve
            if (Input.GetMouseButtonDown(0) || toTransitToIdleRetrieving)
            {
                param.chara.shooter.Retrieve();
                return new StateCharaIdleRetrieving(param); // StateCharaIdleRetrieving
            }

            return null;
        }

        public override IState FixedUpdate()
        {
            return null;
        }

        public override void OnExit()
        {
            param.chara.shooter.eventOnMarkDeactivated -= ToIdleRetrieving;
            param.chara.shooter.RestoreScaledSpeed();
        }

        private void ToIdleRetrieving()
        {
            toTransitToIdleRetrieving = true;
        }
    }
}

