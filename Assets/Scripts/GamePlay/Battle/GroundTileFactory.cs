using UnityEngine;

public class GroundTileFactory : MonoBehaviour
{
    [SerializeField] private GroundTileComponent groundTile1;
    [SerializeField] private GroundTileComponent groundTile2;

    public GroundTileComponent CreateBlock(GameBlockType gameBlockType, Vector3 worldPos)
    {
        GroundTileComponent tile;
        if (gameBlockType == GameBlockType.Type1)
        {
            tile = groundTile1;
        } else
        {
            tile = groundTile2;
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