using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vector3 cameraOffset = new Vector3(0f, 5f, -10f);
    public Transform player;

    void LateUpdate()
    {
        transform.position = player.position + cameraOffset;
    }
}