using UnityEngine;

[CreateAssetMenu(fileName = "priceTag", menuName = "Scriptable Objects/priceTag")]
public class priceTagGroup : ScriptableObject
{
    // public delegate void a(int);
    private int i = 0;
    public void inc()
    {
        Debug.Log(i++);
    }
}
