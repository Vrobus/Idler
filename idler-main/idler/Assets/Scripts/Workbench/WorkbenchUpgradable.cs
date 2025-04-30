using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorkbenchUpgradable : MonoBehaviour
{
    [NonSerialized] public int level = 1;

    [SerializeField] protected ResourceWallet resourceWallet;

    [field: SerializeField] public WorkbenchLevel[] Levels { get; private set; }

    public event Action Upgraded;

    public bool TryUpgrade()
    {
        if (level - 1 >= Levels.Length) return false;

        if (!Array.TrueForAll(Levels[level - 1].ResourceCosts,
            resourceCost => resourceWallet.GetResourceByResourceSO(resourceCost.resourceSO).Amount >= resourceCost.amount)) return false;

        Array.ForEach(Levels[level - 1].ResourceCosts, resourceCost => resourceWallet.GetResourceByResourceSO(resourceCost.resourceSO).Amount -= resourceCost.amount);

        level++;
        IncrementStats();
        Upgraded?.Invoke();
        return true;
    }

    protected abstract void IncrementStats();
}
