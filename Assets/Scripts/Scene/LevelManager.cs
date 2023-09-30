using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

namespace Scene
{
    public class LevelManager : MonoBehaviour
    {
        public Text lightVictory;
        public Text darkVictory;
        private List<string> lights = new List<string>() {"Effort Shown!", "Keep Trying!", "Potential Seen!", "Well Done!"};
        private List<string> darks = new List<string>() {"Failure Faced!", "Mistakes Made!", "Try Harder!", "Dreams Unreached!"};

        private void Start()
        {
            StartCoroutine(LevelStartMessage(SceneManager.GetActiveScene().name));
        }
    
        public void WinLevel()
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
                StartCoroutine(WaitForSceneLoad("Credits"));
            }
        }
    
        public void LoseLevel()
        {
            var rand = new Random(Guid.NewGuid().GetHashCode());
            lightVictory.text = lights[rand.Next(0, lights.Count)];
            darkVictory.text = darks[rand.Next(0, darks.Count)];
            
            StartCoroutine(WaitForSceneLoad(SceneManager.GetActiveScene().name, 4));
        }
    
        private IEnumerator LevelStartMessage(string sceneName)
        {
            string lightW = "";
            string darkW = "";
        
            switch (sceneName)
            {
                case "Level 1":
                    lightW = "The Beginning";
                    darkW = "The End";
                    break;
            
                case "Level 2":
                    lightW = "The Challenge";
                    darkW = "The Despair";
                    break;
            
                case "Level 3":
                    lightW = "The Triumph";
                    darkW = "The Sacrifice";
                    break;
            }
        
            lightVictory.text = lightW;
            darkVictory.text = darkW;
            yield return new WaitForSeconds(2);
            lightVictory.text = "";
            darkVictory.text = "";
        }
    
        private IEnumerator WaitForSceneLoad(string sceneName, int seconds = 2)
        {
            yield return new WaitForSeconds(seconds);
            SceneManager.LoadScene(sceneName);
        }
    }
}
