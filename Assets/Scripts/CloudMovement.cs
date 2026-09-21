using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    Animator animator;
    public float speed = 10f;
    public float rotationSpeed = 100f;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = Vector3.zero;
        bool W = false;
        bool A = false;
        bool S = false;
        bool D = false;

        if (Input.GetKey(KeyCode.W))
        {
            W = true;
            move += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            A = true;
            move += Vector3.left;
            transform.Rotate(Vector3.up, -rotationSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            S = true;
            move += Vector3.back;
        }

        if (Input.GetKey(KeyCode.D))
        {
            D = true;
            move += Vector3.right;
            transform.Rotate(Vector3.up, rotationSpeed * Time.fixedDeltaTime);
        }

        rb.MovePosition(rb.position + transform.TransformDirection(move.normalized) * speed * Time.fixedDeltaTime);
        animator.SetBool("W", W);
        animator.SetBool("A", A);
        animator.SetBool("S", S);
        animator.SetBool("D", D);
    }


}
