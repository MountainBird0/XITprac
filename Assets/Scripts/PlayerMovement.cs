using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    InputActionAsset playerControls; // ������Ʈ
    InputAction movement;            // �Է��۾�

    //�߰�
    InputAction clickA;
    InputAction clickXY;


    CharacterController character;
    Vector3 moveVector;
    [SerializeField] float speed = 10f;

    void Start()
    {
        var gameplayActionMap = playerControls.FindActionMap("Default"); // �׼Ǹ��� ã�ƿ�

        movement = gameplayActionMap.FindAction("Move");
        movement.started += OnMovementChanged;   // => Debug.Log("started");
        movement.performed += OnMovementChanged; // => Debug.Log("performed");
        movement.canceled += OnMovementChanged;  // => Debug.Log("canceled");
        movement.Enable();

        clickA = gameplayActionMap.FindAction("Click");
        clickA.started += ClickAButton;
        clickA.Enable();

        clickXY = gameplayActionMap.FindAction("TwoClick");
        clickXY.started += ClickXYButton;
        clickXY.Enable();


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
        Debug.Log("move");
    }

    public void ClickAButton(InputAction.CallbackContext context)
    {
        float isClick = context.ReadValue<float>();
        if (isClick > 0.1)
        {
            Debug.Log("click A"); // Ű���� M
        }
    }

    public void ClickXYButton(InputAction.CallbackContext context)
    {
        float isClick = context.ReadValue<float>();
        if (isClick > 0.1)
        {
            Debug.Log("click X & Y"); // Ű���� OP
        }
    }
}