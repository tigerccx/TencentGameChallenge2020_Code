using MyFramework.Charactor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class StateCharaMovingDeploying : BaseStateChara
    {
        private MovingDirection mdirLast = MovingDirection.Default;
        private bool toTransitToFastMoving = false;
        private bool toTransitToMovingRetrieving = false;

        public StateCharaMovingDeploying(StateParamChara param) : base(param) { }

        public override void OnEntrance()
        {
            Debug.Log("Chara Enter Moving Deploying");

            // Animator
            param.animator.SetTrigger("ToMoving");

            param.chara.shooter.eventOnMarkActivated += ToFastMoving;
            param.chara.shooter.eventOnMarkBouncingBack += ToMovingRetrieving;
        }

        public override IState Update()
        {
            // Move
            Vector3 dir = MovementHelper.GetMovement();
            if (dir.magnitude >= param.chara.thresMove)
            {
                dir = MovementHelper.NormalizeAndScaleMovementByTime(dir);

                MovingDirection mdirCur = MovementHelper.GetMovingDirection(dir);
                if (mdirCur != mdirLast)
                {
                    Character.SwitchMovingAnimationState(mdirCur, param.animator);
                    mdirLast = mdirCur;
                }
                param.chara.controller.Move(dir);
            }
            else
            {
                return new StateCharaIdleDeploying(param); // StateCharaIdleDeploying
            }

            if (toTransitToFastMoving)
            {
                return new StateCharaFastMoving(param); // StateCharaFastMoving
            }

            if (toTransitToMovingRetrieving)
            {
                return new StateCharaMovingRetrieving(param); // StateCharaMovingRetrieving
            }

            return null;
        }

        public override IState FixedUpdate()
        {
            return null;
        }

        public override void OnExit()
        {
            Character.SwitchMovingAnimationState(MovingDirection.Default, param.animator);
            param.chara.shooter.eventOnMarkActivated -= ToFastMoving;
            param.chara.shooter.eventOnMarkBouncingBack -= ToMovingRetrieving;
        }

        private void ToFastMoving()
        {
            toTransitToFastMoving = true;
        }

        private void ToMovingRetrieving()
        {
            toTransitToMovingRetrieving = true;
        }
    }
}

