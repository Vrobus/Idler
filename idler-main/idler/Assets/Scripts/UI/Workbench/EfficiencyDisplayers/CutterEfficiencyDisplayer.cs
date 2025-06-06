using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CutterEfficiencyDisplayer : EfficiencyDisplayer
{
    private CutterUpgradable CutterUpgradable => (CutterUpgradable)workbenchUpgradable;

    protected override void Redraw()
    {
        SetText(CutterUpgradable.level - 2 >= 0 ? $"�������� ������:\n1 ��. ������ {CutterUpgradable.IncrementIntervalLevels[CutterUpgradable.level - 2]} ������" : "A��������� ��������");
    }
}
