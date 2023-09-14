using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public Text lightVictory;
    public Text darkVictory;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            lightVictory.text = "YOU WIN!";
            darkVictory.text = "YOU SURVIVED!";
            if (SceneManager.GetActiveScene().name == "ScratchScene")
            {
                StartCoroutine(WaitForSceneLoad("Level 1"));
            } else if (SceneManager.GetActiveScene().name == "Level 1")
            {
                StartCoroutine(WaitForSceneLoad("Level 1"));
            }
        }
    }
    private IEnumerator WaitForSceneLoad(string sceneName)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
    
    }
}
