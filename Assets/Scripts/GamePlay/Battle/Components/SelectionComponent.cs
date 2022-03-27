using UnityEngine;

public class SelectionComponent : MonoBehaviour
{
    private Color origColor;
    private Renderer rendererComponent;
    public bool IsSelected { get; private set; }
    public bool IsHovered { get; private set; }

    private void Start()
    {
        rendererComponent = transform.gameObject.GetComponent<Renderer>();
        origColor = rendererComponent.material.color;
    }

    public void SetSelected(bool isSelected)
    {
        var renderer = transform.gameObject.GetComponent<Renderer>();
        if (isSelected)
        {
            renderer.material.color = Color.black;
        } else
        {
            renderer.material.color = origColor;
        }
        IsSelected = isSelected;
    }

    public void SetHovered(bool isHovered)
    {
        if (IsSelected)
        {
            return;
        }
        var renderer = transform.gameObject.GetComponent<Renderer>();
        if (isHovered)
        {
            renderer.material.color = Color.green;
        }
        else
        {
            renderer.material.color = origColor;
        }
        IsHovered = isHovered;
    }
}
