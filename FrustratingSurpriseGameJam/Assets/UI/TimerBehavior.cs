using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehavior : MonoBehaviour {

    private float start_time = 0.0f;
    private Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        start_time = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        float current_time = Time.time - start_time;
        string new_text = ((int)(current_time / 60.0f)).ToString("00") + " : " + ((int)(current_time % 60)).ToString("00");
        if (new_text != text.text)
            text.text = new_text;
	}

    public void Restart()
    {
        start_time = Time.time;
    }
}
