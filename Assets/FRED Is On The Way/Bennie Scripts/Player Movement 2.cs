using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] bool canJump = true;
    [SerializeField] bool isGrounded = true;
    [SerializeField] private Transform _cam;
    [SerializeField] Rigidbody _rb;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Jumping();

    }

    void FixedUpdate()
    {
        Movement();

        PlayerLookAround();

    }
    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
            
    }
    private void Movement()
    {
        // First, convert the player inputs into a Vector3
        Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Second, to make sure movement adjusts based on where we're facing, convert input from local to world space
        Vector3 moveDirection = transform.TransformDirection(playerInput);

        // Third, if we’re holding 2 keys (diagonal), our speed is 41% faster, so normalize to cap it at 1
        if (moveDirection.magnitude > 1)
        {
            moveDirection = moveDirection.normalized;
        }

        // Fourth, apply the movement to our Rigidbody using MovePosition, factoring in move speed and Time.deltaTime
        _rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);
    }
    private void PlayerLookAround()
    {
        //This controls the players ability to look around

        //We first make a vector3 variable and assign it to our camera rotation
        //The .eulerAngles is important bc it turns the value into a Vector3 instead 
        Vector3 rotation = _cam.rotation.eulerAngles;

        //Since we only want to rotate on the y we get rid of x and z
        rotation.x = 0;
        rotation.z = 0;

        //Convers the vertor3 back to a quaternion, which is what unity needs for transform.rotation
        transform.rotation = Quaternion.Euler(rotation);
    }
}
