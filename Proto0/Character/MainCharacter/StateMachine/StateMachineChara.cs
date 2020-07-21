using MyFramework.Charactor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class StateMachineChara : StateMachine
    {
        public Character chara;
        public Animator animator;

        protected override void Start()
        {
            StateParamChara param = new StateParamChara();
            param.chara = chara;
            param.animator = animator;

            stateCur = new StateCharaIdle(param);
            base.Start();
        }
    }
}

