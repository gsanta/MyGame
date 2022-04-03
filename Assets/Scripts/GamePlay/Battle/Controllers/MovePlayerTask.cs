
public class MovePlayerTask : CompositeTask
{
    private MovementStore movementStore;

    public MovePlayerTask(MovementStore movementStore)
    {
        this.movementStore = movementStore;
    }

    protected override void OnAllSubTasksFinished()
    {
        var from = movementStore.from;
        var to = movementStore.to;
        from.Item.GetComponent<MoveComponent>().SetDestination(to.block.transform.position, 2f, FinishMovement);
    }

    private void FinishMovement()
    {
        var from = movementStore.from;
        var to = movementStore.to;

        from.block.GetComponent<SelectionComponent>().SetSelected(false);
        to.block.GetComponent<SelectionComponent>().SetSelected(false);

        movementStore.from = null;
        movementStore.to = null;
        base.OnAllSubTasksFinished();
    }
}
