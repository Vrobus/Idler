using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.5f; // Скорость прокрутки
    private Renderer renderer; // Компонент Renderer для материала

    void Start()
    {
        // Получаем компонент Renderer
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Смещаем текстуру по оси X
        float offset = Time.time * scrollSpeed;
        renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }
}