using UnityEngine;

public class TriggerVolumeInteract : MonoBehaviour
{

    [SerializeField] public bool inTrigger = false;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            inTrigger = true;
        }

        else
        {
            inTrigger = false;
        }
}
        
}
