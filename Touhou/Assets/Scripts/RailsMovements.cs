using UnityEngine;
using UnityEngine.InputSystem;

public class RailsMovements : MonoBehaviour
{
    public Rigidbody2D railRigidBody;
    private Vector2 inputMovement;
    private Vector2 railMovement;
    private Vector2 velocity;
    private float speed;

    public void Start()
    {
        speed = 6f;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        railMovement = Vector2.SmoothDamp(railMovement, inputMovement, ref velocity, 0.01f);
        if(Mathf.Abs(railMovement.y) < Mathf.Abs(railMovement.x))
        {
            railMovement.y = 0f;
        }
        else
        {
            railMovement.x = 0f;
        }
        railRigidBody.velocity = railMovement.normalized * speed;
    }
}