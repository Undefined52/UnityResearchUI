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
        animator.SetBool("Hovering", true);
    }


    public void OnHoverExit()
    {   
        animator.SetBool("Hovering", false);
    }


    public void OnShowText(float active)
    {
        text.SetActive(active != 0);
    }
}
