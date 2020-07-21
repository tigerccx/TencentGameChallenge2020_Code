using MyFramework.Charactor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class StateCharaFastMoving : BaseStateChara
    {
        private MovingDirection mdirLast = MovingDirection.Default;
        private bool toTransitToMovingRetrieving = false;

        public StateCharaFastMoving(StateParamChara param) : base(param) { }

        public override void OnEntrance()
        {
            Debug.Log("Chara Enter Fast Moving");
            
            // Animator
            param.animator.SetTrigger("ToFastMoving");

            param.chara.shooter.SetToScaledSpeed();
            param.chara.shooter.eventOnMarkDeactivated += ToMovingRetrieving;
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
                return new StateCharaIdleDeployed(param); // StateCharaIdleDeployed
            }

            // Retrieve
            if (Input.GetMouseButtonDown(0) || toTransitToMovingRetrieving)
            {
                param.chara.shooter.Retrieve();
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
            param.chara.shooter.eventOnMarkDeactivated -= ToMovingRetrieving;
            param.chara.shooter.RestoreScaledSpeed();
        }

        private void ToMovingRetrieving()
        {
            toTransitToMovingRetrieving = true;
        }
    }
}

