using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Proto0
{
    public class TestUI : MonoBehaviour
    {
        public Text txtDamage;
        public Text txtSecond;
        public Text txtExp;
        public Text txtStage;

        float damageDone = 0;

        public void ShowDamage(float damage)
        {
            damageDone += damage;
            txtDamage.text = damageDone.ToString();
        }

        public void ShowTime(float sec)
        {
            txtSecond.text = sec.ToString();
        }

        public void ShowExperience(float expTotal, float expDiff)
        {
            txtExp.text = expTotal.ToString();
        }

        public void ShowExperienceStage(float expTotal, float expStage)
        {
            txtStage.text = expStage.ToString();
        }
    }
}

