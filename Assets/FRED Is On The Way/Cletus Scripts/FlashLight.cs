using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private GameObject ON;
    [SerializeField] private GameObject OFF;
    [SerializeField] private bool isON;

    [SerializeField] private Image FlashLightBar;
    [SerializeField] private float LightTime, MaxLightTime;
    [SerializeField] private float LightCost;
    [SerializeField] private float RechargeTime;

    void Start()
    {
        ON.SetActive(false);
        OFF.SetActive(true);
        isON = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LightTime <= MaxLightTime && (isON == false))
        {
            LightTime += RechargeTime * Time.deltaTime;
            FlashLightBar.fillAmount = LightTime / MaxLightTime;
        }
        if (isON == true)
        {
            LightTime -= LightCost * Time.deltaTime;
            if (LightTime <= 0)
            {
                LightTime = 0;
                OFF.SetActive(true);
                ON.SetActive(false);
                isON = false;
            }
            FlashLightBar.fillAmount = LightTime / MaxLightTime;

        }


        if (Input.GetKeyUp(KeyCode.F) && (LightTime >= 0))
        {
            isON = !isON;
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
        }
        
    }
}
