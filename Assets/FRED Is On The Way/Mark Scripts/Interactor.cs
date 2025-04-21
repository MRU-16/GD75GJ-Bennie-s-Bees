using UnityEngine;

interface IInteractable 
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform interactorSource;
    [SerializeField] public float interactRange;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange)) 
            { 
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) 
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
