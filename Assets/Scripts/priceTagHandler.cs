using System;
using System.Collections;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class priceTagHandler : MonoBehaviour
{ 
    private TextMeshProUGUI screenText;
    private Animator animator;

    private void Awake()
    {
        screenText = GetComponentInChildren<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
    }
    
    
    public void Changed(Toggle value)
    {
        screenText.text = value.isOn ? "*" : "4.99";
        animator.SetTrigger("Changed");
    }
}
