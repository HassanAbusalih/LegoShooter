using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float pickUpDistance = 2f;
    [SerializeField] string wallTag;
    [SerializeField] string pickedUpTag;
    [SerializeField] GameObject carryPos;
    [SerializeField] GameObject hoverText;
    Vector3 originalScale;
    GameObject currentObject;

    void Update()
    {
        RaycastHit hit;
        hoverText.SetActive(false);
        if (currentObject != null && Input.GetKeyDown(KeyCode.E))
        {
            if (currentObject.tag == wallTag)
            {
                currentObject.tag = pickedUpTag;
            }
            Drop(currentObject.GetComponent<Rigidbody>(), currentObject.GetComponent<Collider>());
            //currentObject.transform.parent = null;
            currentObject = null;
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit, pickUpDistance))
        {
            if (hit.transform.tag == wallTag)
            {
                hoverText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentObject = Instantiate(hit.transform.gameObject, carryPos.transform.position, carryPos.transform.rotation);
                    originalScale = currentObject.transform.localScale;
                    PickUp(currentObject.GetComponent<Rigidbody>(), currentObject.GetComponent<Collider>());
                    //currentObject.transform.SetParent(carryPos.transform);
                }
            }
            else if (hit.transform.tag == pickedUpTag)
            {
                hoverText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Destroy(hit.transform.gameObject);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentObject = hit.transform.gameObject;
                    originalScale = currentObject.transform.localScale;
                    PickUp(currentObject.GetComponent<Rigidbody>(), currentObject.GetComponent<Collider>());
                    //currentObject.transform.SetParent(carryPos.transform);
                }
            }
        }
        if (currentObject != null)
        {
            currentObject.transform.position = carryPos.transform.position;
            currentObject.transform.localScale = originalScale;
            currentObject.transform.forward = transform.up;
            currentObject.transform.rotation = transform.rotation;
        }
    }

    void Drop(Rigidbody rb, Collider collider)
    {
        rb.isKinematic = false;
        collider.enabled = true;
    }

    void PickUp(Rigidbody rb, Collider collider)
    {
        rb.isKinematic = true;
        collider.enabled = false;
    }
}
