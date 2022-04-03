using System;
using UnityEngine;

public class SelectPlayerWithMouseTask : GridSelector, ITask
{
    private bool isActive;
    public event EventHandler<GroundBlockSelectedEventArgs> PlayerSelected;
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

            if (groundBlock == null && groundBlock.Item.isEnemy)
            {
                return;
            }

            groundBlock.block.GetComponent<SelectionComponent>().SetSelected(true);
            movementStore.from = groundBlock;
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
