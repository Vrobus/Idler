using UnityEngine;

public class ClickParticleEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private float stopDelay = 2f; // �������� ����� ����������

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
            Debug.LogError("Particle System �� �������� � ����������!");
        }
    }

    void Update()
    {
        // ������� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            isMouseHeld = true;
            UpdateParticlePosition();
            particles.Play();
        }

        // ��������� ������ ����
        if (Input.GetMouseButton(0) && isMouseHeld)
        {
            UpdateParticlePosition();
        }

        // ���������� ������ ����
        if (Input.GetMouseButtonUp(0))
        {
            isMouseHeld = false;
            mouseReleaseTime = Time.time;
        }

        // �������� ����� ����������
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