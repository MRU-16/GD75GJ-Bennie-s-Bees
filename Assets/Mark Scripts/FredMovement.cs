using UnityEngine;

public class FredMovement : MonoBehaviour
{
    [SerializeField] public Transform tragetObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, tragetObj.position, 10 * Time.deltaTime);
    }
}
