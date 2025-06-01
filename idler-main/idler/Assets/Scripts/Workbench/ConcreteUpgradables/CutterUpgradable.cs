using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterUpgradable : WorkbenchUpgradable
{
    [field: SerializeField] public float[] IncrementIntervalLevels { get; private set; }

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
            yield return new WaitForSeconds(IncrementIntervalLevels[level - 2]);
            
            foreach (var resource in resourceWallet.Resources)
            {
                resource.Amount++;
            }
        }
    }
}
