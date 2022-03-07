
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    private GenericGrid<GridObject> grid;
    private GridFactory gridFactory;
    private RandomShapeChooser randomShapeChooser;

    public void Construct(GenericGrid<GridObject> grid, GridFactory gridFactory, RandomShapeChooser randomShapeChooser)
    {
        this.grid = grid;
        this.gridFactory = gridFactory;
        this.randomShapeChooser = randomShapeChooser;
    }

    public void OnDrop(ProceduralShape shape)
    {
        if (CheckIfAllEmpty(shape))
        {
            var positions = shape.GetPositions();
            foreach (var position in positions)
            {
                int x = position.x;
                int y = position.y;
                var tile = gridFactory.CreateTile(grid, x, y);
                grid.SetValue(x, y, new GridObject(x, y, 1, tile));
            }
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

        randomShapeChooser.ChooseShape();
    }

    private bool CheckIfAllEmpty(ProceduralShape shape)
    {
        return shape.GetPositions().All(pos => grid.GetGridObject(pos.x, pos.y).value == 0);
    }

    private bool CheckIfFull(GridObject[] objs)
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
                grid.SetValue(obj.x, obj.y, new GridObject(obj.x, obj.y, 0, null));
            }
        });
    }
}

enum TileDirection
{
    Row,
    Column
}