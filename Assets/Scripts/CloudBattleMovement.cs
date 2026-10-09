using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloudBattleMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Animator animator;
    Rigidbody rb;
    GameManager gm;
    public Button attackButton;
    public Button magicButton;
    public Button limitButton;
    public Transform enemy;
    public Transform cloud;
    public float distance = 2f;
    private int damage = 100;
    private int heal = 300;
    private int limitDamage = 500;
    private int mpCost = 10;
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
        attackButton.interactable = false;
        Vector3 direction = (enemy.position - cloud.position).normalized;
        cloud.position = enemy.position - direction * distance;
        animator.SetTrigger("Attack");
        Invoke("MoveBack", 2.5f);
    }

    public void CloudMagic()
    {
        if(gm.cloudMP >= mpCost)
        {
            magicButton.interactable = false;
            animator.SetTrigger("Magic");
            gm.cloudHP = gm.cloudHP + heal;
            gm.cloudMP = gm.cloudMP - mpCost;
            StartCoroutine(Turn());
        }
    }

    public void CloudLimit()
    {
        if(gm.cloudDamageTaken >= 1000)
        {
            limitButton.interactable = false;
            animator.SetTrigger("Limit");
            StartCoroutine(Hit());
        }
    }

    IEnumerator Hit()
    {
        Vector3 direction = (enemy.position - cloud.position).normalized;
        cloud.position = enemy.position - direction * distance;
        yield return new WaitForSeconds(5.9f);
        gm.sephiHP = gm.sephiHP - limitDamage;
        MoveBack(); // total animation time 8.542
    }
    void MoveBack()
    {
        cloud.localPosition = Vector3.zero;
        StartCoroutine(Turn());
    }

    IEnumerator Turn()
    {
        yield return new WaitForSeconds(1.5f);
        gm.cloud = false;
        gm.sephi = true;
        gm.Combat();
    }
}
