using System;

using UnityEditor.UIElements;

using UnityEngine;

public class clothingUpdater : MonoBehaviour
{
    public void OnChangeCloths(Material mat)
    {
        for (int childIdx = 0; childIdx < transform.childCount; childIdx++) {
            Transform child = transform.GetChild(childIdx);
            if (child.CompareTag("Shirt")) {
                child.GetComponent<Renderer>().material = mat;
            }
        }
    }
}
