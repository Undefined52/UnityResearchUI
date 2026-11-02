using System;
using System.Collections;

using TMPro;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class priceTagHandler : MonoBehaviour
{
    public float price;
    [SerializeField] private UnityEvent purchase;
    
    private TextMeshProUGUI screenText;
    private Animator animator;
    private Toggle _toggle;

    private void Awake()
    {
        screenText = GetComponentInChildren<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
        _toggle = GetComponent<Toggle>();

        screenText.text = price.ToString("0.00");
    }
    
    
    public void Changed(Toggle value)
    {
        screenText.text = value.isOn ? "*" : price.ToString("0.00");
        animator.SetTrigger("Changed");
    }
    
    
    public void OnEquipConfirmed()
    {
        _toggle.isOn = true;
        purchase.Invoke();
    }
}
