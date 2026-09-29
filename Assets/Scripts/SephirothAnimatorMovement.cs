using UnityEngine;

public class SephirothAnimatorMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SephirothBattleMovement parent;
    void Start()
    {
        parent = GetComponent<SephirothBattleMovement>();
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
