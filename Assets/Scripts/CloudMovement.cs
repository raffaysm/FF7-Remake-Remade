using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    Animator animator;
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool W = false;
        bool A = false;
        bool S = false;
        bool D = false;

        if (Input.GetKey(KeyCode.W))
        {
            W = true;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            A = true;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            S = true;
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            D = true;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        animator.SetBool("W", W);
        animator.SetBool("A", A);
        animator.SetBool("S", S);
        animator.SetBool("D", D);
    }
}
