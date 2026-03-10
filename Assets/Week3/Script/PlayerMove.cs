using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : NetworkBehaviour
{

    CharacterController characterController;
    Vector3 movementTest;
    [SerializeField]
    float speed = 1.0f;
    Vector2 movement;

    Material playerMaterial;
    NetworkVariable<Color> characterColor = new NetworkVariable<Color>(new Color(255, 0, 0));

    private void Awake()
    {
        playerMaterial = GetComponent<Renderer>().material;
        characterController = GetComponent<CharacterController>();

    }

    Color RandomColor()
    {
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        return new Color(r, g, b);

    }

    void OnMovement(InputValue value)
    {
        if (value.isPressed)
        {
            movement = value.Get<Vector2>();
            if (IsOwner) ColorServerRPC();
        }
    }

    public override void OnNetworkSpawn()
    {
        characterColor.OnValueChanged += OnColorChange;
        if (IsServer)
        {
            characterColor.Value = RandomColor();
        }
        playerMaterial.color = characterColor.Value;

    }

    void OnColorChange(Color oldColor, Color newColor)
    {
        print("This is the old color : " + oldColor + " and this is the new color : " + newColor);
        ColorClientRPC(newColor);

    }

    private void Start()
    {
        ColorServerRPC();
        movementTest = new Vector3(1, 0, 1);

    }


    [ClientRpc]
    void ColorClientRPC(Color newColor)
    {
        playerMaterial.color = newColor;

    }

    [ServerRpc]
    void ColorServerRPC()
    {
        if (IsServer) characterColor.Value = RandomColor();

    }



    private void Update()
    {
        if (IsOwner == false) return;

        characterController.Move(new Vector3(movement.x, 0.0f, movement.y) * speed * Time.deltaTime);
    }

}