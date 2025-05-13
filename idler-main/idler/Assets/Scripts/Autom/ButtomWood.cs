using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomWood : MonoBehaviour
{
    [SerializeField] private ResourceChange[] resourceCosts;
    [SerializeField] private ResourceWallet resourceWallet;
    [SerializeField] private Building bedBulding;
    [SerializeField] private ResourceIncrementer resourceIncrementer;

    // Start is called before the first frame update
    void Start()
    {
        bedBulding.Bought += OnBought;
        gameObject.SetActive(false);
    }

    private void OnBought()
    {
        gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
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

        resourceIncrementer.StartIncrementing();
    }
}
