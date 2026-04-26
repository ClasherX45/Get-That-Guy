using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwarmButton : MonoBehaviour
{
    public bool selected = false;
    public SwarmButton swarm;
    public knightButton knight;
    public TankButton tank;

    public Button swarmButton;

    public int count = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void OnButtonClick()
    {
        if (selected == true)
        {
            selected = false;
        }
        else
        {
            Debug.Log("Button was clicked!");
            selected = true;
            knight.selected = false;
            tank.selected = false;
        }
    }
}
