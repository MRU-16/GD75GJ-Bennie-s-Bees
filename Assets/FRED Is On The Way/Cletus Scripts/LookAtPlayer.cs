using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject Player;
    [SerializeField]
    private float FixedRotation = 1;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);
        Vector3 eulerAngles = transform.eulerAngles;
        transform.eulerAngles = new Vector3(FixedRotation, eulerAngles.y, eulerAngles.z);

    }
}
