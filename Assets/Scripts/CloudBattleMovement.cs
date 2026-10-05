using UnityEngine;
using System.Collections;

public class CloudBattleMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Animator animator;
    Rigidbody rb;
    GameManager gm;

    public Transform enemy;
    public Transform cloud;
    public float distance = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        gm = GameManager.gm;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RootMovement()
    {
        if(animator && rb)
        {
            Vector3 newPosition = rb.position + animator.deltaPosition;
            rb.MovePosition(newPosition);
        }
    }

    public void CloudAttack()
    {
        Vector3 direction = (enemy.position - cloud.position).normalized;
        cloud.position = enemy.position - direction * distance;
        animator.SetTrigger("Attack");
        Invoke("MoveBack", 2.5f);
    }

    void MoveBack()
    {
        cloud.localPosition = Vector3.zero;
        StartCoroutine(Turn());
    }

    IEnumerator Turn()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Cloud done");
        gm.cloud = false;
        gm.sephi = true;
        gm.Combat();
    }
}
