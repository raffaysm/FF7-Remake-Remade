using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Vector3 cameraPosition;

    void Update()
    {
        transform.position = cameraPosition;
    }
}