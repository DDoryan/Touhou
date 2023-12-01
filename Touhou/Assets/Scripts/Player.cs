using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;
    private Vector2 inputMovement;
    private Vector2 playerMovement;
    private Vector2 velocity;
    private float speed;

    public void Start()
    {
        speed = 3.0f;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        playerMovement = Vector2.SmoothDamp(playerMovement, inputMovement, ref velocity, 0.01f);
        playerRigidBody.velocity = playerMovement * speed;
    }
}