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

        Player.gameObject.layer = LayerMask.NameToLayer("Hiding");
        
        //set player speed to zero

    }

    public void LockerExit()
    {
        PlayerOBJ.SetActive(false);
        Player.position = destination.position;
        PlayerOBJ.SetActive(true);

        Player.gameObject.layer = LayerMask.NameToLayer("player");

        //set player speed to zero

    }

}
