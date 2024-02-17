using BehaviorDesigner.Runtime.Tasks.Unity.UnityParticleSystem;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public float Damage;

    public Rigidbody RB;

    float lifetime = 6.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out EnemyController enemyController))
        {
            enemyController.TakeDamage(Damage);
            // Add animation later.
            ObjectPooler.EnqueuObject(this, "DefaultProjectile");
        }
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime < 0.0f)
        {
            ObjectPooler.EnqueuObject(this, "DefaultProjectile");
        }
    }
}
