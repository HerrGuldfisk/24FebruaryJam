using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerInputManager inputManager;

    int maxPlayers = 4;

    private List<GameObject> spawnedPlayers = new();

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPlayerJoined()
    {
        
    }
}
