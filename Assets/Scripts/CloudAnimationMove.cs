using UnityEngine;

public class CloudAnimationMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private CloudBattleMovement parent;
    void Start()
    {
        parent = GetComponentInParent<CloudBattleMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnAnimatorMove()
    {
        if(parent != null)
        {
            parent.RootMovement();
        }
    }
}
