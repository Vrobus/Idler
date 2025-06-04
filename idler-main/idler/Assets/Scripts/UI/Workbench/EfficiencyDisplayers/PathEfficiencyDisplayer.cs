using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEfficiencyDisplayer : EfficiencyDisplayer
{
    protected override void Redraw()
    {
        SetText($"Дорожки: {workbenchUpgradable.level}");
    }
}
