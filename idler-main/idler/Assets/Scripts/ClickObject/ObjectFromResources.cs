using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ObjectFromResources : ClickableObjects
{
    [HideInInspector] public bool plantDead = false;
    [SerializeField] private ObjectFromResSO objectFromResSO;

    private SpriteRenderer spriteRenderer;

    private ResourceIncomeMultiplier resourceIncomeMultiplier;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Start()
    {
        base.Start();
        resourceIncomeMultiplier = FindObjectOfType<ResourceIncomeMultiplier>();
        spriteRenderer.sprite = objectFromResSO.objectWithPlant;
    }

    public void ChangeSprite()
    {
        spriteRenderer.sprite = objectFromResSO.objectWithoutPlant;
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
