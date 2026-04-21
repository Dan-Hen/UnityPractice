using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 10f;
    private Vector2 moveInput;
    private Vector2 lookInput;

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log("Moving");
    }

    void OnLook(InputValue value)
    {  
        lookInput = value.Get<Vector2>();
        Debug.Log(lookInput);

    }

    void OnJump()
    {
        Debug.Log("Jumping");
    }

    void OnInteract()
    {
        Debug.Log("Interact");
    }

    void Update()
    {   
        //OnMove
        transform.Translate(new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime * moveSpeed);

        //OnLook - 
        // ----------------------- error :: should transform camera rotation not player -----------------------------
        transform.Rotate(new Vector3(0,lookInput.x,0));

        
        //OnInteract
        //

    }
}