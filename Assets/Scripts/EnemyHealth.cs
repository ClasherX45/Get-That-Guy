using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 50;
    public GameObject victoryTxt;

    private void Start()
    {
        victoryTxt.SetActive(false);
    }
    private void Update()
    {
        var cols = Physics2D.OverlapCircleAll(transform.position, 1.0f);
        foreach (var c in cols)
        {
            if (c.gameObject.tag == "Swarm")
            {
                health -= 1;
                if(health <= 0)
                {
                    Die();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Swarm"))
        {
            health -= 1;
        }
    }

    public void Die()
    {
        
        Destroy(gameObject);
        victoryTxt.SetActive(true);

    }
}

