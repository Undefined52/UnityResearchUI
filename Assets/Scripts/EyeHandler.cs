using UnityEngine;
using UnityEngine.InputSystem;

public class EyeHandler : MonoBehaviour
{
    [SerializeField] private RectTransform eyePosition;
    [SerializeField] private float radius;
    [SerializeField] private Vector2 offset = new (0.5f, 0.5f);

    void Update()
    {
        Vector2 screen = new Vector2 (Screen.height, Screen.height);
        Vector2 mousePosition = Mouse.current.position.ReadValue() / screen - offset;
        Vector2 eye = Vector2.MoveTowards(Vector2.zero, mousePosition*radius, radius);
        eyePosition.anchoredPosition = eye;
    }
}
