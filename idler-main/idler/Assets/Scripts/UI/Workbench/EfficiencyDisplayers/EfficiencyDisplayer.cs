using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(TextMeshProUGUI))]
public abstract class EfficiencyDisplayer : MonoBehaviour
{
    [SerializeField] protected WorkbenchUpgradable workbenchUpgradable;

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

    protected abstract void Redraw();

    protected void SetText(string text)
    {
        tmpu.text = text;
    }
}
