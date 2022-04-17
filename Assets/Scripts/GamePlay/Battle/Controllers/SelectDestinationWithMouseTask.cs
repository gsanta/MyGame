using System;
using UnityEngine;

public class SelectDestinationWithMouseTask : GridSelector, ITask
{
    private bool isActive;
    public event EventHandler<GroundBlockSelectedEventArgs> DestinationSelected;
    private Action taskFinishedAction;
    private MovementStore movementStore;

    public void Construct(MovementStore movementStore, GridStore gridStore)
    {
        this.movementStore = movementStore;
        base.Construct(gridStore);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isActive)
            {
                return;
            }

            var groundBlock = GetGroundBlockAtMousePosition();

            if (groundBlock == null)
            {
                return;
            }

            groundBlock.ground.GetComponent<SelectionComponent>().SetSelected(true);
            movementStore.to = groundBlock;
            taskFinishedAction?.Invoke();
        }
    }

    public void SetActive(bool isActive)
    {
        this.isActive = isActive;
    }

    public void OnFinished(Action action)
    {
        taskFinishedAction = action;
    }
}
