using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomWood : MonoBehaviour
{
    [SerializeField] private Building bedBulding;

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
}
