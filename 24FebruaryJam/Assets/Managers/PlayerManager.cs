using Replayer.Stats;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerInputManager playerInputManager;

    public List<Transform> spawnPoints;

    public static List<GameObject> spawnedPlayers = new();


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPlayerJoined(PlayerInput playerInput)
    {
        spawnedPlayers.Add(playerInput.gameObject);

        if (spawnedPlayers.Count < 1) { Debug.Log("No players spawned"); return; }

        if (playerInput.playerIndex > spawnPoints.Count) { Debug.Log("Player index our of range of spawn points"); return; }

        playerInput.gameObject.GetComponent<CharacterController>().enabled = false;
        playerInput.gameObject.GetComponent<CharacterController>().transform.position = spawnPoints[playerInput.playerIndex].position;
        playerInput.gameObject.GetComponent<CharacterController>().enabled = true;
    }

    
    public static bool GetClosestplayerPosition(Vector3 position, out Vector3 target)
    {
        int closestPlayerIndex = -1;
        float closestDistance = 1000;

        for (int i = 0; i < spawnedPlayers.Count; i++)
        {
            float distance = Vector3.Distance(position, spawnedPlayers[i].transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayerIndex = i;
            }
        }
 
        target = spawnedPlayers[closestPlayerIndex].transform.position;

        return closestPlayerIndex > -1 ? true : false;


        
    }
    
}
