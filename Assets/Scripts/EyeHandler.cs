using UnityEngine;
using UnityEngine.InputSystem;

public class EyeHandler : MonoBehaviour
{
    [SerializeField] private RectTransform eyePosition;
    [SerializeField] private float radius;
    [SerializeField] private Vector2 offset = new (0.5f, 0.5f);

    void Update()
    {
        // this only works for as long as the canvas of the eye remains in the same position in screen space.
        // But the canvas is world space so it might move
        
        Vector2 screen = new (Screen.height, Screen.height);
        Vector2 mousePosition = Mouse.current.position.ReadValue() / screen - offset;
        Vector2 eye = Vector2.MoveTowards(Vector2.zero, mousePosition*radius, radius); // stay on top of the eye
        eyePosition.anchoredPosition = eye;
    }
}
