using UnityEngine;

[CreateAssetMenu(fileName = "NewOutfit", menuName = "Character/Outfit")]
public class OutfitDefinition : ScriptableObject
{
    [SerializeField] private string displayName = "Outfit";
    [SerializeField] private Sprite icon;
    [TextArea]
    [SerializeField] private string description;

    public string DisplayName => displayName;
    public Sprite Icon => icon;
    public string Description => description;
}