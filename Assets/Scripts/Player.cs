using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float groundDrag;
    public float playerHeight;
    public LayerMask ground;
    bool grounded;
    public Transform orientation;
    float horizontal;
    float vertical;
    Vector3 moveDir;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        Inputs();
        if (grounded)
        {
            rb.linearDamping = groundDrag;

        }
        else
        {
            rb.linearDamping = 0;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Inputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

    }

    private void Move()
    {
        moveDir = orientation.forward * vertical + orientation.right * horizontal;

        rb.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);
    }
}
