using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private GameObject ON;
    [SerializeField] private GameObject OFF;
    [SerializeField] private bool isON;
    void Start()
    {
        ON.SetActive(false);
        OFF.SetActive(true);
        isON = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (isON)
            {
                ON.SetActive(true);
                OFF.SetActive(false);
            }
            if (!isON)
            {
                ON.SetActive(false);
                OFF.SetActive(true);
            }
            isON = !isON;
        }
        
    }
}
