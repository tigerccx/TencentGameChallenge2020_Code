using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyFramework;

namespace Proto0
{
    public class NavigationHelper : MonoSingleton<NavigationHelper>
    {
        [SerializeField]
        Grid navigationGrid;
        public Grid NavigationGrid { get { return navigationGrid; } }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}

