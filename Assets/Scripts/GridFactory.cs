using UnityEngine;

public class GridFactory : MonoBehaviour
{

    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellSize;
    [SerializeField] private Vector3 originPosition;
    [SerializeField] private GridTile gridTilePrefab;

    public GenericGrid<GridObject> CreateGrid()
    {
        return new GenericGrid<GridObject>(width, height, cellSize, originPosition, () => new GridObject(0, null));
    }

    public GridTile CreateTile(GenericGrid<GridObject> grid, int xPos, int yPos)
    {
        var worldPos = grid.GetWorldPosition(xPos, yPos);
        var tile = Instantiate(gridTilePrefab, worldPos, Quaternion.identity, transform);
        tile.Construct(8.0f);
        tile.gameObject.SetActive(true);

        grid.SetValue(xPos, yPos, new GridObject(1, tile));
        
        return tile;
    }
}
