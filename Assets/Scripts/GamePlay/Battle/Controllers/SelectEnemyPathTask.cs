using System.Collections.Generic;
using UnityEngine;

public class SelectEnemyPathTask : ITask
{
    private GridStore gridStore;
    private CharacterStore characterStore;
    private MovementStore movementStore;
    private System.Action taskFinishedAction;

    public SelectEnemyPathTask(GridStore gridStore, CharacterStore characterStore, MovementStore movementStore)
    {
        this.gridStore = gridStore;
        this.characterStore = characterStore;
        this.movementStore = movementStore;
    }

    public void OnFinished(System.Action callback)
    {
        taskFinishedAction = callback;
    }

    public void SetActive(bool isActive)
    {
        if (isActive)
        {
            CreatePath();
            taskFinishedAction?.Invoke();
        }
    }

    private void CreatePath()
    {
        var grid = gridStore.GetGrid();
        var (destX, destY) = GetRandomDestination();
        var character = this.characterStore.activeEnemy;
        movementStore.from = character.block;
        movementStore.to = grid.GetGridObject(destX, destY);
        //List<PathNode> nodes = gridStore.GetPathFinding().FindPath(character.block.x, character.block.y, destX, destY);
    }

    private (int, int) GetRandomDestination()
    {
        var grid = gridStore.GetPathGrid();
        var row = Random.Range(0, grid.height);
        var col = Random.Range(0, grid.width);
        return (row, col);
    }
}
