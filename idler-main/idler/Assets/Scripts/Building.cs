using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField] private int countWoodForBuy;
    [SerializeField] private int countMetalForBuy;
    [SerializeField] private GameObject frame;

    private Resources resources;

    public bool WasBought { get; private set; } = false;

    private void Start()
    {
        resources = GameObject.FindWithTag("ManagerResources").GetComponent<Resources>();
    }

    public void Buy()
    {
        if (resources.wood >= countWoodForBuy && resources.metal >= countMetalForBuy)
        {
            resources.wood -= countWoodForBuy;
            resources.metal -= countMetalForBuy;
            resources.TextUpDate();
            gameObject.GetComponent<Image>().color = Color.white;
            WasBought = true;
            gameObject.GetComponent<Button>().enabled = true;
            Destroy(frame);
        }
    }
}
