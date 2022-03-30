using System;
using UnityEngine;

public class UserDestinationSelector : GridSelector, IDestinationSelector
{
    private bool isEnabled;
    public event EventHandler<GroundBlockSelectedEventArgs> DestinationSelected;

    public void SetEnabled(bool isEnabled)
    {
        this.isEnabled = isEnabled;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var groundBlock = GetGroundBlockAtMousePosition();

            if (groundBlock == null)
            {
                OnDestinationSelected(new GroundBlockSelectedEventArgs(groundBlock));
                return;
            }

            if (groundBlock.Item == null)
            {
                return;
            }

            var selectionComponent = groundBlock.block.GetComponent<SelectionComponent>();

            if (groundBlock.Item)

                if (from != null && !groundBlock.Item)
                {
                    to = groundBlock;
                    selectionComponent.SetSelected(true);
                }

            if (from == null && groundBlock.Item)
            {
                from = groundBlock;
                selectionComponent.SetSelected(true);
            }

            if (from != null && to != null)
            {
                from.Item.GetComponent<MoveComponent>().SetDestination(to.block.transform.position, 2f);
                from.block.GetComponent<SelectionComponent>().SetSelected(false);
                to.block.GetComponent<SelectionComponent>().SetSelected(false);
                from = null;
                to = null;
            }
        }

        //if (HasMouseMoved())
        //{
        //    var groundBlock = GetGroundBlockAtMousePosition();

        //    if (groundBlock == null)
        //    {
        //        RemoveHover();
        //        return;
        //    }

        //    var selectionComponent = groundBlock.block.GetComponent<SelectionComponent>();

        //    if (!selectionComponent.IsHovered)
        //    {
        //        RemoveHover();
        //        selectionComponent.SetHovered(true);
        //        hovered = selectionComponent;
        //    }
        //}
    }

    private void OnDestinationSelected(GroundBlockSelectedEventArgs args)
    {
        DestinationSelected?.Invoke(this, args);
    }
}
