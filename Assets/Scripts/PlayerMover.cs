using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public float crouchHeight = 0.5f;

    private Rigidbody2D rb;
    private Collider2D col;
    private bool isGrounded;
    private bool isCrouching;
    private bool jumpRequest;

    private float originalHeight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        originalHeight = col.bounds.size.y;
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
        //HandleCrouch();
    }

    private void FixedUpdate()
    {
        CheckGround();
        ExecuteJump();
        SnapToPixel();
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = new Vector2(moveVelocity.x, rb.velocity.y);  // Maintain the vertical velocity
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded && !isCrouching)
        {
            jumpRequest = true;
        }
    }

    private void ExecuteJump()
    {
        if (jumpRequest)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpRequest = false;
        }
    }

    /*private void HandleCrouch()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
            col.size = new Vector2(col.size.x, crouchHeight);
        }

        if (Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
            col.size = new Vector2(col.size.x, originalHeight);
        }
    }*/

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void SnapToPixel()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Round(pos.x * 100f) / 100f;
        pos.y = Mathf.Round(pos.y * 100f) / 100f;
        transform.position = pos;
    }
}
