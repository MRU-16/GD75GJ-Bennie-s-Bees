using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    private Vector2 _moveDirection;

    public InputActionReference move;

    void Start()
    {

    }

    
    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();

    }


    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(_moveDirection.x * moveSpeed, 0 ,_moveDirection.y * moveSpeed);
    }


}
