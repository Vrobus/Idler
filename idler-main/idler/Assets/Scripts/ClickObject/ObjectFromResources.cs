using UnityEngine;
public class ObjectFromResources : ClickableObjects
{
    [HideInInspector] public bool plantDead = false;
    [SerializeField] private ObjectFromResSO objectFromResSO;
    public void ChangeSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = objectFromResSO.objectWithoutPlant;
    }
    protected override void GetDamage(int damage)
    {
        if (plantDead)
        {
            hp -= damage;
        }
        if (hp <= 0)
        {
            resources.GetMaterials(objectFromResSO.countWood, objectFromResSO.countMetal);
            Destroy(gameObject);
        }
    }
    protected override void Move()
    {
        base.Move();
        if (transform.position.x >= objectFromResSO.pointDie.x)
        {
            Destroy(gameObject);
        }
    }
    
}
