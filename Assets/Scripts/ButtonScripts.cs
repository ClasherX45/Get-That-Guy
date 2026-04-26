using UnityEngine;
using UnityEngine.UI;

public class ButtonScripts : MonoBehaviour
{
    public Button swarmButton;
    public Button knightButton;
    public Button tankButton;

    public int buttonCall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        Debug.Log("Script running");
    }*/

    public void Test()
    {
        Debug.Log("Button pressed");
        swarmButton.interactable = false;

    }

    public void OnButtonClick()
    {
        Debug.Log("Button was clicked!");
    }
}
