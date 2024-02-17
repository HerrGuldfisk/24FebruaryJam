using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBossController : EnemyController
{
    public List<GameObject> ringParts = new();

    public GameObject ringHolder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyStats.MaxHP.BaseValue = 1000;
        EnemyStats.CurrentHP = EnemyStats.MaxHP.Value;
    }

    private void FixedUpdate()
    {
        ringHolder.transform.RotateAround(transform.position, Vector3.up, Time.fixedDeltaTime * 100f);
    }
}
