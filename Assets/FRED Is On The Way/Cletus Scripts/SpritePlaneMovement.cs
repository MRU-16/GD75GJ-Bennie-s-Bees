using System.Collections;

using UnityEngine;

public class SpritePlaneMovement : MonoBehaviour
{
    [SerializeField] private GameObject SpritePlane;

    private Vector3 Flip;

    [SerializeField] private float FlipTime = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DelaySeconds(FlipTime));
    }

    private IEnumerator DelaySeconds(float seconds) 
    { 

        while (true)
        {
            yield return new WaitForSeconds(seconds);
            transform.localScale = new Vector3(transform.localScale.x * 1, transform.localScale.y, transform.localScale.z);
            yield return new WaitForSeconds(seconds);
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
           
        }
    }
}


