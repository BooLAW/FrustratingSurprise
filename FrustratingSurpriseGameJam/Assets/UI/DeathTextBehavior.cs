using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathTextBehavior : MonoBehaviour {

    private PlayerController player;
    private Text text;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        
        string new_text = "Deaths: " + player.death_count.ToString("00");
        if (new_text != text.text)
            text.text = new_text;
    }
}
