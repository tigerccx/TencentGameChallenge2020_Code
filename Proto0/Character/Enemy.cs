using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        CharacterController controller;
        public float maxDis;
        float sqrMaxDis;
        public float minDis;
        float sqrMinDis;

        public bool isTrackingMainChara = true;

        Transform transChara;

        // Start is called before the first frame update
        void Start()
        {
            transChara = GameObject.FindGameObjectWithTag("MainChara").transform;
            sqrMaxDis = maxDis * maxDis;
            sqrMinDis = minDis * minDis;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 thisToMainChara = transChara.position - transform.position;
            thisToMainChara.z = 0;
            float sqrDis = thisToMainChara.sqrMagnitude;
            if (sqrDis > sqrMinDis && sqrDis < sqrMaxDis)
            {
                thisToMainChara = thisToMainChara.normalized * Time.deltaTime;
                controller.Move(thisToMainChara);
            }
        }
    }
}

