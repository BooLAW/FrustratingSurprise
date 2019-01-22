using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private NodeController nodeController;
    private TrapController trapController;
    private UI_Controller uiController;
    private SceneLoader loader;

    // Use this for initialization
    void Start () {
        nodeController = GetComponent<NodeController>();
        trapController = GetComponent<TrapController>();
        uiController = GameObject.Find("In-game UI").GetComponent<UI_Controller>();
        loader = GameObject.Find("SceneManager").GetComponent<SceneLoader>();
    }
	

    public void ResetLevel()
    {
        trapController.Reset();
        nodeController.Reset();
    }

    public void LevelComplete()
    {
        uiController.RestartUI();
        loader.LoadSceneByName("ScoreMenu");

    }
    
}
