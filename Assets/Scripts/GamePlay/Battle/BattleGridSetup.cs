using UnityEngine;

public class BattleGridSetup : MonoBehaviour
{
    [SerializeField] private float cellSize;
    [SerializeField] private GameObject originPosition;
    private GroundTileFactory groundTileFactory;
    private SurfaceComponent surfaceComponent;

    public void Construct(GroundTileFactory groundTileFactory, SurfaceComponent surfaceComponent)
    {
        this.groundTileFactory = groundTileFactory;
        this.surfaceComponent = surfaceComponent;
    }

    public GenericGrid<GroundBlock> Setup(GenericGrid<PuzzleBlock> setupGrid)
    {
        surfaceComponent.SetSize(setupGrid.width, setupGrid.height, cellSize);
        return Create(setupGrid);
    }

    private GenericGrid<GroundBlock> Create(GenericGrid<PuzzleBlock> setupGrid)
    {
        var grid = CreateGameGrid(setupGrid.width, setupGrid.height);

        for (int i = 0; i < grid.width; i++)
        {
            for (int j = 0; j < grid.height; j++)
            {
                var levelBlock = setupGrid.GetGridObject(i, j);
                GroundTileComponent tile;
                if (levelBlock.value == 1)
                {
                    tile = groundTileFactory.CreateBlock(GameBlockType.Type1, grid.GetWorldPosition(i, j));
                } else
                {
                    tile = groundTileFactory.CreateBlock(GameBlockType.Type2, grid.GetWorldPosition(i, j));
                }

                grid.SetValue(i, j, new GroundBlock(i, j, tile));
            }
        }

        return grid;
    }

    private GenericGrid<GroundBlock> CreateGameGrid(int width, int height)
    {
        var origin = originPosition.transform.position + new Vector3(cellSize / 2, cellSize / 2, 0);
        return new GenericGrid<GroundBlock>(width, height, cellSize, origin, (GenericGrid<GroundBlock> grid, int x, int y) => new GroundBlock(x, y, null));
    }
}
