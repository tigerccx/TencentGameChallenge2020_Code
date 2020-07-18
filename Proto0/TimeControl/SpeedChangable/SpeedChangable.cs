using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public abstract class SpeedChangable : MonoBehaviour, ISpeedChangable
    {
        public abstract float GetSpeed();

        public abstract void RestoreSpeed();

        public abstract void ScaleSpeed(float scale);

        public abstract void SetSpeed(float s);
    }
}

