using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework.Charactor
{
    public interface IState
    {
        // Describe the behaviour of the state when entering
        void OnEntrance();
        // Update by Update in Mono. 
        // Return new state if state change is triggered. Return null if not. 
        IState Update();
        // Update by FixedUpdate in Mono. 
        // Return new state if state change is triggered. Return null if not. 
        IState FixedUpdate();
        // Describe the behaviour of the state when exiting
        void OnExit();
    }
}
