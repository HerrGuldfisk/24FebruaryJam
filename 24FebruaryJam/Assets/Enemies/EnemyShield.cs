using UnityEngine;

public class EnemyShield : MonoBehaviour, IDamagable
{
    public void TakeDamage(float damage)
    {
        Destroy(gameObject);
    }
}
