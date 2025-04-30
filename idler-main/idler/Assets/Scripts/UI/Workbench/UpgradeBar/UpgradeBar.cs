using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBar : MonoBehaviour
{
    [SerializeField] private WorkbenchUpgradable workbenchUpgradable;

    private UpgradeBarSegment[] segments;

    private void Awake()
    {
        segments = GetComponentsInChildren<UpgradeBarSegment>(true);
    }

    private void OnEnable()
    {
        workbenchUpgradable.Upgraded += IncrementFill;
    }

    private void OnDisable()
    {
        workbenchUpgradable.Upgraded -= IncrementFill;
    }

    public void IncrementFill()
    {
        for (int i = 0; i < segments.Length; i++)
        {
            if (segments[i].WasActivated) continue;
            segments[i].Activate();
            break;
        }
    }
}
