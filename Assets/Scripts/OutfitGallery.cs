using System;
using UnityEngine;

public class OutfitGallery : MonoBehaviour
{
    [SerializeField] private OutfitCard[] cards;
    [SerializeField] private int startIndex = 0;

    public event Action<OutfitDefinition> OutfitSelected;

    public OutfitDefinition Selected { get; private set; }

    private void OnEnable()
    {
        foreach (OutfitCard card in cards)
        {
            card.Clicked += HandleCardClicked;
        }
    }

    private void OnDisable()
    {
        foreach (OutfitCard card in cards)
        {
            card.Clicked -= HandleCardClicked;
        }
    }

    private void Start()
    {
        if (cards.Length > 0)
        {
            Select(cards[Mathf.Clamp(startIndex, 0, cards.Length - 1)]);
        }
    }

    private void HandleCardClicked(OutfitCard clicked)
    {
        Select(clicked);
    }

    private void Select(OutfitCard selected)
    {
        foreach (OutfitCard card in cards)
        {
            card.SetSelected(card == selected);
        }

        Selected = selected.Definition;
        OutfitSelected?.Invoke(Selected);
    }
}