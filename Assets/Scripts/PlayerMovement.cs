using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    // Ground check
    public Transform groundCheck;   // Place at player's feet (child of player)
    public float groundDistance = 0.4f;  // Sphere radius for ground test
    public LayerMask groundMask;    // Set to "Ground" layer in inspector

    private Rigidbody rb; //Player's rigidBody
    private Vector2 moveInput; //WASD + arrow keys
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();      // Update grounded state each frame
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void OnJump()
    {
        if (isGrounded) // Only jump when grounded
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse); // Upward impulse
        }
    }

    void OnMovement(InputValue value) //Action movement
    {
        moveInput = value.Get<Vector2>(); //Read Vector2 x=A/D y=W/S
    }

    void MovePlayer()
    {
        Vector3 direction = (transform.right * moveInput.x) + (transform.forward * moveInput.y);
        direction = direction.normalized;

        rb.linearVelocity = new Vector3(direction.x*moveSpeed, rb.linearVelocity.y, direction.z*moveSpeed);
    }
    
    void CheckGround()
    {
        if (groundCheck == null)        // Safety: require a groundCheck transform
        {
            isGrounded = false;
            return;
        }

        // True if sphere overlaps any collider on groundMask within groundDistance
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}
