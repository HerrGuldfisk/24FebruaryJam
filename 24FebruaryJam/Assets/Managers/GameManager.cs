using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Projectile defaultProjectilePrefab;

    private void Awake()
    {
        SetupObjectPool();
    }

    void SetupObjectPool()
    {
        ObjectPooler.SetupPool(defaultProjectilePrefab, 100, "DefaultProjectile");
    }
}
