using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.5f; // �������� ���������
    private Renderer renderer; // ��������� Renderer ��� ���������

    void Start()
    {
        // �������� ��������� Renderer
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // ������� �������� �� ��� X
        float offset = Time.time * scrollSpeed;
        renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }
}