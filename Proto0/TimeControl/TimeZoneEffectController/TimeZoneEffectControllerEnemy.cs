using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class TimeZoneEffectControllerEnemy : TimeZoneEffectController
    {
        public SpeedControllerEnemy speedController;
        public Split split;

        public override void OnEnterTimeZone(SlowTimeZone zone)
        {
            // Slow speed
            speedController.SetSpeedScale(zone.magSpeed);

            // Slow split
            split.SetTimeScale(split.GetTimeScale() * zone.magSpeed);
        }

        public override void OnExitTimeZone(SlowTimeZone zone)
        {
            // Restore speed
            speedController.RestoreSpeedScale();

            // Restore split
            split.SetTimeScale(split.GetTimeScale() / zone.magSpeed);
        }
    }
}

