using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour {

    TimerBehavior timer_text;
    DeathTextBehavior deaths_text;
	// Use this for initialization
	void Start () {
        timer_text = GetComponentInChildren<TimerBehavior>();
        deaths_text = GetComponentInChildren<DeathTextBehavior>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartUI()
    {
        timer_text.Restart();
    }
}
