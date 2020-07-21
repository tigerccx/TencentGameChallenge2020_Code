using MyFramework.Charactor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public abstract class BaseStateChara : IState
    {
        public StateParamChara param;

        public BaseStateChara(StateParamChara param)
        {
            this.param = param;
        }

        public abstract void OnEntrance();

        public abstract IState Update();

        public abstract IState FixedUpdate();

        public abstract void OnExit();
    }

    public class StateParamChara
    {
        public Character chara;
        public Animator animator;
    }
}

