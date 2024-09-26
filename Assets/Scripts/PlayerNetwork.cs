using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerNetwork : NetworkBehaviour
{
    private Vector2 moveInput;
    private Vector2 lookInput;

    public float moveSpeed = 5f;
    public float lookSpeed = 0.2f;

    private void OnEnable()
    {
        var inputActions = new PlayerInputActions();
        inputActions.Enable();

        inputActions.Player.Move.performed += MovePlayer;
        inputActions.Player.Move.canceled += MovePlayer;
        inputActions.Player.Look.performed += RotatePlayer;
        inputActions.Player.Look.canceled += RotatePlayer;
    }

    private void OnDisable()
    {
        var inputActions = new PlayerInputActions();
        inputActions.Disable();
    }

    public override void OnNetworkSpawn()
    {
        Debug.Log("Client Id: " + NetworkManager.LocalClient.ClientId);
        Debug.Log("Is owner: " + IsOwner);
        if (!IsOwner)
        {
            enabled = false;
            return;
        }
    }

    private void MovePlayer(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void RotatePlayer(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        // Handle movement
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Handle rotation
        float mouseX = lookInput.x * lookSpeed;
        transform.Rotate(Vector3.up, mouseX);
    }
}