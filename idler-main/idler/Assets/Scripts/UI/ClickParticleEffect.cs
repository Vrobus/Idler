using UnityEngine;

public class ClickParticleEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private float stopDelay = 2f; // Çàäåðæêà ïåðåä îñòàíîâêîé

    private Camera mainCamera;
    private bool isMouseHeld;
    private float mouseReleaseTime;
    AudioManager audioManager;


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

        // Инициализация audioManager
        GameObject audioObject = GameObject.FindGameObjectWithTag("Audio");
        if (audioObject != null)
        {
            audioManager = audioObject.GetComponent<AudioManager>();
            if (audioManager == null)
            {
                Debug.LogError("AudioManager компонент не найден на объекте с тегом Audio!");
            }
        }
        else
        {
            Debug.LogError("Объект с тегом Audio не найден!");
        }
    }


    void Update()
    {
        
        
        // Íàæàòèå êíîïêè ìûøè
        if (Input.GetMouseButtonDown(0))
        {
            isMouseHeld = true;
            UpdateParticlePosition();
            particles.Play();
            audioManager.PlaySFX(audioManager.cuttingLeaves);

        }

        // Óäåðæàíèå êíîïêè ìûøè
        if (Input.GetMouseButton(0) && isMouseHeld)
        {
            UpdateParticlePosition();
        }

        // Îòïóñêàíèå êíîïêè ìûøè
        if (Input.GetMouseButtonUp(0))
        {
            isMouseHeld = false;
            mouseReleaseTime = Time.time;
        }

        // Çàäåðæêà ïîñëå îòïóñêàíèÿ
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