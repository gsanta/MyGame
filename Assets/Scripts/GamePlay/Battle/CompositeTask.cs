using System;

public class CompositeTask : ITask
{
    protected ITask[] subTasks;
    protected ITask activeSubTask;
    private Action taskFinishedAction;

    public void SetActive(bool isActive)
    {
        if (isActive)
        {
            activeSubTask = subTasks[0];
            activeSubTask.SetActive(true);
        } else
        {
            if (activeSubTask != null)
            {
                activeSubTask.SetActive(false);
                activeSubTask = subTasks[0];
            }
        }
    }

    public void SubTasks(ITask[] tasks)
    {
        this.subTasks = tasks;
        foreach(ITask task in tasks) {
            task.OnFinished(OnSubTaskFinished);
        }
    }

    private void OnSubTaskFinished()
    {
        if (activeSubTask != subTasks[subTasks.Length - 1])
        {
            activeSubTask.SetActive(false);
            activeSubTask = subTasks[Array.IndexOf(subTasks, activeSubTask) + 1];
            activeSubTask.SetActive(true);
        } else
        {
            OnAllSubTasksFinished();
        }
    }

    protected virtual void OnAllSubTasksFinished()
    {
        SetActive(false);
        taskFinishedAction?.Invoke();
    }

    public void OnFinished(Action action)
    {
        taskFinishedAction = action;
    }
}
