using UnityEngine;
using UnityEngine.UI;

public class ColorTarget : MonoBehaviour
{
    [SerializeField] private ColorPicker picker;
    [SerializeField] private Graphic target;

    private void OnEnable() => picker.ColorChanged += Apply;
    private void OnDisable() => picker.ColorChanged -= Apply;

    private void Apply(Color c) => target.color = c;
}