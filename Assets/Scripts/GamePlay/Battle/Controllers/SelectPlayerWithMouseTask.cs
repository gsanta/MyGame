using System;
using Battle;
using UnityEngine;

public class SelectPlayerWithMouseTask : GridSelector, ITask
{
    private bool isActive;
    public event EventHandler<GroundBlockSelectedEventArgs> PlayerSelected;
    private Action taskFinishedAction;
    private MovementStore movementStore;
    private TeamStore teamStore;

    public void Construct(MovementStore movementStore, GridStore gridStore, TeamStore teamStore)
    {
        this.movementStore = movementStore;
        this.teamStore = teamStore;
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

            if (groundBlock.item == null || groundBlock.GetItem().teamIndex != teamStore.GetCurrentTeam())
            {
                return;
            }

            groundBlock.ground.GetComponent<SelectionComponent>().SetSelected(true);
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
