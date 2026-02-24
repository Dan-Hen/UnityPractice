using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : NetworkBehaviour
{

    CharacterController characterController;
    [SerializeField]
    float speed = 1.0f;
    Vector3 movementTest;
    Vector2 movement;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

    }

    private void Start()
    {
        movementTest = new Vector3(1, 0, 1);
    }

    void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    private void Update()
    {
        if (IsOwner == false) return; // skip everything if this player isn't the one we own
        
        characterController.Move(new Vector3(movement.x, 0.0f, movement.y) * speed * Time.deltaTime);
    }
}
