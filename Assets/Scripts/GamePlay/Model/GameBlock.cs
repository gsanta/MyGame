using UnityEngine;

public class GameBlock
{
    GameTile gameTile;
    public GameObject player;
    public readonly int x;
    public readonly int y;

    public GameBlock(int x, int y, GameTile gameTile)
    {
        this.gameTile = gameTile;
        this.x = x;
        this.y = y;
    }
}
