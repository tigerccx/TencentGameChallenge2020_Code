using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class Character : MonoBehaviour
    {
        public CharacterController controller;
        public MarkShooter shooter;
        
        private float speedCommon;

        // Start is called before the first frame update
        void Start()
        {
            speedCommon = controller.speed;
        }

        // Update is called once per frame
        void Update()
        {
            #region Input
            // Move
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector3 dir = new Vector3(x, y, 0);
            if (dir.magnitude > 1)
            {
                dir = dir.normalized;
            }
            dir *= Time.deltaTime;
            controller.Move(dir);

            // Shoot
            if (Input.GetMouseButtonDown(0))
            {
                if (shooter.MarkInstance == null)
                {
                    Vector3 posMouse = Input.mousePosition;
                    Vector3 posW = Camera.main.ScreenToWorldPoint(posMouse);
                    posW.z = 0;
                    shooter.Deploy(posW);
                }
                else if (shooter.SMMark.IsActive)
                {
                    shooter.Retrieve();
                }
            }
            #endregion
        }
    }
}

