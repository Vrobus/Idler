using UnityEngine;

public class SpawnPlant : MonoBehaviour
{
    private GameObject curPlant;
    [SerializeField] private GameObject[] prefabsPlant;
    [SerializeField] private float minTimeSpawn;
    [SerializeField] private float maxTimeSpawn;
    private bool exist = true;
    private float elapsedTime = 0;
    private void Update()
    {
        if(curPlant == null && exist)
        {
            exist = false;
        }
        if (!exist)
        {
            TimeToSpawn(Random.Range(minTimeSpawn, maxTimeSpawn));
        }
    }
    private void TimeToSpawn(float time)
    {
        if(elapsedTime >= time)
        {
            curPlant = Instantiate(prefabsPlant[Random.Range(0, prefabsPlant.Length)], transform.position, Quaternion.identity);
            exist = true;
            elapsedTime = 0;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }
    }
}
