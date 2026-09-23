using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    Animator animator;
    public float speed = 10f;
    public Transform cameraTransform;
    Rigidbody rb;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        bool W = Input.GetKey(KeyCode.W);
        bool A = Input.GetKey(KeyCode.A);
        bool S = Input.GetKey(KeyCode.S);
        bool D = Input.GetKey(KeyCode.D);

        // get the camera's forward and right directions, flattened so up/down tilt doesn't affect movement
        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0f;
        camRight.Normalize();

        Vector3 targetDirection = Vector3.zero;

        if (W) targetDirection += camForward;
        if (S) targetDirection -= camForward;
        if (D) targetDirection += camRight;
        if (A) targetDirection -= camRight;

        if (targetDirection != Vector3.zero)
        {
            targetDirection.Normalize();

            // rotate the character to face that direction directly
            transform.rotation = Quaternion.LookRotation(targetDirection);

            // move the character forward in the direction it's now facing
            rb.MovePosition(rb.position + targetDirection * speed * Time.fixedDeltaTime);
        }

        animator.SetBool("W", W);
        animator.SetBool("A", A);
        animator.SetBool("S", S);
        animator.SetBool("D", D);
    }
}