using UnityEngine;

public class GroundBlock
{
    public GroundTileComponent block;
    public ItemComponent Item { set; get; }
    public readonly int x;
    public readonly int y;

    public GroundBlock(int x, int y, GroundTileComponent block)
    {
        this.block = block;
        this.x = x;
        this.y = y;
    }
}
