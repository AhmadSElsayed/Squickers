using UnityEngine;

namespace Interactables
{
    public class LeverController : MonoBehaviour
    {
        public bool doorOpen;
        public GameObject door;
        private Animator animator;
        private bool isColliding;
        private string activateAnimString = "Activate";
        private Opennable opennable;
        private bool isanimatorNotNull;

        public void Start()
        {
            isanimatorNotNull = animator != null;
            opennable = door.GetComponent<Opennable>();
            animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
        }
    
        public void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Player"))
            {
                isColliding = true;
            }
        }
    
        public void OnTriggerExit(Collider other)
        {
            if (other.transform.CompareTag("Player"))
            {
                isColliding = false;
            }
        }

        public void Update()
        {
            if (isColliding)
            {
                if (Input.GetKeyDown(KeyCode.E) && doorOpen == false)
                {
                    doorOpen = true;
                    opennable.Open();
                
                    if (isanimatorNotNull)
                    {
                        animator.SetTrigger(activateAnimString);
                    }
                }
            }
        }
    }
}
