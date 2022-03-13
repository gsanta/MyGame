using UnityEngine;

public class PlayersSetup : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    private int maxPlayers = 3;

    public void Setup(GenericGrid<GameBlock> grid)
    {
        int counter = maxPlayers;

        while (counter > 0)
        {
            var gameBlock = GetRandomBlock(grid);
            if (gameBlock.player == null)
            {
                gameBlock.player = CreatePlayer(grid, gameBlock);
                counter--;
            }
        }
    }

    private GameObject CreatePlayer(GenericGrid<GameBlock> grid, GameBlock block)
    {
        var position = grid.GetWorldPosition(block.x, block.y);
        var player = Instantiate(playerPrefab, position, playerPrefab.transform.rotation, transform);
        var halfHeight = player.GetComponent<Renderer>().bounds.size.y / 2;
        player.transform.Translate(new Vector3(0, halfHeight, 0));
        return player;
    }

    private GameBlock GetRandomBlock(GenericGrid<GameBlock> grid)
    {
        var row = Random.Range(0, grid.height);
        var col = Random.Range(0, grid.width);

        return grid.GetGridObject(col, row);
    }
}
