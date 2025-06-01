using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterUpgradable : WorkbenchUpgradable
{
    [SerializeField] private float[] incrementIntervalLevels;

    private Coroutine incrementResourcesRoutine;

    protected override void IncrementStats()
    {
        if (incrementResourcesRoutine != null) StopCoroutine(incrementResourcesRoutine);
        incrementResourcesRoutine = StartCoroutine(IncrementResourcesRoutine());
    }

    private IEnumerator IncrementResourcesRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(incrementIntervalLevels[level - 2]);
            
            foreach (var resource in resourceWallet.Resources)
            {
                resource.Amount++;
            }
        }
    }
}
