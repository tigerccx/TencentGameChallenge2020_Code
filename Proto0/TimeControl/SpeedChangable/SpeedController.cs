using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public abstract class SpeedController : MonoBehaviour, ISpeedController
    {
        public abstract float GetSpeed();

        public abstract void SetSpeed(float s);

        public abstract void SetSpeedScale(float scale);

        public abstract void RestoreSpeedScale();
    }
}

