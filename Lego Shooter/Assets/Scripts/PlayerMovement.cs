using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] KeyCode forward;
    [SerializeField] KeyCode backward;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode sprint;
    [SerializeField] float speed;
    [SerializeField] float sprintSpeed;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();
        if (Input.GetKey(forward))
        {
            movement += Vector3.ProjectOnPlane(transform.forward, Vector3.up);
        }
        if (Input.GetKey(backward))
        {
            movement -= Vector3.ProjectOnPlane(transform.forward, Vector3.up);
        }
        if (Input.GetKey(left))
        {
            movement -= Vector3.ProjectOnPlane(transform.right, Vector3.up);
        }
        if (Input.GetKey(right))
        {
            movement += Vector3.ProjectOnPlane(transform.right, Vector3.up);
        }
        if (Input.GetKey(sprint))
        {
            movement = movement.normalized * sprintSpeed;
        }
        else
        {
            movement = movement.normalized * speed;
        }
        transform.position += new Vector3(movement.x, 0, movement.z) * Time.deltaTime;
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }
}
