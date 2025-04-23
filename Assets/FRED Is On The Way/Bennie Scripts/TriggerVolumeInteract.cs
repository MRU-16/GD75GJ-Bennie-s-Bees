using UnityEngine;
using UnityEngine.Events;

public class TriggerVolumeInteract : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] private bool inTrigger = false;
    private bool disableScript = false;
    private bool triggerAction = true;

    [SerializeField] private UnityEvent Interacted;

    void Start()
    {
        
    }


    void Update()
    {
        if (inTrigger == true)
        {
            if (inTrigger && Input.GetKey(KeyCode.E) && (disableScript == false))
            {

                Debug.Log("You pressed E and it worked!");
                playerMovement.questPoints = playerMovement.questPoints + 1;
                disableScript = true;
                Interacted.Invoke();

            }
;
        }
        if (inTrigger == false)
        {
            disableScript = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player") 

        {
            Debug.Log("You're in the trigger volume!!!!!!!@!!!!!@#$@#@#$$#@@#$@$");
            inTrigger = true;
            Debug.Log(inTrigger);
           
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inTrigger = false;
            Debug.Log(inTrigger);
            
        }
    }
}
