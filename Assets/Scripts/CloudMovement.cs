using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    Animator animator;
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isMoving", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (!Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isMoving", false);
        }
        
    }
}
