using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public Projectile defaultProjectilePrefab;
    public EnemyProjectile enemyDefaultProjectilePrefab;


    private void Awake()
    {
        SetupObjectPools();
    }

    void SetupObjectPools()
    {
        ObjectPooler.SetupPool(defaultProjectilePrefab, 100, "DefaultProjectile");

        ObjectPooler.SetupPool(enemyDefaultProjectilePrefab, 200, "EnemyDefaultProjectile");
    }
}
