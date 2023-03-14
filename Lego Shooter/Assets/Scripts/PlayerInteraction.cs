using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float pickUpDistance = 2f;
    [SerializeField] string gunTag;
    [SerializeField] Transform carryPos;
    Transform currentObject;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickUpDistance))
        {
            if (hit.transform.tag == gunTag)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentObject = Instantiate(hit.transform);
                    currentObject.parent = carryPos;
                    currentObject.localPosition = Vector3.zero;
                }
            }
        }
        if (currentObject != null && Input.GetKeyDown(KeyCode.E))
        {
            currentObject.parent = null;
            currentObject = null;
        }
    }
}
