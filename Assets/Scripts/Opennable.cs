using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opennable : MonoBehaviour
{
    public bool isOpen = false;
    public float animationSpeed = 50.0f;
    public float maxDegree = 90.0f;
    public bool invertDirection = false;
    
    private float curDegree = 0f;
    
    public void Open()
    {
        isOpen = true;
    }

    public void Update()
    {
        if (!isOpen || !(invertDirection ? (curDegree > -1 * maxDegree) : (curDegree < maxDegree))) return;
        
        float dir = invertDirection ? -1 : 1;
        var changeValue = animationSpeed * Time.deltaTime * dir;
        curDegree += changeValue;
        transform.Rotate(new Vector3(0, 1, 0), changeValue);
    }
}
