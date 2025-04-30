using UnityEngine;

public class ObjectFromResources : ClickableObjects
{
    [HideInInspector] public bool plantDead = false;
    [SerializeField] private ObjectFromResSO objectFromResSO;

    private ResourceIncomeMultiplier resourceIncomeMultiplier;

    protected override void Start()
    {
        base.Start();
        resourceIncomeMultiplier = FindObjectOfType<ResourceIncomeMultiplier>();
    }

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
            for (int i = 0; i < objectFromResSO.resourceChanges.Length; i++)
            {
                ResourceChange resourceChange = objectFromResSO.resourceChanges[i];
                resources.GetResourceByResourceSO(resourceChange.resourceSO).Amount += resourceChange.amount * resourceIncomeMultiplier.value;
            }
            
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
