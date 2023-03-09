using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionZone : MonoBehaviour
{
    Camera camera;
    Ray ray;
    RaycastHit hit;
    Vector3 childPosition, childDefaultPosition;
    Lean.Touch.LeanDragTranslate dragObject;
    [SerializeField] Lean.Touch.LeanDragCamera dragCamera;

    private void Start()
    {
        camera = Camera.main;
        childDefaultPosition = transform.GetChild(0).position;
        dragObject = gameObject.GetComponent<Lean.Touch.LeanDragTranslate>();
    }
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponentInParent<Structure>() != null)
                {
                    dragCamera.enabled = false;
                    dragObject.enabled = true;
                }
                else
                {
                    dragCamera.enabled = true;
                    dragObject.enabled = false;
                }             
            }
            else
            {
                dragCamera.enabled = true;
                dragObject.enabled = false;
            }

            childPosition.x = Mathf.Round(transform.position.x);
            childPosition.y = 0;
            childPosition.z = Mathf.Round(transform.position.z);

            childPosition += childDefaultPosition;

            transform.GetChild(0).position = childPosition;
        }
        else
        {
            dragCamera.enabled = true;
            dragObject.enabled = false;
        }

        if (Input.GetButton("Jump"))
        {
            transform.GetChild(0).parent = null;
            Destroy(gameObject);
        }
    }
}
