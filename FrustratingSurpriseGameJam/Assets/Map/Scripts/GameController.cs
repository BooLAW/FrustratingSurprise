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
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetLevel()
    {
        trapController.Reset();
        nodeController.Reset();
    }
    
}
