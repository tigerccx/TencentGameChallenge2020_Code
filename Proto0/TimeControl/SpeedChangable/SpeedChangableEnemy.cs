using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Proto0
{
    public class SpeedChangableEnemy : SpeedChangable
    {
        CharacterController controller;

        private void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        public override float GetSpeed()
        {
            return controller.speed;
        }

        public override void SetSpeed(float s)
        {
            print("SetSpeed " + gameObject + "  speed: "+s);
            controller.speed = s;
        }

        public override void ScaleSpeed(float scale)
        {
            controller.magSpeed = scale;
        }

        public override void RestoreSpeed()
        {
            controller.magSpeed = 1;
        }
    }

}
