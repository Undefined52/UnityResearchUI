using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    private Animator animator;
    
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    
    public void OnDoorsOpen()
    {
        animator.SetBool("opened", true);
    }


    public void OnDoordClose()
    {   
        animator.SetBool("opened", false);
    }
}
