using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class Ticker : MonoBehaviour
    {
        [SerializeField]
        TestUI ui;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            ui.ShowTime(Time.time);
        }
    }
}


