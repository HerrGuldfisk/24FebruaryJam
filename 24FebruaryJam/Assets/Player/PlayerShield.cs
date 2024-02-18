using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{

    WaitForSecondsRealtime shieldCooldownTime = new WaitForSecondsRealtime(6f);
    public void TakeDamage(float damage)
    {
        StartCoroutine(ShieldCooldown());
    }

    IEnumerator ShieldCooldown()
    {
        MeshCollider meshCollider;
        MeshRenderer meshRenderer;

        if (gameObject.TryGetComponent(out meshCollider))
        { meshCollider.enabled = false; }

        if (gameObject.TryGetComponent(out meshRenderer))
        { meshRenderer.enabled = false; }

        yield return shieldCooldownTime;

        if (gameObject.TryGetComponent(out meshCollider))
        { meshCollider.enabled = true; }

        if (gameObject.TryGetComponent(out meshRenderer))
        { meshRenderer.enabled = true; }
    }
}
