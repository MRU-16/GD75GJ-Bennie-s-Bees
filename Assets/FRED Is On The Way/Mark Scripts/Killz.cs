using UnityEngine;

public class Killz : MonoBehaviour
{
    [SerializeField] private Transform _respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        ResetObject(other);
    }

    private void ResetObject(Collider obj)
    {
        Rigidbody rb = obj.attachedRigidbody;
        if (rb != null)
        {
            rb.angularVelocity = Vector3.zero; 
            rb.MovePosition(_respawnPoint.position); 
        }
        else
        {
            obj.transform.position = _respawnPoint.position; 
        }
    }
}
