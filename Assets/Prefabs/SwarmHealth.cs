using Unity.VisualScripting;
using UnityEngine;

public class SwarmHealth : MonoBehaviour
{
    public int health;
    

    private void Update()
    {
        var cols = Physics2D.OverlapCircleAll(transform.position, 2.0f);
        foreach (var c in cols)
        {
            if (c.gameObject.tag == "PlayerRange")
            {
                health -= 2;
                if(health <= 0)
                {
                    Die();
                }
                Debug.Log("Enemy: " + health);
            }
        }
    }
    
    public void Die()
    {
        Destroy(gameObject);
    }
}
