using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class Character : MonoBehaviour
    {
        public MovementController controller;
        public MarkShooter shooter;

        public float thresMove;

        private float speedCommon;

        // Start is called before the first frame update
        void Start()
        {
            speedCommon = controller.speed;
        }

        // Update is called once per frame
        void Update()
        {
            //#region Input
            //// Move
            //float x = Input.GetAxis("Horizontal");
            //float y = Input.GetAxis("Vertical");
            //Vector3 dir = new Vector3(x, y, 0);
            //if (dir.magnitude > 1)
            //{
            //    dir = dir.normalized;
            //}
            //dir *= Time.deltaTime;
            //controller.Move(dir);

            //// Shoot
            //if (Input.GetMouseButtonDown(0))
            //{
            //    if (shooter.MarkInstance == null)
            //    {
            //        Vector3 posMouse = Input.mousePosition;
            //        Vector3 posW = Camera.main.ScreenToWorldPoint(posMouse);
            //        posW.z = 0;
            //        shooter.Deploy(posW);
            //    }
            //    else if (shooter.SMMark.IsActive)
            //    {
            //        shooter.Retrieve();
            //    }
            //}
            //#endregion
        }

        public static void SwitchMovingAnimationState(MovingDirection mdir, Animator animator)
        {
            switch (mdir)
            {
                case MovingDirection.Up:
                    {
                        animator.SetBool("ToGoUp", true);
                        animator.SetBool("ToGoDown", false);
                        animator.SetBool("ToGoLeft", false);
                        animator.SetBool("ToGoRight", false);
                    }
                    break;
                case MovingDirection.Down:
                    {
                        animator.SetBool("ToGoUp", false);
                        animator.SetBool("ToGoDown", true);
                        animator.SetBool("ToGoLeft", false);
                        animator.SetBool("ToGoRight", false);
                    }
                    break;
                case MovingDirection.Right:
                    {
                        animator.SetBool("ToGoUp", false);
                        animator.SetBool("ToGoDown", false);
                        animator.SetBool("ToGoLeft", false);
                        animator.SetBool("ToGoRight", true);
                    }
                    break;
                case MovingDirection.Left:
                    {
                        animator.SetBool("ToGoUp", false);
                        animator.SetBool("ToGoDown", false);
                        animator.SetBool("ToGoLeft", true);
                        animator.SetBool("ToGoRight", false);
                    }
                    break;
                case MovingDirection.Default:
                    {
                        animator.SetBool("ToGoUp", false);
                        animator.SetBool("ToGoDown", false);
                        animator.SetBool("ToGoLeft", false);
                        animator.SetBool("ToGoRight", false);
                    }
                    break;
            }
        }
    }
}

