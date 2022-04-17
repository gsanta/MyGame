using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundFactory : MonoBehaviour
{
    [SerializeField] private GameObject[] groundPrefabs;
    private Dictionary<GroundType, GameObject> groundPrefabMap = new Dictionary<GroundType, GameObject>();

    private void Awake()
    {
        Array.ForEach(groundPrefabs, (groundPrefab) =>
        {
            var ground = groundPrefab.GetComponent<Ground>();
            groundPrefabMap.Add(ground.type, groundPrefab);
        });
    }

    public GameObject Create(GroundType groundType, Vector3 worldPos)
    {
        var prefab = groundPrefabMap[groundType];

        var ground = Instantiate(prefab, worldPos, Quaternion.identity, transform);
        ground.gameObject.SetActive(true);
        return ground;
    }
}