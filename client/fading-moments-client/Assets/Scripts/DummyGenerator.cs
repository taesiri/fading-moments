using UnityEngine;

namespace Assets.Scripts
{
    public class DummyGenerator : MonoBehaviour
    {
        public GameObject DummyObject;
        public int Height;
        public int Width;
        public int Dist;


        private void Start()
        {
            var offsetX = Dist*Width/2f;
            var offsetZ = Dist*Height/2f;

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    var go = Instantiate(DummyObject, new Vector3(i*Dist - offsetX, 0, j*Dist - offsetZ), Quaternion.identity) as GameObject;

                    go.transform.parent = transform;
                }
            }
        }

        private void Update()
        {
        }
    }
}