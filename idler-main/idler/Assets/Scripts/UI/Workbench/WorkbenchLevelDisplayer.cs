using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class WorkbenchLevelDisplayer : MonoBehaviour
{
    [SerializeField] private WorkbenchUpgradable workbenchUpgradable;

    private TextMeshProUGUI tmpu;

    private void Awake()
    {
        tmpu = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        workbenchUpgradable.Upgraded += Redraw;
    }

    private void OnDisable()
    {
        workbenchUpgradable.Upgraded -= Redraw;
    }

    private void Redraw()
    {
        tmpu.text = $"Уровень: {workbenchUpgradable.level}";
    }
}
