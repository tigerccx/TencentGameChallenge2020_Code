using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public static class MovementHelper
    {
        public static Vector3 GetMovement()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector3 dir = new Vector3(x, y, 0);
            return dir;
        }

        public static Vector3 NormalizeAndScaleMovementByTime(Vector3 dir)
        {
            if (dir.magnitude > 1)
            {
                dir = dir.normalized;
            }
            dir *= Time.deltaTime;
            return dir;
        }

        public static MovingDirection GetMovingDirection(Vector3 dir)
        {
            float x = dir.x;
            float y = dir.y;
            if(x>=y && x >= -y)
            {
                return MovingDirection.Right;
            }
            if(x<=y && x <= -y)
            {
                return MovingDirection.Left;
            }
            if (x < y && x > -y)
            {
                return MovingDirection.Up;
            }
            if (x > y && x < -y)
            {
                return MovingDirection.Down;
            }
            return MovingDirection.Default;
        }
    }
}

