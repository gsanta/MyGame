
using System;
using System.Collections.Generic;
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

    public void OnDrop(DragDrop dragDrop)
    {
        var positions = dragDrop.GetComponent<ProceduralShape>().GetPositions();
        foreach(var position in positions)
        {
            gridFactory.CreateTile(grid, position.x, position.y);
        }

        List<int> fullRows = new List<int>();
        List<int> fullColumns = new List<int>();

        foreach (var position in positions)
        {
            var columnObjects = grid.GetColumnObjects(position.x);

            if (CheckIfFull(columnObjects))
            {
                fullColumns.Add(position.x);
            }

            var rowObjects = grid.GetColumnObjects(position.y);

            if (CheckIfFull(rowObjects))
            {
                fullRows.Add(position.y);
            }
        }

        Destroy(dragDrop.gameObject);

        randomShapeChooser.ChooseShape();
    }

    private bool CheckIfFull(GridObject[] objs)
    {
        return Array.TrueForAll(objs, (obj) => obj.value == 1);
    }

    private void DestroyColumnTiles(int x)
    {
        var columnObjects = grid.GetColumnObjects(x);

    }

    private void DestroyRowTiles()
    {

    }
}
