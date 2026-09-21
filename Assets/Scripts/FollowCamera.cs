
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraOffset = new Vector3(0f, 5f, -10f);
    public float rotationSpeed = 100f;

    Vector3 lastPlayerPosition;

    void Start()
    {
        transform.position = player.position + cameraOffset;
        lastPlayerPosition = player.position;
        transform.LookAt(player);
    }

    void LateUpdate()
    {
        Vector3 playerMovement = player.position - lastPlayerPosition;

        transform.position += playerMovement;

        lastPlayerPosition = player.position;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(player.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(player.position, Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(player.position, transform.right, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(player.position, transform.right, -rotationSpeed * Time.deltaTime);
        }

        transform.LookAt(player);
    }
}
