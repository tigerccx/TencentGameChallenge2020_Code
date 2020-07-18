using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto0
{
    public class MarkRope : MonoBehaviour
    {
        [SerializeField]
        float scaleX;
        [SerializeField]
        float scaleY;

        public Transform transMark;
        public Transform transChara;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public void Update()
        {
            Vector3 charaToMark = transMark.position - transChara.position;
            Vector3 pos = (transMark.position + transChara.position) / 2f;
            Vector3 rot = new Vector3(0, 0, 90 + Vector3.SignedAngle(Vector3.right, charaToMark, Vector3.forward));
            Vector3 scale = new Vector3(scaleX, scaleY * charaToMark.magnitude / 2, 1);

            transform.position = pos;
            transform.localScale = scale;
            transform.rotation = Quaternion.Euler(rot);
        }
    }

}
