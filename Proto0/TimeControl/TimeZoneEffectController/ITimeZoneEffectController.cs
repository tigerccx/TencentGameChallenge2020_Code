using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public interface ITimeZoneEffectController
    {
        void OnEnterTimeZone(SlowTimeZone zone);
        void OnExitTimeZone(SlowTimeZone zone);
    }
}

