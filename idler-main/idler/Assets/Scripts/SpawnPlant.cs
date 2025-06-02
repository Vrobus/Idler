using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SpawnPlant : MonoBehaviour
{
    public List<GameObject> prefabs;
    [SerializeField] private float minTimeSpawn;
    [SerializeField] private float maxTimeSpawn;
    private float elapsedTime = 0;

    public float MinTimeSpawn => minTimeSpawn;
    public float MaxTimeSpawn => maxTimeSpawn;

    private void Update()
    {
        TickSpawner(Random.Range(minTimeSpawn, maxTimeSpawn));
    }

    private void TickSpawner(float time)
    {
        if(elapsedTime >= time)
        {
            Instantiate(prefabs[Random.Range(0, prefabs.Count)], transform.position, Quaternion.identity);
            elapsedTime = 0;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }
    }

    public void DivideSpawnInterval(float divider)
    {
        minTimeSpawn /= divider;
        maxTimeSpawn /= divider;
    }
}
