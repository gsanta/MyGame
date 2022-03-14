using UnityEngine;

public class GroundBlock
{
    GroundTileComponent gameTile;
    public GameObject player;
    public readonly int x;
    public readonly int y;

    public GroundBlock(int x, int y, GroundTileComponent gameTile)
    {
        this.gameTile = gameTile;
        this.x = x;
        this.y = y;
    }
}
