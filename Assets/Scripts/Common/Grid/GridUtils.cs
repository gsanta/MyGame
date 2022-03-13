using System;

public class GridUtils
{
    public static bool IsWithinBoundaries(IntPositions[] positions, GenericGrid<Block2D> grid)
    {
        return Array.TrueForAll(positions, pos => grid.IsWithinGrid(pos.x, pos.y));
    }

    public static bool IsOccupied(IntPositions[] positions, GenericGrid<Block2D> grid)
    {
        return Array.Exists(positions, pos => grid.GetGridObject(pos.x, pos.y).value == 1);
    }
}
