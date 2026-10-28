using UnityEngine;
using UnityEngine.UI;

public class hp_bar : MonoBehaviour
{
    public Image bar_image;
    public float speed = 1f;

    void Update()
    {
        if (bar_image != null)
        {
            bar_image.fillAmount = Mathf.PingPong(Time.time * speed, 1f);
        }
    }
}