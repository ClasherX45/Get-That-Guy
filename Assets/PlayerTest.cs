using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("player test hello");        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("player test collision");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("player test trigger");
    }
}
