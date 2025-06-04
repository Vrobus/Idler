using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathUpgradable : WorkbenchUpgradable
{
    [SerializeField] private PlantSpawner[] pathLevels; 

    protected override void IncrementStats()
    {
        pathLevels[level - 2].enabled = true;
    }
}