using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioSource footstepSource;
    public AudioSource jumpSource;
    public AudioClip jumpClip;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool isMoving = Mathf.Abs(x) > 0.1f || Mathf.Abs(z) > 0.1f;
        bool isGrounded = controller.isGrounded;

        if (isMoving && isGrounded)
        {
            if (!footstepSource.isPlaying)
            {
                footstepSource.Play();
            }
        }
        else
        {
            if (footstepSource.isPlaying)
            {
                footstepSource.Stop();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpClip != null && jumpSource != null)
            {
                jumpSource.PlayOneShot(jumpClip);
            }
        }
    }
}