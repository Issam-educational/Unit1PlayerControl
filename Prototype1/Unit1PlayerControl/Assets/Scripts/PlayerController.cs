using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Movement tuning (editable in the inspector)
    public float speed = 5.0f;
    public float turnSpeed = 5.0f;
    //Input system action, exposed in inspector for binding (WASD,arrow keys)
    public InputAction moveAction;

    //Current input value (x = left/right y=up/down) kept private for internal use
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Enable the move action so it starts reading input
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //Read the 2D vector from the moveAction
        moveInput = moveAction.ReadValue<Vector2>();

        // Move forward/backward along local Z using the y component
        transform.Translate(Vector3.forward *Time.deltaTime * speed * moveInput.y);

        // Rotate around local Y (yaw) using the x component
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * moveInput.x);
    }
}
