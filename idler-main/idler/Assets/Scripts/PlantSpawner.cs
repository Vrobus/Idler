using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    [SerializeField] private PlantDataHolder dataHolder;

    private Coroutine spawnPlantsRoutine;

    private void Start()
    {
        dataHolder.SpawnIntervalChanged += RestartSpawning;
        RestartSpawning();
    }

    private void RestartSpawning()
    {
        if (spawnPlantsRoutine != null)
        {
            StopCoroutine(spawnPlantsRoutine);
            spawnPlantsRoutine = null;
        }

        spawnPlantsRoutine = StartCoroutine(SpawnPlantsRoutine());
    }

    private IEnumerator SpawnPlantsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(dataHolder.MinSpawnInterval, dataHolder.MaxSpawnInterval));
            Instantiate(dataHolder.Prefabs[Random.Range(0, dataHolder.Prefabs.Count)], transform.position, Quaternion.identity);
        }
    }
}
