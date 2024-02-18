using System.Collections;
using UnityEngine;

public class WalkerMinion : EnemyController
{
    CharacterController characterController;

    Transform graphics;

    bool explodeTime;
    public GameObject Explosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        graphics = transform.GetChild(0);
        InitializeStats();
    }

    private void InitializeStats()
    {
        EnemyStats.MoveSpeed.BaseValue = 2;
        EnemyStats.MaxHP.BaseValue = 15;
        EnemyStats.CurrentHP = EnemyStats.MaxHP.Value;
    }

    // Update is called once per frame
    void Update()
    {
        if (explodeTime) return;

        if(PlayerManager.spawnedPlayers.Count > 0 && PlayerManager.GetClosestplayerPosition(transform.position, out Vector3 target))
        {
            characterController.Move((target - transform.position).normalized * EnemyStats.MoveSpeed.Value * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(target - transform.position, Vector3.up);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerControllerScript playerController) && explodeTime == false)
        {
            explodeTime = true;
            Instantiate(Explosion, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity, transform);
        }
    }
}
