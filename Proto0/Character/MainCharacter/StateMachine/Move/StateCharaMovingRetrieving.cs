using MyFramework.Charactor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class StateCharaMovingRetrieving : BaseStateChara
    {
        private MovingDirection mdirLast = MovingDirection.Default;
        private bool toTransitToMoving = false;

        public StateCharaMovingRetrieving(StateParamChara param) : base(param) { }

        public override void OnEntrance()
        {
            Debug.Log("Chara Enter Moving Retrieving");

            // Animator
            param.animator.SetTrigger("ToMoving");

            param.chara.shooter.eventOnMarkRetrieved += ToMoving;
            param.chara.shooter.eventOnMarkBouncedBack += ToMoving;
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
                return new StateCharaIdleRetrieving(param); // StateCharaIdleRetrieving
            }

            if (toTransitToMoving)
            {
                return new StateCharaMoving(param); // StateCharaMoving
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
            param.chara.shooter.eventOnMarkRetrieved -= ToMoving;
            param.chara.shooter.eventOnMarkBouncedBack -= ToMoving;
        }

        private void ToMoving()
        {
            toTransitToMoving = true;
        }
    }
}

