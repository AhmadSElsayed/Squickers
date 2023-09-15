using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public Text lightVictory;
    public Text darkVictory;

    private void Start()
    {
        StartCoroutine(LevelStartMessage(SceneManager.GetActiveScene().name));
    }
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "Level 1")
            {
                lightVictory.text = "Goal Reached!";
                darkVictory.text = "Price Paid!";
                StartCoroutine(WaitForSceneLoad("Level 2"));
            } else if (SceneManager.GetActiveScene().name == "Level 2")
            {
                lightVictory.text = "Level Cleared!";
                darkVictory.text = "Soul Shattered!";
                StartCoroutine(WaitForSceneLoad("Level 3"));
            } 
            else if (SceneManager.GetActiveScene().name == "Level 3")
            {
                lightVictory.text = "Success Gained!";
                darkVictory.text = "Trust Broken!";
            }
        }
    }
    private IEnumerator WaitForSceneLoad(string sceneName)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
    }
    
    private IEnumerator LevelStartMessage(string sceneName)
    {
        string lights = "";
        string darks = "";
        
        switch (sceneName)
        {
            case "Level 1":
                lights = "The Beginning";
                darks = "The End";
                break;
            
            case "Level 2":
                lights = "The Challenge";
                darks = "The Despair";
                break;
            
            case "Level 3":
                lights = "The Triumph";
                darks = "The Sacrifice";
                break;
        }
        
        lightVictory.text = lights;
        darkVictory.text = darks;
        yield return new WaitForSeconds(2);
        lightVictory.text = "";
        darkVictory.text = "";
    }
}
