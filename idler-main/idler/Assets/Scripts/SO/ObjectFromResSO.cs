using UnityEngine;
[CreateAssetMenu(fileName = "ObjectFromResSO")]
public class ObjectFromResSO : ScriptableObject
{
    public string Name;
    public int countWood;
    public int countMetal;
    public Vector2 pointDie;
    public Sprite objectWithPlant;
    public Sprite objectWithoutPlant;
}
