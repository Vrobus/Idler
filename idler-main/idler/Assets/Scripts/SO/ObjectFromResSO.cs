using UnityEngine;
[CreateAssetMenu(fileName = "ObjectFromResSO", menuName = "SO/ObjectFromRes", order = 51)]
public class ObjectFromResSO : ScriptableObject
{
    public string Name;
    public ResourceChange[] resourceChanges;
    public Vector2 pointDie;
    public Sprite objectWithPlant;
    public Sprite objectWithoutPlant;
}
