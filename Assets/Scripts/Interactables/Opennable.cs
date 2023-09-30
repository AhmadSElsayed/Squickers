using Character;
using UnityEngine;

namespace Interactables
{
    public class Opennable : MonoBehaviour
    {
        public bool openByCoins;
        public int coinsAmount;

        public bool openByKey;


        public float animationSpeed = 50.0f;
        public float maxDegree = 90.0f;
        public bool invertDirection;
    
        private float curDegree;
        private bool isOpen;
        private PlayerState playerInventory;

        public void Start()
        {
            playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
        }

        public void Open()
        {
            isOpen = true;
        }

        public bool IsOpen()
        {
            return isOpen;
        }

        public void Update()
        {
            if (!isOpen && openByCoins)
            {
                if (playerInventory.coinCount >= coinsAmount)
                {
                    isOpen = true;
                }
            }

            if (!isOpen || !(invertDirection ? (curDegree > -1 * maxDegree) : (curDegree < maxDegree))) return;
        
            float dir = invertDirection ? -1 : 1;
            var changeValue = animationSpeed * Time.deltaTime * dir;
            curDegree += changeValue;
            transform.Rotate(new Vector3(0, 1, 0), changeValue);
        }
    }
}
