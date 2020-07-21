using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Proto0
{
    public class SpeedControllerChara : SpeedController
    {
        MovementController controller;

        private void Start()
        {
            controller = GetComponent<MovementController>();
        }

        public override float GetSpeed()
        {
            return controller.speed;
        }

        public override void SetSpeed(float s)
        {
            print("SetSpeed " + gameObject + "  speed: " + s);
            controller.speed = s;
        }

        public override void SetSpeedScale(float scale)
        {
            controller.magSpeed = scale;
        }

        public override void RestoreSpeedScale()
        {
            controller.magSpeed = 1;
        }
    }

}
