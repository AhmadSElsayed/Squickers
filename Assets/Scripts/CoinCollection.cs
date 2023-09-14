using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private int Coin = 0;
    private int Key = 0;
    private PlayerState playerState;

    private void Start()
    {
        Debug.Log("started");
        playerState = GetComponent<PlayerState>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with: " + other.tag);
        if (other.transform.CompareTag("Coin"))
        {
            playerState.coinCount++;
            Destroy(other.gameObject);
        }
        
        if (other.transform.CompareTag("Key"))
        {
            Key++;
            Destroy(other.gameObject);
        }

        if (other.transform.CompareTag("Obstacle"))
        {
            if (Key == 0)
            {
                return;
            }
            Key--; 
            Destroy(other.gameObject);
        }
    }
}
