using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public GameObject nameForm;
    public TMP_InputField nameInput;
    public TMP_Text nameText;
    public Slider moneyBar;
    public TMP_Text moneyText;
    public GameObject confirmPopup;
    public TMP_Text confirmText;
    public float money = 50f;

    float pendingPrice;
    GameObject pendingTag;

    void Start()
    {
        nameForm.SetActive(true);
        confirmPopup.SetActive(false);
        moneyBar.maxValue = money;
        UpdateMoney();
    }

    void UpdateMoney()
    {
        moneyBar.value = money;
        moneyText.text = money.ToString("0.00");
    }

    public void ConfirmName()               // OK button
    {
        if (string.IsNullOrWhiteSpace(nameInput.text)) return;
        nameText.text = nameInput.text;
        nameForm.SetActive(false);
    }

    public void AskToBuy(float price)       // plain button
    {
        pendingPrice = price;
        confirmText.text = "Buy this for " + price.ToString("0.00") + "?";
        confirmPopup.SetActive(true);
    }

    public void AskToBuyTag(float price, GameObject tag)   // price tag
    {
        pendingTag = tag;
        AskToBuy(price);
    }

    public void Yes()
    {
        if (pendingPrice > money)
        {
            confirmText.text = "Not enough money!";
            return;
        }

        money -= pendingPrice;
        UpdateMoney();
        if (pendingTag) pendingTag.SetActive(false);   // the price tag disappears
        pendingTag = null;
        confirmPopup.SetActive(false);
    }

    public void No()
    {
        pendingTag = null;
        confirmPopup.SetActive(false);
    }
}