using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool isDragging = false;
    private GameObject player;
    private bool isColliding = false;

    private Rigidbody rb;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>(); //rb equals the rigidbody on the player
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
    

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            rb.useGravity = false;
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z + 3);
        }
        else
        {
            rb.useGravity = true;
        }
        
        if (isColliding)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isDragging = !isDragging;
                
                rb.angularVelocity = new Vector3(0f,isDragging ? 2.0f : 0.0f,0f);
                rb.velocity = new Vector3(0f,0f,0f); 
                transform.rotation = Quaternion.Euler(new Vector3(0f,0f,0f));
            }
        }
    }
}
