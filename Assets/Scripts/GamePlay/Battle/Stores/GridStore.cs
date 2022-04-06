public class GridStore
{
    private GenericGrid<GroundBlock> grid;

    private GenericGrid<PathNode> pathGrid;

    private PathFinding pathFinding;
    public void SetGrid(GenericGrid<GroundBlock> grid)
    {
        this.grid = grid;
    }

    public GenericGrid<GroundBlock> GetGrid()
    {
        return grid;
    }

    public void SetPathGrid(GenericGrid<PathNode> grid)
    {
        pathGrid = grid;
        pathFinding = new PathFinding(pathGrid.width, pathGrid.height);
    }

    public GenericGrid<PathNode> GetPathGrid()
    {
        return pathGrid;
    }

    public PathFinding GetPathFinding()
    {
        return pathFinding;
    }
}
