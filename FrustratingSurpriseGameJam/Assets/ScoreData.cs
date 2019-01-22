using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    private int current_level; 

    private int total_score;
    private int total_deaths;
    private float total_time;
  
    private int current_score;
    private int current_deaths;
    private float current_time;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        current_level = 3;

        total_score = 4;
        total_deaths = 4;
        total_time = 4;

        current_score = 4;
        current_deaths = 4;
        current_time = 4;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
