using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Proto0
{
    public interface IDamageInflicter
    {
        event Action<float> eventOnDamageInflicted;

        float GetDamage();
    }
}

