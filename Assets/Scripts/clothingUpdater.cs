using System.Collections.Generic;

using UnityEngine;

public class clothingUpdater : MonoBehaviour
{
    public void OnChangeCloths(Texture texture)
    {
        // update all the child components with the Shirt tag
        
        for (int childIdx = 0; childIdx < transform.childCount; childIdx++) {
            Transform child = transform.GetChild(childIdx);
            if (child.CompareTag("Shirt")) {
                List<Material> materials = new();
                child.GetComponent<Renderer>().GetSharedMaterials(materials);
                foreach (Material material in materials) {
                    material.mainTexture = texture;
                }
            }
        }
    }
}
