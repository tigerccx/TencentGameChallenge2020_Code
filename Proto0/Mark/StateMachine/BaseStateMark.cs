using MyFramework.Charactor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public abstract class BaseStateMark : IState
    {
        public StateParamMark param;

        public BaseStateMark(StateParamMark param)
        {
            this.param = param;
        }

        public abstract void OnEntrance();
        public abstract IState Update();
        public abstract IState FixedUpdate();
        public abstract void OnExit();
    }

    public class StateParamMark
    {
        public Mark mark;
        public Animator animator;

        public Transform transformMarkShooter;
        public Vector3 posTarg;

        public bool isDeploying = false; // True during deploying.
        public bool isActive = false; // True during state of activeness.
        public bool isRetrieving = false; // True during retrieving.
        public bool isBouncingBack = false; // True during bouncing back.
    }
}

