using BehaviorDesigner.Runtime.Tasks.Unity.UnityParticleSystem;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public PlayerStats PlayerStats;

    [HideInInspector] public virtual float Damage { get; set; }

    public Rigidbody RB;

    float lifetime = 10.0f;

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out EnemyWeakness enemyWeakness))
        {
            enemyWeakness.Enemy.TakeDamage(Damage * 2);
            // Add animation later.
            ObjectPooler.EnqueuObject(this, "DefaultProjectile");
        }
        else if (other.TryGetComponent(out EnemyController enemyController))
        {
            enemyController.TakeDamage(Damage);
            // Add animation later.
            ObjectPooler.EnqueuObject(this, "DefaultProjectile");
        }
        else if (other.TryGetComponent(out IDamagable enemy))
        {
            enemy.TakeDamage(Damage);
            // Add animation later.

            // Move pooling behaviour to teh hit unit.
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
