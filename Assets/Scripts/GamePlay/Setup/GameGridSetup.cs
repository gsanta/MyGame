using UnityEngine;

public class GameGridSetup : MonoBehaviour
{
    [SerializeField] private float cellSize;
    [SerializeField] private GameObject originPosition;
    private GameTileFactory gameTileFactory;

    public void Construct(GameTileFactory gameTileFactory)
    {
        this.gameTileFactory = gameTileFactory;
    }

    public GenericGrid<GameBlock> Create(GenericGrid<Block2D> setupGrid)
    {
        var grid = CreateGameGrid(setupGrid.width, setupGrid.height);

        for (int i = 0; i < grid.width; i++)
        {
            for (int j = 0; j < grid.height; j++)
            {
                var levelBlock = setupGrid.GetGridObject(i, j);
                GameTile tile;
                if (levelBlock.value == 1)
                {
                    tile = gameTileFactory.CreateBlock(GameBlockType.Type1, grid.GetWorldPosition(i, j));
                } else
                {
                    tile = gameTileFactory.CreateBlock(GameBlockType.Type2, grid.GetWorldPosition(i, j));
                }

                grid.SetValue(i, j, new GameBlock(i, j, tile));
            }
        }

        return grid;
    }

    private GenericGrid<GameBlock> CreateGameGrid(int width, int height)
    {
        var origin = originPosition.transform.position + new Vector3(cellSize / 2, cellSize / 2, 0);
        return new GenericGrid<GameBlock>(width, height, cellSize, origin, (int x, int y) => new GameBlock(x, y, null));
    }
}
