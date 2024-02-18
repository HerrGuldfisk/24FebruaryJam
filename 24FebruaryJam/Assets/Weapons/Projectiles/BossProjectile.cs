using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [HideInInspector] public virtual float Damage { get; set; }

    public Rigidbody RB;

    float lifetime = 10.0f;

    private void OnEnable()
    {
        lifetime = 10f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerControllerScript playerController))
        {
            playerController.TakeDamage(Damage);
            // Add animation later.
            ObjectPooler.EnqueuObject(this, "BossDefaultProjectile");
        }
        else if (other.TryGetComponent(out PlayerShield playerShield))
        {
            playerShield.TakeDamage(Damage);
            // Add animation later.
            ObjectPooler.EnqueuObject(this, "BossDefaultProjectile");
        }
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime < 0.0f)
        {
            ObjectPooler.EnqueuObject(this, "BossDefaultProjectile");
        }
    }
}
