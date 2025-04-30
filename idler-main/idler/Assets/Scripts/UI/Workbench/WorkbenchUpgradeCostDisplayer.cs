using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class WorkbenchUpgradeCostDisplayer : MonoBehaviour
{
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
        stringBuilder.AppendLine("Стоимость улучшения:");

        if (workbenchUpgradable.level - 1 < workbenchUpgradable.Levels.Length)
        {
            foreach (var resourceCost in workbenchUpgradable.Levels[workbenchUpgradable.level - 1].ResourceCosts)
            {
                stringBuilder.AppendLine($"{resourceCost.resourceSO.Name} - {resourceCost.amount}");
            }
        }
        else
        {
            stringBuilder.Append("-");
        }

        tmpu.text = stringBuilder.ToString();
    }
}
