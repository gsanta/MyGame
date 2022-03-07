using UnityEngine;

public class GridObject
{
    public int value;
    public GridTile tile;

    public GridObject(int value, GridTile tile)
    {
        this.value = value;
        this.tile = tile;
    }
}