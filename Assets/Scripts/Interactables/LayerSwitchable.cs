using UnityEngine;

namespace Interactables
{
    public class LayerSwitchable : MonoBehaviour
    {
        private int lightLayer = 6;
        private int darkLayer = 3;
        private int curLayer;

        private Draggable draggable;

        public void Start()
        {
            draggable = GetComponent<Draggable>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (draggable.isDragging)
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
}
