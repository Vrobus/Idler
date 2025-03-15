using TMPro;
using UnityEngine;
public class Resources : MonoBehaviour
{
    public int wood;
    public int metal;
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI metalText;
    public void GetMaterials(int MaterialsWood, int MaterialsMetal)
    {
        wood += MaterialsWood;
        metal += MaterialsMetal;
        TextUpDate();
    }
    public void TextUpDate()
    {
        woodText.text = $"{wood}";
        metalText.text = $"{metal}";
    }
}
