using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    private bool canAttack = true;
    public int minionInRange;
    public int attackDamage;
    public float radius = 2f;
    public LayerMask enemyLayer;
    public GameObject damage;
    


    
    private void Update()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);
        int enemyCount = enemies.Length;
        if (enemyCount > 0)
        {
            Debug.Log(enemyCount);
        }

        if(canAttack == true)
        {
            
            if (enemyCount > 0)
            {
                GetComponent<EnemyWander>().moveSpeed = 0f;
                Debug.Log("Spin");
                Spin();
                Invoke("TurnOffCollider", 0.5f);
                StartCoroutine(CanAttack());
                Invoke("EnableMovement", 1.5f);
            }
        }
        else
        {
            
        }
    }


    void EnableMovement()
    {
        GetComponent<EnemyWander>().moveSpeed = 2f;
    }

    public void Spin()
    {
        damage.SetActive(true);
        canAttack = false;
    }

    public void TurnOffCollider()
    {
        damage.SetActive(false);
    }

    private IEnumerator CanAttack()
    {
        yield return new WaitForSeconds(2f);
        canAttack = true;
    }

    //public void Stab()
    //{

    //}
}
