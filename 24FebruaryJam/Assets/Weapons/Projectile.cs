using BehaviorDesigner.Runtime.Tasks.Unity.UnityParticleSystem;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public PlayerStats PlayerStats;

    public GameObject VFXHitGraphics;

    [HideInInspector] public virtual float Damage { get; set; }

    public Rigidbody RB;

    float lifetime = 4f;

    private void OnEnable()
    {
        lifetime = 4f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyWeakness enemyWeakness))
        {
            VFXHit(transform.position);
            enemyWeakness.Enemy.TakeDamage(Damage * 2);
            // Add animation later.
            ObjectPooler.EnqueuObject(this, "DefaultProjectile");
        }
        else if (other.TryGetComponent(out EnemyController enemyController))
        {
            VFXHit(transform.position);
            enemyController.TakeDamage(Damage);
            // Add animation later.
            ObjectPooler.EnqueuObject(this, "DefaultProjectile");
        }
        else if (other.TryGetComponent(out IDamagable enemy))
        {
            VFXHit(transform.position);
            enemy.TakeDamage(Damage);
            // Add animation later.

            // Move pooling behaviour to teh hit unit.
            ObjectPooler.EnqueuObject(this, "DefaultProjectile");
        }


    }

    void VFXHit(Vector3 position)
    {
        GameObject effect = Instantiate(VFXHitGraphics, position, Quaternion.identity, null);
        Destroy(effect, 1);
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
