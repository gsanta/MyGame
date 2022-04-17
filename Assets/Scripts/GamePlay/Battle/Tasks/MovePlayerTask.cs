using System;

public class MovePlayerTask : ITask
{
    private MovementStore movementStore;
    private Action finishedCallback;

    public MovePlayerTask(MovementStore movementStore)
    {
        this.movementStore = movementStore;
    }

    public void OnFinished(Action callback)
    {
        finishedCallback = callback;
    }

    public void SetActive(bool isActive)
    {
        if (isActive)
        {
            var from = movementStore.from;
            var to = movementStore.to;
            from.Item.GetComponent<MoveComponent>().SetDestination(to.gameObject.transform.position, 2f, FinishMovement);
        }
    }

    private void FinishMovement()
    {
        var from = movementStore.from;
        var to = movementStore.to;

        from.gameObject.GetComponent<SelectionComponent>().SetSelected(false);
        to.gameObject.GetComponent<SelectionComponent>().SetSelected(false);

        movementStore.from = null;
        movementStore.to = null;
        finishedCallback();
    }
}
