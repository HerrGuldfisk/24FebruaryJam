using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerScript : MonoBehaviour
{
    private CharacterController controller;
    public PlayerStats playerStats = new();

    private Vector2 movementInput = Vector2.zero;
    private Vector2 lookInput = Vector2.zero;
    [SerializeField]
    private float rotationSmoothing = 100.0f;

    private float gravity;

    public void OnMove(InputValue inputValue) {
        movementInput = inputValue.Get<Vector2>();
    }

    public void OnLook(InputValue inputValue) {
        lookInput = inputValue.Get<Vector2>();
    }

    private void Start() {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update() {
        UpdateMovement();
    }

    void UpdateMovement() {
        if (gameObject.transform.position.y > 0)
        {
            gravity = -9.82f;
        }
        else { gravity = 0f; }

        Vector3 move = new Vector3(movementInput.x, gravity, movementInput.y);
        controller.Move(move * Time.deltaTime * playerStats.MoveSpeed.Value);
    }

    public void TakeDamage(float damage)
    {
        playerStats.CurrentHP -= damage;

        if (playerStats.CurrentHP <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}