using System.Linq;
using Character;
using UnityEngine;

namespace Interactables
{
    public class Draggable : MonoBehaviour
    {
        public bool isDragging;
        private GameObject player;
        private bool isColliding;

        private Rigidbody rb;
        private PlayerState playerState;
        private Collider[] colliders;

        public void Start()
        {
            colliders = GetComponents<Collider>();
            player = GameObject.FindGameObjectWithTag("Player");
            playerState = player.GetComponent<PlayerState>();
            rb = GetComponent<Rigidbody>(); //rb equals the rigidbody on the player
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
    

        // Update is called once per frame
        void Update()
        {
            if (isDragging)
            {
                rb.useGravity = false;
                var position = player.transform.position;
                transform.position = new Vector3(position.x, position.y + 2, position.z + 3);
            }
            else
            {
                rb.useGravity = true;
            }
        
            if (isColliding)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (isDragging)
                    {
                        isDragging = false;
                        playerState.inventoryItem = null;
                        rb.angularVelocity = new Vector3(0f,0.0f,0f);
                        rb.velocity = new Vector3(0f,0f,0f); 
                        transform.rotation = Quaternion.Euler(new Vector3(0f,0f,0f));
                        colliders.Where(c => !c.isTrigger).ToList().ForEach(c => c.enabled = true);
                    }
                    else if (playerState.inventoryItem == null)
                    {
                        isDragging = true;
                        playerState.inventoryItem = gameObject;
                        rb.angularVelocity = new Vector3(0f,2.0f,0f);
                        rb.velocity = new Vector3(0f,0f,0f); 
                        transform.rotation = Quaternion.Euler(new Vector3(0f,0f,0f));
                        colliders.Where(c => !c.isTrigger).ToList().ForEach(c => c.enabled = false);
                    }
                }
            }
        }
    }
}
