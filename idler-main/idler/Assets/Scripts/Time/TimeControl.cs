using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;

    private void Awake()
    {
        if (pauseButton != null)
            pauseButton.onClick.AddListener(PauseTime);
        else
            Debug.LogError("Pause Button не назначена в инспекторе!");

        if (resumeButton != null)
            resumeButton.onClick.AddListener(ResumeTime);
        else
            Debug.LogError("Resume Button не назначена в инспекторе!");
    }

    private void PauseTime()
    {
        Time.timeScale = 0f;
    }

    private void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    private void OnDestroy()
    {
        if (pauseButton != null)
            pauseButton.onClick.RemoveListener(PauseTime);

        if (resumeButton != null)
            resumeButton.onClick.RemoveListener(ResumeTime);
    }
}