using System;
using UnityEngine;

namespace Puzzle
{
    public class GroundFactory : MonoBehaviour
    {
        public GameObject[] grounds;
        public GameObject Create(GroundType type, Vector3 position, GameObject parent = null)
        {
            var gameObject = Instantiate(GetPrefabByType(type), position, Quaternion.identity, transform);
            gameObject.SetActive(true);
            if (parent)
            {
                gameObject.transform.SetParent(parent.transform);
            }

            return gameObject;
        }

        public GroundType GetRandomGroundType()
        {
            var length = Enum.GetNames(typeof(GroundType)).Length;
            var index = UnityEngine.Random.Range(0, length);
            return (GroundType)index;
        }

        private GameObject GetPrefabByType(GroundType type)
        {
            return Array.Find(grounds, ground => ground.GetComponent<Ground>().type == type);
        }
    }
}
