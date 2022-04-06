using System;

public class SelectEnemyTask : ITask
{
    private CharacterStore characterStore;
    private Action taskFinishedAction;

    public SelectEnemyTask(CharacterStore characterStore)
    {
        this.characterStore = characterStore;
    }

    public void OnFinished(Action callback)
    {
        taskFinishedAction = callback;
    }

    public void SetActive(bool isActive)
    {
        if (isActive)
        {
            characterStore.SetNextEnemy();
            taskFinishedAction?.Invoke();
        }
    }
}
