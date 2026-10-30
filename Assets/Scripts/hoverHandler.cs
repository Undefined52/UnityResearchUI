using TMPro;

using UnityEngine;

public class hoverHandler : MonoBehaviour
{
    [SerializeField] private GameObject text;
    
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


    public void OnShowText(float active)
    {
        text.SetActive(active != 0);
    }
}
