using UnityEngine;

public class GroundBlock
{
    public GameObject ground;
    public GameObject item;
    public readonly int x;
    public readonly int y;

    public GroundBlock(int x, int y, GameObject ground)
    {
        this.ground = ground;
        this.x = x;
        this.y = y;
    }
    
    public ItemComponent GetItem()
    {
        return item != null ? item.GetComponent<ItemComponent>() : null;
    }
}
