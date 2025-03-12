using UnityEngine;

public class DamageHeal : MonoBehaviour
{
    [SerializeField]
    public int damageHeal = 10;
    [SerializeField]
    public string target;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(target))
        {
            OnPicked(collision);
            //Destroy(gameObject, 2);
        }
    }


    protected virtual void OnPicked(Collider other)
    {
        
        HealthManager healthManager = other.GetComponent<HealthManager>();
        if (!healthManager) { return; }
        healthManager.Damage(damageHeal);
    }
}
