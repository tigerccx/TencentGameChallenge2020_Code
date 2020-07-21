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
            if (x > y)
            {
                if (x > -y)
                {
                    return MovingDirection.Right;
                }
                else
                {
                    return MovingDirection.Down;
                }
            }
            else
            {
                if (x > -y)
                {
                    return MovingDirection.Up;
                }
                else
                {
                    return MovingDirection.Left;
                }
            }
        }
    }
}

