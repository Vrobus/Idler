using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerUpgradable : WorkbenchUpgradable
{
    [SerializeField] private SpawnPlant plantSpawner;
    [SerializeField] private float[] spawnIntervalDivisionLevels;

    protected override void IncrementStats()
    {
        plantSpawner.DivideSpawnInterval(spawnIntervalDivisionLevels[level - 2]);
    }
}
