using UnityEngine;
using UnityEngine.UI;

public class UpgradebleObjectTest : MonoBehaviour
{
    [Header("��������� ���������")]
    [SerializeField] private int maxLevel = 3;
    [SerializeField] private int currentLevel = 1;

    [Header("������ ��� ���������")]
    [SerializeField] private GameObject secretButton; // ����� ������, ������� ��������

    [Header("UI ��������")]
    [SerializeField] private Text levelText;
    [SerializeField] private Button upgradeButton;

    

    private void Start()
    {
        UpdateUI();
        secretButton.SetActive(false); // �������� ������ � ������
    }

    public void Upgrade()
    {
        if (currentLevel >= maxLevel) return;

        currentLevel++;
        UpdateUI();

        // ���� �������� ������������� ������
        if (currentLevel == maxLevel)
        {
            ShowSecretButton();
        }
    }

    private void UpdateUI()
    {
        levelText.text = $"�������: {currentLevel}/{maxLevel}";

        // ��������� ������ ��������� ��� ���������� ���������
        upgradeButton.interactable = currentLevel < maxLevel;
    }

    private void ShowSecretButton()
    {
        secretButton.SetActive(true);
        // ����� �������� �������� ��� ������
        Debug.Log("��������� ������������ �������! ����� ������ ������������.");
    }
}