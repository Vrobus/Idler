using UnityEngine;
public abstract class ClickableObjects : MonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] private float speed;
    private Pumping pumping;
    protected Resources resources;
    private GameObject managerResourcAndPump;
    private void Start()
    {
        managerResourcAndPump = GameObject.FindWithTag("ManagerResources");
        pumping = managerResourcAndPump.GetComponent<Pumping>();
        resources = managerResourcAndPump.GetComponent<Resources>();
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
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    protected abstract void GetDamage(int damage);
}
