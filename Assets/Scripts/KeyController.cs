using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public int lightLayer = 6;
    public int darkLayer = 3;
    public int bothLayers = 7;

    public void OnTriggerStay(Collider other)
    {
        var isDragging = GetComponent<Draggable>().isDragging;
        if (isDragging && other.transform.CompareTag("Door"))
        {
            var opennableComponent = other.gameObject.GetComponent<Opennable>();
            var componentLayer = other.gameObject.transform.childCount > 1 ? bothLayers :
                other.gameObject.transform.GetChild(0).gameObject.layer;

            if (!opennableComponent.IsOpen() && opennableComponent.openByKey && gameObject.layer == componentLayer)
            {
                opennableComponent.Open();
                Destroy(gameObject);
            }
        }
    }
}
