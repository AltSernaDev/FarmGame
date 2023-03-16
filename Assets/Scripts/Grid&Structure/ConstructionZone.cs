using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider))]
public class ConstructionZone : MonoBehaviour
{
    Camera camera;
    Lean.Touch.LeanDragTranslate dragObject;
    Lean.Touch.LeanDragCamera dragCamera;

    Ray ray;
    RaycastHit hit;

    Vector3 childPosition, childDefaultPosition, traslatePosition;
    int[] size; 
    GridManager gridManager;

    private void Start()
    {
        camera = Camera.main;
        gridManager = GridManager.Instance;
        childDefaultPosition = transform.GetChild(0).position;
        dragCamera = camera.gameObject.GetComponentInParent<Lean.Touch.LeanDragCamera>();
        dragObject = gameObject.GetComponent<Lean.Touch.LeanDragTranslate>();

        //SetBoxCollider();
    }

    private void LateUpdate()
    {
        Grid();
    }

    private void Update()
    {
        FixPosition();

        if (Input.GetButton("Fire1"))
        {
            ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponentInParent<ConstructionZone>() != null)
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
        }
    }

    public void Construct()
    {
        dragCamera.enabled = true;
        dragObject.enabled = false;

        //gridManager.PositionToCell(transform.GetChild(0).position);
        Destroy(gameObject.GetComponentInChildren<Canvas>().gameObject);
        transform.GetChild(0).parent = null;
        Destroy(gameObject);
    }
    public void Cancel()
    {
        dragCamera.enabled = true;
        dragObject.enabled = false;

        Destroy(gameObject.GetComponentInChildren<Canvas>().gameObject);
        Destroy(gameObject);
    }

    private void SetBoxCollider()
    {
        size = gameObject.GetComponentInChildren<Structure>().structureSo.size;

        gameObject.GetComponent<BoxCollider>().size = new Vector3(size[0], 1, size[1]);
        gameObject.GetComponent<BoxCollider>().center = new Vector3(size[0] / 2, 0.5f, size[1] / 2);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    private void Grid()
    {
        childPosition.x = Mathf.Round(transform.position.x);
        childPosition.y = 0;
        childPosition.z = Mathf.Round(transform.position.z);

        childPosition += childDefaultPosition;

        transform.GetChild(0).position = childPosition;
    }
    private void FixPosition()
    {
        traslatePosition.x = gameObject.transform.position.x;
        traslatePosition.y = 0;
        traslatePosition.z = gameObject.transform.position.z + gameObject.transform.position.y;

        gameObject.transform.position = traslatePosition;
    }
}
