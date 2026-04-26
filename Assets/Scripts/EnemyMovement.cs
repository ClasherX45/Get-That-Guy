using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float health;

    private void Update()
    {

        if (health <= 0)
        {
            Debug.Log("Player Died");
            Destroy(gameObject);
        }
    }
}


