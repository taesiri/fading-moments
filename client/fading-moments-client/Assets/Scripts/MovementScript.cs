using UnityEngine;

namespace Assets.Scripts
{
    public class MovementScript : MonoBehaviour
    {
        public float GlobalSpeed;

        private bool _isStarted = false;
        private bool _isStartedF1 = false;
        private bool _isStartedF2 = false;
        private Vector2 _initialPosition;

        public Camera MainCam;

        private void Start()
        {
            if (!MainCam)
            {
                MainCam = Camera.main;
            }
        }

        private void Update()
        {
            HandleTouchInputs();
        }

        private void HandleTouchInputs()
        {
            if (Input.touchCount == 1)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    _isStarted = true;
                    _initialPosition = Input.touches[0].position;
                }
                else if (Input.touches[0].phase != TouchPhase.Ended)
                {
                    var deltaX = Input.touches[0].deltaPosition.y;

                    MainCam.transform.Translate(Vector3.forward*deltaX*GlobalSpeed*Time.deltaTime);
                }
                else if (Input.touches[0].phase == TouchPhase.Ended)
                {
                    _isStarted = false;
                }
            }
            else if (Input.touchCount == 2)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    _isStartedF1 = true;
                }
                if (Input.touches[1].phase == TouchPhase.Began)
                {
                    _isStartedF2 = true;
                }

                if (Input.touches[0].phase != TouchPhase.Ended && Input.touches[1].phase != TouchPhase.Ended)
                {
                    var deltaF1 = Input.touches[0].deltaPosition.x;
                    var deltaF2 = Input.touches[1].deltaPosition.x;

                    if (Mathf.Abs(deltaF1 - deltaF2) < 2f)
                    {
                        MainCam.transform.Rotate(Vector3.up, deltaF1*Time.deltaTime*GlobalSpeed);
                    }
                }


                if (Input.touches[0].phase == TouchPhase.Ended)
                {
                    _isStartedF1 = false;
                }
                if (Input.touches[1].phase == TouchPhase.Ended)
                {
                    _isStartedF2 = false;
                }
            }
        }
    }
}