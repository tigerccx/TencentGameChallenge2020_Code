using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    [RequireComponent(typeof(ISpeedController))]
    public abstract class TimeZoneEffectController : MonoBehaviour, ITimeZoneEffectController
    {
        public abstract void OnEnterTimeZone(SlowTimeZone zone);

        public abstract void OnExitTimeZone(SlowTimeZone zone);
    }
}

