using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawningBuilding : MonoBehaviour
{
    [SerializeField] private Building building;
    [SerializeField] private PlantDataHolder plantDataHolder;
    [SerializeField] private GameObject prefabToSpawn;

    private void Awake()
    {
        building.Bought += OnBought;
    }

    private void OnBought()
    {
        plantDataHolder.Prefabs.Add(prefabToSpawn);
    }
}
