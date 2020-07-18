using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public interface IManager
    {
        void Awake();
        void Start();
        void FixedUpdate();
        void Update();
        void LateUpdate();
        void Destroy();

    }
}

