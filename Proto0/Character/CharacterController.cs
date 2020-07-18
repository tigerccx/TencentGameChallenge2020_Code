using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Proto0
{
    public class CharacterController : MonoBehaviour
    {
        [NonSerialized]
        public float magSpeed = 1;
        public float speed;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Move(Vector3 dir)
        {
            Vector3 movement = dir * speed * magSpeed;
            transform.Translate(movement);
        }
    }

}
