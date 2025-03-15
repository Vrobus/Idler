public class Plant : ClickableObjects
{
    protected override void GetDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            transform.parent.GetComponent<ObjectFromResources>().plantDead = true;
            transform.parent.GetComponent<ObjectFromResources>().ChangeSprite();
            Destroy(gameObject);
        }
    }
    protected override void Move()
    {
        
    }
}
