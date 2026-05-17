using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;

    public float mouseSensitivity = 3f;
    public float distance = 4f;
    public float minDistance = 2f;
    public float maxDistance = 6f;
    public float scrollSpeed = 2f;

    public float minPitch = -20f;
    public float maxPitch = 60f;

    public Vector3 targetOffset = new Vector3(0f, 1.2f, 0f);

    private float yaw = 0f;
    private float pitch = 15f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null) return;

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * scrollSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 targetPosition = target.position + targetOffset;
        Vector3 desiredPosition = targetPosition - rotation * Vector3.forward * distance;

        transform.position = desiredPosition;
        transform.LookAt(targetPosition);
    }
}