using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Resource
{
    [field: SerializeField] public ResourceSO ResourceSO { get; private set; }
    [SerializeField] private int amount = 0;

    public int Amount
    {
        get => amount;
        set
        {
            if (amount == value) return;
            amount = value;
            AmountChanged?.Invoke();
        }
    }

    public event Action AmountChanged;
}
