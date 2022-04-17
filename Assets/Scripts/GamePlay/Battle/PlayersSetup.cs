using System.Collections.Generic;
using Battle;
using UnityEngine;

public class PlayersSetup : MonoBehaviour
{
    private CharacterStore characterStore;
    private ItemFactory itemFactory;

    private List<ItemType> players = new List<ItemType> {
        ItemType.Character
    };

    private List<ItemType> enemies = new List<ItemType> {
        ItemType.Character
    };

    public void Construct(CharacterStore characterStore, ItemFactory itemFactory)
    {
        this.characterStore = characterStore;
        this.itemFactory = itemFactory;
    }

    public void Setup(GenericGrid<GroundBlock> grid)
    {
        players.ForEach(player =>
        {
            CreatePlayer(grid, player, 0);
        });

        enemies.ForEach(player =>
        {
            CreatePlayer(grid, player, 1);
        });
    }

    private GameObject CreatePlayer(GenericGrid<GroundBlock> grid, ItemType itemType, int teamIndex)
    {
        GroundBlock block;

        do
        {
            block = GetRandomBlock(grid);
        } while (block.item != null);

        var position = grid.GetWorldPosition(block.x, block.y);
        var gameObject = itemFactory.Create(itemType, block, position, teamIndex);
        gameObject.SetActive(true);


        var halfBlockHeight = block.ground.gameObject.GetComponent<Renderer>().bounds.size.y / 2;
        var halfPlayerHeight = gameObject.GetComponent<Renderer>().bounds.size.y / 2;
        gameObject.transform.Translate(new Vector3(0, 0, -(halfPlayerHeight + halfBlockHeight)));
        gameObject.GetComponent<MoveComponent>().Construct(grid);

        block.item = gameObject;

        characterStore.AddItem(gameObject.GetComponent<ItemComponent>());

        return gameObject;
    }
    
    private GroundBlock GetRandomBlock(GenericGrid<GroundBlock> grid)
    {
        var row = Random.Range(0, grid.height);
        var col = Random.Range(0, grid.width);

        return grid.GetGridObject(col, row);
    }
}
