using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] GameObject followObject;


    // Update is called once per frame

    private void FixedUpdate()
    {
        transform.position = followObject.transform.position + offset;
    }
}