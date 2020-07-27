using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class Smoke : MonoBehaviour
    {
        public Animator animator;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            AnimatorStateInfo animatorInfo;
            animatorInfo = animator.GetCurrentAnimatorStateInfo(0);  //要在update获取
            if ((animatorInfo.normalizedTime > 1.0f) && (animatorInfo.IsName("Smoke")))//normalizedTime：0-1在播放、0开始、1结束 MyPlay为状态机动画的名字
            {
                Destroy(gameObject);
            }  
        }
    }
}

