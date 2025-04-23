using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] GameObject _playerMovementScript;
    [SerializeField] GameObject _deathScreen;
    //[SerializeField] GameObject _winScreen;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Fred")
        {
            Debug.Log("FRED HIT YOUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU!");
            Death();

        }
    }

    void Death()
    {
        _deathScreen.SetActive(true);
        _playerMovementScript.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
