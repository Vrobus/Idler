using UnityEngine;

public class PathUpgradable : WorkbenchUpgradable
{
    [SerializeField] private PlantSpawner[] pathLevels;
    [SerializeField] private GameObject hiddenObject; // Ссылка на скрытый объект в иерархии

    protected override void Start()
    {
        base.Start();
        InitializeHiddenObject();
        CheckMaxLevelImmediately();
    }

    protected override void IncrementStats()
    {
        if (level - 2 < pathLevels.Length)
        {
            pathLevels[level - 2].enabled = true;
        }
    }

    private void InitializeHiddenObject()
    {
        if (hiddenObject != null)
        {
            hiddenObject.SetActive(false); // Гарантируем, что объект изначально неактивен
        }
        else
        {
            Debug.LogWarning("Hidden Object не назначен в инспекторе!");
        }
    }

    private void CheckMaxLevelImmediately()
    {
        // Если объект уже на максимальном уровне при загрузке
        if (IsAtMaxLevel() && hiddenObject != null)
        {
            hiddenObject.SetActive(true);
        }
    }

    private bool IsAtMaxLevel()
    {
        return level - 1 >= Levels.Length;
    }

    private void OnMaxLevelReached()
    {
        if (hiddenObject != null)
        {
            hiddenObject.SetActive(true);
            Debug.Log("Максимальный уровень достигнут! Объект " + hiddenObject.name + " активирован.");
            
            // Дополнительные эффекты при активации (по желанию)
            
        }
    }

    

    private void OnEnable()
    {
        onMaxLevelReached.AddListener(OnMaxLevelReached);
    }

    private void OnDisable()
    {
        onMaxLevelReached.RemoveListener(OnMaxLevelReached);
    }

    
}
