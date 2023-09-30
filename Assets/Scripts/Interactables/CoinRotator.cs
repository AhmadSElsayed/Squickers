using UnityEngine;

namespace Interactables
{
    public class CoinRotator : MonoBehaviour
    {
        public float speed = 2;
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, speed, 0);
        }
    }
}
