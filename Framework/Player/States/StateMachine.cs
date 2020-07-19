using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework.Charactor
{
    public class StateMachine: MonoBehaviour
    {
        public IState stateCur;

        protected virtual void Start()
        {
            stateCur.OnEntrance();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            IState stateNext;
            stateNext = stateCur.Update();
            if (stateNext != null)
            {
                ChangeState(stateNext);
                if (stateNext.GetType() != typeof(StateEnd))
                {
                    return;
                }
                else
                {
                    End();
                }
            }
        }

        protected virtual void FixedUpdate()
        {
            IState stateNext;
            stateNext = stateCur.FixedUpdate();
            if (stateNext != null)
            {
                ChangeState(stateNext);
                if (stateNext.GetType() != typeof(StateEnd))
                {
                    return;
                }
                else
                {
                    End();
                }
            }
        }

        protected void ChangeState(IState stateNext)
        {
            stateCur.OnExit();
            stateCur = stateNext;
            stateCur.OnEntrance();
        }

        protected virtual void End()
        {

        }
    }

    public class StateEnd : IState
    {

        public void OnEntrance(){}

        public IState Update() { return new StateEnd(); }

        public IState FixedUpdate() { return new StateEnd(); }

        public void OnExit(){}

    }
}