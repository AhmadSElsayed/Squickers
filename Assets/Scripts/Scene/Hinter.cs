using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hinter : MonoBehaviour
{
    public Text LightText;
    public Text DarkText;
    public string Message;
    public int HintTimer = 3;
    private bool shown = false;
    public KeyCode triggerKey = KeyCode.E;

    private void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            if (LightText != null)
            {
                LightText.text = "";
            }

            if (DarkText != null)
            {
                DarkText.text = "";
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && !shown)
        {
            if (LightText != null)
            {
                LightText.text = Message;
            }
            if (DarkText != null)
            {
                DarkText.text = Message;
            }
            shown = true;
            StartCoroutine(ShowHint(HintTimer));
        }
    }
    private IEnumerator ShowHint(int timer)
    {
        yield return new WaitForSeconds(timer);
        if (LightText != null)
        {
            LightText.text = "";
        }
        if (DarkText != null)
        {
            DarkText.text = "";
        }
    
    }
}
