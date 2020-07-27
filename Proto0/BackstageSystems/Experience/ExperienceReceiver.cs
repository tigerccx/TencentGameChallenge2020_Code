using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class ExperienceReceiver : MonoBehaviour
    {
        public void ReceiveExperience(DOExperience doExp)
        {
            ExperienceSystem.GetInstance().AccumulateExperience(doExp.exp);
        }
    }
}

