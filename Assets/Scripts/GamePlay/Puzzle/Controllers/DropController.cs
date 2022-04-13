
using Puzzle;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ShapeDroppedEventArgs : EventArgs
{
    public bool IsSuccess { get; private set; }

    public ShapeDroppedEventArgs(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }
}

public class DropController : MonoBehaviour
{
    private GenericGrid<PuzzleBlock> grid;
    private PuzzleGridSetup gridFactory;
    private GroundFactory groundFactory;

    public void Construct(GenericGrid<PuzzleBlock> grid, PuzzleGridSetup gridFactory, GroundFactory groundFactory)
    {
        this.grid = grid;
        this.gridFactory = gridFactory;
        this.groundFactory = groundFactory;
    }

    public void OnDrop(ShapeComponent shape)
    {
        if (!CheckIfValidPosition(shape))
        {
            OnShapeDropped(new ShapeDroppedEventArgs(false));
            return;
        }

        var positions = shape.GetPositions();

        for (int i = 0; i < positions.Length; i++)
        {
            var position = positions[i];
            int x = position.x;
            int y = position.y;
            var worldPos = grid.GetWorldPosition(x, y) + new Vector3(4.0f, 4.0f, 0);
            var transform = shape.transform.GetChild(i);
            var type = transform.GetComponent<Ground>().type;
            var gameObject = groundFactory.Create(type, worldPos);
            grid.SetValue(x, y, new PuzzleBlock(x, y, 1, gameObject));
        }

        List<int> fullRows = new List<int>();
        List<int> fullColumns = new List<int>();

        foreach (var position in shape.GetPositions())
        {
            var columnObjects = grid.GetColumnObjects(position.x);

            if (CheckIfFull(columnObjects))
            {
                fullColumns.Add(position.x);
            }

            var rowObjects = grid.GetRowObjects(position.y);

            if (CheckIfFull(rowObjects))
            {
                fullRows.Add(position.y);
            }
        }

        fullRows.ForEach(row => DestroyTileLine(TileDirection.Row, row));
        fullColumns.ForEach(col => DestroyTileLine(TileDirection.Column, col));

        Destroy(shape.gameObject);

        OnShapeDropped(new ShapeDroppedEventArgs(true));
    }

    private bool CheckIfValidPosition(ShapeComponent shape)
    {
        var positions = shape.GetPositions();
        if (!GridUtils.IsWithinBoundaries(positions, grid) || GridUtils.IsOccupied(positions, grid))
        {
            return false;
        }

        return true;
    }

    private bool CheckIfFull(PuzzleBlock[] objs)
    {
        return Array.TrueForAll(objs, (obj) => obj.value == 1);
    }

    private void DestroyTileLine(TileDirection tileDirection, int colOrRow)
    {
        var line = tileDirection == TileDirection.Column ? grid.GetColumnObjects(colOrRow) : grid.GetRowObjects(colOrRow);
        Array.ForEach(line, (obj) =>
        {
            if (obj.value == 1)
            {
                Destroy(obj.tile.gameObject);
                grid.SetValue(obj.x, obj.y, new PuzzleBlock(obj.x, obj.y, 0, null));
            }
        });
    }

    public event EventHandler<ShapeDroppedEventArgs> ShapeDropped;
    private void OnShapeDropped(ShapeDroppedEventArgs args)
    {
        ShapeDropped?.Invoke(this, args);
    }
}

enum TileDirection
{
    Row,
    Column
}