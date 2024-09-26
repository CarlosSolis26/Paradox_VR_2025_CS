using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lookSpeed;
    [SerializeField] private Vector2 movementInput;
    [SerializeField] private Vector2 lookInput;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] public Transform spawnPoint;

    private void OnEnable()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.actions["Look"].performed += OnLook;
        playerInput.actions["Look"].canceled += OnLook;
        playerInput.actions["Fire"].performed += OnFire;
        playerInput.actions["Fire"].canceled += OnFire;
    }

    private void OnDisable()
    {
        playerInput.actions["Look"].performed -= OnLook;
        playerInput.actions["Look"].canceled -= OnLook;
        playerInput.actions["Fire"].performed -= OnFire;
        playerInput.actions["Fire"].canceled -= OnFire;
    }

    private void Update()
    {
        MovePlayer(movementInput);
        Rotate();
    }

    private void MovePlayer(Vector2 moveVector)
    {
        Vector3 movementPlayer = new Vector3(moveVector.x,0,moveVector.y);
        movementPlayer.Normalize();
        transform.Translate(movementPlayer * moveSpeed * Time.deltaTime, Space.World);
    }

    private void Rotate()
    {
        // Rotate around the Y-axis based on mouse delta X
        float rotationAmount = lookInput.x * lookSpeed;
        transform.Rotate(Vector3.up, rotationAmount);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // Read the mouse delta
        lookInput = context.ReadValue<Vector2>();
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
    }
}