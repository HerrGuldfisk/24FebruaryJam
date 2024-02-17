using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject minion;

    private float BaseCooldownTime = 1f;
    private float spawnCooldown = 1;
    
    void Update()
    {
        if(PlayerManager.spawnedPlayers.Count > 0 && spawnCooldown <= 0)
        {
            SpawnUnit();
            spawnCooldown = BaseCooldownTime;
        }

        spawnCooldown -= Time.deltaTime;
    }

    private void SpawnUnit()
    {

        var vector2 = Random.insideUnitCircle.normalized * 5;
        Vector3 position = new Vector3(vector2.x, 0, vector2.y);


        Instantiate(minion, position, Quaternion.identity, null);
    }
}
