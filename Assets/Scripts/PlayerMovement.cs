using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    InputActionAsset playerControls; // 업데이트
    InputAction movement;            // 입력작업

    //추가
    InputAction clickA;


    CharacterController character;
    Vector3 moveVector;
    [SerializeField] float speed = 10f;

    void Start()
    {
        var gameplayActionMap = playerControls.FindActionMap("Default"); // 액션맵을 찾아옴

        movement = gameplayActionMap.FindAction("Move");

        movement.performed += OnMovementChanged;
        movement.canceled += OnMovementChanged; // 버튼이 올라오고 내려오고?
        movement.Enable();

        clickA = gameplayActionMap.FindAction("Click");

        clickA.performed += ClickAButton;
        clickA.Enable();

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

    public void ClickAButton(InputAction.CallbackContext context)
    {
        float isClick = context.ReadValue<float>();
        if(isClick > 0.1)
        {
            Debug.Log("click A"); // 키보드 M
        }
    }
}
