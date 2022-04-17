using UnityEngine;

public class GroundBlock
{
    public GameObject gameObject;
    public ItemComponent Item { set; get; }
    public readonly int x;
    public readonly int y;

    public GroundBlock(int x, int y, GameObject gameObject)
    {
        this.gameObject = gameObject;
        this.x = x;
        this.y = y;
    }
}
