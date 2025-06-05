using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class WorkbenchUpgradable : MonoBehaviour
{
    protected virtual void Start()
    {
        // Можно оставить пустым или перенести общий код инициализации сюда
    }

    [NonSerialized] public int level = 1;

    [SerializeField] protected ResourceWallet resourceWallet;
    [field: SerializeField] public WorkbenchLevel[] Levels { get; private set; }

    // Событие при достижении максимального уровня
    public UnityEvent onMaxLevelReached;

    public event Action Upgraded;

    public bool TryUpgrade()
    {
        if (level - 1 >= Levels.Length) return false;

        if (!Array.TrueForAll(Levels[level - 1].ResourceCosts,
            resourceCost => resourceWallet.GetResourceByResourceSO(resourceCost.resourceSO).Amount >= resourceCost.amount))
            return false;

        Array.ForEach(Levels[level - 1].ResourceCosts, resourceCost =>
            resourceWallet.GetResourceByResourceSO(resourceCost.resourceSO).Amount -= resourceCost.amount);

        level++;
        IncrementStats();
        Upgraded?.Invoke();

        // Проверяем достижение максимального уровня
        if (level - 1 >= Levels.Length)
        {
            onMaxLevelReached?.Invoke();
        }

        return true;
    }

    protected abstract void IncrementStats();
}