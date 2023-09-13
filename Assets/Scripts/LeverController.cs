using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public bool doorOpen = false;
    public GameObject door;
    private Animator animator;
    private bool isColliding = false;

    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            isColliding = true;
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            isColliding = false;
        }
    }

    public void Update()
    {
        if (isColliding)
        {
            if (Input.GetKeyDown(KeyCode.E) && doorOpen == false)
            {
                doorOpen = true;
                door.GetComponent<Opennable>().Open();
                
                if (animator != null)
                {
                    animator.SetBool("IsActivated", true);
                }
            }
        }
    }
}
