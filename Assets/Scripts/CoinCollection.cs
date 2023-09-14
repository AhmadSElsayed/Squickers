using UnityEngine;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour
{
    private PlayerState playerState;
    public Text ScoreUI;

    private void Start()
    {
        Debug.Log("started");
        playerState = GetComponent<PlayerState>();
        ScoreUI.text = "Coins: " + playerState.coinCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with: " + other.tag);
        if (other.transform.CompareTag("Coin"))
        {
            playerState.coinCount++;
            ScoreUI.text = "Coins: " + playerState.coinCount;
            Destroy(other.gameObject);
        }
        
    }
}
