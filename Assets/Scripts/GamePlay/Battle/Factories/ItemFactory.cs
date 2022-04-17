using UnityEngine;

namespace Battle
{
    public class ItemFactory : MonoBehaviour
    {
        [SerializeField] private Material[] characterMaterials;
        [SerializeField] private GameObject characterPrefab;
        
        public GameObject Create(ItemType itemType, GroundBlock block, Vector3 position, int teamIndex)
        {
            GameObject gameObject = null;

            switch(itemType)
            {
                case ItemType.Character:
                    gameObject = Instantiate(characterPrefab, position, characterPrefab.transform.rotation, transform);
                    break;
            }

            gameObject.GetComponent<Renderer>().material = characterMaterials[teamIndex];
            
            var itemComponent = gameObject.GetComponent<ItemComponent>();
            itemComponent.block = block;
            itemComponent.teamIndex = teamIndex;
            return gameObject;
        }
    }
}