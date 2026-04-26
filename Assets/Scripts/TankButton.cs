using UnityEngine;
using UnityEngine.UI;

public class TankButton : MonoBehaviour
{
    public bool selected = false;
    public SwarmButton swarm;
    public knightButton knight;
    public TankButton tank;

    public Button tankButton;

    public int count = 1;

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
            swarm.selected = false;
            knight.selected = false;
        }
        
    }
}
