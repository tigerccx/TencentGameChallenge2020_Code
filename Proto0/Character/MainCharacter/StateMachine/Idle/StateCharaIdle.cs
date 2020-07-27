using System.Collections;
using System.Collections.Generic;
using MyFramework.Charactor;
using UnityEngine;

namespace Proto0
{
    public class StateCharaIdle : BaseStateChara
    {
        public StateCharaIdle(StateParamChara param) : base(param) { }

        public override void OnEntrance()
        {
            Debug.Log("Chara Enter Idle");

            // Animator
            param.animator.SetTrigger("ToIdle");
        }

        public override IState Update()
        {
            // Move
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector3 dir = new Vector3(x, y, 0);
            if (dir.magnitude >= param.chara.thresMove)
            {
                return new StateCharaMoving(param); // StateCharaMoving
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

                    return new StateCharaIdleDeploying(param); // StateCharaIdleDeploying
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
            
        }
    }

}
