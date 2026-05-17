using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float platformSpeed = 1f;
    [SerializeField] private Vector3 start;
    [SerializeField] private Vector3 end;

    private Vector3 lastPosition;
    private Vector3 velocity;
    private Vector3 deltaMovement;

    public Vector3 GetVelocity()
    {
        return velocity;
    }

    public Vector3 GetDeltaMovement()
    {
        return deltaMovement;
    }

    void Start()
    {
        transform.position = start;
        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        float t = Mathf.PingPong(Time.time * platformSpeed, 1.0f);
        Vector3 newPosition = Vector3.Lerp(start, end, t);

        deltaMovement = newPosition - lastPosition;
        velocity = deltaMovement / Time.fixedDeltaTime;

        transform.position = newPosition;
        lastPosition = newPosition;
    }
}