using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField] private ResourceChange[] resourceCosts;
    [SerializeField] private GameObject frame;

    private ResourceWallet resourceWallet;

    public bool WasBought { get; private set; } = false;

    public event Action Bought;

    private void Start()
    {
        resourceWallet = GameObject.FindWithTag("ManagerResources").GetComponent<ResourceWallet>();
    }

    public void Buy()
    {
        // Check if can buy
        for (int i = 0; i < resourceCosts.Length; i++)
        {
            if (resourceWallet.GetResourceByResourceSO(resourceCosts[i].resourceSO).Amount < resourceCosts[i].amount) return;
        }

        // Subtract resources
        for (int i = 0; i < resourceCosts.Length; i++)
        {
            resourceWallet.GetResourceByResourceSO(resourceCosts[i].resourceSO).Amount -= resourceCosts[i].amount;
        }

        gameObject.GetComponent<Image>().color = Color.white;
        WasBought = true;
        if (gameObject.TryGetComponent(out Button button))
            button.enabled = true;
        Destroy(frame);
        Bought?.Invoke();
    }
}
