
using System;

public interface ITask
{
    void SetActive(bool isActive);
    void OnFinished(Action callback);
}
