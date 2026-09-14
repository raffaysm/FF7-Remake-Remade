using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vector3 cameraOffset = new Vector3(0f, 5f, -10f);
    public Transform player;
    public float cameraSpeed = 100f;

    void LateUpdate()
    {
        transform.position = player.position + cameraOffset;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, cameraSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -cameraSpeed * Time.deltaTime);
        }
    }
}