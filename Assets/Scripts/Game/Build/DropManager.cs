
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShapeDroppedEventArgs : EventArgs
{
    public bool IsSuccess { get; private set; }

    public ShapeDroppedEventArgs(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }
}

public class DropManager : MonoBehaviour
{
    private GenericGrid<Block2D> grid;
    private LevelGridSetup gridFactory;

    public void Construct(GenericGrid<Block2D> grid, LevelGridSetup gridFactory)
    {
        this.grid = grid;
        this.gridFactory = gridFactory;
    }

    public void OnDrop(ProceduralShape shape)
    {
        if (!CheckIfValidPosition(shape))
        {
            OnShapeDropped(new ShapeDroppedEventArgs(false));
            return;
        }

        var positions = shape.GetPositions();
        foreach (var position in positions)
        {
            int x = position.x;
            int y = position.y;
            var tile = gridFactory.CreateTile(grid, x, y);
            grid.SetValue(x, y, new Block2D(x, y, 1, tile));
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

    private bool CheckIfValidPosition(ProceduralShape shape)
    {
        var positions = shape.GetPositions();
        if (!GridUtils.IsWithinBoundaries(positions, grid) || GridUtils.IsOccupied(positions, grid))
        {
            return false;
        }

        return true;
    }

    private bool CheckIfFull(Block2D[] objs)
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
                grid.SetValue(obj.x, obj.y, new Block2D(obj.x, obj.y, 0, null));
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