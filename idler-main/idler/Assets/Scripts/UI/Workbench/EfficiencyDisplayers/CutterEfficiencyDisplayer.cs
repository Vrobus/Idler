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
        SetText(CutterUpgradable.level - 2 >= 0 ? $"Скорость добычи:\n1 ед. каждые {CutterUpgradable.IncrementIntervalLevels[CutterUpgradable.level - 2]} секунд" : "Aвтодобыча ресурсов");
    }
}
