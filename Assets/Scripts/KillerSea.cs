using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class KillerSea : MonoBehaviour
{
    public Text lightVictory;
    public Text darkVictory;
    private List<string> lights = new List<string>() {"Effort Shown!", "Keep Trying!", "Potential Seen!", "Well Done!"};
    private List<string> darks = new List<string>() {"Failure Faced!", "Mistakes Made!", "Try Harder!", "Dreams Unreached!"};
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            var rand = new Random(Guid.NewGuid().GetHashCode());
            lightVictory.text = lights[rand.Next(0, lights.Count)];
            darkVictory.text = darks[rand.Next(0, darks.Count)];
            
            Destroy(other.gameObject);
            StartCoroutine(WaitForSceneLoad(SceneManager.GetActiveScene().name));
        }
        
    }
    
    private IEnumerator WaitForSceneLoad(string sceneName)
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(sceneName);
    }
}
