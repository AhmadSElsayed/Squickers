using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class MainMenu : MonoBehaviour
    {

        public void NewGame()
        {
            SceneManager.LoadScene("Level 1");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
