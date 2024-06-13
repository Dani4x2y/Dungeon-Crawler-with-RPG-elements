using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRaycast : MonoBehaviour
{
    public GameObject crosshair;
    public float interactionDistance;
    public LayerMask layers;

    void Update()
    {
        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * interactionDistance;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, layers))
        {
            Door d = hit.collider.gameObject.GetComponentInParent<Door>();
            if (d != null)
            {
                Debug.Log("door component found");
                crosshair.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    d.openClose();
                }
            }
        }
        else
        {
            crosshair.SetActive(false);
        }
    }
}
