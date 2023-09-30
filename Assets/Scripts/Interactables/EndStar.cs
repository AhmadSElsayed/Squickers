using Scene;
using UnityEngine;

namespace Interactables
{
    public class EndStar : MonoBehaviour
    {
        public LevelManager levelManager;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                levelManager.WinLevel();
            }
        }
    }
}
