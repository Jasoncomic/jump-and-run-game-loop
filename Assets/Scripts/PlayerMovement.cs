using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.2f;
    public Transform cameraTransform;

    [Header("Moving Platform")]
    public LayerMask platformLayer;
    public float groundCheckDistance = 1.3f;

    private CharacterController controller;
    private Vector3 velocity;
    private Vector3 platformVelocity;

    private float inputX;
    private float inputZ;
    private bool jumpPressed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Read input in Update so button presses are not missed
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        bool isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 move = (forward * inputZ) + (right * inputX);

        if (move.magnitude > 1f)
        {
            move.Normalize();
        }

        // Rotate player
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Get platform velocity
        platformVelocity = GetPlatformVelocity();

        Vector3 finalMove = move * speed + platformVelocity;

        controller.Move(finalMove * Time.fixedDeltaTime);

        if (jumpPressed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        jumpPressed = false;

        velocity.y += gravity * Time.fixedDeltaTime;
        controller.Move(velocity * Time.fixedDeltaTime);
    }

    private Vector3 GetPlatformVelocity()
    {
        RaycastHit hit;

        Vector3 origin = transform.position + Vector3.up * 0.2f;

        if (Physics.Raycast(origin, Vector3.down, out hit, groundCheckDistance, platformLayer))
        {
            MovingPlatform platform = hit.collider.GetComponent<MovingPlatform>();

            if (platform != null)
            {
                return platform.GetVelocity();
            }
        }

        return Vector3.zero;
    }
}