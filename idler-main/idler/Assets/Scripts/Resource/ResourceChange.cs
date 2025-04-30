using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ResourceChange
{
    public ResourceSO resourceSO;
    public int amount;

    public ResourceChange(ResourceSO resourceSO, int amount)
    {
        this.resourceSO = resourceSO;
        this.amount = amount;
    }
}
