using UnityEngine;

public class LevelGridSetup : MonoBehaviour
{

    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellSize;
    [SerializeField] private Tile2D gridTilePrefab;
    [SerializeField] private GameObject originPosition;


    public GenericGrid<Block2D> CreateGrid()
    {
        return new GenericGrid<Block2D>(width, height, cellSize, originPosition.transform.position, (int x, int y) => new Block2D(x, y, 0, null));
    }

    public void DestroyGrid(GenericGrid<Block2D> grid)
    {
        for (int i = 0; i < grid.width; i++)
        {
            for (int j = 0; j < grid.height; j++)
            {
                var block = grid.GetGridObject(i, j);
                if (block.tile)
                {
                    Destroy(block.tile.gameObject);
                }
                grid.SetValue(i, j, new Block2D(i, j, 0, null));
            }
        }
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
