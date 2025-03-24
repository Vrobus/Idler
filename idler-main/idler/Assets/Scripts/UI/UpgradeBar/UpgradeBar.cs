using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBar : MonoBehaviour
{
    private UpgradeBarSegment[] segments;

    private void Awake()
    {
        segments = GetComponentsInChildren<UpgradeBarSegment>(true);
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
