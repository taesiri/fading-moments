using UnityEngine;

namespace Assets.Scripts
{
    public class SelfRotate : MonoBehaviour
    {
        public float Speed = 10.0f;


        public bool UseCurve = false;

        public AnimationCurve AnimateCurve;

        public bool XAxis = true;
        public bool YAxis = true;
        public bool ZAxis = true;

        private void Start()
        {

        }

        private void Update()
        {
            if (UseCurve)
            {
                if (YAxis)
                    transform.Rotate(Vector3.up, AnimateCurve.Evaluate(Time.time));
                if (XAxis)
                    transform.Rotate(Vector3.right, AnimateCurve.Evaluate(Time.time));
                if (ZAxis)
                    transform.Rotate(Vector3.back, AnimateCurve.Evaluate(Time.time));
            }
            else
            {
                if (YAxis)
                    transform.Rotate(Vector3.up, Speed*Time.deltaTime);
                if (XAxis)
                    transform.Rotate(Vector3.right, Speed*Time.deltaTime/2.0f);
                if (ZAxis)
                    transform.Rotate(Vector3.back, Speed*Time.deltaTime/4.0f);
            }
        }
    }
}