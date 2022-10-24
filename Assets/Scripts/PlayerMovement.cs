using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputActionAsset playerControls; // ������Ʈ
    InputAction movement;            // �Է��۾�


    CharacterController character;
    Vector3 moveVector;
    [SerializeField] float speed = 10f;

    void Start()
    {
        var gameplayActionMap = playerControls.FindActionMap("Default"); // �׼Ǹ��� ã�ƿ�

        movement = gameplayActionMap.FindAction("Move");

        movement.performed += OnMovementChanged;
        movement.canceled += OnMovementChanged; // ��ư�� �ö���� ��������?
        movement.Enable();

        character = GetComponent<CharacterController>(); 
        
    }

    private void FixedUpdate()
    {
        character.Move(moveVector * speed * Time.fixedDeltaTime);
    }

    public void OnMovementChanged(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        moveVector = new Vector3(direction.x, 0, direction.y);
    }
}
