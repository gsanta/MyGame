public class BattleTask : CompositeTask
{
    protected override void OnAllSubTasksFinished()
    {
        activeSubTask = subTasks[0];
        activeSubTask.SetActive(true);
    }
}
