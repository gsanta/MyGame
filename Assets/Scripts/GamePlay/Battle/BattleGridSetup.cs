using UnityEngine;

public class BattleGridSetup : MonoBehaviour
{
    [SerializeField] private float cellSize;
    [SerializeField] private GameObject originPosition;
    private GroundFactory groundFactory;
    private SurfaceComponent surfaceComponent;
    private GridStore gridStore;

    public void Construct(GroundFactory groundFactory, SurfaceComponent surfaceComponent, GridStore gridStore)
    {
        this.groundFactory = groundFactory;
        this.surfaceComponent = surfaceComponent;
        this.gridStore = gridStore;
    }

    public GenericGrid<GroundBlock> Setup(GenericGrid<PuzzleBlock> setupGrid)
    {
        surfaceComponent.SetSize(setupGrid.width, setupGrid.height, cellSize);
        var grid = Create(setupGrid);
        gridStore.SetGrid(grid);
        gridStore.SetPathGrid(CreatePathGrid(grid));
        return grid;
    }

    private GenericGrid<GroundBlock> Create(GenericGrid<PuzzleBlock> setupGrid)
    {
        var grid = CreateGameGrid(setupGrid.width, setupGrid.height);

        for (int i = 0; i < grid.width; i++)
        {
            for (int j = 0; j < grid.height; j++)
            {
                var puzzleBlock = setupGrid.GetGridObject(i, j);
                var groundType = puzzleBlock.tile ? puzzleBlock.tile.GetComponent<Ground>().type : GroundType.Hell;
                var ground = groundFactory.Create(groundType, grid.GetWorldPosition(i, j));
                grid.SetValue(i, j, new GroundBlock(i, j, ground));
            }
        }

        return grid;
    }

    private GenericGrid<PathNode> CreatePathGrid(GenericGrid<GroundBlock> grid)
    {
        var pathGrid = new GenericGrid<PathNode>(grid.width, grid.height, cellSize, grid.originPosition, (GenericGrid<PathNode> grid, int x, int y) => new PathNode(grid, x, y));

        for (int i = 0; i < grid.width; i++)
        {
            for (int j = 0; j < grid.height; j++)
            {
                var block = grid.GetGridObject(i, j);

                if (block.Item != null)
                {
                    pathGrid.GetGridObject(i, j).isWalkable = false;
                }
            }
        }

        return pathGrid;
    }

    private GenericGrid<GroundBlock> CreateGameGrid(int width, int height)
    {
        var origin = originPosition.transform.position + new Vector3(cellSize / 2, cellSize / 2, 0);
        return new GenericGrid<GroundBlock>(width, height, cellSize, origin, (GenericGrid<GroundBlock> grid, int x, int y) => new GroundBlock(x, y, null));
    }
}
