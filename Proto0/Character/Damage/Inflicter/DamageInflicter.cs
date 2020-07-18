using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    //[RequireComponent(typeof(Collider2D))]
    public abstract class DamageInflicter : MonoBehaviour, IDamageInflicter
    {
        public event Action<float> eventOnDamageInflicted;

        public void InflictDamage(IDamageReceiver receiver)
        {
            float damage = GetDamage();
            receiver.ReceiveDamage(damage);
            eventOnDamageInflicted?.Invoke(damage);
        }

        public abstract float GetDamage();
    }
}

