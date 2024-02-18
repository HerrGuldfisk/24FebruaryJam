using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public Projectile defaultProjectilePrefab;
    public EnemyProjectile enemyDefaultProjectilePrefab;
    public BossProjectile bossProjectilePrefab;

    private void Awake()
    {
        SetupObjectPools();
    }

    void SetupObjectPools()
    {
        ObjectPooler.SetupPool(defaultProjectilePrefab, 500, "DefaultProjectile");

        ObjectPooler.SetupPool(enemyDefaultProjectilePrefab, 300, "EnemyDefaultProjectile");

        ObjectPooler.SetupPool(bossProjectilePrefab, 300, "BossDefaultProjectile");
    }
}
