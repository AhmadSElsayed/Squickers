using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Interactables
{
    public class Hinter : MonoBehaviour
    {
        public Text lightText;
        public Text darkText;
        public string message;
        public int hintTimer = 3;
        private bool shown;
        public KeyCode triggerKey = KeyCode.E;
        private bool islightTextNotNull;
        private bool isdarkTextNotNull;

        private void Start()
        {
            isdarkTextNotNull = darkText != null;
            islightTextNotNull = lightText != null;
        }

        private void Update()
        {
            if (Input.GetKeyDown(triggerKey))
            {
                if (islightTextNotNull)
                {
                    lightText.text = "";
                }

                if (isdarkTextNotNull)
                {
                    darkText.text = "";
                }
            }
        
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Player") && !shown)
            {
                if (islightTextNotNull)
                {
                    lightText.text = message;
                }
                if (isdarkTextNotNull)
                {
                    darkText.text = message;
                }
                shown = true;
                StartCoroutine(ShowHint(hintTimer));
            }
        }
        private IEnumerator ShowHint(int timer)
        {
            yield return new WaitForSeconds(timer);
            if (islightTextNotNull)
            {
                lightText.text = "";
            }
            if (isdarkTextNotNull)
            {
                darkText.text = "";
            }
    
        }
    }
}
