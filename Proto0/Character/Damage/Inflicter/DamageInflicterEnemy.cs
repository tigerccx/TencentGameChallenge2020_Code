using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class DamageInflicterEnemy : DamageInflicter
    {
        public float damage;

        public override float GetDamage()
        {
            return damage;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            DamageReceiverChara receiverChara = collision.gameObject.GetComponent<DamageReceiverChara>();
            if (receiverChara != null)
            {
                InflictDamage(receiverChara);
            }
        }
    }
}

