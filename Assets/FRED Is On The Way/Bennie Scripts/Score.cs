using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    public TMP_Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerMovement.memoryPoints.ToString() + "/6";
    }
}
