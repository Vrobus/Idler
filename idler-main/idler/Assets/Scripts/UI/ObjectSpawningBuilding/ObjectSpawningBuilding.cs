using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawningBuilding : MonoBehaviour
{
    [SerializeField] private Building building;
    [SerializeField] private SpawnPlant plantSpawner;
    [SerializeField] private GameObject prefabToSpawn;

    private void Awake()
    {
        building.Bought += OnBought;
    }

    private void OnBought()
    {
        plantSpawner.prefabs.Add(prefabToSpawn);
    }
}
