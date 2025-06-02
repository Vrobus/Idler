using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class CrowbarEfficiencyDisplayer : EfficiencyDisplayer
{
    [SerializeField] private ResourceIncomeMultiplier resourceIncomeMultiplier;

    protected override void Redraw()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine($"Кол-во ресурса / Клик: {resourceIncomeMultiplier.value}");
        SetText(stringBuilder.ToString());
    }
}
