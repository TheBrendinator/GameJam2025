using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int damage { get; set; } = 50; // Remove this before merging!
    public float speed;
    public float groundDrag;
    public float playerHeight;
    public LayerMask ground;
    public bool grounded;
    public Transform orientation;
    float horizontal;
    float vertical;
    Vector3 moveDir;
    Rigidbody rb;

    public float jumpForce;
    public float airMultiplier;
    public bool canJump = true;
    public float jumpCooldown;

    bool canDash;
    public float dashForce;
    public bool isDashing;
    private float regularSpeed;
    public float maxSpeed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    void Update()
    {
        
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        Inputs();

        if (isDashing)
        {
            maxSpeedClamp();
        }
        else
        {
            speedClamp();
        }
        if (grounded)
        {
            rb.linearDamping = groundDrag;
            Invoke(nameof(dashCooldown), 1f);
            Invoke(nameof(resetDash), 0.2f);

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
        if (Input.GetKey(KeyCode.Space) && grounded && canJump)
        {
            canJump = false;
            Jump();
            Invoke(nameof(resetJump), jumpCooldown);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            CancelInvoke(nameof(dashCooldown));
            CancelInvoke(nameof(resetDash));
            dash();
            isDashing = true;
            canDash = false;
        }
    }

    private void Move()
    {
        moveDir = orientation.forward * vertical + orientation.right * horizontal;

        if (grounded)
        {
            rb.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDir.normalized * speed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void speedClamp()
    {
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (flatVelocity.magnitude > speed)
        {
            Vector3 limitedVel = flatVelocity.normalized * speed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
     private void maxSpeedClamp()
    {
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if(flatVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVel = flatVelocity.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void resetJump()
    {
        canJump = true;
    }

    private void dash()
    {
        if (rb.linearVelocity.x > 0 || rb.linearVelocity.y > 0)
        {
            rb.AddForce(moveDir * dashForce, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(orientation.forward * dashForce, ForceMode.Impulse);
        }
    }
    private void resetDash()
    {
        isDashing = false;
    }
    private void dashCooldown()
    {
        canDash = true;
    }
}
