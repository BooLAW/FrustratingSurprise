using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private NodeController nodeController;
    private TrapController trapController;
    private UI_Controller uiController;

    // Use this for initialization
    void Start () {
        nodeController = GetComponent<NodeController>();
        trapController = GetComponent<TrapController>();
        uiController = GameObject.Find("In-game UI").GetComponent<UI_Controller>();
    }
	

    public void ResetLevel()
    {
        trapController.Reset();
        nodeController.Reset();
    }

    public void LevelComplete()
    {
        uiController.RestartUI();
    }
    
}
