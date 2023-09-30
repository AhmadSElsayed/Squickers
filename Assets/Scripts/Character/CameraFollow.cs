using Unity.VisualScripting;
using UnityEngine;

namespace Character
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] Vector3 offset;
        [SerializeField] GameObject followObject;


        // Update is called once per frame

        private void FixedUpdate()
        {
            if (!followObject.IsDestroyed())
            {
                transform.position = followObject.transform.position + offset;
            }
        }
    }
}