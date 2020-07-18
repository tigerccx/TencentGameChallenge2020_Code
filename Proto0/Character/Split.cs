using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Proto0
{
    public class Split : MonoBehaviour
    {
        public float durSplit = 5;
        private float durTemp;
        [SerializeField]
        private bool toDestroyAfterSplit = true;
        [SerializeField]
        private float dueSplitScaleAfterSplitting = 1;
        //[SerializeField]
        private float timeScale = 1;

        public int countSplit;
        public GameObject prefabSplit;
        private float disSpawn = 3f;


        System.Random random;

        // Start is called before the first frame update
        void Start()
        {
            durTemp = 0;
            random = new System.Random();
        }

        // Update is called once per frame
        void Update()
        {
            durTemp += Time.deltaTime * timeScale;
            {
                if (durTemp >= durSplit)
                {
                    DoSplit();
                    durTemp = 0;
                    if (toDestroyAfterSplit)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }

        public void DoSplit()
        {
            for(int i = 0; i < countSplit; ++i)
            {
                Vector3 pos = new Vector2((float)random.NextDouble()*2-1, (float)random.NextDouble()*2-1);
                pos += transform.position;
                GameObject goNew = GameObject.Instantiate(prefabSplit, pos, Quaternion.identity);
                var split = goNew.GetComponent<Split>();
                if (split != null)
                {
                    split.durSplit = durSplit * dueSplitScaleAfterSplitting;
                }
            }
        }

        public void SetTimeScale(float scale)
        {
            timeScale = scale;
        }

        public float GetTimeScale()
        {
            return timeScale;
        }
    }
}

