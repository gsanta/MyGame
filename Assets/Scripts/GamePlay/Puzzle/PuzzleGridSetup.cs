using UnityEngine;

public class PuzzleGridSetup : MonoBehaviour
{

    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellSize;
    [SerializeField] private PuzzleTileComponent gridTilePrefab;
    [SerializeField] private GameObject originPosition;


    public GenericGrid<PuzzleBlock> CreateGrid()
    {
        return new GenericGrid<PuzzleBlock>(width, height, cellSize, originPosition.transform.position, (int x, int y) => new PuzzleBlock(x, y, 0, null));
    }

    public void DestroyGrid(GenericGrid<PuzzleBlock> grid)
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
                grid.SetValue(i, j, new PuzzleBlock(i, j, 0, null));
            }
        }
    }

    public PuzzleTileComponent CreateTile(GenericGrid<PuzzleBlock> grid, int xPos, int yPos)
    {
        var worldPos = grid.GetWorldPosition(xPos, yPos);
        var tile = Instantiate(gridTilePrefab, worldPos, Quaternion.identity, transform);
        tile.Construct(8.0f);
        tile.gameObject.SetActive(true);

        return tile;
    }
}
