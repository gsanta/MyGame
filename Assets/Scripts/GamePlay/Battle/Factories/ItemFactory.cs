using UnityEngine;

namespace Battle
{
    public class ItemFactory : MonoBehaviour
    {
        [SerializeField] private Material characterMaterialLight;
        [SerializeField] private Material characterMaterialDark;
        [SerializeField] private GameObject characterPrefab;
        
        public ItemComponent Create(ItemType itemType, GroundBlock block, Vector3 position, int teamIndex)
        {
            GameObject gameObject = null;

            switch(itemType)
            {
                case ItemType.Character:
                    gameObject = Instantiate(characterPrefab, position, characterPrefab.transform.rotation, transform);
                    break;
            }

            if (gameObject != null && isEnemy)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.black;
            }

            var itemComponent = gameObject.GetComponent<ItemComponent>();
            itemComponent.isEnemy = isEnemy;
            itemComponent.block = block;
            return itemComponent;
        }
    }
}