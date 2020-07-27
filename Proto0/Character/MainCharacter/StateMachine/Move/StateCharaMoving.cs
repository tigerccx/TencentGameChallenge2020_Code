using MyFramework.Charactor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class StateCharaMoving : BaseStateChara
    {
        private MovingDirection mdirLast = MovingDirection.Default;

        public StateCharaMoving(StateParamChara param) : base(param) { }

        public override void OnEntrance()
        {
            Debug.Log("Chara Enter Moving");

            // Animator
            param.animator.SetTrigger("ToMoving");

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
                return new StateCharaIdle(param); // StateCharaIdle
            }

            // Shoot
            if (Input.GetMouseButtonDown(0))
            {
                if (param.chara.shooter.MarkInstance == null)
                {
                    Vector3 posMouse = Input.mousePosition;
                    Vector3 posW = Camera.main.ScreenToWorldPoint(posMouse);
                    posW.z = 0;

                    param.chara.shooter.Deploy(posW);

                    return new StateCharaMovingDeploying(param); // StateCharaMovingDeploying
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
            Character.SwitchMovingAnimationState(MovingDirection.Default, param.animator);
        }
    }
}
