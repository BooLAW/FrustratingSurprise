using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private NodeController nodeController;
    private TrapController trapController;

    // Use this for initialization
    void Start () {
        nodeController = GetComponent<NodeController>();
        trapController = GetComponent<TrapController>();
	}
	

    public void ResetLevel()
    {
        trapController.Reset();
        nodeController.Reset();
    }

    public void LevelComplete()
    {

    }
    
}
