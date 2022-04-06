
public class MoveCharacterTask : CompositeTask
{
    private MovementStore movementStore;

    public MoveCharacterTask(MovementStore movementStore)
    {
        this.movementStore = movementStore;
    }
}
