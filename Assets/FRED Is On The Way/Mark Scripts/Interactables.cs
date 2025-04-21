using Unity.VisualScripting;
using UnityEngine;

public class Interactables : Interactor
{
    public void Interactor() 
    { 
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Debug.Log("WOW IT WORKS");
        }
    }
}
