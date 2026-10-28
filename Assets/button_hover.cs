using UnityEngine;
using UnityEngine.EventSystems;

public class button_hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 default_scale = Vector3.one;
    public Vector3 hover_scale = new Vector3(1.1f, 1.1f, 1.1f);

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = hover_scale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = default_scale;
    }
}