using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isMoving", true);
        }

        if (!Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isMoving", false);
        }
        
    }
}
