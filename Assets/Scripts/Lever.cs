using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    private bool on = false;
    private bool playerInRange = false;

    private InputAction interactAction;

    [SerializeField] private Transform onPosition;
    [SerializeField] private Transform offPosition;
    [SerializeField] private GameObject leverHandle;

    void Start()
    {
        this.interactAction = InputSystem.actions.FindAction("Interact");
    }

    void ToggleLever()
    {
        this.on = !this.on;

        if (this.on)
        {
            this.leverHandle.transform.SetPositionAndRotation(
                this.onPosition.position,
                this.onPosition.rotation
            );
        }
        else
        {
            this.leverHandle.transform.SetPositionAndRotation(
                this.offPosition.position,
                this.offPosition.rotation
            );
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            playerInRange = true;
            Debug.Log("Player entered range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            playerInRange = false;
            Debug.Log("Player left range");
        }
    }

    void FixedUpdate()
    {
        if (playerInRange && this.interactAction.WasPressedThisFrame())
        {
            Debug.Log("Lever activated");
            ToggleLever();
        }
    }
}

// Commit comment 2