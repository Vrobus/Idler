using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowbarUpgradable : WorkbenchUpgradable
{
    [SerializeField] private ResourceIncomeMultiplier resourceIncomeMultiplier;
    [SerializeField] private int[] resourcePerClickLevels;

    protected override void IncrementStats()
    {
        resourceIncomeMultiplier.value = resourcePerClickLevels[level - 2];
    }
}
