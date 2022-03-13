using UnityEngine;

public class GridFactory : MonoBehaviour
{

    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellSize;
    [SerializeField] private Tile2D gridTilePrefab;

    private Config config;

    public void Construct(Config config)
    {
        this.config = config;
    }

    public GenericGrid<Block2D> CreateGrid()
    {
        return new GenericGrid<Block2D>(width, height, cellSize, config.originPosition, (int x, int y) => new Block2D(x, y, 0, null));
    }

    public GenericGrid<GameBlock> CreateGameGrid()
    {
        var origin = config.originPosition + new Vector3(cellSize / 2, cellSize / 2, 0);
        return new GenericGrid<GameBlock>(width, height, cellSize, origin, (int x, int y) => new GameBlock(x, y, null));
    }

    public Tile2D CreateTile(GenericGrid<Block2D> grid, int xPos, int yPos)
    {
        var worldPos = grid.GetWorldPosition(xPos, yPos);
        var tile = Instantiate(gridTilePrefab, worldPos, Quaternion.identity, transform);
        tile.Construct(8.0f);
        tile.gameObject.SetActive(true);

        return tile;
    }
}
