using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SpawnerEfficiencyDisplayer : EfficiencyDisplayer
{
    private readonly StringBuilder stringBuilder = new();

    [SerializeField] private PlantDataHolder plantDataHolder;

    protected override void Redraw()
    {
        float minTime = Mathf.RoundToInt(plantDataHolder.MinSpawnInterval);
        float maxTime = Mathf.RoundToInt(plantDataHolder.MaxSpawnInterval);

        stringBuilder.Clear();
        stringBuilder.AppendLine("������� ��������� ������");
        stringBuilder.AppendLine($"{minTime}-{maxTime} ������");
        SetText(stringBuilder.ToString());
    }
}
