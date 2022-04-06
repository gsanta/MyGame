using System.Collections.Generic;

public class CharacterStore
{

    public List<ItemComponent> enemies = new List<ItemComponent>();
    public ItemComponent activeEnemy;

    public void SetNextEnemy()
    {
        if (activeEnemy == null)
        {
            activeEnemy = enemies[0];
        } else
        {
            activeEnemy = enemies.IndexOf(activeEnemy) == enemies.Count - 1 ? enemies[0] : enemies[enemies.IndexOf(activeEnemy)];
        }
    }

    public void AddItem(ItemComponent item)
    {
        if (item.isEnemy)
        {
            enemies.Add(item);
        }
    }


    public GroundBlock selectedEnemy;
}
