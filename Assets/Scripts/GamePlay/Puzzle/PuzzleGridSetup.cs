using UnityEngine;

public class PuzzleGridSetup : MonoBehaviour
{

    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellSize;
    [SerializeField] private GameObject[] gridTilePrefab;
    [SerializeField] private PuzzleTileComponent gridHighlightTilePrefab;
    [SerializeField] private GameObject originPosition;


    public GenericGrid<PuzzleBlock> CreateGrid()
    {
        return new GenericGrid<PuzzleBlock>(width, height, cellSize, originPosition.transform.position, (GenericGrid<PuzzleBlock> grid, int x, int y) => new PuzzleBlock(x, y, 0, null));
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

    public GameObject CreateTile(GenericGrid<PuzzleBlock> grid, int xPos, int yPos)
    {
        var worldPos = grid.GetWorldPosition(xPos, yPos) + new Vector3(4.0f, 4.0f, 0);
        var tile = Instantiate(gridHighlightTilePrefab, worldPos, Quaternion.identity, transform);
        tile.gameObject.SetActive(true);

        return tile.gameObject;
    }

    public PuzzleTileComponent CreateHighlightTile(GenericGrid<PuzzleBlock> grid, int xPos, int yPos)
    {
        var worldPos = grid.GetWorldPosition(xPos, yPos);
        var tile = Instantiate(gridHighlightTilePrefab, worldPos, Quaternion.identity, transform);
        tile.Construct(8.0f);
        tile.gameObject.SetActive(true);

        return tile;
    }
}
