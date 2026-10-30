using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OutfitCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private OutfitDefinition definition;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image frame;

    [Header("Visual states")]
    [SerializeField] private Color normalFrame = new Color(1f, 1f, 1f, 0.2f);
    [SerializeField] private Color hoverFrame = new Color(1f, 1f, 1f, 0.6f);
    [SerializeField] private Color selectedFrame = new Color(1f, 0.8f, 0.2f, 1f);
    [SerializeField] private float hoverScale = 1.05f;

    private Button button;
    private bool isHovered;
    private bool isSelected;

    public event Action<OutfitCard> Clicked;

    public OutfitDefinition Definition => definition;

    private void Awake()
    {
        button = GetComponent<Button>();
        ApplyDefinition();
        UpdateVisuals();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(HandleClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(HandleClick);
        isHovered = false;
        UpdateVisuals();
    }

    private void OnValidate()
    {
        ApplyDefinition();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
        UpdateVisuals();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        UpdateVisuals();
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;
        UpdateVisuals();
    }

    private void HandleClick()
    {
        Clicked?.Invoke(this);
    }

    private void ApplyDefinition()
    {
        if (definition == null)
        {
            return;
        }

        if (icon != null)
        {
            icon.sprite = definition.Icon;
        }

        if (nameText != null)
        {
            nameText.text = definition.DisplayName;
        }
    }

    private void UpdateVisuals()
    {
        if (frame != null)
        {
            frame.color = isSelected ? selectedFrame : (isHovered ? hoverFrame : normalFrame);
        }

        transform.localScale = Vector3.one * (isHovered ? hoverScale : 1f);
    }
}