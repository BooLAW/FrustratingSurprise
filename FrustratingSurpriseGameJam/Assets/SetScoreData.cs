using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class SetScoreData : MonoBehaviour {

    public Text time_ui;
    public Text death_ui;

    public Text level_ui; 

    // Use this for initialization
    void Start ()
    {
		time_ui.text = "5";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
