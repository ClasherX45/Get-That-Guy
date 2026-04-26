using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SwarmMovement : MonoBehaviour
{
    public GameObject playerTarget;
    public float speed;
    public float health;
    public float distanceAwayFromPlayer;
    private bool canAttack = true;
    public float scaleAmt;

    private void Update()
    {

        if (playerTarget != null)
        {

            Vector2 targetPosition;
            Vector2 minionPosition;

            minionPosition = transform.position;
            targetPosition = playerTarget.transform.position;
            float distance = Vector2.Distance(minionPosition, targetPosition);

            if (canAttack == true)
            {

                if (distance > distanceAwayFromPlayer)
                {
                    
                    playerTarget = GameObject.FindGameObjectWithTag("Player");
                    transform.position = Vector2.MoveTowards(minionPosition, targetPosition, speed * Time.deltaTime);

                }
                else
                {

                    canAttack = false;
                    Attack();
                }
            }

            if (transform.position.x < playerTarget.transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

    }

    public void Attack()
    {

        scaleAmt = 0.5f;
        transform.localScale = Vector3.one * scaleAmt;
        Invoke("Return", 2f);

    }

    public void Return()
    {
        scaleAmt = 1;
        transform.localScale = Vector3.one * scaleAmt;
        StartCoroutine(CanAttack());
    }

    private IEnumerator CanAttack()
    {
        yield return new WaitForSeconds(2f);
        canAttack = true;

    }

}
