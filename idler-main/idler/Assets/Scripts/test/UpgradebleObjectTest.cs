using UnityEngine;
using UnityEngine.UI;

public class UpgradebleObjectTest : MonoBehaviour
{
    [Header("Настройки улучшений")]
    [SerializeField] private int maxLevel = 3;
    [SerializeField] private int currentLevel = 1;

    [Header("Кнопка для появления")]
    [SerializeField] private GameObject secretButton; // Новая кнопка, которая появится

    [Header("UI элементы")]
    [SerializeField] private Text levelText;
    [SerializeField] private Button upgradeButton;

    

    private void Start()
    {
        UpdateUI();
        secretButton.SetActive(false); // Скрываем кнопку в начале
    }

    public void Upgrade()
    {
        if (currentLevel >= maxLevel) return;

        currentLevel++;
        UpdateUI();

        // Если достигли максимального уровня
        if (currentLevel == maxLevel)
        {
            ShowSecretButton();
        }
    }

    private void UpdateUI()
    {
        levelText.text = $"Уровень: {currentLevel}/{maxLevel}";

        // Отключаем кнопку улучшения при достижении максимума
        upgradeButton.interactable = currentLevel < maxLevel;
    }

    private void ShowSecretButton()
    {
        secretButton.SetActive(true);
        // Можно добавить анимацию или эффект
        Debug.Log("Достигнут максимальный уровень! Новая кнопка активирована.");
    }
}