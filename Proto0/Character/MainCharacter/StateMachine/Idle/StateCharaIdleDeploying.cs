using MyFramework.Charactor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class StateCharaIdleDeploying : BaseStateChara
    {
        private bool toTransitToIdleDeployed = false;
        private bool toTransitToIdleRetrieving = false;

        public StateCharaIdleDeploying(StateParamChara param) : base(param) { }

        public override void OnEntrance()
        {
            Debug.Log("Chara Enter Idle Deploying");

            // Animator
            param.animator.SetTrigger("ToIdle");

            param.chara.shooter.eventOnMarkActivated += ToIdleDeployed;
            param.chara.shooter.eventOnMarkBouncingBack += ToIdleRetrieving;
        }

        public override IState Update()
        {
            // Move
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector3 dir = new Vector3(x, y, 0);
            if (dir.magnitude >= param.chara.thresMove)
            {
                return new StateCharaMovingDeploying(param); // StateCharaMovingDeploying
            }

            if (toTransitToIdleDeployed)
            {
                return new StateCharaIdleDeployed(param); // StateCharaIdleDeployed
            }

            if (toTransitToIdleRetrieving)
            {
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
            param.chara.shooter.eventOnMarkActivated -= ToIdleDeployed;
            param.chara.shooter.eventOnMarkBouncingBack -= ToIdleRetrieving;
        }

        private void ToIdleDeployed()
        {
            toTransitToIdleDeployed = true;
        }

        private void ToIdleRetrieving()
        {
            toTransitToIdleRetrieving = true;
        }
    }
}

