using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceSO", menuName = "SO/Resource", order = 51)]
public class ResourceSO : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
}