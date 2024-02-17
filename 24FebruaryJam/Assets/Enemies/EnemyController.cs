using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyStats EnemyStats = new();

    public void TakeDamage(float damage)
    {
        EnemyStats.CurrentHP -= damage;

        if(EnemyStats.CurrentHP <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
