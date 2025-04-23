using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class TriggerVolumeInteract : MonoBehaviour
{
    [SerializeField] GameObject pressButtonUI;
    [SerializeField] GameObject interactableNPC;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] private GameObject _Fred;
    [SerializeField] private bool inTrigger = false;
    [SerializeField] private float FredSpeedIncreaseMultiplier = .5f;
    private bool disableScript = false;
    

    private NavMeshAgent _agent;  

    

    [SerializeField] private UnityEvent Interacted;

    void Start()
    {
        _agent = _Fred.GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (inTrigger == true)
        {
            if (inTrigger && Input.GetKey(KeyCode.E) && (disableScript == false))
            {

                Debug.Log("You pressed E and it worked!");
                playerMovement.memoryPoints += 1;
                Debug.Log("The total number of quest points you have is now " + playerMovement.memoryPoints + "/6" );
                interactableNPC.SetActive(false);
                IncreaseFredSpeed();
                enabled = false;
                pressButtonUI.SetActive(false);
                disableScript = true;
                //Interacted.Invoke();

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
            pressButtonUI.SetActive(true);
            //Debug.Log(inTrigger);
           
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inTrigger = false;
            pressButtonUI.SetActive(false);
            //Debug.Log(inTrigger);
            
        }
    }

    private void IncreaseFredSpeed()
    {
        _agent.speed = _agent.speed + (playerMovement.memoryPoints * FredSpeedIncreaseMultiplier);
        _agent.angularSpeed = _agent.angularSpeed + (playerMovement.memoryPoints * 60 * FredSpeedIncreaseMultiplier);
    }
}
