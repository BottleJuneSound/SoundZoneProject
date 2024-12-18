using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    InputAction moveAction;
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        InputActionAsset inputActions = GetComponent<PlayerInput>().actions;
        moveAction = inputActions.FindAction("Move");

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        Vector3 moveValue = new Vector3(moveVector.x, 0, moveVector.y);

        Transform camDirTransform = Camera.main.transform;
        Vector3 camDirForward = camDirTransform.forward;
        Vector3 camDirRight = camDirTransform.right;

        camDirForward.y = 0;
        camDirRight.y = 0;
        camDirForward.Normalize();
        camDirRight.Normalize();

        Vector3 moveDir = (camDirRight * moveVector.x + camDirForward * moveVector.y);
       
        if(moveDir != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * 10);

        }

        if (moveAction.IsPressed())
        {
            moveSpeed = 10;
        }
        moveValue = moveDir * moveSpeed * Time.deltaTime;   //이동 방향에 따른 앞뒤 업데이트

        characterController.Move(moveValue);
        //Debug.Log("moveValue " + moveValue);
    }
}
