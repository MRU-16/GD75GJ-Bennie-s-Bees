using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _cam;

    public Rigidbody rb;
    public float moveSpeed;
    public float sensitivity;
    private Vector2 _moveDirection;
    private Vector2 _lookDirection;

    public InputActionReference move;
    public InputActionReference look;
    //public GameObject head;

    void Start()
    {

    }


    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
        _lookDirection = look.action.ReadValue<Vector2>();

        Vector3 rotation = _cam.rotation.eulerAngles;
        rotation.x = 0f;
        rotation.z = 0f;

        transform.rotation = Quaternion.Euler(rotation);
        //Vector3 BodyRotation = transform.rotation.eulerAngles;
        //BodyRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);

    }


    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(_moveDirection.x * moveSpeed, 0 ,_moveDirection.y * moveSpeed);
        
    }


}
