using UnityEngine;

public class WalkerMinion : EnemyController
{
    CharacterController characterController;

    Transform graphics;

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
        if(PlayerManager.spawnedPlayers.Count > 0 && PlayerManager.GetClosestplayerPosition(transform.position, out Vector3 target))
        {
            characterController.Move((target - transform.position).normalized * EnemyStats.MoveSpeed.Value * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(target - transform.position, Vector3.up);
        }
    }
}
