using UnityEngine;

public class WalkerMinion : EnemyController
{
    CharacterController characterController;

    Transform graphics;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        graphics = transform.GetChild(0);
        InitializeStats();
    }

    private void InitializeStats()
    {
        EnemyStats.MoveSpeed.BaseValue = 4 + PlayerManager.spawnedPlayers.Count;
        EnemyStats.MaxHP.BaseValue = 10 + 10 * PlayerManager.spawnedPlayers.Count;
        EnemyStats.CurrentHP = EnemyStats.MaxHP.Value;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerManager.spawnedPlayers.Count > 0 && PlayerManager.GetClosestplayerPosition(transform.position, out Vector3 target))
        {
            characterController.Move((target - transform.position).normalized * EnemyStats.MoveSpeed.Value * Time.deltaTime);
            graphics.LookAt(target - transform.position);
        }
    }
}
