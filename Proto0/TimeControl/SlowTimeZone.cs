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
            TimeZoneSlowable slowable = collision.gameObject.GetComponent<TimeZoneSlowable>();
            if (slowable != null)
            {
                ISpeedChangable sc = collision.gameObject.GetComponent<ISpeedChangable>();
                if (sc != null)
                {
                    sc.SetSpeed(sc.GetSpeed() * magSpeed);
                }
            }

            Split spt = collision.gameObject.GetComponent<Split>();
            if (spt != null)
            {
                spt.SetTimeScale(spt.GetTimeScale() * magSpeed);
            }
        }

        /// <summary>
        /// Handle time zone exiting effect
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerExit2D(Collider2D collision)
        {
            TimeZoneSlowable slowable = collision.gameObject.GetComponent<TimeZoneSlowable>();
            if (slowable != null)
            {
                ISpeedChangable sc = collision.gameObject.GetComponent<ISpeedChangable>();
                if (sc != null)
                {
                    sc.SetSpeed(sc.GetSpeed() / magSpeed);
                }
            }

            Split spt = collision.gameObject.GetComponent<Split>();
            if (spt != null)
            {
                spt.SetTimeScale(spt.GetTimeScale() / magSpeed);
            }
        }
    }
}

