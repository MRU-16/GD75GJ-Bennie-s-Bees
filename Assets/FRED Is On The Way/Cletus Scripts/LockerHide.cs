using UnityEngine;

public class LockerHide : MonoBehaviour
{
    [SerializeField] Transform Player, destination;
    [SerializeField] GameObject PlayerOBJ;





    // Update is called once per frame
    void Update()
    {

    }

    public void LockerEnter()
    {
        PlayerOBJ.SetActive(false);
        Player.position = destination.position;
        PlayerOBJ.SetActive(true);
    }



}
