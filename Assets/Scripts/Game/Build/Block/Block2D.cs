using UnityEngine;

public class Block2D
{
    public readonly int value;
    public readonly Tile2D tile;
    public readonly int x;
    public readonly int y;

    public Block2D(int x, int y, int value, Tile2D tile)
    {
        this.value = value;
        this.tile = tile;
        this.x = x;
        this.y = y;
    }
}