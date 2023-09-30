using UnityEngine;
using UnityEngine.UI;

namespace Character
{
    public class CoinCollection : MonoBehaviour
    {
        private PlayerState playerState;
        public Text scoreUI;

        private void Start()
        {
            Debug.Log("started");
            playerState = GetComponent<PlayerState>();
            if (scoreUI != null)
            {
                scoreUI.text = "Coins: " + playerState.coinCount;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Collided with: " + other.tag);
            if (other.transform.CompareTag("Coin"))
            {
                playerState.coinCount++;
                if (scoreUI != null)
                {
                    scoreUI.text = "Coins: " + playerState.coinCount;
                }
                Destroy(other.gameObject);
            }
        
        }
    }
}
