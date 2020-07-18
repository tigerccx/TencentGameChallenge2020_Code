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
        GameObject goZone;
        [SerializeField]
        Collider2D colider;
        [SerializeField]
        DamageInflicterMark inflicter;

        [SerializeField]
        bool toLimitActiveTime = false;
        float durTempActive = 0;
        public float durActive = 3;

        public event Action eventOnActivated;
        public event Action eventOnDeactivated;

        //
        // States
        //
        private bool isDeploying = false;
        public bool IsDeploying { get { return isDeploying; } }

        private bool isActive = false;
        public bool IsActive { get { return isActive; } }

        private bool isRetrieving = false;
        public bool IsRetrieving { get { return isRetrieving; } }

        //
        // Timing
        //
        private float durLeft;
        private float durTemp;

        [NonSerialized]
        public Transform transMarkShooter;
        public event Action eventOnRetrieved;

        public float durDeploy = 0.5f;
        public float durRetrieve = 0.3f;

        // Start is called before the first frame update
        void Start()
        {
            goZone.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (isRetrieving)
            {
                durTemp += Time.deltaTime;
                MoveBackProcess();
            }

            if (toLimitActiveTime)
            {
                if (isActive)
                {
                    durTempActive += Time.deltaTime;
                    if (durTempActive >= durActive)
                    {
                        MoveBack();
                    }
                }
            }
        }

        public void MoveTowards(Vector3 posW)
        {
            MoveTowards(posW, durDeploy);
        }

        public void MoveTowards(Vector3 posW, float durTime)
        {
            isDeploying = true;
            PropertyAnimationManager.GetInstance().StartAnimatingPropertyVector3(transform, "position", (val) => { transform.position = val; }, () => { return transform.position; }, transform.position, posW, durTime,
                null, null, null, CallbackOnMovingEnd);
        }

        public void BounceBack()
        {
            PropertyAnimationManager.GetInstance().EndAnimatingPropertyVector3(transform, "position", PropertyAnimationManager.EndPropertyState.Keep);
        }

        private void CallbackOnMovingEnd(PropertyAnimationManager.EndPropertyState state)
        {
            isDeploying = false;
            if (state == PropertyAnimationManager.EndPropertyState.Targ)
            {
                goZone.SetActive(true);
                isActive = true;
                eventOnActivated?.Invoke();
            }
            else if(state == PropertyAnimationManager.EndPropertyState.Keep)
            {
                colider.enabled = false;
                MoveBack();
            }
        }

        public void MoveBack()
        {
            MoveBack(durRetrieve);
        }

        public void MoveBack(float durTime)
        {
            isActive = false;
            durTempActive = 0f;
            isRetrieving = true;
            eventOnDeactivated?.Invoke();
            durLeft = durTime;
            durTemp = 0f;
            Vector3 pos = transMarkShooter.position;

            MoveBackTowards(pos, durTime);
        }

        private void MoveBackTowards(Vector3 posW, float durTime)
        {
            goZone.SetActive(false);
            PropertyAnimationManager.GetInstance().StartAnimatingPropertyVector3(transform, "position", (val) => { transform.position = val; }, () => { return transform.position; }, transform.position, posW, durTime,
                null, null, null, CallbackOnMovingBackEnd);
        }

        private void MoveBackProcess()
        {
            PropertyAnimationManager.GetInstance().EndAnimatingPropertyVector3(transform, "position", PropertyAnimationManager.EndPropertyState.Keep);
        }

        private void CallbackOnMovingBackEnd(PropertyAnimationManager.EndPropertyState state)
        {
            if(state == PropertyAnimationManager.EndPropertyState.Keep)
            {
                //print("R Pause");
                durLeft -= durTemp;
                durTemp = 0f;
                Vector3 pos = transMarkShooter.position;
                MoveBackTowards(pos, durLeft);
            }
            else if(state == PropertyAnimationManager.EndPropertyState.Targ)
            {
                //print("R ENDDDDDDDDDDDDDDDDDDDDDD");
                durLeft = 0;
                durTemp = 0;
                isRetrieving = false;
                colider.enabled = true;
                eventOnRetrieved?.Invoke();
            }
            else
            {
                print("不可能存在Src的啊");
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                if (isDeploying)
                {
                    BounceBack();
                    inflicter.enabled = false;
                }
                //if (isRetrieving)
                //{
                //    print("DAMAGE!!!!!");
                //    Destroy(collision.gameObject); // TEST
                //}
                //if (isDeploying && isRetrieving)
                //{
                //    print("????????????????????????????????????/");
                //}
            }

            //Wall wall = collision.gameObject.GetComponent<Wall>();
            //if (wall != null)
            //{
            //    Destroy(collision.gameObject);
            //    if (isDeploying)
            //    {
            //        print("Wall Boom!");
            //        BounceBack();
            //    }
            //    if (isRetrieving)
            //    {
            //        print("WALL BOOOOOOMMMMMMMM!!!!!");
            //    }
            //    if (isDeploying && isRetrieving)
            //    {
            //        print("????????????????????????????????????/");
            //    }
            //}
        }
    }
}

