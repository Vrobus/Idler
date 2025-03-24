using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UpgradeBarSegment : MonoBehaviour
{
    private Image image;

    public bool WasActivated { get; private set; }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public Color activeColor = Color.white;

    public void Activate()
    {
        image.color = activeColor;
        WasActivated = true;
    }
}
