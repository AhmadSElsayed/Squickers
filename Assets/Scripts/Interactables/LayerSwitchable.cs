using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSwitchable : MonoBehaviour
{
    public int lightLayer = 6;
    public int darkLayer = 3;
    public int curLayer = 0;

    private Rigidbody rigidBody;

    public void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (GetComponent<Draggable>().isDragging)
            {
                curLayer = gameObject.layer;

                if (curLayer == lightLayer)
                {
                    UpdateLayer(gameObject, darkLayer);
                }
                else if (curLayer == darkLayer)
                {
                    UpdateLayer(gameObject, lightLayer);
                }
            }
        }
    }

    public void UpdateLayer(GameObject o,int layer)
    {
        o.layer = layer;

        for (int i = 0; i < o.transform.childCount; i++)
        {
            GameObject child = o.transform.GetChild(i).gameObject;
            UpdateLayer(child, layer);
        }
    }
}
