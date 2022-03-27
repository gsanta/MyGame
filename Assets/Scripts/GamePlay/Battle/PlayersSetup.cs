using System.Collections.Generic;
using UnityEngine;

public class PlayersSetup : MonoBehaviour
{
    [SerializeField] private GameObject acrobatPrefab;
    [SerializeField] private GameObject musicianPrefab;
    [SerializeField] private GameObject balloonPrefab;

    private List<PlayerData> players = new List<PlayerData> {
        new PlayerData(PlayerType.Acrobat, true),
        new PlayerData(PlayerType.Musician, true),
        new PlayerData(PlayerType.Balloon, true),
    };

    private List<PlayerData> enemies = new List<PlayerData> {
        new PlayerData(PlayerType.Acrobat, false),
        new PlayerData(PlayerType.Musician, false),
        new PlayerData(PlayerType.Balloon, false),
    };

    public void Setup(GenericGrid<GroundBlock> grid)
    {
        players.ForEach(player =>
        {
            CreatePlayer(grid, player);
        });

        enemies.ForEach(player =>
        {
            CreatePlayer(grid, player);
        });
    }

    private GameObject CreatePlayer(GenericGrid<GroundBlock> grid, PlayerData player)
    {
        GroundBlock block;

        do
        {
            block = GetRandomBlock(grid);
        } while (block.Player != null);

        var position = grid.GetWorldPosition(block.x, block.y);
        var gameObject = CreateGameObject(player, position);
        gameObject.SetActive(true);


        var halfBlockHeight = block.block.gameObject.GetComponent<Renderer>().bounds.size.y / 2;
        var halfPlayerHeight = gameObject.GetComponent<Renderer>().bounds.size.y / 2;
        gameObject.transform.Translate(new Vector3(0, 0, -(halfPlayerHeight + halfBlockHeight)));
        gameObject.GetComponent<MoveComponent>().Construct(grid);

        block.Player = gameObject;

        return gameObject;
    }

    private GameObject CreateGameObject(PlayerData player, Vector3 position)
    {
        GameObject gameObject = null;

        switch(player.type)
        {
            case PlayerType.Balloon:
                gameObject = Instantiate(balloonPrefab, position, balloonPrefab.transform.rotation, transform);
                break;
            case PlayerType.Acrobat:
                gameObject = Instantiate(acrobatPrefab, position, balloonPrefab.transform.rotation, transform);
                break;
            case PlayerType.Musician:
                gameObject = Instantiate(musicianPrefab, position, balloonPrefab.transform.rotation, transform);
                break;
        }

        if (gameObject != null && player.isEnemy)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }

        return gameObject;
    }

    private GroundBlock GetRandomBlock(GenericGrid<GroundBlock> grid)
    {
        var row = Random.Range(0, grid.height);
        var col = Random.Range(0, grid.width);

        return grid.GetGridObject(col, row);
    }
}
