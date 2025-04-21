using Unity.VisualScripting;
using UnityEngine;

public class FredMovement : MonoBehaviour
{
    [SerializeField] public Transform tragetObj;
    [SerializeField] public int fredSpeed;
    [SerializeField] public int objectsCollected;
    [SerializeField] public int speedObject1;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, tragetObj.position, fredSpeed * Time.deltaTime);
    }

}
