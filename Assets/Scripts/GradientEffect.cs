using UnityEngine;
using UnityEngine.UI;

public class GradientEffect : BaseMeshEffect
{
    [SerializeField] private Color left = Color.black;
    [SerializeField] private Color right = Color.white;

    public void SetColors(Color newLeft, Color newRight)
    {
        left = newLeft;
        right = newRight;

        if (graphic != null)
        {
            graphic.SetVerticesDirty();
        }
    }

    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive() || vh.currentVertCount == 0)
        {
            return;
        }

        Rect rect = graphic.rectTransform.rect;
        UIVertex vertex = default;

        for (int i = 0; i < vh.currentVertCount; i++)
        {
            vh.PopulateUIVertex(ref vertex, i);

            float t = Mathf.InverseLerp(rect.xMin, rect.xMax, vertex.position.x);

            Color gradient = Color.Lerp(left, right, t);
            vertex.color = gradient * (Color)vertex.color;

            vh.SetUIVertex(vertex, i);
        }
    }
}