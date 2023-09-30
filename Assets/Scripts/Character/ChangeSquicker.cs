using UnityEngine;

namespace Character
{
    public class ChangeSquicker : MonoBehaviour
    {
        public float switchTimeInSeconds = 4.0f;

        private GameObject lightSquicker;
        private GameObject darkSquicker;
        private int lightLayer = 6;
        private int darkLayer = 3;
        public float timePassed;
    
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                if (child.CompareTag("Player") && child.layer == lightLayer)
                    lightSquicker = child;
                else if (child.CompareTag("Player") && child.layer == darkLayer)
                    darkSquicker = child;
            }
        }

        // Update is called once per frame
        void Update()
        {
            timePassed += Time.deltaTime;
            if (timePassed > switchTimeInSeconds)
            {
                lightSquicker.SetActive(!lightSquicker.activeSelf);
                darkSquicker.SetActive(!darkSquicker.activeSelf);
                timePassed -= switchTimeInSeconds;
            }
        }
    }
}
