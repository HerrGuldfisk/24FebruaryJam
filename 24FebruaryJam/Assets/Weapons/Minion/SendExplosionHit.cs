using UnityEngine;

public class SendExplosionHit : MonoBehaviour
{
    public ExplosionAttack Attack;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");

        if (TryGetComponent(out PlayerControllerScript playerController))
        {
            Attack.RunOnTriggerEnter(other);
        }

        if (TryGetComponent(out PlayerShield shield))
        {
            Attack.RunOnTriggerEnter(other);
        }
    }
}
