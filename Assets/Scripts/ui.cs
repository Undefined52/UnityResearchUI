using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    // public GameObject nameForm;
    // public TMP_InputField nameInput;
    // public TMP_Text nameText;
    public Slider moneyBar;
    public TMP_Text moneyText;
    public GameObject confirmPopup;
    public TMP_Text confirmText;
    public float money = 50f;

    private priceTagHandler priceTag;

    void Start()
    {
        // nameForm.SetActive(true);
        confirmPopup.SetActive(false);
        moneyBar.maxValue = money;
        UpdateMoney();
    }

    void UpdateMoney(float delta = 0)
    {   
        money += delta;
        moneyBar.value = money;
        moneyText.text = money.ToString("0.00");
    }

    // public void ConfirmName()               // OK button
    // {
    //     if (string.IsNullOrWhiteSpace(nameInput.text)) return;
    //     nameText.text = nameInput.text;
    //     nameForm.SetActive(false);
    // }

    public void AskToBuy(GameObject tag)       // plain button
    {
        priceTag = tag.GetComponent<priceTagHandler>(); // get the product info from the caller
        confirmText.text = "Buy this for " + priceTag.price.ToString("0.00") + "?";
        confirmPopup.SetActive(true);
    }

    public void Yes()
    {
        if (priceTag.price > money) {
            confirmText.text = "Not enough money!";
            return;
        }
        
        UpdateMoney(-priceTag.price);
        
        priceTag.OnEquipConfirmed(); // let the object know it is purchased
        confirmPopup.SetActive(false);
    }

    public void No()
    {
        confirmPopup.SetActive(false);
    }
}
