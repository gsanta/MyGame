using System;
using UnityEngine;

public class DelayTask : MonoBehaviour, ITask
{
    [SerializeField] private float delay;
    private Action taskFinishedAction;


    public void OnFinished(Action action)
    {
        taskFinishedAction = action;
    }

    public void SetActive(bool isActive)
    {
        if (isActive)
        {
            Invoke("FinishTask", delay);
        }
    }

    private void FinishTask()
    {
        taskFinishedAction?.Invoke();
    }
}
