using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    [SerializeField] private LabeledSlider red;
    [SerializeField] private LabeledSlider green;
    [SerializeField] private LabeledSlider blue;
    [SerializeField] private Image preview;
    [SerializeField] private TMP_Text hexText;
    [SerializeField] private Color startColor = Color.white;

    public event Action<Color> ColorChanged;

    public Color CurrentColor => new Color32(
        (byte)red.Value, (byte)green.Value, (byte)blue.Value, 255);

    private void OnEnable()
    {
        red.OnValueChanged += HandleChannelChanged;
        green.OnValueChanged += HandleChannelChanged;
        blue.OnValueChanged += HandleChannelChanged;
    }

    private void OnDisable()
    {
        red.OnValueChanged -= HandleChannelChanged;
        green.OnValueChanged -= HandleChannelChanged;
        blue.OnValueChanged -= HandleChannelChanged;
    }

    private void Start()
    {
        SetColor(startColor);
    }

    public void SetColor(Color color)
    {
        Color32 c = color;
        red.SetValue(c.r);
        green.SetValue(c.g);
        blue.SetValue(c.b);
        Refresh();
        ColorChanged?.Invoke(CurrentColor);
    }

    private void HandleChannelChanged(LabeledSlider source, int value)
    {
        Refresh();
        ColorChanged?.Invoke(CurrentColor);
    }

    private void Refresh()
    {
        Color current = CurrentColor;
        preview.color = current;
        hexText.text = "#" + ColorUtility.ToHtmlStringRGB(current);
    }
}