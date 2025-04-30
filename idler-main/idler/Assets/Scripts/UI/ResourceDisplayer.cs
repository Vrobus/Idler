using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ResourceDisplayer : MonoBehaviour
{
    [SerializeField] private ResourceWallet resourceWallet;
    [SerializeField] private ResourceSO resourceSOToDisplay;

    private TextMeshProUGUI tmpu;

    private Resource resource;

    private void Start()
    {
        if (resourceWallet.IsDictionaryFilled) Initialize();
        else resourceWallet.DictionaryFilled += Initialize;
    }

    private void Initialize()
    {
        tmpu = GetComponent<TextMeshProUGUI>();
        resource = resourceWallet.GetResourceByResourceSO(resourceSOToDisplay);
        Redraw();
        resource.AmountChanged += Redraw;
    }

    private void Redraw()
    {
        tmpu.text = resource.Amount.ToString();
    }
}
