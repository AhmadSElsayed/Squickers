﻿using Scene;
using UnityEngine;

namespace Environment
{
    public class KillerSea : MonoBehaviour
    {
        public LevelManager levelManger;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                levelManger.LoseLevel();
            }
        }
    }
}
