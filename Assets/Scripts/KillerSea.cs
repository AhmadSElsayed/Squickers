using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KillerSea : MonoBehaviour
{
    public Text lightVictory;
    public Text darkVictory;
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            lightVictory.text = "You Lose!";
            darkVictory.text = "You Can't Swim!";
            Destroy(other.gameObject);
            StartCoroutine(WaitForSceneLoad(SceneManager.GetActiveScene().name));
        }
        
    }
    
    private IEnumerator WaitForSceneLoad(string sceneName)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
