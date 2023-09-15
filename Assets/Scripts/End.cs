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
                lightVictory.text = "YOU WIN!";
                darkVictory.text = "YOU SURVIVED!";
                StartCoroutine(WaitForSceneLoad("Level 2"));
            } else if (SceneManager.GetActiveScene().name == "Level 2")
            {
                lightVictory.text = "YOU WIN!";
                darkVictory.text = "YOU SURVIVED!";
                StartCoroutine(WaitForSceneLoad("Level 3"));
            } 
            else if (SceneManager.GetActiveScene().name == "Level 3")
            {
                lightVictory.text = "YOU WIN!";
                darkVictory.text = "YOU SURVIVED!";
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
        lightVictory.text = sceneName;
        darkVictory.text = sceneName;
        yield return new WaitForSeconds(2);
        lightVictory.text = "";
        darkVictory.text = "";
    }
}
