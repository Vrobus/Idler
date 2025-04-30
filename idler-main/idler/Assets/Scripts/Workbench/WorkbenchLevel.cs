using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WorkbenchLevel
{
    [field: SerializeField] public ResourceChange[] ResourceCosts { get; private set; }
}
