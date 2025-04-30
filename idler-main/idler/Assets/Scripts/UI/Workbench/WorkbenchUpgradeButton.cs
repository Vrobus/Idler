using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class WorkbenchUpgradeButton : MonoBehaviour
{
    [SerializeField] private WorkbenchUpgradable workbenchUpgradable;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        workbenchUpgradable.TryUpgrade();
    }
}
