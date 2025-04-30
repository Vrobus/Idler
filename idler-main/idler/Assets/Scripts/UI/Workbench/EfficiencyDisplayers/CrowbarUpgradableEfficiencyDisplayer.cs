using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CrowbarUpgradableEfficiencyDisplayer : MonoBehaviour
{
    [SerializeField] private ResourceIncomeMultiplier resourceIncomeMultiplier;
    [SerializeField] private WorkbenchUpgradable workbenchUpgradable;

    private TextMeshProUGUI tmpu;

    private void Awake()
    {
        tmpu = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        Redraw();
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
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine($"Кол-во ресурса / Клик: {resourceIncomeMultiplier.value}");
        tmpu.text = stringBuilder.ToString();
    }
}
