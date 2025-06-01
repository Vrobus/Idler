using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CutterEfficiencyDisplayer : MonoBehaviour
{
    [SerializeField] private CutterUpgradable cutterUpgradable;

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
        cutterUpgradable.Upgraded += Redraw;
    }

    private void OnDisable()
    {
        cutterUpgradable.Upgraded -= Redraw;
    }

    private void Redraw()
    {
        tmpu.text = cutterUpgradable.level - 2 >= 0 ? $"Скорость добычи:\n1 ед. каждые {cutterUpgradable.IncrementIntervalLevels[cutterUpgradable.level - 2]} секунд" : "-";
    }
}
