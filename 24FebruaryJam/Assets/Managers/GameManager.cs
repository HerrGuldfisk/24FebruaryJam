using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Projectile defaultProjectilePrefab;

    private void Awake()
    {
        SetupObjectPools();
    }

    void SetupObjectPools()
    {
        ObjectPooler.SetupPool(defaultProjectilePrefab, 100, "DefaultProjectile");
    }
}
