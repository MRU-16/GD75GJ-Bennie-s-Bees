using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private Transform _cam;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // This controls the player movement
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime;
        float yValue = 0f;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(xValue * moveSpeed, yValue * moveSpeed, zValue * moveSpeed);


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
