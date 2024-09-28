using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerNetwork : NetworkBehaviour
{
    private Vector2 moveInput;
    private Vector2 lookInput;

    public float moveSpeed = 5f;
    public float lookSpeed = 0.2f;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] public Transform spawnPoint;

    public float bulletVelocity = 1f; 

    private void OnEnable()
    {
        var inputActions = new PlayerInputActions();
        inputActions.Enable();

        inputActions.Player.Move.performed += MovePlayer;
        inputActions.Player.Move.canceled += MovePlayer;
        inputActions.Player.Look.performed += RotatePlayer;
        inputActions.Player.Look.canceled += RotatePlayer;
        inputActions.Player.Fire.performed += FirePlayer;
    }

    private void OnDisable()
    {
        var inputActions = new PlayerInputActions();
        inputActions.Disable();

        inputActions.Player.Move.performed -= MovePlayer;
        inputActions.Player.Move.canceled -= MovePlayer;
        inputActions.Player.Look.performed -= RotatePlayer;
        inputActions.Player.Look.canceled -= RotatePlayer;
        inputActions.Player.Fire.performed -= FirePlayer;
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

    private void FirePlayer(InputAction.CallbackContext context)
    {
        if (IsServer && IsOwner)
        {
            //GameObject bulletInstance = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            BulletSpawnMovement();
        }
        else {
            ShootServerRpc(spawnPoint.position, spawnPoint.rotation);
        }
    }

    private void BulletSpawnMovement()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        bulletInstance.GetComponent<NetworkObject>().Spawn();
        Rigidbody rb = bulletInstance.GetComponent<Rigidbody>();
        rb.velocity = spawnPoint.forward * bulletVelocity;
    }

    [ServerRpc]
    void ShootServerRpc(Vector3 position, Quaternion rotation)
    {
            GameObject bulletInstance = Instantiate(bulletPrefab, position, rotation);
            bulletInstance.GetComponent<NetworkObject>().Spawn();
            Rigidbody rb = bulletInstance.GetComponent<Rigidbody>();
            rb.velocity = spawnPoint.forward * bulletVelocity;
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