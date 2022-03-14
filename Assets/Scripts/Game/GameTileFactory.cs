using UnityEngine;

public class GameTileFactory : MonoBehaviour
{
    [SerializeField] private GameTile gameBlockTile1;
    [SerializeField] private GameTile gameBlockTile2;

    public GameTile CreateBlock(GameBlockType gameBlockType, Vector3 worldPos)
    {
        GameTile tile;
        if (gameBlockType == GameBlockType.Type1)
        {
            tile = gameBlockTile1;
        } else
        {
            tile = gameBlockTile2;
        }

        var newTile = Instantiate(tile, worldPos, Quaternion.identity, transform);
        newTile.gameObject.SetActive(true);
        return newTile;
    }
}

public enum GameBlockType
{
    Type1, Type2
}