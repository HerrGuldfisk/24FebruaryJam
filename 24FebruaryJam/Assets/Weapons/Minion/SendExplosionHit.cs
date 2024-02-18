using UnityEngine;

public class SendExplosionHit : MonoBehaviour
{
    public ExplosionAttack Attack;

    private void OnTriggerEnter(Collider other)
    {
        Attack.RunOnTriggerEnter(other);
    }
}
