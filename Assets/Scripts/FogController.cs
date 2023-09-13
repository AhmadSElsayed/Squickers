using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    public bool FogEnabled = false;
    private bool prevState = false;

    void OnPreRender()
    {
        prevState = RenderSettings.fog;
        RenderSettings.fog = FogEnabled;
    }

    void OnPostRender()
    {
        RenderSettings.fog = prevState;
    }
}