using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class DamageInflicterMark : DamageInflicter
    {
        public float damage;

        public override float GetDamage()
        {
            return damage;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            DamageReceiverEnemy receiver = collision.gameObject.GetComponent<DamageReceiverEnemy>();
            if (receiver != null)
            {
                print("DAMAGE");
                InflictDamage(receiver);
            }
        }
    }
}

