using UnityEngine;

public class SelectionComponent : MonoBehaviour
{
    private Color origColor;
    public bool IsSelected { get; private set; }
    public void SetSelected(bool isSelected)
    {
        var renderer = transform.gameObject.GetComponent<Renderer>();
        if (isSelected)
        {
            origColor = renderer.material.color;
            renderer.material.color = Color.black;
        } else
        {
            renderer.material.color = origColor;
        }
        IsSelected = isSelected;
    }
}
