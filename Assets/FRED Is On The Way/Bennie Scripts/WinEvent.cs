using UnityEngine;

public class WinEvent : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameObject _player;
    //[SerializeField] GameObject _deathScreen;
    [SerializeField] GameObject _winScreen;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.memoryPoints > 1)
        {
            Win();
        }
        

    }


    void Win()
    {
        _winScreen.SetActive(true);
        _player.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
