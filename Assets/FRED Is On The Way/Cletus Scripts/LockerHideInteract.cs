using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class LockerHide1 : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] private bool inTrigger = false;
    
    private bool disableScript = false;
    private bool inCloset = false;

    [SerializeField] private UnityEvent Interacted;
    [SerializeField] private UnityEvent Interacted2;

    void Start()
    {
        
    }


    void Update()
    {
        if (inTrigger == true)
        {
            if (inTrigger && Input.GetKeyDown(KeyCode.E) && (disableScript == false))
            {

                Debug.Log("You pressed E and it worked!");
                playerMovement.memoryPoints += 1;
                Interacted.Invoke();
            
                disableScript = true;
            }
            else if (inTrigger && Input.GetKeyDown(KeyCode.E) && disableScript && Player.gameObject.layer == LayerMask.NameToLayer("Hiding"))
            {
                Player.gameObject.layer = LayerMask.NameToLayer("player");
                Debug.Log("You pressed E and it worked!");
                playerMovement.memoryPoints += 1;
                disableScript = false;
                Interacted2.Invoke();

            }
            //check player layer to hidden
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")

        {
            //Debug.Log("You're in the trigger volume!");
            inTrigger = true;
            //Debug.Log(inTrigger);

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inTrigger = false;
           
            //Debug.Log(inTrigger);

        }
    }

    
}
