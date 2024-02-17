using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public float Damage;

    public Rigidbody RB;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out EnemyController enemyController))
        {
            enemyController.TakeDamage(Damage);
            // Add animation later.
            Destroy(gameObject);
        }
    }
}
