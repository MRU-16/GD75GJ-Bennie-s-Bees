using UnityEngine;

public class TriggerVolumeInteract : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] private bool inTrigger = false;
    private bool disableScript = false;
    private bool triggerAction = true;



    void Start()
    {
        
    }


    void Update()
    {
        if (inTrigger && Input.GetKey(KeyCode.E) && (disableScript == false))
        {
            Debug.Log("You pressed E and it worked!");
            playerMovement.questPoints = playerMovement.questPoints + 1;
            disableScript = true;
        }
;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You're in the trigger volume!!!!!!!@!!!!!@#$@#@#$$#@@#$@$");
        if (other.gameObject.tag == "Player") 

        {

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
