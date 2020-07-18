using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public interface IDamageReceiver
    {
        event Action<float> eventOnDamaged;

        void ReceiveDamage(float damage);
    }
}

