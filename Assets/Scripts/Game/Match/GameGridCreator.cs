public class GameGridCreator
{
    private GridFactory gridFactory;
    private readonly GameTileFactory gameTileFactory;

    public GameGridCreator(GridFactory gridFactory, GameTileFactory gameTileFactory)
    {
        this.gridFactory = gridFactory;
        this.gameTileFactory = gameTileFactory;
    }

    public GenericGrid<GameBlock> Create(GenericGrid<Block2D> setupGrid)
    {
        var grid = gridFactory.CreateGameGrid();

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
}
