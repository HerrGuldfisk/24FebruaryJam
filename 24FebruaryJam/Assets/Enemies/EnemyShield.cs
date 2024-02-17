using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour, IDamagable
{
    WaitForSecondsRealtime shieldCooldownTime = new WaitForSecondsRealtime(5f);
    public void TakeDamage(float damage)
    {
        StartCoroutine(ShieldCooldown());
    }

    IEnumerator ShieldCooldown()
    {
        gameObject.GetComponent<MeshCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        yield return shieldCooldownTime;

        gameObject.GetComponent<MeshCollider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
