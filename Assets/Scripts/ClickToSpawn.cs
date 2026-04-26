using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToSpawn : MonoBehaviour
{
    public TMP_Text swarmCount;
    public TMP_Text knightCount;
    public TMP_Text tankCount;

    public GameObject minionPrefab;
    public GameObject knightPrefab;
    public GameObject tankPrefab;


    public SwarmButton swarm;
    public knightButton knight;
    public TankButton tank;
    private void Update()
    {
        swarmCount.text = swarm.count.ToString();
        knightCount.text = knight.count.ToString();
        tankCount.text = tank.count.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (swarm.selected == true)
                {
                    if (swarm.count != 0)
                    {
                        Debug.Log("Minion Spawned");
                        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        mousePos.z = 0f; // Keep on 2D plane
                        Instantiate(minionPrefab, mousePos, Quaternion.identity);
                        swarm.count--;
                    }
                    else if (swarm.count <= 0)
                    {
                        swarm.swarmButton.interactable = false;
                        StartCoroutine(swarmWait(8f));
                    }
                }
                else if (knight.selected == true)
                {
                    if (knight.count != 0)
                    {
                        Debug.Log("Minion Spawned");
                        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        mousePos.z = 0f; // Keep on 2D plane
                        Instantiate(knightPrefab, mousePos, Quaternion.identity);
                        knight.count--;
                    }
                    else if (knight.count <= 0)
                    {
                        knight.KnightButton.interactable = false;
                        StartCoroutine(knightWait(10f));
                    }
                }
                else if (tank.selected == true)
                {
                    if (tank.count != 0)
                    {
                        Debug.Log("Minion Spawned");
                        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        mousePos.z = 0f; // Keep on 2D plane
                        Instantiate(tankPrefab, mousePos, Quaternion.identity);
                        tank.count--;
                    }
                    else if (tank.count <= 0)
                    {
                        tank.tankButton.interactable = false;
                        StartCoroutine(tankWait(12f));
                    }
                }
            }
        }
            
        
    }


    private IEnumerator swarmWait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        swarm.count = 5;
        swarm.swarmButton.interactable = true;
    }

    private IEnumerator knightWait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        knight.count = 2;
        knight.KnightButton.interactable = true;
    }

    private IEnumerator tankWait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        tank.count = 1;
        tank.tankButton.interactable = true;
    }
}
