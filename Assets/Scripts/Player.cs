using System;
using Unity.Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
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

    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    public ParticleSystem ps;
    public CinemachineCamera cam;
    private bool isJumping;
    private bool isLand;
    public Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        animator.SetBool("Jump", isJumping);
        animator.SetBool("Landing", isLand);
        animator.SetBool("Grounded", grounded);
        
        
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
            Invoke(nameof(resetDash), 0.2f);
            Invoke(nameof(dashCooldown), 1f);

        }
        if(isJumping && grounded)
        {
            isLand = true;
            
            Invoke(nameof(landingCooldown), 0.1f);
        }
        else
        {
            rb.linearDamping = 0;
        }

        if (cam.Lens.FieldOfView > 60)
        {
            cam.Lens.FieldOfView -= 0.2f;
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
            isJumping = true;
            Jump();
            Invoke(nameof(resetJump), jumpCooldown);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            CancelInvoke(nameof(dashCooldown));
            CancelInvoke(nameof(resetDash));
            ps.Play();
            dash();
            isDashing = true;
            canDash = false;
        }

        if (OnSlope())
        {
            rb.AddForce(GetSlopeMoveDirection() * speed * 20f, ForceMode.Force);
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
        isJumping = true;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void resetJump()
    {
        canJump = true;
        isJumping = false;
    }

    private void dash()
    {
        cam.Lens.FieldOfView += 15;
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

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;


    }
    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDir, slopeHit.normal).normalized;
    }

    private void landingCooldown()
    {
        isLand = false;
    }
}
