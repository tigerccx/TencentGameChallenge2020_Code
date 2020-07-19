using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using MyFramework;

namespace Proto0
{
    public class Mark : MonoBehaviour
    {
        [SerializeField]
        private GameObject goZone;
        public GameObject GoZone { get => goZone; }
        [SerializeField]
        private Collider2D colliderMark;
        public Collider2D ColliderMark { get => colliderMark;}
        [SerializeField]
        private DamageInflicterMark inflicter;
        public DamageInflicterMark Inflicter { get => inflicter;}
        [SerializeField]
        private StateMachineMark smMark;

        //
        // Limit time of activeness
        //
        public bool toLimitActiveTime = false;
        float durTempActive = 0;
        public float durActive = 3;

        //
        // Events
        //
        public Action onDeploying; // When mark is (created) and begins to deploy.
        public Action onActivated; // When mark has successfully reached the position and activated.
        public Action onRetrieving; // When mark starts being retrieved
        public Action onDeactivated; // When mark is deactivated and starts to be retrieved.
        public Action onRetrieved; // When mark has been retrieved.
        public Action onBouncingBack; // When mark bounces back.
        public Action onBouncedBack; // When mark has bounced back

        ////
        //// States
        ////
        //private bool isDeploying = false;
        //public bool IsDeploying { get { return isDeploying; } } // True during deploying.

        //private bool isActive = false;
        //public bool IsActive { get { return isActive; } } // True during state of activeness.

        //private bool isRetrieving = false;
        //public bool IsRetrieving { get { return isRetrieving; } } // True during retrieving.

        //private bool isBouncingBack = false;
        //public bool IsBouncingBack { get { return isBouncingBack; } } // True during bouncing back.



        //
        // Timing
        //
        private float durLeft;
        private float durTemp;

        public float durDeploy = 0.5f;
        public float durRetrieve = 0.3f;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}

