using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerInputManager playerInputManager;

    public List<Transform> spawnPoints;

    private List<GameObject> spawnedPlayers = new();

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
}
