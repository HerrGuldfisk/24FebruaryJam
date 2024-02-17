using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float BaseCooldownTime = 1;
    private float spawnCooldown = 1;
    
    void Update()
    {
        if(PlayerManager.spawnedPlayers.Count > 0 && spawnCooldown <= 0)
        {
            SpawnUnit();
            spawnCooldown = 
        }
    }

    private void SpawnUnit()
    {
        
    }
}
