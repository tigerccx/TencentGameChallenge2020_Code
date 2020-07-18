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
    }
}

