using UnityEngine;

public class hoverHandler : MonoBehaviour
{
    private Animator animator;
    
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }


    public void OnHoverEnter()
    {
        animator.ResetTrigger("no_hover");
        animator.SetTrigger("hover");   
    }


    public void OnHoverExit()
    {   
        animator.ResetTrigger("hover");
        animator.SetTrigger("no_hover");
    }
}
