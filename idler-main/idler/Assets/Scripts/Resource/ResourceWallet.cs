using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceWallet : MonoBehaviour
{
    private readonly Dictionary<ResourceSO, Resource> resourceDictionary = new();

    [field: SerializeField] public Resource[] Resources { get; private set; }

    public bool IsDictionaryFilled { get; private set; } = false;

    public event Action DictionaryFilled;

    private void Start()
    {
        for (int i = 0; i < Resources.Length; i++)
        {
            resourceDictionary.Add(Resources[i].ResourceSO, Resources[i]);
        }

        IsDictionaryFilled = true;
        DictionaryFilled?.Invoke();
    }

    public Resource GetResourceByResourceSO(ResourceSO resourceSO)
    {
        return resourceDictionary.GetValueOrDefault(resourceSO) ?? throw new Exception("Resource not found");
    }
}
