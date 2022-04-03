public class Hover : GridSelector
{
    private SelectionComponent hovered;

    private void Update()
    {
        if (HasMouseMoved())
        {
            var groundBlock = GetGroundBlockAtMousePosition();

            if (groundBlock == null)
            {
                RemoveHover();
                return;
            }

            var selectionComponent = groundBlock.block.GetComponent<SelectionComponent>();

            if (!selectionComponent.IsHovered)
            {
                RemoveHover();
                selectionComponent.SetHovered(true);
                hovered = selectionComponent;
            }
        }
    }

    private void RemoveHover()
    {
        if (hovered)
        {
            hovered.SetHovered(false);
            hovered = null;
        }
    }
}
