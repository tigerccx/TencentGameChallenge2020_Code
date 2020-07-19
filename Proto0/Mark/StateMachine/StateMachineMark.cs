using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyFramework.Charactor;

namespace Proto0
{
    public class StateMachineMark : StateMachine
    {
        public StateParamMark paramMark;

        public bool IsDeploying { get{ BaseStateMark state = stateCur as BaseStateMark; return state.param.isDeploying; } }
        public bool IsActive { get { BaseStateMark state = stateCur as BaseStateMark; return state.param.isActive; } }
        public bool IsRetrieving { get { BaseStateMark state = stateCur as BaseStateMark; return state.param.isRetrieving; } }
        public bool IsBouncingBack { get { BaseStateMark state = stateCur as BaseStateMark; return state.param.isBouncingBack; } }

        protected override void Start()
        {
            stateCur = new StateMarkDeploying(paramMark);
            base.Start();
        }

        protected override void End()
        {
            base.End();
            GameObject.Destroy(gameObject);
        }

        public void ManualRetrieve()
        {
            if (stateCur.GetType() == typeof(StateMarkActivated))
            {
                (stateCur as StateMarkActivated).Retrieve();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                if (IsDeploying)
                {
                    (stateCur as StateMarkDeploying).BounceBack();
                }
            }
        }
    }
}

