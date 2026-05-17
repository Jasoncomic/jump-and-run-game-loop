using UnityEngine;

public class SawSpin : MonoBehaviour
{
    public float spinSpeed = 720f;

    public enum SpinAxis
    {
        X,
        Y,
        Z
    }

    public SpinAxis spinAxis = SpinAxis.Z;

    void Update()
    {
        if (spinAxis == SpinAxis.X)
        {
            transform.Rotate(spinSpeed * Time.deltaTime, 0f, 0f);
        }
        else if (spinAxis == SpinAxis.Y)
        {
            transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
        }
        else if (spinAxis == SpinAxis.Z)
        {
            transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
        }
    }
}