using UnityEngine;

public class ClickParticleEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private float stopDelay = 2f; // Задержка перед остановкой

    private Camera mainCamera;
    private bool isMouseHeld;
    private float mouseReleaseTime;

    void Start()
    {
        mainCamera = Camera.main;

        if (particles != null)
        {
            particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
        else
        {
            Debug.LogError("Particle System не назначен в инспекторе!");
        }
    }

    void Update()
    {
        // Нажатие кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
            isMouseHeld = true;
            UpdateParticlePosition();
            particles.Play();
        }

        // Удержание кнопки мыши
        if (Input.GetMouseButton(0) && isMouseHeld)
        {
            UpdateParticlePosition();
        }

        // Отпускание кнопки мыши
        if (Input.GetMouseButtonUp(0))
        {
            isMouseHeld = false;
            mouseReleaseTime = Time.time;
        }

        // Задержка после отпускания
        if (!isMouseHeld && particles.isPlaying && Time.time >= mouseReleaseTime + stopDelay)
        {
            particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    void UpdateParticlePosition()
    {
        Vector3 clickPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        clickPosition.z = 0;
        particles.transform.position = clickPosition;
    }
}