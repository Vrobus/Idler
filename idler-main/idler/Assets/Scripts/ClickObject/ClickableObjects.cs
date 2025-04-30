using UnityEngine;
public abstract class ClickableObjects : MonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] private float speed;
    private Pumping pumping;
    protected ResourceWallet resources;
    private GameObject managerResourcAndPump;

    protected virtual void Start()
    {
        managerResourcAndPump = GameObject.FindWithTag("ManagerResources");
        pumping = managerResourcAndPump.GetComponent<Pumping>();
        resources = managerResourcAndPump.GetComponent<ResourceWallet>();
    }

    private void Update()
    {
        Move();
    }

    private void OnMouseDown()
    {
        GetDamage(pumping.damageClick);
    }

    protected virtual void Move()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }

    protected abstract void GetDamage(int damage);
}
