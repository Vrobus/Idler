using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SpawnerEfficiencyDisplayer : EfficiencyDisplayer
{
    private readonly StringBuilder stringBuilder = new();

    [SerializeField] private SpawnPlant plantSpawner;

    protected override void Redraw()
    {
        float minTime = Mathf.RoundToInt(plantSpawner.MinTimeSpawn);
        float maxTime = Mathf.RoundToInt(plantSpawner.MaxTimeSpawn);

        stringBuilder.Clear();
        stringBuilder.AppendLine("������� ��������� ������");
        stringBuilder.AppendLine($"{minTime}-{maxTime} ������");
        SetText(stringBuilder.ToString());
    }
}
