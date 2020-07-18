using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class Test0 : MonoBehaviour
    {
        [SerializeField]
        GameObject prefabEnemy;

        bool frozen = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(2))
            {
                Vector3 posScreen = Input.mousePosition;
                Vector3 posW = Camera.main.ScreenToWorldPoint(posScreen);
                posW.z = 0;
                Instantiate(prefabEnemy, posW, Quaternion.identity);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
