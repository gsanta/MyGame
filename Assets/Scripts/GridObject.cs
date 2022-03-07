using UnityEngine;

public class GridObject
{
    public readonly int value;
    public readonly GridTile tile;
    public readonly int x;
    public readonly int y;

    public GridObject(int x, int y, int value, GridTile tile)
    {
        this.value = value;
        this.tile = tile;
        this.x = x;
        this.y = y;
    }
}