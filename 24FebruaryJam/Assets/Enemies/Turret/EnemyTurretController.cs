using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretController : EnemyController
{
    public DefaultGun DefaultGun { get; private set; } = new DefaultGun();
    public EnemyProjectile DefaultProjectile;

    private float timeStamp;
    private float cooldownPeriodInSeconds = 1f;

    private float range = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyStats.MaxHP.BaseValue = 100;
        EnemyStats.CurrentHP = EnemyStats.MaxHP.Value;

        DefaultGun.ProjectileSpeed.BaseValue = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target;

        if (PlayerManager.spawnedPlayers.Count > 0 && PlayerManager.GetClosestplayerPosition(transform.position, out target))
        {
            transform.rotation = Quaternion.LookRotation(target - transform.position, Vector3.up);

            if (timeStamp <= Time.time && Vector3.Distance(target, transform.position) < range)
            {
                EnemyProjectile projectile = ObjectPooler.DequeuObject<EnemyProjectile>("EnemyDefaultProjectile");
                projectile.transform.position = transform.position;
                projectile.transform.rotation = Quaternion.LookRotation((target - transform.position).normalized);
                projectile.Damage = DefaultGun.Damage.Value;
                projectile.RB.linearVelocity = (target - transform.position).normalized * DefaultGun.ProjectileSpeed.Value;
                projectile.gameObject.SetActive(true);

                timeStamp = Time.time + cooldownPeriodInSeconds;
            }
        }
    }
}
