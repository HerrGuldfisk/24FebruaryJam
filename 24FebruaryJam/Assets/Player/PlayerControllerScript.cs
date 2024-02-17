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
        UpdateRotation();
    }

    void UpdateMovement() {
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerStats.MoveSpeed.Value);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

    void UpdateRotation() {
        if (Mathf.Abs(lookInput.x) > 0 || Mathf.Abs(lookInput.y) > 0)
        {
            Vector3 playerDir = Vector3.right * lookInput.x + Vector3.forward * lookInput.y;
            if (playerDir.sqrMagnitude > 0.0f)
            {
                Quaternion newrotation = Quaternion.LookRotation(playerDir, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, newrotation, rotationSmoothing * Time.deltaTime);
            }
        }
    }
}