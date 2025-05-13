using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceIncrementer : MonoBehaviour
{
    [SerializeField] private ResourceWallet resourceWallet;
    [SerializeField] private ResourceChange[] resourceChanges;

    public Button startButton;         // ������ �������
    public float interval = 1f;        // �������� � ��������
    public int resource = 0;           // ������� �������

    private bool isRunning = false;

    void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartIncrementing);
        }
    }

    void StartIncrementing()
    {
        if (!isRunning)
        {
            isRunning = true;
            InvokeRepeating(nameof(AddResource), interval, interval);
        }
    }

    void AddResource()
    {
        foreach (var resourceChange in resourceChanges)
        {
            resourceWallet.GetResourceByResourceSO(resourceChange.resourceSO).Amount += resourceChange.amount;
        }
        Debug.Log("Resource: " + resource);
    }

    // ������������� � ����� ���������, ���� �����
    public void StopIncrementing()
    {
        isRunning = false;
        CancelInvoke(nameof(AddResource));
    }
}