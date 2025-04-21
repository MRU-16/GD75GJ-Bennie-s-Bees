using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    public float sensitivity;
    private Vector2 _moveDirection;
    private Vector2 _lookDirection;

    public InputActionReference move;
    public InputActionReference look;
    public GameObject head;

    void Start()
    {

    }


    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
        _lookDirection = look.action.ReadValue<Vector2>();
        transform.rotation = head.transform.rotation;


    }


    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(_moveDirection.x * moveSpeed, 0 ,_moveDirection.y * moveSpeed);
        
    }


}
