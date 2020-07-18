using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public abstract class DamageReceiver : MonoBehaviour, IDamageReceiver
    {
        public event Action<float> eventOnDamaged;

        public void ReceiveDamage(float damage)
        {
            DoDamage(damage);
            eventOnDamaged?.Invoke(damage);
        }

        protected abstract void DoDamage(float damage);
    }
}

