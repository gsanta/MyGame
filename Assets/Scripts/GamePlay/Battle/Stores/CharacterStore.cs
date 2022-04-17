using System.Collections.Generic;

public class CharacterStore
{

    private List<ItemComponent> items = new List<ItemComponent>();
    public ItemComponent activeEnemy;

    public void SetNextEnemy()
    {
        if (activeEnemy == null)
        {
            activeEnemy = items[0];
        } else
        {
            activeEnemy = items.IndexOf(activeEnemy) == items.Count - 1 ? items[0] : items[items.IndexOf(activeEnemy)];
        }
    }

    public void AddItem(ItemComponent item)
    { 
        items.Add(item);
    }


    public GroundBlock selectedEnemy;
}
