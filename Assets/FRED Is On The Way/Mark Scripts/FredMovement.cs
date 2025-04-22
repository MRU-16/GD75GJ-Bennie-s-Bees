using Unity.VisualScripting;
using UnityEngine;

public class FredMovement : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] public int fredSpeed;
    [SerializeField] public int objectsCollected;
    [SerializeField] public int speedObject1;
    [SerializeField] public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, fredSpeed * Time.deltaTime);
        if (target.position != pos) 
        {
             pos = Vector3.MoveTowards(transform.position, target.position, fredSpeed * Time.deltaTime);
        }
        
        rb.MovePosition(pos);
        transform.LookAt(target);
    }

}
