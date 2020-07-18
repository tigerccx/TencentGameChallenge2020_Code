using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class DamageReceiverEnemy : DamageReceiver
    {
        protected override void DoDamage(float damage)
        {
            GameObject.Destroy(gameObject);
        }
    }
}

