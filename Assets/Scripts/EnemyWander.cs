using System.Threading;
using UnityEngine;

public class EnemyWander : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 2f;
    public float changeDirectionTime = 2f;

    private float timer;
    private Vector2 moveDirection;
    private int moveDirectionIndex = 0;

    private void Start()
    {
        PickNewDirection();
        timer = changeDirectionTime;
    }


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 )
        {
            Debug.Log("timer done");
            PickNewDirection();
            timer = changeDirectionTime;
        }

        Move();

    }
    void PickNewDirection()
    {
        int rand = Random.Range(0, 4);

        moveDirectionIndex = rand;
        //int rand = Random.Range(0, 4);
        switch (rand)
        {
          
            case 0:
                moveDirection = Vector2.up;
                
                
                break;
            case 1:
                moveDirection = Vector2.down;
                
                break;
            case 2:
                moveDirection = Vector2.left;
                
                break;
            case 3:
                moveDirection = Vector2.right;
                
                break;

        }

        GetComponent<Rigidbody2D>().linearVelocity = moveDirection * moveSpeed;
    }


    void HitEdge()
    {
        switch (moveDirectionIndex)
        {
            case 0:
                moveDirection = Vector2.down;
                moveDirectionIndex = 1;
                break;
            case 1:
                moveDirection = Vector2.up;
                moveDirectionIndex = 0;
                break;
            case 2:
                moveDirection = Vector2.right;
                moveDirectionIndex = 3;
                break;
            case 3:
                moveDirection = Vector2.left;
                moveDirectionIndex = 2;
                break;
        }

        GetComponent<Rigidbody2D>().linearVelocity = moveDirection * moveSpeed;

        //reset timer
        Debug.Log("reset timer");
        timer = changeDirectionTime;

    }

    void Move()
    {
        //transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        //GetComponent<Rigidbody2D>().MovePosition(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("player wander trigger");

        if(collision.CompareTag("Boundary"))
        {
            Debug.Log("player hit boundary: HitEdge");
            HitEdge();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("player collision");
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Debug.Log("player hit boundary");
            PickNewDirection();
        }
    }
}
