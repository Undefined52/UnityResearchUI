using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LabeledSlider : MonoBehaviour
{
    [SerializeField] private string labelName = "Label";
    [SerializeField] private TMP_Text labelText;
    [SerializeField] private TMP_Text valueText;
    [SerializeField] private Slider slider;

    public event Action<LabeledSlider, int> OnValueChanged;

    public string LabelName => labelName;
    public int Value => Mathf.RoundToInt(slider.value);

    private void OnEnable()
    {
        slider.onValueChanged.AddListener(HandleSliderChanged);
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveListener(HandleSliderChanged);
    }

    private void Start()
    {
        Refresh();
    }

    public void SetValue(int value)
    {
        slider.value = value;
        Refresh();
    }

    private void HandleSliderChanged(float x)
    {
        Refresh();
        OnValueChanged?.Invoke(this, Value);
    }

    private void Refresh()
    {
        labelText.text = labelName;
        valueText.text = Value.ToString();
    }
}