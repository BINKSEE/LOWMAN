using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float rotationSpeed = 150f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}

