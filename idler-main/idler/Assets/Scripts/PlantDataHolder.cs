using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDataHolder : MonoBehaviour
{
    [field: SerializeField] public List<GameObject> Prefabs { get; private set; }

    [SerializeField] private float minSpawnInterval = 5f;
    [SerializeField] private float maxSpawnInterval = 10f;

    public float MinSpawnInterval
    {
        get => minSpawnInterval;
        set
        {
            if (minSpawnInterval == value) return;
            SpawnIntervalChanged?.Invoke();
            minSpawnInterval = value;
        }
    }

    public float MaxSpawnInterval
    {
        get => maxSpawnInterval;
        set
        {
            if (maxSpawnInterval == value) return;
            SpawnIntervalChanged?.Invoke();
            maxSpawnInterval = value;
        }
    }

    public event Action SpawnIntervalChanged;

    public void DivideSpawnInterval(float divider)
    {
        MinSpawnInterval /= divider;
        MaxSpawnInterval /= divider;
    }
}
