using Unity.VisualScripting;
using System.Collections;
using UnityEngine;

public class SephirothBattleMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    Animator animator;
    GameManager gm;
    public Transform enemy;
    public Transform sephi;
    public float distance = 2f;
    private int damage = 150;

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
        if(rb && animator)
        {
            Vector3 newPosition = rb.position + animator.deltaPosition;
            rb.MovePosition(newPosition);
        }
    }
    public void SephiAttack()
    {
        animator.SetTrigger("Attack");
        Invoke("Hit", 1f);
    }

    void Hit()
    {
        Vector3 direction = (enemy.position - sephi.position).normalized;
        sephi.position = enemy.position - direction * distance;
        Invoke("MoveBack", 2.5f);
    }
    void MoveBack()
    {
        gm.cloudHP = gm.cloudHP - damage;
        gm.cloudDamageTaken = gm.cloudDamageTaken + damage;
        sephi.localPosition = Vector3.zero;
        StartCoroutine(Turn());
    }

    IEnumerator Turn()
    {
        yield return new WaitForSeconds(1.5f);
        gm.cloud = true;
        gm.sephi = false;
        gm.Combat();
    }
}
