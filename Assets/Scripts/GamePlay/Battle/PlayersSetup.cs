using System.Collections.Generic;
using UnityEngine;

public class PlayersSetup : MonoBehaviour
{
    [SerializeField] private GameObject acrobatPrefab;
    [SerializeField] private GameObject musicianPrefab;
    [SerializeField] private GameObject balloonPrefab;
    private CharacterStore characterStore;

    private List<ItemType> players = new List<ItemType> {
        ItemType.Acrobat, ItemType.Musician, ItemType.Balloon
    };

    private List<ItemType> enemies = new List<ItemType> {
        ItemType.Acrobat, ItemType.Musician, ItemType.Balloon
    };

    public void Construct(CharacterStore characterStore)
    {
        this.characterStore = characterStore;
    }

    public void Setup(GenericGrid<GroundBlock> grid)
    {
        players.ForEach(player =>
        {
            CreatePlayer(grid, player, false);
        });

        enemies.ForEach(player =>
        {
            CreatePlayer(grid, player, true);
        });
    }

    private GameObject CreatePlayer(GenericGrid<GroundBlock> grid, ItemType itemType, bool isEnemy)
    {
        GroundBlock block;

        do
        {
            block = GetRandomBlock(grid);
        } while (block.Item != null);

        var itemComponent = CreateGameObject(grid, itemType, block, isEnemy);
        var gameObject = itemComponent.gameObject;
        gameObject.SetActive(true);


        var halfBlockHeight = block.block.gameObject.GetComponent<Renderer>().bounds.size.y / 2;
        var halfPlayerHeight = gameObject.GetComponent<Renderer>().bounds.size.y / 2;
        gameObject.transform.Translate(new Vector3(0, 0, -(halfPlayerHeight + halfBlockHeight)));
        gameObject.GetComponent<MoveComponent>().Construct(grid);

        block.Item = itemComponent;

        characterStore.AddItem(itemComponent);

        return gameObject;
    }

    private ItemComponent CreateGameObject(GenericGrid<GroundBlock> grid, ItemType itemType, GroundBlock block, bool isEnemy)
    {
        var position = grid.GetWorldPosition(block.x, block.y);

        GameObject gameObject = null;

        switch(itemType)
        {
            case ItemType.Balloon:
                gameObject = Instantiate(balloonPrefab, position, balloonPrefab.transform.rotation, transform);
                break;
            case ItemType.Acrobat:
                gameObject = Instantiate(acrobatPrefab, position, balloonPrefab.transform.rotation, transform);
                break;
            case ItemType.Musician:
                gameObject = Instantiate(musicianPrefab, position, balloonPrefab.transform.rotation, transform);
                break;
        }

        if (gameObject != null && isEnemy)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }

        var itemComponent = gameObject.GetComponent<ItemComponent>();
        itemComponent.isEnemy = isEnemy;
        itemComponent.block = block;
        return itemComponent;
    }

    private GroundBlock GetRandomBlock(GenericGrid<GroundBlock> grid)
    {
        var row = Random.Range(0, grid.height);
        var col = Random.Range(0, grid.width);

        return grid.GetGridObject(col, row);
    }
}
