using UnityEngine;

public class PathUpgradable : WorkbenchUpgradable
{
    [SerializeField] private PlantSpawner[] pathLevels;
    [SerializeField] private GameObject hiddenObject; // ������ �� ������� ������ � ��������

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
            hiddenObject.SetActive(false); // �����������, ��� ������ ���������� ���������
        }
        else
        {
            Debug.LogWarning("Hidden Object �� �������� � ����������!");
        }
    }

    private void CheckMaxLevelImmediately()
    {
        // ���� ������ ��� �� ������������ ������ ��� ��������
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
            Debug.Log("������������ ������� ���������! ������ " + hiddenObject.name + " �����������.");
            
            // �������������� ������� ��� ��������� (�� �������)
            
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
