using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class TimeZoneEffectControllerEnemy : TimeZoneEffectController
    {
        public SpeedControllerEnemy speedController;

        public override void OnEnterTimeZone(SlowTimeZone zone)
        {
            speedController.SetSpeedScale(zone.magSpeed);
        }

        public override void OnExitTimeZone(SlowTimeZone zone)
        {
            speedController.RestoreSpeedScale();
        }
    }
}

