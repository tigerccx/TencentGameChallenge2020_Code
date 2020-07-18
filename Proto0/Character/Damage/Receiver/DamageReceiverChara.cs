using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class DamageReceiverChara : DamageReceiver
    {
        public TestUI ui;

        private float damage = 0;

        // Start is called before the first frame update
        void Start()
        {
            eventOnDamaged += ui.ShowDamage;
        }

        // Update is called once per frame
        void Update()
        {

        }

        protected override void DoDamage(float damage)
        {
            
        }
    }
}

