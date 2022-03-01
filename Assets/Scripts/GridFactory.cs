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
        return new GenericGrid<GridObject>(width, height, cellSize, originPosition, () => new GridObject());
    }

    public GridTile CreateTile(Vector3 position)
    {
        var tile = Instantiate(gridTilePrefab, position, Quaternion.identity, transform);
        tile.Construct(8.0f);
        tile.gameObject.SetActive(true);
        return tile;
    }
}
