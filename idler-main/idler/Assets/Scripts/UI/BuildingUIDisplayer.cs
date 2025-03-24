using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingUIDisplayer : MonoBehaviour
{
    public Building building;

    [field: SerializeField] public UnityEvent OnDisplayed { get; private set; }

    public void DisplayIfBought()
    {
        if (!building.WasBought) return;
        OnDisplayed?.Invoke();
    }
}
