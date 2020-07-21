using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class SlowTimeZone : MonoBehaviour
    {
        public float magSpeed = 0.5f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Handle time zone entering effect
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            TimeZoneEffectController tzec = collision.gameObject.GetComponent<TimeZoneEffectController>();
            if (tzec != null)
            {
                tzec.OnEnterTimeZone(this);
            }
        }

        /// <summary>
        /// Handle time zone exiting effect
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerExit2D(Collider2D collision)
        {
            TimeZoneEffectController tzec = collision.gameObject.GetComponent<TimeZoneEffectController>();
            if (tzec != null)
            {
                tzec.OnExitTimeZone(this);
            }
        }
    }
}

