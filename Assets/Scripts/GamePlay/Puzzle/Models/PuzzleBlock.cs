using UnityEngine;

public class PuzzleBlock
{
    public readonly int value;
    public readonly GameObject tile;
    public readonly int x;
    public readonly int y;

    public PuzzleBlock(int x, int y, int value, GameObject tile)
    {
        this.value = value;
        this.tile = tile;
        this.x = x;
        this.y = y;
    }
}