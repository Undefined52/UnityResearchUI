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
        // this event is called from the toggle component.
        
        screenText.text = value.isOn ? "*" : price.ToString("0.00");
        animator.SetTrigger("Changed"); // this triggers the blinking animation
    }
    
    
    public void OnEquipConfirmed()
    {   
        // this function is called when the yes option is pressed in the popup
        _toggle.isOn = true; // we set this toggle to true sending all other pricetags an event (so they can go to not selected)
        purchase.Invoke(); // We send the got purchased event (which sends the texture to the player)
    }
}
