using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerUpgradable : WorkbenchUpgradable
{
    [SerializeField] private PlantDataHolder dataHolder;
    [SerializeField] private float[] spawnIntervalDivisionLevels;

    protected override void IncrementStats()
    {
        dataHolder.DivideSpawnInterval(spawnIntervalDivisionLevels[level - 2]);
    }
}
